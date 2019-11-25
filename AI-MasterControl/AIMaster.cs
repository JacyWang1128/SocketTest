using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Net;
using AI_MasterControl.Element;

namespace AI_MasterControl
{
    public delegate void MessageHandle(Dictionary<String, String> dic);
    public delegate void FilePreEventHandler();
    public delegate void AddControlEventHandler(CameraSettings setting);
    public partial class AIMaster : UserControl
    {
        MessageHandle msgh;
        public VCZcamera camera;
        String configPath;
        private Int32 Original_Width;
        private Int32 Original_Height;
        Point mousePoint;
        Boolean isAllScreen = false;
        Control originControl;
        Panel p;
        Color infoColor = Color.White;
        public CameraSettings cameraSetting;
        public AddControlEventHandler aceh;
        public AIMaster()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            aceh = new AddControlEventHandler(SetCamera);
            cameraSetting = new CameraSettings();
            msgh = new MessageHandle(ShowInfo);
            FilePreEventHandler fpeh = new FilePreEventHandler(SetFilePreFile);
            camera = new VCZcamera(msgh, pictureBox1, fpeh);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void ShowInfo(Dictionary<String, String> Info)
        {
            //lbBadCount.Text = Info["BadCount"];
            //lbGoodCount.Text = Info["GoodCount"];
            //lbCycleTime.Text = Info["CycleTime"];
            //lbCameraIP.Text = Info["CameraIP"];
            //lbCameraName.Text = Info["CameraName"];
            //lbRoiheight.Text = Info["Roi_height"];
            //lbRoiwidth.Text = Info["Roi_width"];
            //lbRoix.Text = Info["Roi_x"];
            //lbRoiy.Text = Info["Roi_y"];
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            //panel1.BackColor = Color.FromArgb(8, Color.LightGreen);
            //panel2.BackColor = Color.FromArgb(8, Color.LightGreen);
            panel1.BackColor = Color.Transparent;
            panel2.BackColor = Color.Transparent;
            Original_Height = this.Height;
            Original_Width = this.Width;
            lbCameraIP.BringToFront();
            lbCameraName.BringToFront();
        }

        private void btStartListening_Click(object sender, EventArgs e)
        {
            if (camera.isReceiving)
            {
                camera.Stop();
                btStartListening.Text = "开始监听";
            }
            else
            {
                IPAddress addr;
                if (IPAddress.TryParse(tbIPaddress.Text, out addr))
                {
                    camera.CameraIP = addr.ToString();
                    camera.Port = Convert.ToInt32(nudPort.Value);
                    camera.Start();
                    btStartListening.Text = "结束监听";
                }
                else
                {
                    MessageBox.Show("请输入合法IP地址！");
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            camera.Stop();
        }

        private void SetRotate(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                camera.rotate = 0;
            }
            if (radioButton1.Checked)
            {
                camera.rotate = RotateFlipType.Rotate90FlipNone;
            }
            if (radioButton2.Checked)
            {
                camera.rotate = RotateFlipType.Rotate180FlipNone;
            }
            if (radioButton3.Checked)
            {
                camera.rotate = RotateFlipType.Rotate270FlipNone;
            }
        }

        private void btSelectFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "请选择文件夹";
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            fbd.ShowNewFolderButton = true;
            if (DialogResult.OK == fbd.ShowDialog())
            {
                tbFolder.Text = fbd.SelectedPath;
                SetFilePreFile();
            }
        }

        public void SetFilePreFile()
        {
            camera.PathNG = GetFilePreString(cameraSetting.PreStringNG);
            camera.PathOK = GetFilePreString(cameraSetting.PreStringOK);
            camera.FilePrefix = GetFilePreString(cameraSetting.PreString);
        }

        public String GetFilePreString(String preString)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(preString);
            if (cameraSetting.IsIpAddress)
            {
                sb.Append(camera.CameraIP.Replace(".", "_") + "_");
            }
            if (cameraSetting.IsCameraName)
            {
                sb.Append(camera.CameraName.Replace(".", "_") + "_");
            }
            if (cameraSetting.IsDate)
            {
                sb.Append(DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss_ffff"));
            }
            return sb.ToString();
        }

        private void SaveInfoChecked(object sender, EventArgs e)
        {
            SetFilePreFile();
        }

