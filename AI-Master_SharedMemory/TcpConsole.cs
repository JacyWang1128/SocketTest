using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AI_Master_SharedMemory
{
    public partial class TcpConsole : Form
    {
        PCONLAN_TCP myTcp = new PCONLAN_TCP();

        public TcpConsole()
        {
            InitializeComponent();
            btConnect.BackColor = Color.Pink;
            btSend.Enabled = false;

            //是否显示控制台 true 显示； false 隐藏
            rtbConsole.Visible = true;
        }

        private void Print(String message)
        {
            //控制台输出
            rtbConsole.AppendText(message + "\r\n");
        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            //连接逻辑
            if (btConnect.Text == "连接")
            {
                IPAddress ip;
                if (IPAddress.TryParse(tbIPAddress.Text, out ip))
                {
                    Boolean result = myTcp.connect(tbIPAddress.Text, (Int32)nudPortNumber.Value);
                    if (result)
                    {
                        btConnect.Text = "断开";
                        btConnect.BackColor = Color.LightGreen;
                        Print("TCP已连接");
                        btSend.Enabled = true;
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
            }
            else
            {
                Boolean result = myTcp.disconnect();
                if (result)
                {
                    btConnect.Text = "连接";
                    btConnect.BackColor = Color.Pink;
                    Print("已断开连接");
                    btSend.Enabled = false;
                }
                else
                {
                    Print("断开失败！");
                }
            }
        }

        private void btSend_Click(object sender, EventArgs e)
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
                }
                return;
            }

            //发送指令用法 response为返回值
            String response = myTcp.communicate_extended_ack(tbInput.Text);
            while (response.Length < "OKcomplete".Length - 1)
            {
                Thread.Sleep(200);
                response = myTcp.communicate_extended_ack(tbInput.Text);
            }
            Print(response);
            //发送指令结束
        }

        private void TcpConsole_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (myTcp.ConnectStatus())
            {
                myTcp.disconnect();
            }
        }
    }
}
