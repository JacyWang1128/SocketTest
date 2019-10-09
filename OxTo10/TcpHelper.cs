using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace OxTo10
{
    public class TcpHelper
    {
        public delegate void ErrorMethod(String error);

        TcpClient m_client;
        NetworkStream m_nwStream;
        String m_lastError;
        ErrorMethod em;

        ~TcpHelper()
        {
            em = null;
        }

        public void SetLastError(String content)
        {
            m_lastError = "错误：" + content;
            em(m_lastError);
        }
        

        public Boolean connect(String ip,Int32 port)
        {
            try
            {
                m_client = new TcpClient(ip,port);
                m_nwStream = m_client.GetStream();
                m_nwStream.ReadTimeout = 2000;
            }
            catch (Exception e)
            {
                SetLastError(e.Message);
                return false;
            }
            return true;
        }

        public bool disconnect()
        {
            try
            {
                m_client.Close();
                return true;
            }
            catch (Exception e)
            {
                SetLastError(e.Message);
                return false;
            }
        }

        public bool communicate_extended_ack(string message)
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
                return false;
            }

            //---read back the text---
            string received = "";
            try
            {
                while ((received != "OKcompleted") && (received != "OKfailed"))
                {
                    byte[] bytesToRead = new byte[m_client.ReceiveBufferSize];
                    int bytesRead = m_nwStream.Read(bytesToRead, 0, m_client.ReceiveBufferSize);
                    received += Encoding.ASCII.GetString(bytesToRead, 0, bytesRead);
                }
                Console.WriteLine("Received : " + received);
                if (received == "OKcompleted")
                {
                    return true;
                }
                else
                {
                    m_lastError = received;
                    return false;
                }

            }
            catch (Exception e)
            {
                m_lastError = e.ToString();
                return false;
            }
        }
    }
}
