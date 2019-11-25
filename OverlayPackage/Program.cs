using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace OverlayPackage
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            UdpClient udp = new UdpClient(4557);
            IPEndPoint iep = null;
            while (true)
            {
                byte[] bytes = udp.Receive(ref iep);
                var target = BitConverter.ToString(bytes, 0).Split('-');
                for (int i = 1; i <= target.Length; i++)
                {
                    Console.Write(target[i-1] + " ");
                    if(0 == i % 8)
                    {
                        Console.Write(" ");
                    }
                    if(0 == i % 16)
                    {
                        Console.Write("\r\n");
                    }
                }
                Console.WriteLine();
                Console.WriteLine("一次接收");
            }
        }

        static void OutputBuffer(byte[] buffer)
        {
            int i = 1;
            foreach (var item in buffer)
            {
                Console.Write(String.Format("{0,x2}", item) + " ");
                i++;
                if(i % 8 == 0)
                {
                    Console.Write("\r\n");
                }
            }
        }
    }
}
