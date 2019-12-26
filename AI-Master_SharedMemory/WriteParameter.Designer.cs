namespace AI_Master_SharedMemory
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btClose = new System.Windows.Forms.Button();
            this.plRight = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.rtbConsole = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btChange = new System.Windows.Forms.Button();
            this.tbX = new System.Windows.Forms.TextBox();
            this.tbY = new System.Windows.Forms.TextBox();
            this.tbWidth = new System.Windows.Forms.TextBox();
            this.tbHeight = new System.Windows.Forms.TextBox();
            this.pbWindow = new System.Windows.Forms.PictureBox();
            this.nudPortNumber = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.tbInputCommad = new System.Windows.Forms.TextBox();
            this.tbInput = new System.Windows.Forms.TextBox();
            this.btSendCommand = new System.Windows.Forms.Button();
            this.btSend = new System.Windows.Forms.Button();
            this.btConnect = new System.Windows.Forms.Button();
            this.plRight.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWindow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPortNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // btClose
            // 
            this.btClose.BackColor = System.Drawing.Color.Transparent;
            this.btClose.BackgroundImage = global::AI_Master_SharedMemory.Properties.Resources.删除;
            this.btClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btClose.FlatAppearance.BorderSize = 0;
            this.btClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btClose.Location = new System.Drawing.Point(0, 0);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(25, 25);
            this.btClose.TabIndex = 2;
            this.btClose.UseVisualStyleBackColor = false;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // plRight
            // 
            this.plRight.Controls.Add(this.tabControl1);
            this.plRight.Controls.Add(this.rtbConsole);
            this.plRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.plRight.Location = new System.Drawing.Point(1221, 0);
            this.plRight.Name = "plRight";
            this.plRight.Size = new System.Drawing.Size(200, 645);
            this.plRight.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(200, 505);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.nudPortNumber);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.tbInputCommad);
            this.tabPage1.Controls.Add(this.tbInput);
            this.tabPage1.Controls.Add(this.btSendCommand);
            this.tabPage1.Controls.Add(this.btSend);
            this.tabPage1.Controls.Add(this.btConnect);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(192, 479);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "基本参数";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(192, 479);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "相机参数";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // rtbConsole
            // 
            this.rtbConsole.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rtbConsole.Location = new System.Drawing.Point(0, 505);
            this.rtbConsole.Name = "rtbConsole";
            this.rtbConsole.Size = new System.Drawing.Size(200, 140);
            this.rtbConsole.TabIndex = 0;
            this.rtbConsole.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 613);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1221, 32);
            this.panel1.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 9;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.btChange, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbX, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbY, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbWidth, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbHeight, 7, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(539, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(682, 32);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "X：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(161, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Y：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(319, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "宽：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(477, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 32);
            this.label4.TabIndex = 3;
            this.label4.Text = "高：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btChange
            // 
            this.btChange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btChange.Location = new System.Drawing.Point(635, 3);
            this.btChange.Name = "btChange";
            this.btChange.Size = new System.Drawing.Size(44, 26);
            this.btChange.TabIndex = 4;
            this.btChange.Text = "更改";
            this.btChange.UseVisualStyleBackColor = true;
            this.btChange.Click += new System.EventHandler(this.btChange_Click);
            // 
            // tbX
            // 
            this.tbX.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbX.Location = new System.Drawing.Point(48, 3);
            this.tbX.Name = "tbX";
            this.tbX.Size = new System.Drawing.Size(100, 21);
            this.tbX.TabIndex = 5;
            // 
            // tbY
            // 
            this.tbY.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbY.Location = new System.Drawing.Point(206, 3);
            this.tbY.Name = "tbY";
            this.tbY.Size = new System.Drawing.Size(100, 21);
            this.tbY.TabIndex = 5;
            // 
            // tbWidth
            // 
            this.tbWidth.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbWidth.Location = new System.Drawing.Point(364, 3);
            this.tbWidth.Name = "tbWidth";
            this.tbWidth.Size = new System.Drawing.Size(100, 21);
            this.tbWidth.TabIndex = 5;
            // 
            // tbHeight
            // 
            this.tbHeight.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbHeight.Location = new System.Drawing.Point(522, 3);
            this.tbHeight.Name = "tbHeight";
            this.tbHeight.Size = new System.Drawing.Size(100, 21);
            this.tbHeight.TabIndex = 5;
            // 
            // pbWindow
            // 
            this.pbWindow.Location = new System.Drawing.Point(40, 40);
            this.pbWindow.Name = "pbWindow";
            this.pbWindow.Size = new System.Drawing.Size(640, 512);
            this.pbWindow.TabIndex = 5;
            this.pbWindow.TabStop = false;
            // 
            // nudPortNumber
            // 
            this.nudPortNumber.Location = new System.Drawing.Point(64, 9);
            this.nudPortNumber.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudPortNumber.Name = "nudPortNumber";
            this.nudPortNumber.Size = new System.Drawing.Size(60, 21);
            this.nudPortNumber.TabIndex = 18;
            this.nudPortNumber.Value = new decimal(new int[] {
            5953,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "端口号：";
            // 
            // tbInputCommad
            // 
            this.tbInputCommad.Location = new System.Drawing.Point(5, 62);
            this.tbInputCommad.Name = "tbInputCommad";
            this.tbInputCommad.Size = new System.Drawing.Size(119, 21);
            this.tbInputCommad.TabIndex = 16;
            // 
            // tbInput
            // 
            this.tbInput.Location = new System.Drawing.Point(5, 35);
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(119, 21);
            this.tbInput.TabIndex = 15;
            // 
            // btSendCommand
            // 
            this.btSendCommand.Location = new System.Drawing.Point(130, 62);
            this.btSendCommand.Name = "btSendCommand";
            this.btSendCommand.Size = new System.Drawing.Size(56, 23);
            this.btSendCommand.TabIndex = 13;
            this.btSendCommand.Text = "发送";
            this.btSendCommand.UseVisualStyleBackColor = true;
            this.btSendCommand.Click += new System.EventHandler(this.btSendCommand_Click);
            // 
            // btSend
            // 
            this.btSend.Location = new System.Drawing.Point(130, 33);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(56, 23);
            this.btSend.TabIndex = 14;
            this.btSend.Text = "发送";
            this.btSend.UseVisualStyleBackColor = true;
            this.btSend.Click += new System.EventHandler(this.btSend_Click);
            // 
            // btConnect
            // 
            this.btConnect.Location = new System.Drawing.Point(130, 6);
            this.btConnect.Name = "btConnect";
            this.btConnect.Size = new System.Drawing.Size(56, 23);
            this.btConnect.TabIndex = 12;
            this.btConnect.Text = "连接";
            this.btConnect.UseVisualStyleBackColor = true;
            this.btConnect.Click += new System.EventHandler(this.btConnect_Click);
            // 
            // WriteParameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbWindow);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.plRight);
            this.Controls.Add(this.btClose);
            this.Name = "WriteParameter";
            this.Size = new System.Drawing.Size(1421, 645);
            this.Load += new System.EventHandler(this.WriteParameter_Load);
            this.plRight.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWindow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPortNumber)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Panel plRight;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox rtbConsole;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btChange;
        private System.Windows.Forms.TextBox tbX;
        private System.Windows.Forms.TextBox tbY;
        private System.Windows.Forms.TextBox tbWidth;
        private System.Windows.Forms.TextBox tbHeight;
        private System.Windows.Forms.PictureBox pbWindow;
        private System.Windows.Forms.NumericUpDown nudPortNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbInputCommad;
        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.Button btSendCommand;
        private System.Windows.Forms.Button btSend;
        private System.Windows.Forms.Button btConnect;

    }
}
