using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace AI_MasterControl
{
    public class UdpHelper
    {
        private Boolean _isReceive = true;

        public Queue<List<Byte[]>> UdpPackageBuffer;//解析包共享队列

        public Queue<Byte[]> tempUdpPackageBuffer;//

        public List<Byte[]> tempUdpBuffer;//每张图片完整包的缓存

        private UdpClient udpClient;

        public VCZcamera camera;

        MessageHandle msgh;

        

        public UdpHelper(MessageHandle msgh, VCZcamera camera)
        {
            udpClient = null;
            UdpPackageBuffer = new Queue<List<byte[]>>();
            tempUdpPackageBuffer = new Queue<byte[]>();
            tempUdpBuffer = new List<byte[]>();
            this.msgh = msgh;
            this.camera = camera;
            //Thread t = new Thread(ShowSocketStatus);
            //t.Priority = ThreadPriority.Lowest;
            //t.Start();
        }

        public bool IsReceive
        {
            get
            {
                return _isReceive;
            }

            set
            {
                _isReceive = value;
            }
        }

        public void CreateListening()
        {
            if(port != 0)
            {
                StopListening();
                Thread.Sleep(500);
                ListeningPort(port);
            }
        }

        public void StopListening()
        {
            IsReceive = false;
            s = null;
            if (udpClient != null)
            {
                udpClient.Close();
            }
            GC.Collect();
            udpClient = null;
        }
        //public void ReceiveHandler(IAsyncResult ar)
        //{
        //    Int32 iImgNum = BitConverter.ToInt32(udpbuffer, 4);
        //    Int16 iPackageNum = BitConverter.ToInt16(udpbuffer, 0);
        //    var content = System.Text.Encoding.Default.GetBytes($"{iImgNum}_{iPackageNum}OK");
        //    udpClient.Send(content, content.Length, udpClient.Address.ToString(), remote.Port);
        //    //TimeSpan sendts = sw.Elapsed - ts;
        //    //Console.WriteLine(sendts.ToString());
        //    UdpPackageBuffer.Enqueue(udpbuffer);
        //}
        public Stopwatch sw = new Stopwatch();

        TimeSpan ts;
        Byte[] udpbuffer = new byte[50000];
        IPEndPoint remote;
        #region 老方法
        public void SendReceive()
        {
            ts = sw.Elapsed;
            while (_isReceive)
            {
                if (tempUdpPackageBuffer.Count > 0)
                {
                    Byte[] package = tempUdpPackageBuffer.Dequeue();
                    if (remote.Address.ToString() == camera.CameraIP)
                    {
                        Int32 iImgNum = BitConverter.ToInt32(package, 4);
                        Int16 iPackageNum = BitConverter.ToInt16(package, 0);
                        if (1 == iPackageNum)
                        {
                            Console.WriteLine((sw.Elapsed - ts).ToString());
                            ts = sw.Elapsed;
                        }
                        var content = System.Text.Encoding.Default.GetBytes(iImgNum + "_" + iPackageNum + "OK");
                        udpClient.Send(content, content.Length, remote.Address.ToString(), remote.Port);
                        tempUdpBuffer.Add(package);
                    }
                }
                Thread.Sleep(1);
                //CommonHelper.Delay(1);
            }
        }
        #endregion

        Int32 packagecount = 0;
        Int32 packageTotal = 0;
        Int32 lastPackagenum = 0;

        public void Receive(IAsyncResult ar)
        {
            UdpState s = ar.AsyncState as UdpState;
            UdpClient udpc = s.UdpClient;
            try
            {
                if (s != null)
                {
                    IPEndPoint ip = s.IP;
                    Byte[] package = udpc.EndReceive(ar, ref ip);
                    if (ip.Address.ToString() == camera.CameraIP)
                    {
                        Int32 iImgNum = BitConverter.ToInt32(package, 4);
                        Int16 iPackageNum = BitConverter.ToInt16(package, 0);
                        var content = System.Text.Encoding.Default.GetBytes(iImgNum+"_"+iPackageNum+"OK");
                        udpClient.Send(content, content.Length, ip.Address.ToString(), ip.Port);
                        //if (UdpPackageBuffer.Count > 10)
                        //{
                        //    Int32 count = UdpPackageBuffer.Count;
                        //    while (count > 10)
                        //    {
                        //        UdpPackageBuffer.Dequeue();
                        //        count = UdpPackageBuffer.Count;
                        //    }
                        //}
                        if (1 == iPackageNum)
                        {
                            packagecount = 0;
                            tempUdpBuffer.Clear();
                            Int32 iPackageCount = (Int32)BitConverter.ToInt16(package, 2);
                            Int32 overlaycount = BitConverter.ToInt32(package, 8);
                            packageTotal = 1 + iPackageCount + overlaycount;
                        }
                        if (lastPackagenum != iPackageNum)
                        {
                            packagecount++;
                        }
                        tempUdpBuffer.Add(package);
                        lastPackagenum = iImgNum;
                        if (packagecount == packageTotal)
                        {
                            UdpPackageBuffer.Enqueue(new List<Byte[]>(tempUdpBuffer));
                        }
                    }
                    if (_isReceive)
                    {
                        udpc.BeginReceive(Receive, s);
                    }
                }
            }
            catch (Exception)
            {

                camera.Stop();
                Thread.Sleep(10);
                if (camera.isReceiving)
                {
                    camera.Start();
                }
            }
        }

        Int32 port = 0;
        UdpState s;
        public void ShowSocketStatus()
        {
            while (true)
            {
                if (udpClient != null)
                    Console.WriteLine("UDP状态："+udpClient.Client.Connected);
                Thread.Sleep(500);
            }
        }

        public void test()
        {
            udpClient.BeginReceive(Receive, s);
        }

        public void ListeningPort(Object iport)
        {
            try
            {
                port = Convert.ToInt32(iport);
                IsReceive = true;
                //在本机指定的端口接收
                udpClient = new UdpClient(port);
                udpClient.Client.ReceiveTimeout = 500000;
                remote = null;
                s = new UdpState(udpClient, remote);
                udpClient.BeginReceive(Receive, s);
                //while (_isReceive)
                //{
                //    try
                //    {
                //        if (udpClient.Available > 0)
                //        {

                //            ts = sw.Elapsed;
                //            byte[] bytes = udpClient.Receive(ref remote);
                //            tempUdpPackageBuffer.Enqueue(bytes);
                //            //udpClient.Client.Listen(port);
                //            //udpClient.Client.BeginReceive(udpbuffer,0,udpbuffer.Length, SocketFlags.None, new AsyncCallback(ReceiveHandler),null);
                //            //TimeSpan rects = sw.Elapsed - ts;
                //            //ts = sw.Elapsed;
                //            //Console.WriteLine(rects.ToString());
                //            //if (remote.Address.ToString() == camera.CameraIP)
                //            //{
                //            //    Int32 iImgNum = BitConverter.ToInt32(bytes, 4);
                //            //    Int16 iPackageNum = BitConverter.ToInt16(bytes, 0);
                //            //    var content = System.Text.Encoding.Default.GetBytes($"{iImgNum}_{iPackageNum}OK");
                //            //    udpClient.Send(content, content.Length, remote.Address.ToString(), remote.Port);
                //            //    TimeSpan sendts = sw.Elapsed - ts;
                //            //    Console.WriteLine(sendts.ToString());
                //            //    UdpPackageBuffer.Enqueue(bytes);
                //            //}
                //            //msgh($"收到：{iImgNum}_{iPackageNum},已回复");
                //        }
                //    }
                //    catch (Exception ex)
                //    {
                //        LoggHelper.WriteLog("UDP接收错误", ex);
                //    }

                //    Thread.Sleep(1);
                //    //CommonHelper.Delay(1);

                //}
                //udpClient.Close();
            }
            catch (Exception ex)
            {

            }
            //msgh("结束监听！");
        }
    }
    public class UdpState
    {
        private UdpClient udpclient = null;

        public UdpClient UdpClient
        {
            get { return udpclient; }
        }

        private IPEndPoint ip;

        public IPEndPoint IP
        {
            get { return ip; }
        }

        public UdpState(UdpClient udpclient, IPEndPoint ip)
        {
            this.udpclient = udpclient;
            this.ip = ip;
        }
    }
}
