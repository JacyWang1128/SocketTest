using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EVT;

namespace eyeview_eyecontrol
{
    public partial class eyeview_eyecontrol : Form
    {
        PCONLAN_TCP eyecontrol = new PCONLAN_TCP();
        ExecuteEyeVision launcher = new ExecuteEyeVision("EyeVision.exe");
        stringRcv globalString = new stringRcv();

        public eyeview_eyecontrol()
        {
            InitializeComponent();
            globalString.init(tb_gs);
            reset();
        }

        private void btn_exec_Click(object sender, EventArgs e)
        {
            if (btn_exec.Text == "exec")
            {
                if (0 != launcher.launchEyeVision())
                {
                    return;
                }
                btn_exec.Text = "kill";
            }
            else
            {
                launcher.killEyeVision();
                btn_exec.Text = "exec";
            }
        }
        private void reset()
        {
            tb_ev1.Text = "127.0.0.1:1000";
            tb_ev2.Text = "127.0.0.10:1000";
            tb_ec_addr.Text = "127.0.0.1:5953";
            tb_cmd1.Text = "#001transfer_mix_gs.ckp#";
            tb_cmd2.Text = "#034;4#";
            tb_cmd3.Text = "";
            tb_cmd4.Text = "";
        }

        private void btn_ec_connect_Click(object sender, EventArgs e)
        {
            if (btn_ec_connect.Text == "connect")
            {
                char[] d = { ':' };
                string ip = "127.0.0.1";
                int port = 5953;
                string[] addr = tb_ec_addr.Text.Split(d);
                if (addr.Length == 2)
                {
                    ip = addr[0];
                    port = Convert.ToInt32(addr[1]);
                }
                if (eyecontrol.connect(ip, port))
                {
                    btn_ec_connect.Text = "disconnect";
                }
            }
            else
            {
                eyecontrol.disconnect();
                btn_ec_connect.Text = "connect";
            }
        }

        private void btn_ec_start_Click(object sender, EventArgs e)
        {
            eyecontrol.start();
        }

        private void btn_ec_stop_Click(object sender, EventArgs e)
        {
            eyecontrol.stop();
        }

        private void btn_ec_once_Click(object sender, EventArgs e)
        {
            eyecontrol.execute_cycles(1);
        }

        private void btn_ev_hide_Click(object sender, EventArgs e)
        {
            if (btn_ec_hide.Text == "hide")
            {
                string msg = "#034;16#";
                eyecontrol.communicate_normal_ack(msg);
                btn_ec_hide.Text = "show";
            }
            else
            {
                string msg = "#034;0#";
                eyecontrol.communicate_normal_ack(msg);
                btn_ec_hide.Text = "hide";
            }
        }

        private void btn_ev_start_Click(object sender, EventArgs e)
        {
            if (btn_ev_start.Text == "start")
            {
                long lResult = EyeView.EVInitEyeVisionSubsystem((IntPtr)0);

                int shmCount = 2;
                int shmImgSize = 2000 * 2000;
                EyeView.EVInitializeSharedMemory(shmCount, shmImgSize);

                EyeView.EVInitImgRecvVars();

                if (tb_ev1.Text.Length > 7)
                {
                    string addr = tb_ev1.Text + (char)0;
                    EyeView.EVAddCameraDisplay(
                            this.pb1.Handle,
                            addr,
                            1,
                            0,
                            this.pb1.Width,
                            this.pb1.Height,
                            20000,
                            1);
                }
                if (tb_ev2.Text.Length > 7)
                {
                    string addr = tb_ev2.Text + (char)0;
                    EyeView.EVAddCameraDisplay(
                            this.pb2.Handle,
                            addr,
                            2,
                            0,
                            this.pb2.Width,
                            this.pb2.Height,
                            20000,
                            1);
                }

                EyeView.EVSetParLong((int)IMG_RECV_PAR.IMG_RECV_PAR_SEND_UDP_ACKNOWLEDGEMENT, 1);

                // Set local port number EyeView is listening on.
                int port = 4557;
                EyeView.EVSetParLong((int)IMG_RECV_PAR.IMG_RECV_PAR_PORT_ADDRESS, port);
                EyeView.EVStartImgRecvThread();
                btn_ev_start.Text = "stop";
            }
            else
            {
                EyeView.EVStopImgRecvThread();
                EyeView.EVDeinitEyeVisionSubsystem();
                btn_ev_start.Text = "start";
            }

        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            System.IO.StreamWriter file =
                new System.IO.StreamWriter("eyeview_eyecontrol_config.txt");
            file.WriteLine(tb_ev1.Text);
            file.WriteLine(tb_ev2.Text);
            file.WriteLine(tb_ec_addr.Text);
            file.WriteLine(tb_cmd1.Text);
            file.WriteLine(tb_cmd2.Text);
            file.WriteLine(tb_cmd3.Text);
            file.WriteLine(tb_cmd4.Text);
            file.Close();
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            System.IO.StreamReader file =
                new System.IO.StreamReader("eyeview_eyecontrol_config.txt");
            tb_ev1.Text = file.ReadLine();
            tb_ev2.Text = file.ReadLine();
            tb_ec_addr.Text = file.ReadLine();
            tb_cmd1.Text = file.ReadLine();
            tb_cmd2.Text = file.ReadLine();
            tb_cmd3.Text = file.ReadLine();
            tb_cmd4.Text = file.ReadLine();
            file.Close();

        }

        private void btn_send1_Click(object sender, EventArgs e)
        {
            eyecontrol.communicate_normal_ack(tb_cmd1.Text);
        }

        private void btn_send2_Click(object sender, EventArgs e)
        {
            eyecontrol.communicate_normal_ack(tb_cmd2.Text);
        }
        private void btn_send3_Click(object sender, EventArgs e)
        {
            eyecontrol.communicate_normal_ack(tb_cmd3.Text);
        }
        private void btn_send4_Click(object sender, EventArgs e)
        {
            eyecontrol.communicate_normal_ack(tb_cmd4.Text);
        }

        private void btn_gs_start_Click(object sender, EventArgs e)
        {
            if (btn_gs_start.Text == "start")
            {
                globalString.start();
                btn_gs_start.Text = "stop";
            }
            else
            {
                globalString.stop();
                btn_gs_start.Text = "start";
            }
        }
    }
}
