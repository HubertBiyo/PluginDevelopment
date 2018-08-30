using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;

namespace QRCode.ZXing.One
{
    public partial class FrmZXing : Form
    {
        EncodingOptions options = null;
        BarcodeWriter writer = null;

        public FrmZXing()
        {
            InitializeComponent();
            options = new QrCodeEncodingOptions
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = PCBQR.Width,
                Height = PCBQR.Height
            };
            writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            writer.Options = options;
        }

        private void btnQRCode_Click(object sender, EventArgs e)
        {
            if (txtName.Text == string.Empty)
            {
                MessageBox.Show("输入内容不能为空！");
                return;
            }
            Bitmap bitmap = writer.Write(txtName.Text);
            PCBQR.Image = bitmap;
        }

        private void btnSaveQRCode_Click(object sender, EventArgs e)
        {
            //@"d:\文件夹\2.rar
            string strFileName = "D:\\" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + (new Random()).Next().ToString().Substring(0, 4) + ".jpg"; ;
            FileInfo fi = new FileInfo(strFileName);
            if (fi.Exists)
            {
                fi.Delete();
                this.PCBQR.Image.Save(strFileName);
                MessageBox.Show("下载成功");
            }
            else
            {
                this.PCBQR.Image.Save(strFileName);
                MessageBox.Show("已下载成功");
            }
        }
    }
}
