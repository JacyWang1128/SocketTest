namespace AI_Master_SharedMemory
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.treeviewIcon = new System.Windows.Forms.ImageList(this.components);
            this.plLeftTop = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btAdd = new System.Windows.Forms.Button();
            this.btDelete = new System.Windows.Forms.Button();
            this.btUpdate = new System.Windows.Forms.Button();
            this.btConfig = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.plRightBottom = new System.Windows.Forms.Panel();
            this.btCollospan = new System.Windows.Forms.Button();
            this.plRightTop = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.plLeftTop.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.plRightBottom.SuspendLayout();
            this.plRightTop.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            this.splitContainer1.Panel1.Controls.Add(this.plLeftTop);
            this.splitContainer1.Panel1MinSize = 300;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.plRightBottom);
            this.splitContainer1.Panel2.Controls.Add(this.plRightTop);
            this.splitContainer1.Size = new System.Drawing.Size(1264, 985);
            this.splitContainer1.SplitterDistance = 300;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.DarkGray;
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.treeviewIcon;
            this.treeView1.Location = new System.Drawing.Point(0, 77);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(300, 908);
            this.treeView1.TabIndex = 1;
            // 
            // treeviewIcon
            // 
            this.treeviewIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeviewIcon.ImageStream")));
            this.treeviewIcon.TransparentColor = System.Drawing.Color.Transparent;
            this.treeviewIcon.Images.SetKeyName(0, "摄像头.png");
            // 
            // plLeftTop
            // 
            this.plLeftTop.Controls.Add(this.tableLayoutPanel1);
            this.plLeftTop.Controls.Add(this.label1);
            this.plLeftTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.plLeftTop.Location = new System.Drawing.Point(0, 0);
            this.plLeftTop.Name = "plLeftTop";
            this.plLeftTop.Size = new System.Drawing.Size(300, 77);
            this.plLeftTop.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.DarkGray;
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.Controls.Add(this.label6, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btAdd, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btDelete, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btUpdate, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btConfig, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 42);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(300, 35);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(262, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 35);
            this.label6.TabIndex = 4;
            this.label6.Text = "配置";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label6.Click += new System.EventHandler(this.btConfig_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(188, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 35);
            this.label5.TabIndex = 3;
            this.label5.Text = "设置";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.Click += new System.EventHandler(this.btUpdate_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(114, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 35);
            this.label4.TabIndex = 2;
            this.label4.Text = "删除";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btAdd
            // 
            this.btAdd.BackgroundImage = global::AI_Master_SharedMemory.Properties.Resources.添加__1_;
            this.btAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btAdd.Dock = System.Windows.Forms.DockStyle.Top;
            this.btAdd.FlatAppearance.BorderSize = 0;
            this.btAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAdd.Location = new System.Drawing.Point(3, 3);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(31, 26);
            this.btAdd.TabIndex = 0;
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btDelete
            // 
            this.btDelete.BackgroundImage = global::AI_Master_SharedMemory.Properties.Resources.删除;
            this.btDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btDelete.Dock = System.Windows.Forms.DockStyle.Top;
            this.btDelete.FlatAppearance.BorderSize = 0;
            this.btDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDelete.Location = new System.Drawing.Point(77, 3);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(31, 26);
            this.btDelete.TabIndex = 0;
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btUpdate
            // 
            this.btUpdate.BackgroundImage = global::AI_Master_SharedMemory.Properties.Resources.修改;
            this.btUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btUpdate.Dock = System.Windows.Forms.DockStyle.Top;
            this.btUpdate.FlatAppearance.BorderSize = 0;
            this.btUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btUpdate.Location = new System.Drawing.Point(151, 3);
            this.btUpdate.Name = "btUpdate";
            this.btUpdate.Size = new System.Drawing.Size(31, 26);
            this.btUpdate.TabIndex = 0;
            this.btUpdate.UseVisualStyleBackColor = true;
            this.btUpdate.Click += new System.EventHandler(this.btUpdate_Click);
            // 
            // btConfig
            // 
            this.btConfig.BackgroundImage = global::AI_Master_SharedMemory.Properties.Resources.闪电;
            this.btConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btConfig.Dock = System.Windows.Forms.DockStyle.Top;
            this.btConfig.FlatAppearance.BorderSize = 0;
            this.btConfig.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btConfig.Location = new System.Drawing.Point(225, 3);
            this.btConfig.Name = "btConfig";
            this.btConfig.Size = new System.Drawing.Size(31, 26);
            this.btConfig.TabIndex = 0;
            this.btConfig.UseVisualStyleBackColor = true;
            this.btConfig.Click += new System.EventHandler(this.btConfig_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(40, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 35);
            this.label3.TabIndex = 1;
            this.label3.Text = "添加";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "相机列表";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // plRightBottom
            // 
            this.plRightBottom.AutoScroll = true;
            this.plRightBottom.BackColor = System.Drawing.Color.Silver;
            this.plRightBottom.Controls.Add(this.btCollospan);
            this.plRightBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plRightBottom.Location = new System.Drawing.Point(0, 42);
            this.plRightBottom.Name = "plRightBottom";
            this.plRightBottom.Size = new System.Drawing.Size(963, 943);
            this.plRightBottom.TabIndex = 1;
            // 
            // btCollospan
            // 
            this.btCollospan.Location = new System.Drawing.Point(5, 419);
            this.btCollospan.Name = "btCollospan";
            this.btCollospan.Size = new System.Drawing.Size(15, 50);
            this.btCollospan.TabIndex = 0;
            this.btCollospan.Text = "《";
            this.btCollospan.UseVisualStyleBackColor = true;
            this.btCollospan.Click += new System.EventHandler(this.btCollospan_Click);
            // 
            // plRightTop
            // 
            this.plRightTop.Controls.Add(this.label2);
            this.plRightTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.plRightTop.Location = new System.Drawing.Point(0, 0);
            this.plRightTop.Name = "plRightTop";
            this.plRightTop.Size = new System.Drawing.Size(963, 42);
            this.plRightTop.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(963, 40);
            this.label2.TabIndex = 1;
            this.label2.Text = "实时图像";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 985);
            this.Controls.Add(this.splitContainer1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "AI-Master";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.plLeftTop.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.plRightBottom.ResumeLayout(false);
            this.plRightTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel plLeftTop;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Button btUpdate;
        private System.Windows.Forms.Button btConfig;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList treeviewIcon;
        private System.Windows.Forms.Panel plRightTop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel plRightBottom;
        private System.Windows.Forms.Button btCollospan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}

