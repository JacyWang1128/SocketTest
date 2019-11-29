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
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btSendCommand = new System.Windows.Forms.Button();
            this.btSend = new System.Windows.Forms.Button();
            this.btConnect = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.gbControlBox.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.btSendCommand);
            this.panel2.Controls.Add(this.btSend);
            this.panel2.Controls.Add(this.btConnect);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(194, 527);
            this.panel2.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(8, 62);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(8, 35);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btSendCommand
            // 
            this.btSendCommand.Location = new System.Drawing.Point(114, 62);
            this.btSendCommand.Name = "btSendCommand";
            this.btSendCommand.Size = new System.Drawing.Size(75, 23);
            this.btSendCommand.TabIndex = 1;
            this.btSendCommand.Text = "发送";
            this.btSendCommand.UseVisualStyleBackColor = true;
            this.btSendCommand.Click += new System.EventHandler(this.btSendCommand_Click);
            // 
            // btSend
            // 
            this.btSend.Location = new System.Drawing.Point(114, 33);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(75, 23);
            this.btSend.TabIndex = 1;
            this.btSend.Text = "发送";
            this.btSend.UseVisualStyleBackColor = true;
            this.btSend.Click += new System.EventHandler(this.btSend_Click);
            // 
            // btConnect
            // 
            this.btConnect.Location = new System.Drawing.Point(114, 3);
            this.btConnect.Name = "btConnect";
            this.btConnect.Size = new System.Drawing.Size(75, 23);
            this.btConnect.TabIndex = 0;
            this.btConnect.Text = "连接";
            this.btConnect.UseVisualStyleBackColor = true;
            this.btConnect.Click += new System.EventHandler(this.btConnect_Click);
            // 
            // WriteParameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "WriteParameter";
            this.Size = new System.Drawing.Size(1187, 547);
            this.panel1.ResumeLayout(false);
            this.gbControlBox.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbControlBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btConnect;
        private System.Windows.Forms.Button btSend;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btSendCommand;
    }
}
