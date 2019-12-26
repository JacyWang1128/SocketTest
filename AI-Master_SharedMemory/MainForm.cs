using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AI_Master_SharedMemory
{
    public partial class MainForm : Form
    {
        //treenode与picturebox和address映射
        Dictionary<TreeNode, KeyValuePair<String, PictureBox>> dicPictureBox;
        Boolean isStart = false;
        public MainForm()
        {
            InitializeComponent();
            dicPictureBox = new Dictionary<TreeNode, KeyValuePair<string, PictureBox>>();
        }

        //此处不适用
        //丝滑般流畅
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ExStyle |= 0x02000000;
        //        return cp;
        //    }
        //}

        private void SetCameraDisplay(Dictionary<TreeNode, KeyValuePair<String, PictureBox>> dic)
        {
            Int32 i = 1;
            foreach (var item in dic)
            {
                AiMaster.EVAddCameraDisplay(item.Value.Value.Handle,
                    item.Value.Key,
                    i++,
                    0,
                    item.Value.Value.Width,
                    item.Value.Value.Height,
                    20000,
                    1);
            }
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            //创建显示窗口信息poco
            DisplayPictureboxInfo dpi = new DisplayPictureboxInfo();
            //设置显示窗口信息
            AddWindow aw = new AddWindow(dpi);
            DialogResult dlgr = aw.ShowDialog();
            if (DialogResult.OK == dlgr)
            {
                //创建显示窗口
                PictureBox pb = new PictureBox();
                pb.Location = new Point(dpi.X, dpi.Y);
                pb.Width = dpi.Width;
                pb.Height = dpi.Height;
                RegisterControl(pb);
                plRightBottom.Controls.Add(pb);
                TreeNode tn = new TreeNode("IM:" + dpi.Index, 0, 0);
                treeView1.Nodes.Add(tn);
                dicPictureBox[tn] = new KeyValuePair<string, PictureBox>("127.0.0." + (10 + dpi.Index) + ":1000", pb);
                SaveConfig();
                if (isStart)
                {
                    StopReceiveAIMaster();
                }
                InitAIMaster();
                SetCameraDisplay(dicPictureBox);
                StartReceiveAIMaster();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //RegisterControl(pictureBox1);
            Int32 y = (btCollospan.Parent.Height - btCollospan.Height) / 2;
            btCollospan.Location = new Point(0, y);
            try
            {


                if (ReadConfig.ExistConfigFile())
                {
                    var infos = ReadConfig.GetConfig();
                    if (infos.Length > 0)
                    {
                        foreach (var item in infos)
                        {
                            PictureBox pb = new PictureBox();
                            pb.BackColor = Color.Gray;
                            pb.Location = new Point(item.X, item.Y);
                            pb.Width = item.Width;
                            pb.Height = item.Height;
                            TreeNode tn = new TreeNode("IM:" + item.Index, 0, 0);
                            treeView1.Nodes.Add(tn);
                            dicPictureBox[tn] = new KeyValuePair<string, PictureBox>("127.0.0." + (10 + item.Index) + ":1000", pb);
                            RegisterControl(pb);
                            plRightBottom.Controls.Add(pb);
                        }
                        InitAIMaster();
                        SetCameraDisplay(dicPictureBox);
                        StartReceiveAIMaster();
                    }
                }
            }
            catch
            {
                MessageBox.Show("缺少AIMaster支持");
            }

        }
        private void InitAIMaster()
        {
            long lResult = AiMaster.EVInitEyeVisionSubsystem((IntPtr)0);
            int shmCount = 2;
            int shmImgSize = 2000 * 2000;
            AiMaster.EVInitializeSharedMemory(shmCount, shmImgSize);
            AiMaster.EVInitImgRecvVars();
            AiMaster.EVSetParLong((int)IMG_RECV_PAR.IMG_RECV_PAR_SEND_UDP_ACKNOWLEDGEMENT, 1);
        }
        private void StartReceiveAIMaster()
        {
            // Set local port number EyeView is listening on.
            int port = 64557;
            AiMaster.EVSetParLong((int)IMG_RECV_PAR.IMG_RECV_PAR_PORT_ADDRESS, port);
            AiMaster.EVStartImgRecvThread();
            isStart = true;
        }
        private void StopReceiveAIMaster()
        {
            AiMaster.EVStopImgRecvThread();
            AiMaster.EVDeinitEyeVisionSubsystem();
            isStart = false;
        }
        private void SaveConfig()
        {
            List<DisplayPictureboxInfo> lstDpis = new List<DisplayPictureboxInfo>();
            foreach (var item in dicPictureBox)
            {
                DisplayPictureboxInfo dpi = new DisplayPictureboxInfo();
                dpi.X = item.Value.Value.Location.X;
                dpi.Y = item.Value.Value.Location.Y;
                dpi.Width = item.Value.Value.Width;
                dpi.Height = item.Value.Value.Height;
                dpi.Index = Convert.ToInt32(item.Key.Text.Substring(item.Key.Text.LastIndexOf(":") + 1));
                lstDpis.Add(dpi);
            }
            ReadConfig.SaveConfig(lstDpis.ToArray());
        }

        #region 控件拖动缩放
        private void RegisterControl(Control control)
        {
            control.MouseDown += new MouseEventHandler(Control_MouseDown);
            control.MouseUp += new MouseEventHandler(Control_MouseUp);
            control.MouseMove += new MouseEventHandler(Control_MouseMove);
            control.MouseWheel += new MouseEventHandler(Control_MouseWheel);
            control.MouseDoubleClick += new MouseEventHandler(Control_MouseDoubleClick);
        }

        Boolean isPress = false;
        Int32 x, y;
        Boolean isAllScreen = false;
        Control cParent;
        Panel p;
        private void Control_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!isAllScreen)
            {
                isAllScreen = true;
                p = new Panel();
                p.Dock = DockStyle.Fill;
                (sender as Control).Parent.Controls.Add(p);
                p.BringToFront();
                cParent = (sender as Control).Parent;
                (sender as Control).Parent = p;
                (sender as Control).Dock = DockStyle.Fill;
            }
            else
            {
                isAllScreen = false;
                (sender as Control).Dock = DockStyle.None;
                (sender as Control).Parent = cParent;
                p.Dispose();
            }
        }
        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isPress = true;
                x = e.X;
                y = e.Y;
            }
        }

        private void Control_MouseUp(object sender, MouseEventArgs e)
        {
            isPress = false;
        }

        private void Control_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPress)
            {
                Int32 x0 = (sender as Control).Location.X;
                Int32 y0 = (sender as Control).Location.Y;
                (sender as Control).Location = new Point(x0 + (e.X - x), y0 + (e.Y - y));
            }
        }

        private void Control_MouseWheel(object sender, MouseEventArgs e)
        {
            Size size = (sender as Control).Size;
            Int32 x = e.Delta;
            if (x > 0)
            {
                size.Width = (Int32)(size.Width * 1.05);
                size.Height = (Int32)(size.Height * 1.05);
            }
            else
            {
                size.Width = (Int32)(size.Width / 1.05);
                size.Height = (Int32)(size.Height / 1.05);
            }
            if (size.Height < (sender as Control).Parent.Height)
                (sender as Control).Size = size;

        }
        #endregion

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                StopReceiveAIMaster();
            }
            catch (Exception)
            {

            }

            Environment.Exit(0);
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                if (isStart)
                {
                    StopReceiveAIMaster();
                }
                plRightBottom.Controls.Remove(dicPictureBox[treeView1.SelectedNode].Value);
                dicPictureBox[treeView1.SelectedNode].Value.Dispose();
                dicPictureBox.Remove(treeView1.SelectedNode);
                SaveConfig();
                treeView1.Nodes.Remove(treeView1.SelectedNode);
                InitAIMaster();
                SetCameraDisplay(dicPictureBox);
                StartReceiveAIMaster();
            }
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                DisplayPictureboxInfo dpi = new DisplayPictureboxInfo();
                PictureBox pb = dicPictureBox[treeView1.SelectedNode].Value;
                dpi.X = pb.Location.X;
                dpi.Y = pb.Location.Y;
                dpi.Width = pb.Width;
                dpi.Height = pb.Height;
                dpi.Index = Convert.ToInt32(treeView1.SelectedNode.Text.Substring(treeView1.SelectedNode.Text.LastIndexOf(":") + 1));
                AddWindow aw = new AddWindow(dpi);
                aw.Text = "修改相机";
                DialogResult dlgr = aw.ShowDialog();
                if (DialogResult.OK == dlgr)
                {
                    pb.Location = new Point(dpi.X, dpi.Y);
                    pb.Width = dpi.Width;
                    pb.Height = dpi.Height;
                    treeView1.SelectedNode.Text = "IM:" + dpi.Index;
                    dicPictureBox[treeView1.SelectedNode] = new KeyValuePair<string, PictureBox>("127.0.0." + (10 + dpi.Index) + ":1000", pb);
                    SaveConfig();
                    if (isStart)
                    {
                        StopReceiveAIMaster();
                    }
                    InitAIMaster();
                    SetCameraDisplay(dicPictureBox);
                    StartReceiveAIMaster();
                }
                treeView1.Select();
            }
        }

        private void StartDisplay()
        {
            InitAIMaster();
            SetCameraDisplay(dicPictureBox);
            StartReceiveAIMaster();
        }

        private void btConfig_Click(object sender, EventArgs e)
        {
            //TcpConsole tc = new TcpConsole();
            //tc.Show();
            if (treeView1.SelectedNode != null)
            {
                StopReceiveAIMaster();
                CloseHandler clh = new CloseHandler(StartDisplay);
                Panel p = new Panel();
                p.Dock = DockStyle.Fill;
                WriteParameter wp = new WriteParameter(dicPictureBox[treeView1.SelectedNode].Key, clh);
                wp.Dock = DockStyle.Fill;
                p.Controls.Add(wp);
                this.Controls.Add(p);
                p.BringToFront();
            }
        }

        private void btCollospan_Click(object sender, EventArgs e)
        {
            if (splitContainer1.Panel1Collapsed)
            {
                splitContainer1.Panel1Collapsed = false;
                btCollospan.Text = "《";
            }
            else
            {
                splitContainer1.Panel1Collapsed = true;
                btCollospan.Text = "》";
            }
            Int32 y = (btCollospan.Parent.Height - btCollospan.Height) / 2;
            btCollospan.Location = new Point(0, y);
        }
    }
}
