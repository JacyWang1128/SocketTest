namespace AI_MasterControl
{
    partial class WriteParameter
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbControlBox = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rtbConsole = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.nudPortNumber = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.tbInputCommad = new System.Windows.Forms.TextBox();
            this.tbInput = new System.Windows.Forms.TextBox();
            this.btSendCommand = new System.Windows.Forms.Button();
            this.btSend = new System.Windows.Forms.Button();
            this.btConnect = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btClose = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.gbControlBox.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPortNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gbControlBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(987, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 547);
            this.panel1.TabIndex = 0;
            // 
            // gbControlBox
            // 
            this.gbControlBox.Controls.Add(this.panel2);
            this.gbControlBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbControlBox.Location = new System.Drawing.Point(0, 0);
            this.gbControlBox.Name = "gbControlBox";
            this.gbControlBox.Size = new System.Drawing.Size(200, 547);
            this.gbControlBox.TabIndex = 0;
            this.gbControlBox.TabStop = false;
            this.gbControlBox.Text = "groupBox1";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.rtbConsole);
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(194, 527);
            this.panel2.TabIndex = 0;
            // 
            // rtbConsole
            // 
            this.rtbConsole.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rtbConsole.Location = new System.Drawing.Point(0, 429);
            this.rtbConsole.Name = "rtbConsole";
            this.rtbConsole.Size = new System.Drawing.Size(192, 96);
            this.rtbConsole.TabIndex = 5;
            this.rtbConsole.Text = "";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(10);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(192, 525);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.nudPortNumber);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.tbInputCommad);
            this.tabPage1.Controls.Add(this.tbInput);
            this.tabPage1.Controls.Add(this.btSendCommand);
            this.tabPage1.Controls.Add(this.btSend);
            this.tabPage1.Controls.Add(this.btConnect);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(184, 499);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "基础设置";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // nudPortNumber
            // 
            this.nudPortNumber.Location = new System.Drawing.Point(62, 9);
            this.nudPortNumber.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudPortNumber.Name = "nudPortNumber";
            this.nudPortNumber.Size = new System.Drawing.Size(60, 21);
            this.nudPortNumber.TabIndex = 11;
            this.nudPortNumber.Value = new decimal(new int[] {
            5953,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "端口号：";
            // 
            // tbInputCommad
            // 
            this.tbInputCommad.Location = new System.Drawing.Point(3, 62);
            this.tbInputCommad.Name = "tbInputCommad";
            this.tbInputCommad.Size = new System.Drawing.Size(119, 21);
            this.tbInputCommad.TabIndex = 9;
            // 
            // tbInput
            // 
            this.tbInput.Location = new System.Drawing.Point(3, 35);
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(119, 21);
            this.tbInput.TabIndex = 8;
            // 
            // btSendCommand
            // 
            this.btSendCommand.Location = new System.Drawing.Point(128, 62);
            this.btSendCommand.Name = "btSendCommand";
            this.btSendCommand.Size = new System.Drawing.Size(56, 23);
            this.btSendCommand.TabIndex = 6;
            this.btSendCommand.Text = "发送";
            this.btSendCommand.UseVisualStyleBackColor = true;
            this.btSendCommand.Click += new System.EventHandler(this.btSendCommand_Click);
            // 
            // btSend
            // 
            this.btSend.Location = new System.Drawing.Point(128, 33);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(56, 23);
            this.btSend.TabIndex = 7;
            this.btSend.Text = "发送";
            this.btSend.UseVisualStyleBackColor = true;
            this.btSend.Click += new System.EventHandler(this.btSend_Click);
            // 
            // btConnect
            // 
            this.btConnect.Location = new System.Drawing.Point(128, 6);
            this.btConnect.Name = "btConnect";
            this.btConnect.Size = new System.Drawing.Size(56, 23);
            this.btConnect.TabIndex = 5;
            this.btConnect.Text = "连接";
            this.btConnect.UseVisualStyleBackColor = true;
            this.btConnect.Click += new System.EventHandler(this.btConnect_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(184, 499);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "参数设置";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btClose
            // 
            this.btClose.BackgroundImage = global::AI_MasterControl.Properties.Resources.删除;
            this.btClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btClose.FlatAppearance.BorderSize = 0;
            this.btClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btClose.Location = new System.Drawing.Point(0, 0);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(25, 25);
            this.btClose.TabIndex = 1;
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // WriteParameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "WriteParameter";
            this.Size = new System.Drawing.Size(1187, 547);
            this.Load += new System.EventHandler(this.WriteParameter_Load);
            this.panel1.ResumeLayout(false);
            this.gbControlBox.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPortNumber)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbControlBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox tbInputCommad;
        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.Button btSendCommand;
        private System.Windows.Forms.Button btSend;
        private System.Windows.Forms.Button btConnect;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox rtbConsole;
        private System.Windows.Forms.NumericUpDown nudPortNumber;
        private System.Windows.Forms.Label label3;
    }
}
