namespace AI_MasterControl
{
    partial class AddCamera
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCamera));
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.tbCmosWidth = new System.Windows.Forms.TextBox();
            this.tbCmosHeight = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tbPreStr = new System.Windows.Forms.TextBox();
            this.cbDate = new System.Windows.Forms.CheckBox();
            this.cbCameraName = new System.Windows.Forms.CheckBox();
            this.cbIPaddress = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btSelectFolder = new System.Windows.Forms.Button();
            this.tbFolder = new System.Windows.Forms.TextBox();
            this.cbRestorSize = new System.Windows.Forms.CheckBox();
            this.cbAutoSaving = new System.Windows.Forms.CheckBox();
            this.gbConnection = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbIPaddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nudPort = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btSelectColor = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbWidth = new System.Windows.Forms.TextBox();
            this.tbHeight = new System.Windows.Forms.TextBox();
            this.tbX = new System.Windows.Forms.TextBox();
            this.tbY = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbDistinguishOK = new System.Windows.Forms.CheckBox();
            this.cbDistinguishNG = new System.Windows.Forms.CheckBox();
            this.cbDistinguish = new System.Windows.Forms.CheckBox();
            this.panel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.gbConnection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Controls.Add(this.groupBox7);
            this.panel2.Controls.Add(this.groupBox5);
            this.panel2.Controls.Add(this.groupBox6);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(235, 346);
            this.panel2.TabIndex = 33;
            // 
            // groupBox4
            // 
            this.groupBox4.AutoSize = true;
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.radioButton1);
            this.groupBox4.Controls.Add(this.radioButton4);
            this.groupBox4.Controls.Add(this.radioButton2);
            this.groupBox4.Controls.Add(this.radioButton3);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(0, 263);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(235, 82);
            this.groupBox4.TabIndex = 26;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "图片旋转设置";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(114, 22);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(71, 16);
            this.radioButton1.TabIndex = 7;
            this.radioButton1.Text = "旋转90°";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.SetRotate);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Checked = true;
            this.radioButton4.Location = new System.Drawing.Point(9, 22);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(59, 16);
            this.radioButton4.TabIndex = 7;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "不旋转";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.SetRotate);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(9, 46);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(77, 16);
            this.radioButton2.TabIndex = 7;
            this.radioButton2.Text = "旋转180°";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.SetRotate);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(114, 46);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(77, 16);
            this.radioButton3.TabIndex = 7;
            this.radioButton3.Text = "旋转270°";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.SetRotate);
            // 
            // groupBox7
            // 
            this.groupBox7.AutoSize = true;
            this.groupBox7.BackColor = System.Drawing.Color.Transparent;
            this.groupBox7.Controls.Add(this.tbCmosWidth);
            this.groupBox7.Controls.Add(this.tbCmosHeight);
            this.groupBox7.Controls.Add(this.label15);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox7.Location = new System.Drawing.Point(0, 201);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(235, 62);
            this.groupBox7.TabIndex = 29;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "相机CMOS设置";
            // 
            // tbCmosWidth
            // 
            this.tbCmosWidth.Location = new System.Drawing.Point(57, 21);
            this.tbCmosWidth.Name = "tbCmosWidth";
            this.tbCmosWidth.Size = new System.Drawing.Size(52, 21);
            this.tbCmosWidth.TabIndex = 14;
            this.tbCmosWidth.Tag = "宽";
            this.tbCmosWidth.Text = "1280";
            // 
            // tbCmosHeight
            // 
            this.tbCmosHeight.Location = new System.Drawing.Point(130, 21);
            this.tbCmosHeight.Name = "tbCmosHeight";
            this.tbCmosHeight.Size = new System.Drawing.Size(52, 21);
            this.tbCmosHeight.TabIndex = 15;
            this.tbCmosHeight.Tag = "高";
            this.tbCmosHeight.Text = "1024";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 26);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(119, 12);
            this.label15.TabIndex = 13;
            this.label15.Text = "分辨率：          *";
            // 
            // groupBox5
            // 
            this.groupBox5.AutoSize = true;
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.tbPreStr);
            this.groupBox5.Controls.Add(this.cbDate);
            this.groupBox5.Controls.Add(this.cbCameraName);
            this.groupBox5.Controls.Add(this.cbIPaddress);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(0, 113);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(235, 88);
            this.groupBox5.TabIndex = 27;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "图片名称设置";
            // 
            // tbPreStr
            // 
            this.tbPreStr.Location = new System.Drawing.Point(9, 47);
            this.tbPreStr.Name = "tbPreStr";
            this.tbPreStr.Size = new System.Drawing.Size(212, 21);
            this.tbPreStr.TabIndex = 5;
            // 
            // cbDate
            // 
            this.cbDate.AutoSize = true;
            this.cbDate.Location = new System.Drawing.Point(173, 25);
            this.cbDate.Name = "cbDate";
            this.cbDate.Size = new System.Drawing.Size(48, 16);
            this.cbDate.TabIndex = 4;
            this.cbDate.Text = "日期";
            this.cbDate.UseVisualStyleBackColor = true;
            // 
            // cbCameraName
            // 
            this.cbCameraName.AutoSize = true;
            this.cbCameraName.Checked = true;
            this.cbCameraName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCameraName.Location = new System.Drawing.Point(83, 25);
            this.cbCameraName.Name = "cbCameraName";
            this.cbCameraName.Size = new System.Drawing.Size(72, 16);
            this.cbCameraName.TabIndex = 3;
            this.cbCameraName.Text = "相机名称";
            this.cbCameraName.UseVisualStyleBackColor = true;
            // 
            // cbIPaddress
            // 
            this.cbIPaddress.AutoSize = true;
            this.cbIPaddress.Location = new System.Drawing.Point(9, 25);
            this.cbIPaddress.Name = "cbIPaddress";
            this.cbIPaddress.Size = new System.Drawing.Size(60, 16);
            this.cbIPaddress.TabIndex = 2;
            this.cbIPaddress.Text = "IP地址";
            this.cbIPaddress.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.AutoSize = true;
            this.groupBox6.BackColor = System.Drawing.Color.Transparent;
            this.groupBox6.Controls.Add(this.btSelectFolder);
            this.groupBox6.Controls.Add(this.tbFolder);
            this.groupBox6.Controls.Add(this.cbRestorSize);
            this.groupBox6.Controls.Add(this.cbDistinguishNG);
            this.groupBox6.Controls.Add(this.cbDistinguish);
            this.groupBox6.Controls.Add(this.cbDistinguishOK);
            this.groupBox6.Controls.Add(this.cbAutoSaving);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox6.Location = new System.Drawing.Point(0, 0);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(235, 113);
            this.groupBox6.TabIndex = 28;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "保存路径设置";
            // 
            // btSelectFolder
            // 
            this.btSelectFolder.Location = new System.Drawing.Point(173, 20);
            this.btSelectFolder.Name = "btSelectFolder";
            this.btSelectFolder.Size = new System.Drawing.Size(48, 23);
            this.btSelectFolder.TabIndex = 6;
            this.btSelectFolder.Text = "选择";
            this.btSelectFolder.UseVisualStyleBackColor = true;
            this.btSelectFolder.Click += new System.EventHandler(this.btSelectFolder_Click);
            // 
            // tbFolder
            // 
            this.tbFolder.Location = new System.Drawing.Point(9, 21);
            this.tbFolder.Name = "tbFolder";
            this.tbFolder.Size = new System.Drawing.Size(158, 21);
            this.tbFolder.TabIndex = 5;
            // 
            // cbRestorSize
            // 
            this.cbRestorSize.AutoSize = true;
            this.cbRestorSize.Location = new System.Drawing.Point(9, 52);
            this.cbRestorSize.Name = "cbRestorSize";
            this.cbRestorSize.Size = new System.Drawing.Size(72, 16);
            this.cbRestorSize.TabIndex = 2;
            this.cbRestorSize.Text = "还原大小";
            this.cbRestorSize.UseVisualStyleBackColor = true;
            // 
            // cbAutoSaving
            // 
            this.cbAutoSaving.AutoSize = true;
            this.cbAutoSaving.Location = new System.Drawing.Point(83, 52);
            this.cbAutoSaving.Name = "cbAutoSaving";
            this.cbAutoSaving.Size = new System.Drawing.Size(72, 16);
            this.cbAutoSaving.TabIndex = 1;
            this.cbAutoSaving.Text = "自动记录";
            this.cbAutoSaving.UseVisualStyleBackColor = true;
            // 
            // gbConnection
            // 
            this.gbConnection.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbConnection.BackColor = System.Drawing.Color.Transparent;
            this.gbConnection.Controls.Add(this.label11);
            this.gbConnection.Controls.Add(this.tbIPaddress);
            this.gbConnection.Controls.Add(this.label1);
            this.gbConnection.Controls.Add(this.nudPort);
            this.gbConnection.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbConnection.Location = new System.Drawing.Point(0, 0);
            this.gbConnection.Name = "gbConnection";
            this.gbConnection.Size = new System.Drawing.Size(235, 113);
            this.gbConnection.TabIndex = 30;
            this.gbConnection.TabStop = false;
            this.gbConnection.Text = "相机连接设置";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 31);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 12);
            this.label11.TabIndex = 21;
            this.label11.Text = "接收IP地址：";
            // 
            // tbIPaddress
            // 
            this.tbIPaddress.Location = new System.Drawing.Point(90, 28);
            this.tbIPaddress.Name = "tbIPaddress";
            this.tbIPaddress.Size = new System.Drawing.Size(131, 21);
            this.tbIPaddress.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "接收端口号：";
            // 
            // nudPort
            // 
            this.nudPort.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nudPort.Location = new System.Drawing.Point(90, 67);
            this.nudPort.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.nudPort.Name = "nudPort";
            this.nudPort.Size = new System.Drawing.Size(56, 22);
            this.nudPort.TabIndex = 20;
            this.nudPort.Value = new decimal(new int[] {
            4557,
            0,
            0,
            0});
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.gbConnection);
            this.panel1.Location = new System.Drawing.Point(265, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(235, 346);
            this.panel1.TabIndex = 34;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(128, 298);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 33;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(29, 298);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 33;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.btSelectColor);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 205);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(235, 58);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "图像信息设置";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(90, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 15);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btSelectColor
            // 
            this.btSelectColor.Location = new System.Drawing.Point(128, 25);
            this.btSelectColor.Name = "btSelectColor";
            this.btSelectColor.Size = new System.Drawing.Size(48, 23);
            this.btSelectColor.TabIndex = 1;
            this.btSelectColor.Text = "选择";
            this.btSelectColor.UseVisualStyleBackColor = true;
            this.btSelectColor.Click += new System.EventHandler(this.btSelectColor_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "信息显示颜色：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbWidth);
            this.groupBox1.Controls.Add(this.tbHeight);
            this.groupBox1.Controls.Add(this.tbX);
            this.groupBox1.Controls.Add(this.tbY);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 113);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(235, 92);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "监视位置设置";
            // 
            // tbWidth
            // 
            this.tbWidth.Location = new System.Drawing.Point(62, 56);
            this.tbWidth.Name = "tbWidth";
            this.tbWidth.Size = new System.Drawing.Size(49, 21);
            this.tbWidth.TabIndex = 1;
            this.tbWidth.Text = "320";
            // 
            // tbHeight
            // 
            this.tbHeight.Location = new System.Drawing.Point(172, 56);
            this.tbHeight.Name = "tbHeight";
            this.tbHeight.Size = new System.Drawing.Size(49, 21);
            this.tbHeight.TabIndex = 1;
            this.tbHeight.Text = "256";
            // 
            // tbX
            // 
            this.tbX.Location = new System.Drawing.Point(62, 24);
            this.tbX.Name = "tbX";
            this.tbX.Size = new System.Drawing.Size(49, 21);
            this.tbX.TabIndex = 1;
            this.tbX.Text = "0";
            // 
            // tbY
            // 
            this.tbY.Location = new System.Drawing.Point(172, 24);
            this.tbY.Name = "tbY";
            this.tbY.Size = new System.Drawing.Size(49, 21);
            this.tbY.TabIndex = 1;
            this.tbY.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(117, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "高（H）：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "宽（W）：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(117, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "纵（Y）：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "横（X）：";
            // 
            // cbDistinguishOK
            // 
            this.cbDistinguishOK.AutoSize = true;
            this.cbDistinguishOK.Location = new System.Drawing.Point(9, 77);
            this.cbDistinguishOK.Name = "cbDistinguishOK";
            this.cbDistinguishOK.Size = new System.Drawing.Size(60, 16);
            this.cbDistinguishOK.TabIndex = 1;
            this.cbDistinguishOK.Text = "只存OK";
            this.cbDistinguishOK.UseVisualStyleBackColor = true;
            // 
            // cbDistinguishNG
            // 
            this.cbDistinguishNG.AutoSize = true;
            this.cbDistinguishNG.Location = new System.Drawing.Point(83, 77);
            this.cbDistinguishNG.Name = "cbDistinguishNG";
            this.cbDistinguishNG.Size = new System.Drawing.Size(60, 16);
            this.cbDistinguishNG.TabIndex = 1;
            this.cbDistinguishNG.Text = "只存NG";
            this.cbDistinguishNG.UseVisualStyleBackColor = true;
            // 
            // cbDistinguish
            // 
            this.cbDistinguish.AutoSize = true;
            this.cbDistinguish.Location = new System.Drawing.Point(161, 52);
            this.cbDistinguish.Name = "cbDistinguish";
            this.cbDistinguish.Size = new System.Drawing.Size(66, 16);
            this.cbDistinguish.TabIndex = 1;
            this.cbDistinguish.Text = "区分O/N";
            this.cbDistinguish.UseVisualStyleBackColor = true;
            // 
            // AddCamera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(514, 359);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddCamera";
            this.ShowInTaskbar = false;
            this.Text = "添加相机";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.AddCamera_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.gbConnection.ResumeLayout(false);
            this.gbConnection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox tbCmosWidth;
        private System.Windows.Forms.TextBox tbCmosHeight;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox tbPreStr;
        private System.Windows.Forms.CheckBox cbDate;
        private System.Windows.Forms.CheckBox cbCameraName;
        private System.Windows.Forms.CheckBox cbIPaddress;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btSelectFolder;
        private System.Windows.Forms.TextBox tbFolder;
        private System.Windows.Forms.CheckBox cbRestorSize;
        private System.Windows.Forms.CheckBox cbAutoSaving;
        private System.Windows.Forms.GroupBox gbConnection;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbIPaddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudPort;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbWidth;
        private System.Windows.Forms.TextBox tbHeight;
        private System.Windows.Forms.TextBox tbX;
        private System.Windows.Forms.TextBox tbY;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btSelectColor;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox cbDistinguishOK;
        private System.Windows.Forms.CheckBox cbDistinguishNG;
        private System.Windows.Forms.CheckBox cbDistinguish;
    }
}