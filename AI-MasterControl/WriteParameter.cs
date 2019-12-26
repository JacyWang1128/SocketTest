using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;

namespace AI_MasterControl
{
    public partial class WriteParameter : UserControl
    {
        public PCONLAN_TCP myTcp = null;
        //ip地址
        String ip = null;
        List<AIMaster> AIMasters;
        public WriteParameter(params AIMaster[] param)
        {
            InitializeComponent();
            myTcp = new PCONLAN_TCP();
            AIMasters = new List<AIMaster>();
            foreach (var item in param)
            {
                AIMasters.Add(item);
            }
            btConnect.BackColor = Color.Pink;
            //允许跨线程更改UI
            CheckForIllegalCrossThreadCalls = false;
        }

        //丝滑般流畅
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void Print(String message)
        {
            //控制台输出
            rtbConsole.AppendText(message + "\r\n");
        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            btConnect.Enabled = false;
            //连接逻辑
            if (btConnect.Text == "连接")
            {
                new Thread(t =>
                {
                    IPAddress ip;
                    if (IPAddress.TryParse(gbControlBox.Text, out ip))
                    {
                        Boolean result = myTcp.connect(gbControlBox.Text, (Int32)nudPortNumber.Value);
                        if (result)
                        {
                            btConnect.Text = "断开";
                            btConnect.BackColor = Color.LightGreen;
                            Print("TCP已连接");
                            SetButtonEnable(true);
                        }
                        else
                        {
                            Print("连接失败！");
                        }
                    }
                    else
                    {
                        MessageBox.Show("请输入合法IP！");
                    }
                    btConnect.Enabled = true;
                }).Start();
            }
            else
            {
                new Thread(t => {
                    Boolean result = myTcp.disconnect();
                    if (result)
                    {
                        btConnect.Text = "连接";
                        btConnect.BackColor = Color.Pink;
                        Print("已断开连接");
                        btSend.Enabled = false;
                        SetButtonEnable(false);
                    }
                    else
                    {
                        Print("断开失败！");
                    }
                    btConnect.Enabled = true;
                }).Start();
            }
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            SetButtonEnable(false);
            new Thread(t => {
                if (!myTcp.ConnectStatus())
                {
                    Print("正在尝试TCP重连...");
                    if (myTcp.connect())
                    {
                        Print("TCP重连成功！");
                    }
                    else
                    {
                        Print("TCP连接异常！请重新连接！！！");
                        SetButtonEnable(true);
                        return;
                    }
                }
                //发送指令用法 response为返回值
                String response = myTcp.communicate_extended_ack(tbInput.Text);
                while (response.Length < "OKcomplete".Length - 1)
                {
                    Thread.Sleep(200);
                    response = myTcp.communicate_extended_ack(tbInput.Text);
                }
                Print(response);
                Thread.Sleep(500);
                SetButtonEnable(true);
            }).Start();
        }

        //此方法在每次发送时都应先调用，让其他按钮不可用，防止串发，发送结束后再激活其他按钮
        /// <summary>
        /// 在TCP断开状态下，使发送按钮禁用，新添加的按钮应在此处处理Enable
        /// </summary>
        /// <param name="status">按钮可用性</param>
        private void SetButtonEnable(Boolean status)
        {
            btSend.Enabled = status;
            btSendCommand.Enabled = status;
        }

        private void WriteParameter_Load(object sender, EventArgs e)
        {
            SetButtonEnable(false);
            Panel p = new Panel();
            this.Parent.Controls.Add(p);
            p.Controls.Add(this);
            this.Dock = DockStyle.Fill;
            p.Dock = DockStyle.Fill;
            p.BringToFront();
            Int32 i = 0;
            foreach (var item in AIMasters)
            {
                item.prePb = item.camera.showImagePanel;
                PictureBox pb = new PictureBox();
                pb.Location = new Point(0 + (i++ * 330), 40);
                pb.BackColor = Color.DarkGray;
                pb.Size = new Size(320, 256);
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                lock (item.camera.showImagePanel)
                {
                    item.camera.showImagePanel = pb;
                }
                this.Controls.Add(pb);
                RegisterControl(pb);
            }
            gbControlBox.Text = AIMasters[0].camera.CameraIP;
            ip = gbControlBox.Text;
        }

        #region 控件拖动缩放
        private void RegisterControl(Control control)
        {
            control.MouseDown += new MouseEventHandler(Control_MouseDown);
            control.MouseUp += new MouseEventHandler(Control_MouseUp);
            control.MouseMove += new MouseEventHandler(Control_MouseMove);
            control.MouseWheel += new MouseEventHandler(Control_MouseWheel);
        }

        Boolean isPress = false;
        Int32 x, y;
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

        private void btClose_Click(object sender, EventArgs e)
        {
            foreach (var item in AIMasters)
            {
                item.camera.showImagePanel = item.prePb;
            }
            if (myTcp.ConnectStatus())
            {
                myTcp.disconnect();
            }
            this.Parent.Dispose();
        }


        private void btSendCommand_Click(object sender, EventArgs e)
        {
            SetButtonEnable(false);
            new Thread(t =>
            {
                if (!myTcp.ConnectStatus())
                {
                    Print("正在尝试TCP重连...");
                    if (myTcp.connect())
                    {
                        Print("TCP重连成功！");
                    }
                    else
                    {
                        Print("TCP连接异常！请重新连接！！！");
                        SetButtonEnable(true);
                        return;
                    }
                }
                //发送指令用法 response为返回值
                String response = myTcp.communicate_extended_ack(tbInputCommad.Text);
                while (response.Length < "OKcomplete".Length - 1)
                {
                    Thread.Sleep(200);
                    response = myTcp.communicate_extended_ack(tbInputCommad.Text);
                }
                Print(response);
                SetButtonEnable(true);
                Thread.Sleep(500);
            }).Start();
        }

    }
}
