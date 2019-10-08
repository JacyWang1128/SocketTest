using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace EVT
{
    class PCONLAN_TCP
    {
        TcpClient m_client;
        NetworkStream m_nwStream;
        string m_lastError;

        public bool connect()
        {
            const int EYEVISION_PCONLAN_TCP_PORT = 5953;
            const string EYEVISION_IP = "127.0.0.1";
            return connect(EYEVISION_IP, EYEVISION_PCONLAN_TCP_PORT);
        }

        public bool connect(string eyeVisionIP, int eyeVisionPort)
        {
            try
            {
                m_client = new TcpClient(eyeVisionIP, eyeVisionPort);
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

        public bool start()
        {
            string message = "#002#";
            return communicate_extended_ack(message);
        }

        public bool execute_cycles(int i)
        {
            string message = "#028" + i + "#";
            return communicate_extended_ack(message);
        }

        public bool stop()
        {
            string message = "#003#";
            return communicate_extended_ack(message);
        }

        public bool stop_immediately()
        {
            string message = "#004#";
            return communicate_extended_ack(message);
        }
        public bool ping()
        {
            string message = "#008#";
            return communicate_extended_ack(message);
        }

        public bool load_image(string imagepath)
        {
            string message = "#031" + imagepath + "#";
            return communicate_extended_ack(message);
        }

        public bool exit_eyevision()
        {
            string message = "#999#";
            return communicate_normal_ack(message);
        }

        public bool switchProgram(string programname)
        {
            string message = "#001" + programname + "#";
            return communicate_extended_ack(message);
        }

        public string getLastError()
        {
            return m_lastError;
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

        public bool communicate_normal_ack(string message)
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
            try
            {
                byte[] bytesToRead = new byte[m_client.ReceiveBufferSize];
                int bytesRead = m_nwStream.Read(bytesToRead, 0, m_client.ReceiveBufferSize);
                Console.WriteLine("Received : " + Encoding.ASCII.GetString(bytesToRead, 0, bytesRead));

                string received = Encoding.ASCII.GetString(bytesToRead, 0, bytesRead);
                if ( received != "OK")
                {
                    m_lastError = "received token (" + received + ") was not OK" ;
                    return false;
                }
                else
                {
                    return true;
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
