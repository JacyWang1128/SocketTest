using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;

namespace AI_Master_SharedMemory
{
    public delegate void CloseHandler();
    public partial class WriteParameter : UserControl
    {
        PCONLAN_TCP myTcp;
        String addr;
        CloseHandler clh;
        Boolean isStart = false;
        public WriteParameter(String addr,CloseHandler clh)
        {
            InitializeComponent();
            myTcp = new PCONLAN_TCP();
            this.addr = addr;
            this.clh = clh;
            btConnect.BackColor = Color.Pink;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            if (myTcp.ConnectStatus())
            {
                myTcp.disconnect();
            }
            StopReceiveAIMaster();
            clh();
            this.Parent.Dispose();
            this.Dispose();
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
            AiMaster.EVAddCameraDisplay(pbWindow.Handle,
                   addr,
                   1,
                   0,
                   pbWindow.Width,
                   pbWindow.Height,
                   20000,
                   1);
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

        private void WriteParameter_Load(object sender, EventArgs e)
        {
            tbHeight.Text = pbWindow.Height.ToString();
            tbWidth.Text = pbWindow.Width.ToString();
            tbY.Text = pbWindow.Location.Y.ToString();
            tbX.Text = pbWindow.Location.X.ToString();
            InitAIMaster();
            StartReceiveAIMaster();
        }

        private void btChange_Click(object sender, EventArgs e)
        {
            StopReceiveAIMaster();
            try
            {
                pbWindow.Width = Convert.ToInt32(tbWidth.Text);
                pbWindow.Height = Convert.ToInt32(tbHeight.Text);
                pbWindow.Location = new Point(Convert.ToInt32(tbX.Text), Convert.ToInt32(tbY.Text));
            }
            catch (Exception)
            {
                MessageBox.Show("请输入合理数值！");
            }
            InitAIMaster();
            StartReceiveAIMaster();
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
                    if (IPAddress.TryParse("127.0.0.1", out ip))
                    {
                        Boolean result = myTcp.connect("127.0.0.1", (Int32)nudPortNumber.Value);
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
                new Thread(t =>
                {
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

        
    }
}
