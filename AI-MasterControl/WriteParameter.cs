using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace AI_MasterControl
{
    public partial class WriteParameter : UserControl
    {
        public PCONLAN_TCP myTcp = null;
        //ip地址
        String ip = null;
        //端口号
        Int32 port = 5953;
        //Tcp状态
        Boolean isConnected = false;
        public WriteParameter(String IP,params AIMaster[] param)
        {
            InitializeComponent();
            myTcp = new PCONLAN_TCP();
            ip = IP;
        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                btConnect.Text = "断开";
                myTcp.disconnect();
            }
            else
            {
                btConnect.Text = "连接";
                myTcp.connect(ip, port);
            }
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            String message = String.IsNullOrEmpty(textBox1.Text) ? "#002#" : textBox1.Text;
            textBox2.Text = GetTcpRequest($"#029;1;Draw line.PointStart.Point.X#").Remove(0,"OKcompleted ".Length).Replace(',','.');
        }

        public String GetTcpRequest(String message)
        {
            String temp = myTcp.communicate_extended_ack(message);
            if (temp.Contains("OKcompleted"))
            {
                return temp;
            }
            else
            {
                temp = GetTcpRequest(message);
                return temp;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btSendCommand_Click(object sender, EventArgs e)
        {
            myTcp.communicate_normal_ack($"#030;1;Draw line.PointStart.Point.X;{textBox2.Text}#");
        }
    }
}
