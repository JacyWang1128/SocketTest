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
        VCZcamera camera;
        public MainForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            rtbConsole.BackColor = Color.Black;
            rtbConsole.ForeColor = Color.LightGreen;
        }

        private void AppendText(String text)
        {
            try
            {
                rtbConsole.AppendText($"{text}\r\n");
            }
            catch (Exception)
            {

               // throw;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            msgh = new MessageHandle(AppendText);
            camera = new VCZcamera(msgh);
        }

        private void btStartListening_Click(object sender, EventArgs e)
        {
            camera.Start(Convert.ToInt32(nudPort.Value));
        }

        private void btStopListening_Click(object sender, EventArgs e)
        {
            camera.Stop();
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            rtbConsole.Clear();
        }
    }
}
