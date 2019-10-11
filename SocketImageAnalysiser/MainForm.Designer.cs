namespace SocketImageAnalysiser
{
    partial class MainForm
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
            this.btStartListening = new System.Windows.Forms.Button();
            this.rtbConsole = new System.Windows.Forms.RichTextBox();
            this.pbImgShow = new System.Windows.Forms.PictureBox();
            this.nudPort = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btStopListening = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbImgShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).BeginInit();
            this.SuspendLayout();
            // 
            // btStartListening
            // 
            this.btStartListening.Location = new System.Drawing.Point(46, 28);
            this.btStartListening.Name = "btStartListening";
            this.btStartListening.Size = new System.Drawing.Size(120, 34);
            this.btStartListening.TabIndex = 0;
            this.btStartListening.Text = "开始监听";
            this.btStartListening.UseVisualStyleBackColor = true;
            this.btStartListening.Click += new System.EventHandler(this.btStartListening_Click);
            // 
            // rtbConsole
            // 
            this.rtbConsole.Location = new System.Drawing.Point(46, 86);
            this.rtbConsole.Name = "rtbConsole";
            this.rtbConsole.Size = new System.Drawing.Size(602, 240);
            this.rtbConsole.TabIndex = 1;
            this.rtbConsole.Text = "";
            // 
            // pbImgShow
            // 
            this.pbImgShow.Location = new System.Drawing.Point(714, 86);
            this.pbImgShow.Name = "pbImgShow";
            this.pbImgShow.Size = new System.Drawing.Size(394, 516);
            this.pbImgShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImgShow.TabIndex = 2;
            this.pbImgShow.TabStop = false;
            // 
            // nudPort
            // 
            this.nudPort.Location = new System.Drawing.Point(215, 37);
            this.nudPort.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.nudPort.Name = "nudPort";
            this.nudPort.Size = new System.Drawing.Size(120, 21);
            this.nudPort.TabIndex = 3;
            this.nudPort.Value = new decimal(new int[] {
            4557,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(172, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "端口号";
            // 
            // btStopListening
            // 
            this.btStopListening.Location = new System.Drawing.Point(356, 28);
            this.btStopListening.Name = "btStopListening";
            this.btStopListening.Size = new System.Drawing.Size(99, 34);
            this.btStopListening.TabIndex = 5;
            this.btStopListening.Text = "停止监听";
            this.btStopListening.UseVisualStyleBackColor = true;
            this.btStopListening.Click += new System.EventHandler(this.btStopListening_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 614);
            this.Controls.Add(this.btStopListening);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudPort);
            this.Controls.Add(this.pbImgShow);
            this.Controls.Add(this.rtbConsole);
            this.Controls.Add(this.btStartListening);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbImgShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btStartListening;
        private System.Windows.Forms.RichTextBox rtbConsole;
        private System.Windows.Forms.PictureBox pbImgShow;
        private System.Windows.Forms.NumericUpDown nudPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btStopListening;
    }
}

