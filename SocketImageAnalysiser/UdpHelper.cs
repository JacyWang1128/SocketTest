using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketImageAnalysiser
{
    public class UdpHelper
    {
        private Boolean _isReceive = true;

        public Queue<Byte[]> UdpPackageBuffer;//解析包共享队列

        private UdpClient udpClient;

        MessageHandle msgh;

        public UdpHelper(MessageHandle msgh = null)
        {
            UdpPackageBuffer = new Queue<byte[]>();
            if (msgh != null)
            {
                this.msgh = msgh;
                msgh("创建了一个udphelper");
            }
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
            msgh("结束监听！");
        }

        public void ListeningPort(Object iport)
        {
            try
            {
                Int32 port = Convert.ToInt32(iport);
                //在本机指定的端口接收
                msgh($"正在监听端口：{port}");
                udpClient = new UdpClient(port);
                IPEndPoint remote = null;
                while (_isReceive)
                {
                    try
                    {
                        if (udpClient.Available > 0)
                        {
                            //关闭udpClient时此句会产生异常
                            byte[] bytes = udpClient.Receive(ref remote);
                            Int32 iImgNum = BitConverter.ToInt32(bytes, 4);
                            Int16 iPackageNum = BitConverter.ToInt16(bytes, 0);
                            var content = System.Text.Encoding.Default.GetBytes($"{iImgNum}_{iPackageNum}OK");
                            udpClient.Send(content, content.Length, remote.Address.ToString(), remote.Port);
                            UdpPackageBuffer.Enqueue(bytes);
                            msgh($"收到：{iImgNum}_{iPackageNum},已回复");
                        }
                    }
                    catch (Exception ex)
                    {
                        if (msgh != null)
                            msgh(ex.Message);
                    }
                }
                udpClient.Close();
            }
            catch (Exception ex)
            {
                if (msgh != null)
                    msgh($"{ex.Message}\n监听已结束");
            }
        }
    }
}
