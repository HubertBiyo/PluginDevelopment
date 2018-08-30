namespace QRCode.ZXing.Multiple
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonsms = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.xlsExpData = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.xlsExpData)).BeginInit();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Location = new System.Drawing.Point(481, 124);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(2, 180);
            this.label12.TabIndex = 60;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(18, 211);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 17);
            this.label2.TabIndex = 55;
            this.label2.Text = "2.有兴趣关注本人订阅号书茶烟雨";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(18, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 17);
            this.label1.TabIndex = 54;
            this.label1.Tag = "";
            this.label1.Text = "1.批量生成二维码利用ZXing实现";
            // 
            // buttonsms
            // 
            this.buttonsms.BackColor = System.Drawing.Color.LightSteelBlue;
            this.buttonsms.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonsms.Location = new System.Drawing.Point(18, 54);
            this.buttonsms.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonsms.Name = "buttonsms";
            this.buttonsms.Size = new System.Drawing.Size(139, 33);
            this.buttonsms.TabIndex = 52;
            this.buttonsms.Text = "批量生成二维码";
            this.buttonsms.UseVisualStyleBackColor = false;
            this.buttonsms.Click += new System.EventHandler(this.buttonsms_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(18, 442);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(850, 12);
            this.progressBar1.TabIndex = 51;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(687, 22);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(181, 20);
            this.comboBox1.TabIndex = 48;
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(18, 21);
            this.txtFilePath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(531, 21);
            this.txtFilePath.TabIndex = 47;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(560, 13);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 33);
            this.button1.TabIndex = 46;
            this.button1.Text = "选择Excel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // xlsExpData
            // 
            this.xlsExpData.Location = new System.Drawing.Point(18, 318);
            this.xlsExpData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xlsExpData.Name = "xlsExpData";
            this.xlsExpData.RowTemplate.Height = 23;
            this.xlsExpData.Size = new System.Drawing.Size(850, 116);
            this.xlsExpData.TabIndex = 45;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 463);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonsms);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.xlsExpData);
            this.Name = "Form1";
            this.Text = "批量生成二维码图片";
            ((System.ComponentModel.ISupportInitialize)(this.xlsExpData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonsms;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView xlsExpData;
    }
}

