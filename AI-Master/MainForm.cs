using AI_MasterControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace AI_Master
{
    public partial class MainForm : Form
    {
        Dictionary<TreeNode, AIMaster> dicTreeNode;
        public MainForm()
        {
            InitializeComponent();
            //this.WindowState = FormWindowState.Maximized;
            //this.FormBorderStyle = FormBorderStyle.None;
            treeView1.ImageList = ilTreeViewIconList;
            dicTreeNode = new Dictionary<TreeNode, AIMaster>();
            timer1.Start();
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

        public Int32 GEtIndexIntreeview(TreeNodeCollection tnc, String text)
        {
            for (int i = 0; i < tnc.Count; i++)
            {
                if (tnc[i].Text == text)
                {
                    return i;
                }
            }
            return -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AIMaster ai = new AIMaster();
            AI_MasterControl.AddCamera adc = new AI_MasterControl.AddCamera(ai.cameraSetting, ai.aceh, "添加相机");
            if (DialogResult.OK == adc.ShowDialog())
            {
                plMiddle.Controls.Add(ai);
                TreeNode ctn = new TreeNode("Port:" + ai.camera.Port, 0, 0);
                Int32 flag = GEtIndexIntreeview(treeView1.Nodes, ai.camera.CameraIP);
                if (flag < 0)
                {
                    TreeNode tn = new TreeNode(ai.camera.CameraIP, 1, 1);
                    treeView1.Nodes.Add(tn);
                }
                Int32 Index = GEtIndexIntreeview(treeView1.Nodes, ai.camera.CameraIP);
                treeView1.Nodes[Index].Nodes.Add(ctn);
                dicTreeNode[ctn] = ai;
                treeView1.ExpandAll();
                treeView1.SelectedNode = treeView1.Nodes[treeView1.Nodes.Count - 1];
            }
            else
            {
                ai.Dispose();
            }
            Write_Config();
            treeView1.Select();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                if (treeView1.SelectedNode.Level != 0)
                {
                    dicTreeNode[treeView1.SelectedNode].Dispose();
                    dicTreeNode.Remove(treeView1.SelectedNode);
                }
                else
                {
                    foreach (TreeNode item in treeView1.SelectedNode.Nodes)
                    {
                        dicTreeNode[item].Dispose();
                        dicTreeNode.Remove(item);
                    }
                }
                treeView1.SelectedNode.Remove();
                treeView1.Select();
                Write_Config();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //dataGridView1.Rows.Clear();
            Int32 rowsCount = dataGridView1.Rows.Count;
            foreach (var item in dicTreeNode)
            {
                SetCameraInfo(item.Value.camera.camInfo);
                item.Key.Text = String.IsNullOrEmpty(item.Value.camera.CameraName) ? "Port:" + item.Value.camera.Port : item.Value.camera.CameraName + " port:" + item.Value.camera.Port;
            }
            for (int i = 0; i < rowsCount - 1; i++)
            {
                try
                {
                    dataGridView1.Rows.RemoveAt(0);
                }
                catch (Exception)
                {

                }
            }
            dataGridView1.ClearSelection();
        }

        private void SetCameraInfo(CameraInfo caminfo)
        {
            if (caminfo.CameraIp == "0.0.0.0")
            {
                return;
            }
            //foreach (DataGridViewRow item in dataGridView1.Rows)
            //{
            //    if (item.Cells[0].Value != null)
            //    {
            //        if (item.Cells[0].Value.ToString() == caminfo.CameraIp)
            //        {
            //            item.Cells[0].Value = caminfo.CameraIp;
            //            item.Cells[1].Value = caminfo.CameraName;
            //            item.Cells[2].Value = caminfo.RoiWidth;
            //            item.Cells[3].Value = caminfo.RoiHeight;
            //            item.Cells[4].Value = caminfo.RoiX;
            //            item.Cells[5].Value = caminfo.RoiY;
            //            item.Cells[6].Value = caminfo.GoodCount;
            //            item.Cells[7].Value = caminfo.BadCount;
            //            item.Cells[8].Value = caminfo.CycleTime;
            //            return;
            //        }
            //    }
            //}
            Int32 Index = dataGridView1.Rows.Add();
            dataGridView1.Rows[Index].Cells[0].Value = caminfo.CameraIp;
            dataGridView1.Rows[Index].Cells[1].Value = caminfo.CameraName;
            dataGridView1.Rows[Index].Cells[2].Value = caminfo.RoiWidth;
            dataGridView1.Rows[Index].Cells[3].Value = caminfo.RoiHeight;
            dataGridView1.Rows[Index].Cells[4].Value = caminfo.RoiX;
            dataGridView1.Rows[Index].Cells[5].Value = caminfo.RoiY;
            dataGridView1.Rows[Index].Cells[6].Value = caminfo.GoodCount;
            dataGridView1.Rows[Index].Cells[7].Value = caminfo.BadCount;
            dataGridView1.Rows[Index].Cells[8].Value = caminfo.CycleTime;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                if (treeView1.SelectedNode.Level > 0)
                {
                    dicTreeNode[treeView1.SelectedNode].SetCamera();
                    //treeView1.SelectedNode.Text = dicTreeNode[treeView1.SelectedNode].camera.CameraIP;
                    treeView1.SelectedNode = treeView1.SelectedNode;
                    treeView1.Select();
                    if (treeView1.SelectedNode.Parent.Text != dicTreeNode[treeView1.SelectedNode].camera.CameraIP)
                    {
                        TreeNode currentTreeNode = treeView1.SelectedNode;
                        Int32 Index = GEtIndexIntreeview(treeView1.Nodes, dicTreeNode[treeView1.SelectedNode].camera.CameraIP);
                        var OriginalTreeNode = treeView1.SelectedNode.Parent;
                        OriginalTreeNode.Nodes.Remove(currentTreeNode);
                        if (Index < 0)
                        {
                            TreeNode tn = new TreeNode(dicTreeNode[currentTreeNode].camera.CameraIP, 1, 1);
                            treeView1.Nodes.Add(tn);
                            tn.Nodes.Add(currentTreeNode);
                        }
                        else
                        {
                            treeView1.Nodes[Index].Nodes.Add(currentTreeNode);
                        }
                        if (OriginalTreeNode.Nodes.Count == 1)
                        {
                            treeView1.Nodes.Remove(OriginalTreeNode);
                        }
                    }
                    Write_Config();
                    treeView1.ExpandAll();
                }
                else
                {
                    if (treeView1.SelectedNode.Nodes.Count > 0)
                    {
                        List<AIMaster> aimasters = new List<AIMaster>();
                        foreach (TreeNode item in treeView1.SelectedNode.Nodes)
                        {
                            aimasters.Add(dicTreeNode[item]);
                        }
                        WriteParameter wp = new WriteParameter(aimasters.ToArray());
                        this.Controls.Add(wp);
                    }
                }
            }
        }

        private void Write_Config()
        {
            List<CameraSettings> lst = new List<CameraSettings>();
            foreach (var item in dicTreeNode)
            {
                lst.Add(item.Value.cameraSetting);
            }
            ReadConfig.SaveConfig(lst.ToArray());
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var item in dicTreeNode)
            {
                if (item.Value.camera.isReceiving)
                {
                    item.Value.camera.Stop();
                    item.Value.camera.isReceiving = false;
                }
            }
            //Write_Config();
            LoggHelper.WriteLog("程序正常退出！");
            Environment.Exit(0);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ReplaceButton();
            button7.BackgroundImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
            button8.BackgroundImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            splitContainer2.SplitterDistance = splitContainer1.Width;
            if (ReadConfig.ExistConfigFile())
            {
                try
                {
                    var Settings = ReadConfig.GetConfig();
                    foreach (var item in Settings)
                    {
                        AIMaster ai = new AIMaster();
                        ai.cameraSetting = item;
                        ai.SetCamera(item);
                        Directory.CreateDirectory(item.PreString.Substring(0, item.PreString.LastIndexOf(@"\") + 1));
                        if (item.PreStringNG != null)
                            Directory.CreateDirectory(item.PreStringNG.Substring(0, item.PreStringNG.LastIndexOf(@"\") + 1));
                        if (item.PreStringOK != null)
                            Directory.CreateDirectory(item.PreStringOK.Substring(0, item.PreStringOK.LastIndexOf(@"\") + 1));
                        if (item.PreStringWarning != null)
                            Directory.CreateDirectory(item.PreStringWarning.Substring(0, item.PreStringWarning.LastIndexOf(@"\") + 1));
                        Int32 Index = GEtIndexIntreeview(treeView1.Nodes, ai.camera.CameraIP);
                        TreeNode ctn = new TreeNode("Port:" + ai.camera.Port, 0, 0);
                        if (Index < 0)
                        {
                            TreeNode tn = new TreeNode(ai.camera.CameraIP, 1, 1);
                            tn.Nodes.Add(ctn);
                            treeView1.Nodes.Add(tn);
                        }
                        else
                        {
                            treeView1.Nodes[Index].Nodes.Add(ctn);
                        }
                        dicTreeNode[ctn] = ai;
                        plMiddle.Controls.Add(ai);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("读取配置文件失败");
                }
            }
            treeView1.ExpandAll();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                splitContainer2.SplitterDistance = splitContainer1.Width;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void splitContainer2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("测试到啦！");
        }

        Int32 originalSplitContainer1Width;
        Int32 originalplBottomHeight;

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            ReplaceButton();
        }

        private void ReplaceButton()
        {
            plMiddle.AutoScroll = false;
            button7.BringToFront();
            splitContainer2.SplitterDistance = splitContainer3.SplitterDistance;
            button8.Location = new Point((button8.Parent.Width - button8.Width) / 2, /*splitContainer4.SplitterDistance*/button8.Parent.Height - button8.Height);
            button7.Location = new Point(0, (splitContainer4.SplitterDistance - button7.Height) / 2);
            //dataGridView1.Height = plBottom.Height - button8.Height;
            plMiddle.AutoScroll = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            splitContainer3.Panel1Collapsed = !splitContainer3.Panel1Collapsed;
            splitContainer2.Panel1Collapsed = !splitContainer2.Panel1Collapsed;
            button7.BackgroundImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
            ReplaceButton();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            splitContainer4.Panel2Collapsed = !splitContainer4.Panel2Collapsed;
            button8.BackgroundImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
            ReplaceButton();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            button2_Click(null, e);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            button1.PerformClick();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            button3.PerformClick();
        }

        private void splitContainer3_SplitterMoved(object sender, SplitterEventArgs e)
        {
            ReplaceButton();
        }

        private void splitContainer4_SplitterMoved(object sender, SplitterEventArgs e)
        {
            ReplaceButton();
        }
    }
}
