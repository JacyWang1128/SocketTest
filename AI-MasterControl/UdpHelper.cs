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

        public Queue<Byte[]> UdpPackageBuffer;//解析包共享队列

        public Queue<Byte[]> tempUdpPackageBuffer;//

        private UdpClient udpClient;

        public VCZcamera camera;

        MessageHandle msgh;

        public UdpHelper(MessageHandle msgh, VCZcamera camera)
        {
            UdpPackageBuffer = new Queue<byte[]>();
            tempUdpPackageBuffer = new Queue<byte[]>();
            this.msgh = msgh;
            this.camera = camera;
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

        public void StopListening()
        {
            IsReceive = false;
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
                        if(1 == iPackageNum)
                        {
                            Console.WriteLine((sw.Elapsed - ts).ToString());
                            ts = sw.Elapsed;
                        }
                        var content = System.Text.Encoding.Default.GetBytes($"{iImgNum}_{iPackageNum}OK");
                        udpClient.Send(content, content.Length, remote.Address.ToString(), remote.Port);
                        UdpPackageBuffer.Enqueue(package);
                    }
                }
                Thread.Sleep(1);
                //CommonHelper.Delay(1);
            }
        }

        public void ListeningPort(Object iport)
        {
            try
            {
                Thread t = new Thread(SendReceive);
                t.Priority = ThreadPriority.Lowest;
                t.Start();
                Int32 port = Convert.ToInt32(iport);
                IsReceive = true;
                //在本机指定的端口接收
                udpClient = new UdpClient(port);
                remote = null;
                sw.Start();
                while (_isReceive)
                {
                    try
                    {
                        if (udpClient.Available > 0)
                        {

                            ts = sw.Elapsed;
                            byte[] bytes = udpClient.Receive(ref remote);
                            tempUdpPackageBuffer.Enqueue(bytes);
                            //udpClient.Client.Listen(port);
                            //udpClient.Client.BeginReceive(udpbuffer,0,udpbuffer.Length, SocketFlags.None, new AsyncCallback(ReceiveHandler),null);
                            //TimeSpan rects = sw.Elapsed - ts;
                            //ts = sw.Elapsed;
                            //Console.WriteLine(rects.ToString());
                            //if (remote.Address.ToString() == camera.CameraIP)
                            //{
                            //    Int32 iImgNum = BitConverter.ToInt32(bytes, 4);
                            //    Int16 iPackageNum = BitConverter.ToInt16(bytes, 0);
                            //    var content = System.Text.Encoding.Default.GetBytes($"{iImgNum}_{iPackageNum}OK");
                            //    udpClient.Send(content, content.Length, remote.Address.ToString(), remote.Port);
                            //    TimeSpan sendts = sw.Elapsed - ts;
                            //    Console.WriteLine(sendts.ToString());
                            //    UdpPackageBuffer.Enqueue(bytes);
                            //}
                            //msgh($"收到：{iImgNum}_{iPackageNum},已回复");
                        }
                    }
                    catch (Exception ex)
                    {
                        LoggHelper.WriteLog("UDP接收错误", ex);
                    }
                    
                    Thread.Sleep(1);
                    //CommonHelper.Delay(1);
                    
                }
                udpClient.Close();
            }
            catch (Exception ex)
            {

            }
            //msgh("结束监听！");
        }
    }
}