        private void cbAutoSaving_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAutoSaving.Checked)
            {
                SetFilePreFile();
                camera.IsSaveing = true;
            }
            else
            {
                camera.IsSaveing = false;
            }
        }

        private void cbRestorSize_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbRestorSize.Checked)
                {
                    camera.SetCMOS(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
                    camera.IsRestore = true;
                }
                else
                {
                    camera.IsRestore = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            tbFolder.Text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            cbAutoSaving.Checked = false;
        }


        private Boolean IsOverShow(Rectangle controlClientRectangle, Point location)
        {
            return controlClientRectangle.Contains(location);
        }

        private void 相机设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCamera();
            //if (IsOverShow(this.ClientRectangle, new Point(mousePoint.X + panel2.Width, mousePoint.Y + panel2.Height)))
            //{
            //    panel2.Location = mousePoint;
            //}
            //else
            //{
            //    panel2.Location = new Point(this.Width / 20, this.Height / 20);
            //}
            //panel2.Visible = true;
        }

        public void SetCamera()
        {
            AddCamera ac = new AddCamera(cameraSetting, aceh, "相机设置");
            ac.ShowDialog();
        }

        public void SetCamera(CameraSettings setting)
        {
            this.Width = setting.ControlWidth;
            this.Height = setting.ControlHeight;
            this.Location = new Point(setting.ControlX, setting.ControlY);
            this.camera.CameraIP = setting.CameraIP;
            this.camera.Port = setting.Port;
            this.camera.FilePrefix = setting.PreString;
            this.camera.CmosHeight = setting.Cmos_Heigt;
            this.camera.CmosWidth = setting.Cmos_Width;
            this.camera.IsRestore = setting.IsRestore;
            SetFilePreFile();
            this.camera.IsSaveing = setting.IsAutoSaving;
            this.camera.rotate = setting.RotateType;
            this.infoColor = setting.InfoColor;
            this.camera.IsDistinguish = setting.IsDistinguished;
            this.camera.IsSaveNG = setting.IsSaveNG;
            this.camera.IsSaveOK = setting.IsSaveOK;
            if (!camera.isReceiving)
                camera.Start();
        }

        private void AIMaster_Resize(object sender, EventArgs e)
        {
            if (Original_Width > 0 || Original_Height > 0)
            {
                Int32 Original_X = panel2.Location.X;
                Int32 Original_Y = panel2.Location.Y;
                Int32 Current_Width = this.Width;
                double Proportion = (double)Current_Width / (double)Original_Width;
                panel2.Location = new Point(Convert.ToInt32(Original_X * Proportion), Convert.ToInt32(Original_Y * Proportion));
                Original_X = panel1.Location.X;
                Original_Y = panel1.Location.Y;
                panel1.Location = new Point(Convert.ToInt32(Original_X * Proportion), Convert.ToInt32(Original_Y * Proportion));
            }
        }
        Boolean isSelected = false;
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (isSelected)
            {
                PictureBox p = (PictureBox)sender;
                Pen pp = new Pen(Color.Red);
                e.Graphics.DrawRectangle(pp, p.ClientRectangle.X,
                p.ClientRectangle.Y,
                p.ClientRectangle.X + p.ClientRectangle.Width - 1,
                p.ClientRectangle.Y + p.ClientRectangle.Height - 1);
            }
            if (isAllScreen)
            {
                if (pictureBox1.Image != null)
                    e.Graphics.DrawString($"{camera.camInfo.CameraIp}  {camera.camInfo.CameraName}\r\nCycleTime:{camera.camInfo.CycleTime}ms \r\nGoodCount:{camera.camInfo.GoodCount} \r\nBadCount:{camera.camInfo.BadCount} \r\nRoi_Width:{camera.camInfo.RoiWidth}\r\nRoi_Height:{camera.camInfo.RoiHeight}\r\nRoi_X:{camera.camInfo.RoiX}\r\nRoi_Y:{camera.camInfo.RoiY}", Font, new SolidBrush(infoColor), new PointF(10, 10));
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            MouseButtons whichButton = e.Button;
            switch (whichButton)
            {
                case MouseButtons.Left:
                    isSelected = !isSelected;
                    pictureBox1.Refresh();
                    break;
                case MouseButtons.None:
                    break;
                case MouseButtons.Right:
                    mousePoint = this.PointToScreen((e as MouseEventArgs).Location);
                    //mousePoint = new Point((e as MouseEventArgs).X + this.Location.X, (e as MouseEventArgs).Y + this.Location.Y);
                    开始监听ToolStripMenuItem.Text = camera.isReceiving ? "结束监听" : "开始监听";
                    contextMenuStrip1.Show(mousePoint);
                    break;
                case MouseButtons.Middle:
                    break;
                case MouseButtons.XButton1:
                    break;
                case MouseButtons.XButton2:
                    break;
                default:
                    break;
            }
            panel2.Visible = false;
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!isAllScreen)
            {
                isAllScreen = true;
                p = new Panel();
                p.Dock = DockStyle.Fill;
                this.ParentForm.Controls.Add(p);
                p.BringToFront();
                originControl = this.Parent;
                this.Parent = p;
                this.Dock = DockStyle.Fill;
            }
            else
            {
                isAllScreen = false;
                this.Dock = DockStyle.None;
                this.Parent = originControl;
                p.Dispose();
            }
        }

        private void 开始监听ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (camera.isReceiving)
            {
                camera.Stop();
            }
            else
            {
                camera.Start();
            }
        }

        private void Rotate_Button(object sender, EventArgs e)
        {
            不旋转ToolStripMenuItem.Text = "不旋转";
            旋转90ToolStripMenuItem.Text = "旋转90°";
            旋转180ToolStripMenuItem.Text = "旋转180°";
            旋转270ToolStripMenuItem.Text = "旋转270°";
            if (sender == 不旋转ToolStripMenuItem)
            {
                camera.rotate = RotateFlipType.RotateNoneFlipNone;
                (sender as ToolStripMenuItem).Text = "不旋转 √";
            }
            else if (sender == 旋转90ToolStripMenuItem)
            {
                camera.rotate = RotateFlipType.Rotate90FlipNone;
                (sender as ToolStripMenuItem).Text = "旋转90 √";
            }
            else if (sender == 旋转180ToolStripMenuItem)
            {
                camera.rotate = RotateFlipType.Rotate180FlipNone;
                (sender as ToolStripMenuItem).Text = "旋转180 √";
            }
            else if (sender == 旋转270ToolStripMenuItem)
            {
                camera.rotate = RotateFlipType.Rotate270FlipNone;
                (sender as ToolStripMenuItem).Text = "旋转270 √";
            }
        }
    }
}
