namespace QRCode.ZXing.One
{
    partial class FrmZXing
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmZXing));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveQRCode = new System.Windows.Forms.Button();
            this.btnQRCode = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.PCBQR = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PCBQR)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.PCBQR);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnSaveQRCode);
            this.panel1.Controls.Add(this.btnQRCode);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(655, 364);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(357, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "请输入文本：";
            // 
            // btnSaveQRCode
            // 
            this.btnSaveQRCode.Location = new System.Drawing.Point(517, 302);
            this.btnSaveQRCode.Name = "btnSaveQRCode";
            this.btnSaveQRCode.Size = new System.Drawing.Size(75, 23);
            this.btnSaveQRCode.TabIndex = 7;
            this.btnSaveQRCode.Text = "下载二维码图片";
            this.btnSaveQRCode.UseVisualStyleBackColor = true;
            this.btnSaveQRCode.Click += new System.EventHandler(this.btnSaveQRCode_Click);
            // 
            // btnQRCode
            // 
            this.btnQRCode.Location = new System.Drawing.Point(385, 297);
            this.btnQRCode.Name = "btnQRCode";
            this.btnQRCode.Size = new System.Drawing.Size(82, 29);
            this.btnQRCode.TabIndex = 6;
            this.btnQRCode.Text = "生成二维码";
            this.btnQRCode.UseVisualStyleBackColor = true;
            this.btnQRCode.Click += new System.EventHandler(this.btnQRCode_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(357, 60);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(278, 213);
            this.txtName.TabIndex = 5;
            this.txtName.Text = "http://www.xinyo.xin";
            // 
            // PCBQR
            // 
            this.PCBQR.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PCBQR.BackgroundImage")));
            this.PCBQR.ErrorImage = null;
            this.PCBQR.InitialImage = ((System.Drawing.Image)(resources.GetObject("PCBQR.InitialImage")));
            this.PCBQR.Location = new System.Drawing.Point(17, 16);
            this.PCBQR.Name = "PCBQR";
            this.PCBQR.Size = new System.Drawing.Size(300, 300);
            this.PCBQR.TabIndex = 9;
            this.PCBQR.TabStop = false;
            this.PCBQR.WaitOnLoad = true;
            // 
            // FrmZXing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 388);
            this.Controls.Add(this.panel1);
            this.Name = "FrmZXing";
            this.Text = "生成二维码";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PCBQR)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveQRCode;
        private System.Windows.Forms.Button btnQRCode;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.PictureBox PCBQR;
    }
}

