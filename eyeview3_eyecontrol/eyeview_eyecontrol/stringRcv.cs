using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Net;


namespace EVT
{
    class stringRcv
    {
        CancellationTokenSource cts = new CancellationTokenSource();
        TcpListener listener = new TcpListener(IPAddress.Any, 4556);
        TextBox m_tb;

        public stringRcv()
        {
        }

        ~stringRcv()
        {

        }

        public void init(TextBox tb)
        {
            m_tb = tb;
        }

        public void start()
        {
            listener.Start();
            AcceptClientsAsync(listener, cts.Token);
            SetText("started");
        }

        public void stop()
        {
            listener.Stop();
            SetText("stopped");
        }

        public void SetText(string value)
        {
            m_tb.Invoke(new MethodInvoker(() => { m_tb.Text = value; }));
        }


        async Task AcceptClientsAsync(TcpListener listener, CancellationToken ct)
        {
            int clientCounter = 0;
            while (!ct.IsCancellationRequested)
            {
                TcpClient client = await listener.AcceptTcpClientAsync()
                                                    .ConfigureAwait(false);
                clientCounter++;
                asyncReadTask(client, clientCounter, ct);
            }

        }
        async Task asyncReadTask(TcpClient client,
                             int clientIndex,
                             CancellationToken ct)
        {
            using (client)
            {
                byte[] buf = new byte[4096];
                NetworkStream stream = client.GetStream();
                while (!ct.IsCancellationRequested)
                {
                    Task timeoutTask = Task.Delay(TimeSpan.FromSeconds(15));
                    Task<int> amountReadTask = stream.ReadAsync(buf, 0, buf.Length, ct);
                    Task completedTask = await Task.WhenAny(timeoutTask, amountReadTask)
                                                  .ConfigureAwait(false);
                    if (completedTask == timeoutTask)
                    {
                        SetText("timeout");
                        break;
                    }

                    var bytesRead = amountReadTask.Result;
                    if (bytesRead == 0)
                    {
                        break;
                    }
                    SetText(Encoding.ASCII.GetString(buf, 0, bytesRead));
                }
            }
        }
    }
}
