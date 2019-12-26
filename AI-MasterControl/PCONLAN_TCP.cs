using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace AI_MasterControl
{
    public class PCONLAN_TCP
    {
        TcpClient m_client;
        NetworkStream m_nwStream;
        string m_lastError;

        public bool connect()
        {
            const int AIMASTER_PCONLAN_TCP_PORT = 5953;
            const string AIMASTER_IP = "127.0.0.1";
            return connect(AIMASTER_IP, AIMASTER_PCONLAN_TCP_PORT);
        }

        /// <summary>
        /// 连接Tcp服务器
        /// </summary>
        /// <param name="AIMasterIP">服务器IP地址</param>
        /// <param name="AIMasterPort">服务器端口号</param>
        /// <returns>true：连接成功；false：连接失败</returns>
        public bool connect(string AIMasterIP, int AIMasterPort)
        {
            try
            {
                m_client = new TcpClient(AIMasterIP, AIMasterPort);
                m_nwStream = m_client.GetStream();
                m_nwStream.ReadTimeout = 2000;
            }
            catch (Exception e)
            {
                m_lastError = e.ToString();
                return false;
            }
            return true;
        }

        /// <summary>
        /// 断开连接
        /// </summary>
        /// <returns>true：断开连接；false：断开出错</returns>
        public bool disconnect()
        {
            try
            {
                m_lastError = "";
                m_client.Close();
                return true;
            }
            catch (Exception e)
            {
                m_lastError = e.ToString();
                return false;
            }
        }

        /// <summary>
        /// 获得Tcp连接状态
        /// </summary>
        /// <returns>true：已连接；false：未连接</returns>
        public Boolean ConnectStatus()
        {
            try
            {
                return m_client.Connected;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public String start()
        {
            string message = "#002#";
            return communicate_extended_ack(message);
        }

        public String execute_cycles(int i)
        {
            string message = "#028" + i + "#";
            return communicate_extended_ack(message);
        }

        public String stop()
        {
            string message = "#003#";
            return communicate_extended_ack(message);
        }

        public String stop_immediately()
        {
            string message = "#004#";
            return communicate_extended_ack(message);
        }
        public String ping()
        {
            string message = "#008#";
            return communicate_extended_ack(message);
        }

        public String load_image(string imagepath)
        {
            string message = "#031" + imagepath + "#";
            return communicate_extended_ack(message);
        }

        public String exit_eyevision()
        {
            string message = "#999#";
            return communicate_extended_ack(message);
        }

        public String switchProgram(string programname)
        {
            string message = "#001" + programname + "#";
            return communicate_extended_ack(message);
        }

        public string getLastError()
        {
            return m_lastError;
        }

        /// <summary>
        /// 发送指令
        /// </summary>
        /// <param name="message">指令内容</param>
        /// <returns>服务器返回（若报错，返回报错内容）</returns>
        public String communicate_extended_ack(string message)
        {
            try
            {
                m_lastError = "";
                byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(message);

                //---send the text---
                Console.WriteLine("Sending : " + message);
                m_nwStream.Write(bytesToSend, 0, bytesToSend.Length);
            }
            catch (Exception e)
            {
                m_lastError = e.ToString();
                return m_lastError;
            }

            //---read back the text---
            string received = "";
            try
            {
                int bytesRead = 0;
                while (0 >= bytesRead/*(received != "OKcompleted") && (received != "OKfailed")*/)
                {
                    byte[] bytesToRead = new byte[m_client.ReceiveBufferSize];
                    bytesRead = m_nwStream.Read(bytesToRead, 0, m_client.ReceiveBufferSize);
                    received += Encoding.ASCII.GetString(bytesToRead, 0, bytesRead);
                }
                Console.WriteLine("Received : " + received);
                return received;

            }
            catch (Exception e)
            {
                m_lastError = e.ToString();
                return m_lastError;
            }
        }
    }
}
