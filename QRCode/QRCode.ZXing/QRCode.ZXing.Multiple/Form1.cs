using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ThoughtWorks.QRCode.Codec;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;

namespace QRCode.ZXing.Multiple
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetMid(this);
            Form.CheckForIllegalCrossThreadCalls = false;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);
        }
        public static void SetMid(Form form)
        {
            form.SetBounds((Screen.GetBounds(form).Width / 2) - (form.Width / 2),
                (Screen.GetBounds(form).Height / 2) - (form.Height / 2),
                form.Width, form.Height, BoundsSpecified.Location);
        }
        #region 批量生成二维码
        private void buttonsms_Click(object sender, EventArgs e)
        {
            this.txtFilePath.Enabled = false;
            this.comboBox1.Enabled = false;
            this.button1.Enabled = false;
            Thread thread = new Thread(new ThreadStart(UpdateSitelogin));
            thread.Start();
        }
        private void UpdateSitelogin()
        {
            string fullPath = txtFilePath.Text.Trim();
            string sheetName = comboBox1.Text.Trim() + "$";

            Microsoft.Office.Interop.Excel.ApplicationClass oApp = null;
            Microsoft.Office.Interop.Excel.Workbook oBook = null;
            System.Diagnostics.Process[] excel进程 = null;
            int m, killId = 0;
            try
            {
                System.DateTime 开始时间1 = System.DateTime.Now;
                oApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
                System.DateTime 开始时间2 = System.DateTime.Now;
                excel进程 = System.Diagnostics.Process.GetProcessesByName("EXCEL");
                //立即获取进程创建时间
                for (m = 0; m < excel进程.Length; m++)
                {
                    if (开始时间1 < excel进程[m].StartTime && 开始时间2 > excel进程[m].StartTime)
                    {
                        killId = m;
                    }
                }
                //获取最后进程创建时间成功
                oBook = oApp.Workbooks.Open(fullPath, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                #region 更新Excel
                Microsoft.Office.Interop.Excel.Worksheet oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oBook.Worksheets[sheetName.Replace("$", "")];

                Microsoft.Office.Interop.Excel.Range r;

                int countColumn = oSheet.UsedRange.Columns.Count;
                int countRow = oSheet.UsedRange.Rows.Count;

                this.progressBar1.Maximum = countRow - 1;
                this.progressBar1.Value = 0;

                countColumn = 1;
                #region 执行结果
                r = (Microsoft.Office.Interop.Excel.Range)(oSheet.Cells[1, countColumn + 1]);
                r.Value2 = "执行结果";
               
                //找到库里最大值再加2
                int maxnum = GetMaxnum() + 2;
                int num = maxnum;
                #region SDK方式更新
                for (int i = 2; i < countRow + 1; i++)
                {
                    this.progressBar1.Value++;

                    r = (Microsoft.Office.Interop.Excel.Range)(oSheet.Cells[i, 1]);//读取第一列数据
                    string cellValue = r.Text.ToString().Trim();
                    r = (Microsoft.Office.Interop.Excel.Range)(oSheet.Cells[i, countColumn + 1]);
                    string resultValue = r.Text.ToString().Trim();
                    num++;
                    if (cellValue == "" || resultValue == "生成失败")
                    {
                        continue;
                    }
                    else
                    {
                        try
                        {
                            EncodingOptions options = null;
                            BarcodeWriter writer = null;
                            options = new QrCodeEncodingOptions
                            {
                                DisableECI = true,
                                CharacterSet = "UTF-8",
                                Width = 500,
                                Height = 500,
                                Margin=1
                            };

                            writer = new BarcodeWriter();
                            writer.Format = BarcodeFormat.QR_CODE;
                            writer.Options = options;

                            Bitmap bitmap = writer.Write(cellValue);

                            System.Drawing.Image Img = bitmap;
                            string msms = "2017-10-17";
                            string VCardSrc = CardImage.SaveVCardCodeImages(Img, 300, 300, msms, cellValue.Trim());//图片保存路径
                            if (!string.IsNullOrEmpty(VCardSrc))
                            {
                                r.Value2 = VCardSrc +"|"+ cellValue;
                                //加入数据库
                                //ADDData(num, cellValue.Trim(), VCardSrc);
                            }
                            else
                            {
                                r.Value2 = "生成失败";
                            }
                        }
                        catch (Exception ex)
                        { r.Value2 = ex.Message; }

                    }
                }
                #endregion



                #endregion

                r = null;
                oBook.Save();
                oBook.Close();
                #endregion

                oBook = null;
                oApp.Quit();
                oApp = null;
                if (excel进程[killId].HasExited == false)
                {
                    excel进程[killId].Kill();
                }

                this.progressBar1.Value = 0;
                MessageBox.Show("生成完毕！");
            }
            catch (Exception ex)
            {
                oBook = null;
                oApp.Quit();
                oApp = null;
                if (excel进程[killId].HasExited == false)
                {
                    excel进程[killId].Kill();
                }

                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.txtFilePath.Enabled = true;
                this.comboBox1.Enabled = true;
                this.button1.Enabled = true;

            }
        }
        #endregion
        private int GetMaxnum()
        {
            try
            {
                StringBuilder sbSql = new StringBuilder();
                sbSql.Append("SELECT ");
                sbSql.Append("  max(QCodeValue) ");
                sbSql.Append("FROM ");
                sbSql.Append("  QCodeInfo ");
                DataTable dt = new DataTable();
                SQLExecuteQuery(sbSql.ToString(), dt);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return int.Parse(dt.Rows[0][0].ToString());
                }
                else
                {
                    return 0;
                }
            }
            catch { return 0; }
            
        }
        /// <summary>
        /// 插入二维码info表

        /// </summary>
        /// <param name="content"></param>
        /// <param name="time"></param>
        private void ADDData(int QCodeValue, string BM, string QCodeUrl)
        {
            //未找到短信回复码，更新到数据库中
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("INSERT INTO ");
            sbSql.Append("  QCodeInfo(QCodeValue, ");
            sbSql.Append("  QCodeUrl,BM) ");
            sbSql.Append("VALUES ");
            sbSql.Append("  (" + QCodeValue + ", ");
            sbSql.Append("  '" + QCodeUrl + "', '" + BM + "')");
            Insert(sbSql.ToString());
        }
        private void SQLExecuteQuery(string CommandText, DataTable DT)
        {
            SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["infoconn"]);
            try
            {
                Connection.Open();
                SqlCommand SqlCmd = new SqlCommand(CommandText, Connection);
                SqlCmd.CommandTimeout = 0;
                SqlDataAdapter SqlDap = new SqlDataAdapter(SqlCmd);
                SqlDap.Fill(DT);
                SqlCmd.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("执行数据库操作失败: " + ex.Message + CommandText);
            }
            finally
            {
                Connection.Close();
            }
        }
        private void Insert(string sql)
        {
            SqlConnection Connection = new SqlConnection(ConfigurationManager.AppSettings["infoconn"]);
            try
            {
                Connection.Open();
                SqlCommand cmd = new SqlCommand(sql, Connection);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Connection.Close();
            }
        }
        //上传excel源数据
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                LoadFile2();//加载excel
            }
            catch
            {
                try
                {
                    this.LoadFile();//加载excel
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void LoadFile2()
        {
            OpenFileDialog pOpen;

            pOpen = new OpenFileDialog();
            pOpen.Filter = "Excel files (*.xlsx)|*.xlsx;*.xls";
            pOpen.FilterIndex = 1;
            if (pOpen.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = pOpen.FileName;

                System.DateTime 开始时间1 = System.DateTime.Now;
                Microsoft.Office.Interop.Excel.ApplicationClass oApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
                System.DateTime 开始时间2 = System.DateTime.Now;
                System.Diagnostics.Process[] excel进程 = System.Diagnostics.Process.GetProcessesByName("EXCEL");
                //立即获取进程创建时间

                int m, killId = 0;
                for (m = 0; m < excel进程.Length; m++)
                {

                    if (开始时间1 < excel进程[m].StartTime && 开始时间2 > excel进程[m].StartTime)
                    {
                        killId = m;
                    }
                }
                //获取最后进程创建时间成功
                Microsoft.Office.Interop.Excel.Workbook oBook = oApp.Workbooks._Open(pOpen.FileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                comboBox1.Items.Clear();
                comboBox1.Tag = pOpen.FileName;
                foreach (Microsoft.Office.Interop.Excel.Worksheet sSheet in oBook.Sheets)
                {
                    comboBox1.Items.Add(sSheet.Name);
                }

                oBook = null;
                oApp.Quit();
                oApp = null;
                if (excel进程[killId].HasExited == false)
                {
                    excel进程[killId].Kill();
                }
                comboBox1.SelectedIndex = 0;
            }
        }
        private void LoadFile()
        {
            try
            {
                //获取Excel文件路径和名称  
                OpenFileDialog odXls = new OpenFileDialog();
                // 指定相应的打开文档的目录  
                odXls.InitialDirectory = "C://";
                // 设置文件格式  
                odXls.Filter = "Excel files (*.xlsx)|*.xlsx;*.xls";
                odXls.FilterIndex = 2;
                odXls.RestoreDirectory = true;
                if (odXls.ShowDialog() == DialogResult.OK)
                {
                    txtFilePath.Text = odXls.FileName;
                    OleDbConnection oledbConn = null;
                    string sConnString = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + odXls.FileName + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1;'";
                    oledbConn = new OleDbConnection(sConnString);
                    oledbConn.Open();
                    DataTable dt = oledbConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                    comboBox1.Items.Clear();
                    foreach (DataRow dr in dt.Rows)
                    {
                        comboBox1.Items.Add(((String)dr["TABLE_NAME"]).Replace("$", ""));
                    }
                    if (comboBox1.Items.Count > 0)
                        comboBox1.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
