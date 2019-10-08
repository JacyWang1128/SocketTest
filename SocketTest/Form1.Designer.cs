namespace SocketTest
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rtbReceive = new System.Windows.Forms.RichTextBox();
            this.rtbSend = new System.Windows.Forms.RichTextBox();
            this.tbInput = new System.Windows.Forms.TextBox();
            this.btSend = new System.Windows.Forms.Button();
            this.tbReceiveAddress = new System.Windows.Forms.TextBox();
            this.tbReceivePort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSendAddress = new System.Windows.Forms.TextBox();
            this.tbSendPort = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btReceiveStartListen = new System.Windows.Forms.Button();
            this.btReceiveFinishListen = new System.Windows.Forms.Button();
            this.btSendStartListen = new System.Windows.Forms.Button();
            this.btSendFinishListen = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btReceiveFinishListen);
            this.splitContainer1.Panel1.Controls.Add(this.btReceiveStartListen);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.tbReceivePort);
            this.splitContainer1.Panel1.Controls.Add(this.tbReceiveAddress);
            this.splitContainer1.Panel1.Controls.Add(this.rtbReceive);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btSendFinishListen);
            this.splitContainer1.Panel2.Controls.Add(this.btSendStartListen);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.btSend);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.tbInput);
            this.splitContainer1.Panel2.Controls.Add(this.tbSendPort);
            this.splitContainer1.Panel2.Controls.Add(this.rtbSend);
            this.splitContainer1.Panel2.Controls.Add(this.tbSendAddress);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(1033, 527);
            this.splitContainer1.SplitterDistance = 520;
            this.splitContainer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "接收区";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "发送区";
            // 
            // rtbReceive
            // 
            this.rtbReceive.Location = new System.Drawing.Point(14, 42);
            this.rtbReceive.Name = "rtbReceive";
            this.rtbReceive.Size = new System.Drawing.Size(491, 316);
            this.rtbReceive.TabIndex = 1;
            this.rtbReceive.Text = "";
            // 
            // rtbSend
            // 
            this.rtbSend.Location = new System.Drawing.Point(18, 42);
            this.rtbSend.Name = "rtbSend";
            this.rtbSend.Size = new System.Drawing.Size(479, 316);
            this.rtbSend.TabIndex = 1;
            this.rtbSend.Text = "";
            // 
            // tbInput
            // 
            this.tbInput.Location = new System.Drawing.Point(18, 364);
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(397, 21);
            this.tbInput.TabIndex = 2;
            // 
            // btSend
            // 
            this.btSend.Location = new System.Drawing.Point(422, 364);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(75, 23);
            this.btSend.TabIndex = 3;
            this.btSend.Text = "发送";
            this.btSend.UseVisualStyleBackColor = true;
            // 
            // tbReceiveAddress
            // 
            this.tbReceiveAddress.Location = new System.Drawing.Point(84, 440);
            this.tbReceiveAddress.Name = "tbReceiveAddress";
            this.tbReceiveAddress.Size = new System.Drawing.Size(160, 21);
            this.tbReceiveAddress.TabIndex = 2;
            // 
            // tbReceivePort
            // 
            this.tbReceivePort.Location = new System.Drawing.Point(297, 440);
            this.tbReceivePort.Name = "tbReceivePort";
            this.tbReceivePort.Size = new System.Drawing.Size(42, 21);
            this.tbReceivePort.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(30, 443);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "监听IP：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(250, 443);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "端口：";
            // 
            // tbSendAddress
            // 
            this.tbSendAddress.Location = new System.Drawing.Point(74, 440);
            this.tbSendAddress.Name = "tbSendAddress";
            this.tbSendAddress.Size = new System.Drawing.Size(160, 21);
            this.tbSendAddress.TabIndex = 2;
            // 
            // tbSendPort
            // 
            this.tbSendPort.Location = new System.Drawing.Point(287, 440);
            this.tbSendPort.Name = "tbSendPort";
            this.tbSendPort.Size = new System.Drawing.Size(42, 21);
            this.tbSendPort.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(20, 443);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "目标IP：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(240, 443);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "端口：";
            // 
            // btReceiveStartListen
            // 
            this.btReceiveStartListen.Location = new System.Drawing.Point(345, 438);
            this.btReceiveStartListen.Name = "btReceiveStartListen";
            this.btReceiveStartListen.Size = new System.Drawing.Size(75, 23);
            this.btReceiveStartListen.TabIndex = 5;
            this.btReceiveStartListen.Text = "开始监听";
            this.btReceiveStartListen.UseVisualStyleBackColor = true;
            // 
            // btReceiveFinishListen
            // 
            this.btReceiveFinishListen.Location = new System.Drawing.Point(430, 438);
            this.btReceiveFinishListen.Name = "btReceiveFinishListen";
            this.btReceiveFinishListen.Size = new System.Drawing.Size(75, 23);
            this.btReceiveFinishListen.TabIndex = 5;
            this.btReceiveFinishListen.Text = "结束监听";
            this.btReceiveFinishListen.UseVisualStyleBackColor = true;
            // 
            // btSendStartListen
            // 
            this.btSendStartListen.Location = new System.Drawing.Point(337, 438);
            this.btSendStartListen.Name = "btSendStartListen";
            this.btSendStartListen.Size = new System.Drawing.Size(75, 23);
            this.btSendStartListen.TabIndex = 5;
            this.btSendStartListen.Text = "开始监听";
            this.btSendStartListen.UseVisualStyleBackColor = true;
            // 
            // btSendFinishListen
            // 
            this.btSendFinishListen.Location = new System.Drawing.Point(422, 438);
            this.btSendFinishListen.Name = "btSendFinishListen";
            this.btSendFinishListen.Size = new System.Drawing.Size(75, 23);
            this.btSendFinishListen.TabIndex = 5;
            this.btSendFinishListen.Text = "结束监听";
            this.btSendFinishListen.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 527);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btReceiveFinishListen;
        private System.Windows.Forms.Button btReceiveStartListen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbReceivePort;
        private System.Windows.Forms.TextBox tbReceiveAddress;
        private System.Windows.Forms.RichTextBox rtbReceive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btSendFinishListen;
        private System.Windows.Forms.Button btSendStartListen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btSend;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.TextBox tbSendPort;
        private System.Windows.Forms.RichTextBox rtbSend;
        private System.Windows.Forms.TextBox tbSendAddress;
        private System.Windows.Forms.Label label2;
    }
}

