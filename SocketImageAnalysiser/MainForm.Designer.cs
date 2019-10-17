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
            try
            {
                base.Dispose(disposing);
            }
            catch (System.Exception)
            {
                
            }
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btStartListening = new System.Windows.Forms.Button();
            this.nudPort = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btStopListening = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbCameraName = new System.Windows.Forms.Label();
            this.lbCameraIP = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbRoix = new System.Windows.Forms.Label();
            this.lbRoiy = new System.Windows.Forms.Label();
            this.lbRoiwidth = new System.Windows.Forms.Label();
            this.lbRoiheight = new System.Windows.Forms.Label();
            this.lbGoodCount = new System.Windows.Forms.Label();
            this.lbCycleTime = new System.Windows.Forms.Label();
            this.lbBadCount = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btStartListening
            // 
            this.btStartListening.Location = new System.Drawing.Point(6, 39);
            this.btStartListening.Name = "btStartListening";
            this.btStartListening.Size = new System.Drawing.Size(120, 34);
            this.btStartListening.TabIndex = 0;
            this.btStartListening.Text = "开始监听";
            this.btStartListening.UseVisualStyleBackColor = true;
            this.btStartListening.Click += new System.EventHandler(this.btStartListening_Click);
            // 
            // nudPort
            // 
            this.nudPort.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nudPort.Location = new System.Drawing.Point(132, 12);
            this.nudPort.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.nudPort.Name = "nudPort";
            this.nudPort.Size = new System.Drawing.Size(120, 22);
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
            this.label1.Location = new System.Drawing.Point(7, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "接收端口号：";
            // 
            // btStopListening
            // 
            this.btStopListening.Location = new System.Drawing.Point(132, 39);
            this.btStopListening.Name = "btStopListening";
            this.btStopListening.Size = new System.Drawing.Size(120, 34);
            this.btStopListening.TabIndex = 5;
            this.btStopListening.Text = "停止监听";
            this.btStopListening.UseVisualStyleBackColor = true;
            this.btStopListening.Click += new System.EventHandler(this.btStopListening_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(84, 79);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(71, 16);
            this.radioButton1.TabIndex = 7;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "旋转90°";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.SetRotate);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(7, 101);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(77, 16);
            this.radioButton2.TabIndex = 7;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "旋转180°";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.SetRotate);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(84, 101);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(77, 16);
            this.radioButton3.TabIndex = 7;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "旋转270°";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.SetRotate);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(7, 79);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(59, 16);
            this.radioButton4.TabIndex = 7;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "不旋转";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.SetRotate);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbCameraIP);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lbCameraName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(6, 123);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(246, 61);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "相机信息";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbBadCount);
            this.groupBox2.Controls.Add(this.lbCycleTime);
            this.groupBox2.Controls.Add(this.lbRoiheight);
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
            this.groupBox2.Location = new System.Drawing.Point(6, 190);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(246, 172);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "图片信息";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "相机名称：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "相机IP：";
            // 
            // lbCameraName
            // 
            this.lbCameraName.AutoSize = true;
            this.lbCameraName.Location = new System.Drawing.Point(93, 21);
            this.lbCameraName.Name = "lbCameraName";
            this.lbCameraName.Size = new System.Drawing.Size(0, 12);
            this.lbCameraName.TabIndex = 0;
            // 
            // lbCameraIP
            // 
            this.lbCameraIP.AutoSize = true;
            this.lbCameraIP.Location = new System.Drawing.Point(93, 38);
            this.lbCameraIP.Name = "lbCameraIP";
            this.lbCameraIP.Size = new System.Drawing.Size(0, 12);
            this.lbCameraIP.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "ROI_X：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "ROI_Y：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "ROI_宽：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "ROI_高：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 106);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "GoodCount：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 127);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "BadCount：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 149);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "CycleTime：";
            // 
            // lbRoix
            // 
            this.lbRoix.AutoSize = true;
            this.lbRoix.Location = new System.Drawing.Point(93, 21);
            this.lbRoix.Name = "lbRoix";
            this.lbRoix.Size = new System.Drawing.Size(0, 12);
            this.lbRoix.TabIndex = 1;
            // 
            // lbRoiy
            // 
            this.lbRoiy.AutoSize = true;
            this.lbRoiy.Location = new System.Drawing.Point(93, 43);
            this.lbRoiy.Name = "lbRoiy";
            this.lbRoiy.Size = new System.Drawing.Size(0, 12);
            this.lbRoiy.TabIndex = 1;
            // 
            // lbRoiwidth
            // 
            this.lbRoiwidth.AutoSize = true;
            this.lbRoiwidth.Location = new System.Drawing.Point(93, 64);
            this.lbRoiwidth.Name = "lbRoiwidth";
            this.lbRoiwidth.Size = new System.Drawing.Size(0, 12);
            this.lbRoiwidth.TabIndex = 1;
            // 
            // lbRoiheight
            // 
            this.lbRoiheight.AutoSize = true;
            this.lbRoiheight.Location = new System.Drawing.Point(93, 86);
            this.lbRoiheight.Name = "lbRoiheight";
            this.lbRoiheight.Size = new System.Drawing.Size(0, 12);
            this.lbRoiheight.TabIndex = 1;
            // 
            // lbGoodCount
            // 
            this.lbGoodCount.AutoSize = true;
            this.lbGoodCount.Location = new System.Drawing.Point(93, 106);
            this.lbGoodCount.Name = "lbGoodCount";
            this.lbGoodCount.Size = new System.Drawing.Size(0, 12);
            this.lbGoodCount.TabIndex = 1;
            // 
            // lbCycleTime
            // 
            this.lbCycleTime.AutoSize = true;
            this.lbCycleTime.Location = new System.Drawing.Point(93, 149);
            this.lbCycleTime.Name = "lbCycleTime";
            this.lbCycleTime.Size = new System.Drawing.Size(0, 12);
            this.lbCycleTime.TabIndex = 1;
            // 
            // lbBadCount
            // 
            this.lbBadCount.AutoSize = true;
            this.lbBadCount.Location = new System.Drawing.Point(93, 127);
            this.lbBadCount.Name = "lbBadCount";
            this.lbBadCount.Size = new System.Drawing.Size(0, 12);
            this.lbBadCount.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(258, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(640, 512);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 535);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton4);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.btStopListening);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudPort);
            this.Controls.Add(this.btStartListening);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btStartListening;
        private System.Windows.Forms.NumericUpDown nudPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btStopListening;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbCameraIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbCameraName;
        private System.Windows.Forms.Label label2;
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
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

