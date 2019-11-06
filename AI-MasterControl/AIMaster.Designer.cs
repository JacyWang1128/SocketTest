namespace AI_MasterControl
{
    partial class AIMaster
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
            camera.Stop();
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
            this.tbIPaddress = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btSelectFolder = new System.Windows.Forms.Button();
            this.tbFolder = new System.Windows.Forms.TextBox();
            this.cbRestorSize = new System.Windows.Forms.CheckBox();
            this.cbAutoSaving = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.cbDate = new System.Windows.Forms.CheckBox();
            this.cbCameraName = new System.Windows.Forms.CheckBox();
            this.cbIPaddress = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbCameraIP = new System.Windows.Forms.Label();
            this.lbBadCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbCameraName = new System.Windows.Forms.Label();
            this.lbCycleTime = new System.Windows.Forms.Label();
            this.lbRoiheight = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbRoiy = new System.Windows.Forms.Label();
            this.lbGoodCount = new System.Windows.Forms.Label();
            this.lbRoiwidth = new System.Windows.Forms.Label();
            this.lbRoix = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nudPort = new System.Windows.Forms.NumericUpDown();
            this.btStartListening = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gbConnection = new System.Windows.Forms.GroupBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip();
            this.相机设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.gbConnection.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbIPaddress
            // 
            this.tbIPaddress.Location = new System.Drawing.Point(90, 14);
            this.tbIPaddress.Name = "tbIPaddress";
            this.tbIPaddress.Size = new System.Drawing.Size(131, 21);
            this.tbIPaddress.TabIndex = 30;
            // 
            // groupBox7
            // 
            this.groupBox7.AutoSize = true;
            this.groupBox7.BackColor = System.Drawing.Color.Transparent;
            this.groupBox7.Controls.Add(this.textBox1);
            this.groupBox7.Controls.Add(this.textBox2);
            this.groupBox7.Controls.Add(this.label15);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox7.Location = new System.Drawing.Point(0, 172);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(229, 62);
            this.groupBox7.TabIndex = 29;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "相机CMOS设置";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(57, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(52, 21);
            this.textBox1.TabIndex = 14;
            this.textBox1.Tag = "宽";
            this.textBox1.Text = "1280";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(130, 21);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(52, 21);
            this.textBox2.TabIndex = 15;
            this.textBox2.Tag = "高";
            this.textBox2.Text = "1024";
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
            // groupBox6
            // 
            this.groupBox6.AutoSize = true;
            this.groupBox6.BackColor = System.Drawing.Color.Transparent;
            this.groupBox6.Controls.Add(this.btSelectFolder);
            this.groupBox6.Controls.Add(this.tbFolder);
            this.groupBox6.Controls.Add(this.cbRestorSize);
            this.groupBox6.Controls.Add(this.cbAutoSaving);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox6.Location = new System.Drawing.Point(0, 0);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(229, 89);
            this.groupBox6.TabIndex = 28;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "保存路径设置";
            // 
            // btSelectFolder
            // 
            this.btSelectFolder.Location = new System.Drawing.Point(173, 19);
            this.btSelectFolder.Name = "btSelectFolder";
            this.btSelectFolder.Size = new System.Drawing.Size(48, 23);
            this.btSelectFolder.TabIndex = 6;
            this.btSelectFolder.Text = "选择";
            this.btSelectFolder.UseVisualStyleBackColor = true;
            this.btSelectFolder.Click += new System.EventHandler(this.btSelectFolder_Click);
            // 
            // tbFolder
            // 
            this.tbFolder.Location = new System.Drawing.Point(9, 20);
            this.tbFolder.Name = "tbFolder";
            this.tbFolder.Size = new System.Drawing.Size(158, 21);
            this.tbFolder.TabIndex = 5;
            // 
            // cbRestorSize
            // 
            this.cbRestorSize.AutoSize = true;
            this.cbRestorSize.Location = new System.Drawing.Point(21, 53);
            this.cbRestorSize.Name = "cbRestorSize";
            this.cbRestorSize.Size = new System.Drawing.Size(72, 16);
            this.cbRestorSize.TabIndex = 2;
            this.cbRestorSize.Text = "还原大小";
            this.cbRestorSize.UseVisualStyleBackColor = true;
            this.cbRestorSize.CheckedChanged += new System.EventHandler(this.cbRestorSize_CheckedChanged);
            // 
            // cbAutoSaving
            // 
            this.cbAutoSaving.AutoSize = true;
            this.cbAutoSaving.Location = new System.Drawing.Point(110, 53);
            this.cbAutoSaving.Name = "cbAutoSaving";
            this.cbAutoSaving.Size = new System.Drawing.Size(72, 16);
            this.cbAutoSaving.TabIndex = 1;
            this.cbAutoSaving.Text = "自动记录";
            this.cbAutoSaving.UseVisualStyleBackColor = true;
            this.cbAutoSaving.CheckedChanged += new System.EventHandler(this.cbAutoSaving_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.AutoSize = true;
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.textBox3);
            this.groupBox5.Controls.Add(this.cbDate);
            this.groupBox5.Controls.Add(this.cbCameraName);
            this.groupBox5.Controls.Add(this.cbIPaddress);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(0, 89);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(229, 83);
            this.groupBox5.TabIndex = 27;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "图片名称设置";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(9, 42);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(212, 21);
            this.textBox3.TabIndex = 5;
            // 
            // cbDate
            // 
            this.cbDate.AutoSize = true;
            this.cbDate.Location = new System.Drawing.Point(173, 20);
            this.cbDate.Name = "cbDate";
            this.cbDate.Size = new System.Drawing.Size(48, 16);
            this.cbDate.TabIndex = 4;
            this.cbDate.Text = "日期";
            this.cbDate.UseVisualStyleBackColor = true;
            this.cbDate.CheckedChanged += new System.EventHandler(this.SaveInfoChecked);
            // 
            // cbCameraName
            // 
            this.cbCameraName.AutoSize = true;
            this.cbCameraName.Checked = true;
            this.cbCameraName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCameraName.Location = new System.Drawing.Point(83, 20);
            this.cbCameraName.Name = "cbCameraName";
            this.cbCameraName.Size = new System.Drawing.Size(72, 16);
            this.cbCameraName.TabIndex = 3;
            this.cbCameraName.Text = "相机名称";
            this.cbCameraName.UseVisualStyleBackColor = true;
            this.cbCameraName.CheckedChanged += new System.EventHandler(this.SaveInfoChecked);
            // 
            // cbIPaddress
            // 
            this.cbIPaddress.AutoSize = true;
            this.cbIPaddress.Location = new System.Drawing.Point(9, 20);
            this.cbIPaddress.Name = "cbIPaddress";
            this.cbIPaddress.Size = new System.Drawing.Size(60, 16);
            this.cbIPaddress.TabIndex = 2;
            this.cbIPaddress.Text = "IP地址";
            this.cbIPaddress.UseVisualStyleBackColor = true;
            this.cbIPaddress.CheckedChanged += new System.EventHandler(this.SaveInfoChecked);
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
            this.groupBox4.Location = new System.Drawing.Point(0, 234);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(229, 82);
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
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(960, 768);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbCameraIP);
            this.groupBox2.Controls.Add(this.lbBadCount);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lbCameraName);
            this.groupBox2.Controls.Add(this.lbCycleTime);
            this.groupBox2.Controls.Add(this.lbRoiheight);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lbRoiy);
            this.groupBox2.Controls.Add(this.lbGoodCount);
            this.groupBox2.Controls.Add(this.lbRoiwidth);
            this.groupBox2.Controls.Add(this.lbRoix);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(229, 212);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "图片信息";
            // 
            // lbCameraIP
            // 
            this.lbCameraIP.AutoSize = true;
            this.lbCameraIP.ForeColor = System.Drawing.SystemColors.Control;
            this.lbCameraIP.Location = new System.Drawing.Point(94, 42);
            this.lbCameraIP.Name = "lbCameraIP";
            this.lbCameraIP.Size = new System.Drawing.Size(41, 12);
            this.lbCameraIP.TabIndex = 0;
            this.lbCameraIP.Text = "相机IP";
            // 
            // lbBadCount
            // 
            this.lbBadCount.AutoSize = true;
            this.lbBadCount.Location = new System.Drawing.Point(94, 170);
            this.lbBadCount.Name = "lbBadCount";
            this.lbBadCount.Size = new System.Drawing.Size(0, 12);
            this.lbBadCount.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "相机IP：";
            // 
            // lbCameraName
            // 
            this.lbCameraName.AutoSize = true;
            this.lbCameraName.ForeColor = System.Drawing.SystemColors.Control;
            this.lbCameraName.Location = new System.Drawing.Point(94, 21);
            this.lbCameraName.Name = "lbCameraName";
            this.lbCameraName.Size = new System.Drawing.Size(53, 12);
            this.lbCameraName.TabIndex = 0;
            this.lbCameraName.Text = "相机名称";
            // 
            // lbCycleTime
            // 
            this.lbCycleTime.AutoSize = true;
            this.lbCycleTime.Location = new System.Drawing.Point(94, 192);
            this.lbCycleTime.Name = "lbCycleTime";
            this.lbCycleTime.Size = new System.Drawing.Size(0, 12);
            this.lbCycleTime.TabIndex = 1;
            // 
            // lbRoiheight
            // 
            this.lbRoiheight.AutoSize = true;
            this.lbRoiheight.Location = new System.Drawing.Point(94, 129);
            this.lbRoiheight.Name = "lbRoiheight";
            this.lbRoiheight.Size = new System.Drawing.Size(0, 12);
            this.lbRoiheight.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "相机名称：";
            // 
            // lbRoiy
            // 
            this.lbRoiy.AutoSize = true;
            this.lbRoiy.Location = new System.Drawing.Point(94, 86);
            this.lbRoiy.Name = "lbRoiy";
            this.lbRoiy.Size = new System.Drawing.Size(0, 12);
            this.lbRoiy.TabIndex = 1;
            // 
            // lbGoodCount
            // 
            this.lbGoodCount.AutoSize = true;
            this.lbGoodCount.Location = new System.Drawing.Point(94, 149);
            this.lbGoodCount.Name = "lbGoodCount";
            this.lbGoodCount.Size = new System.Drawing.Size(0, 12);
            this.lbGoodCount.TabIndex = 1;
            // 
            // lbRoiwidth
            // 
            this.lbRoiwidth.AutoSize = true;
            this.lbRoiwidth.Location = new System.Drawing.Point(94, 107);
            this.lbRoiwidth.Name = "lbRoiwidth";
            this.lbRoiwidth.Size = new System.Drawing.Size(0, 12);
            this.lbRoiwidth.TabIndex = 1;
            // 
            // lbRoix
            // 
            this.lbRoix.AutoSize = true;
            this.lbRoix.Location = new System.Drawing.Point(94, 64);
            this.lbRoix.Name = "lbRoix";
            this.lbRoix.Size = new System.Drawing.Size(0, 12);
            this.lbRoix.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 192);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "CycleTime：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 170);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "BadCount：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "ROI_宽：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 149);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "GoodCount：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "ROI_高：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "ROI_Y：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "ROI_X：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 12);
            this.label11.TabIndex = 21;
            this.label11.Text = "接收IP地址：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "接收端口号：";
            // 
            // nudPort
            // 
            this.nudPort.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nudPort.Location = new System.Drawing.Point(90, 39);
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
            // btStartListening
            // 
            this.btStartListening.Location = new System.Drawing.Point(150, 38);
            this.btStartListening.Name = "btStartListening";
            this.btStartListening.Size = new System.Drawing.Size(71, 25);
            this.btStartListening.TabIndex = 19;
            this.btStartListening.Text = "开始监听";
            this.btStartListening.UseVisualStyleBackColor = true;
            this.btStartListening.Click += new System.EventHandler(this.btStartListening_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Location = new System.Drawing.Point(53, 81);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(229, 212);
            this.panel1.TabIndex = 31;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.gbConnection);
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Controls.Add(this.groupBox7);
            this.panel2.Controls.Add(this.groupBox5);
            this.panel2.Controls.Add(this.groupBox6);
            this.panel2.Location = new System.Drawing.Point(638, 102);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(229, 385);
            this.panel2.TabIndex = 32;
            // 
            // gbConnection
            // 
            this.gbConnection.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbConnection.BackColor = System.Drawing.Color.Transparent;
            this.gbConnection.Controls.Add(this.label11);
            this.gbConnection.Controls.Add(this.tbIPaddress);
            this.gbConnection.Controls.Add(this.label1);
            this.gbConnection.Controls.Add(this.btStartListening);
            this.gbConnection.Controls.Add(this.nudPort);
            this.gbConnection.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbConnection.Location = new System.Drawing.Point(0, 316);
            this.gbConnection.Name = "gbConnection";
            this.gbConnection.Size = new System.Drawing.Size(229, 69);
            this.gbConnection.TabIndex = 30;
            this.gbConnection.TabStop = false;
            this.gbConnection.Text = "相机连接设置";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.相机设置ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 26);
            // 
            // 相机设置ToolStripMenuItem
            // 
            this.相机设置ToolStripMenuItem.Name = "相机设置ToolStripMenuItem";
            this.相机设置ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.相机设置ToolStripMenuItem.Text = "相机设置";
            this.相机设置ToolStripMenuItem.Click += new System.EventHandler(this.相机设置ToolStripMenuItem_Click);
            // 
            // AIMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.Name = "AIMaster";
            this.Size = new System.Drawing.Size(960, 768);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.AIMaster_Resize);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.gbConnection.ResumeLayout(false);
            this.gbConnection.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbIPaddress;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btSelectFolder;
        private System.Windows.Forms.TextBox tbFolder;
        private System.Windows.Forms.CheckBox cbRestorSize;
        private System.Windows.Forms.CheckBox cbAutoSaving;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.CheckBox cbDate;
        private System.Windows.Forms.CheckBox cbCameraName;
        private System.Windows.Forms.CheckBox cbIPaddress;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbBadCount;
        private System.Windows.Forms.Label lbCycleTime;
        private System.Windows.Forms.Label lbRoiheight;
        private System.Windows.Forms.Label lbRoiy;
        private System.Windows.Forms.Label lbGoodCount;
        private System.Windows.Forms.Label lbRoiwidth;
        private System.Windows.Forms.Label lbRoix;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbCameraIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbCameraName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudPort;
        private System.Windows.Forms.Button btStartListening;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox gbConnection;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 相机设置ToolStripMenuItem;
    }
}
