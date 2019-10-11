using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SocketImageAnalysiser
{
    public partial class MainForm : Form
    {
        MessageHandle msgh;
        UdpHelper uh;
        public MainForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void AppendText(String text)
        {
            rtbConsole.AppendText($"{text}\r\n");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            msgh = new MessageHandle(AppendText);
        }

        private void btStartListening_Click(object sender, EventArgs e)
        {
            //Thread t = new Thread()
            uh = new UdpHelper(msgh);
            Thread t = new Thread(uh.ListeningPort);
            t.Start(nudPort.Value);
        }

        private void btStopListening_Click(object sender, EventArgs e)
        {
            uh.StopListening();
        }
    }
}
