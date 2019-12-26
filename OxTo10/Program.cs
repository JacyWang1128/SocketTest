using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace OxTo10
{
    public class Test
    {

        #region 数组操作方法
        public Byte[] GetSegmentInArray(Byte[] source, Int32 Start, Int32 Count)
        {
            Byte[] t = new Byte[Count];

            for (int i = 0; i < Count; i++)
            {
                t[i] = source[Start + i];
            }

            return t;
        }

        public String BytesToString(Byte[] source)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in source)
            {
                if (!(item == 0x0a || item == 0x3b))
                {
                    sb.Append((char)item);
                }
            }
            return sb.ToString();
        }

        public Int32 GetCountWithSearchInArray(Byte[] source, Int32 start, params Byte[] key)
        {
            Int32 count = 0;
            Int32 len = source.Length;
            Int32 keyLen = key.Length;
            for (int i = start; i < len; i++)
            {
                if (source[i] == key[0])
                {
                    Int32 flag = 1;
                    for (int j = 1; j < keyLen; j++)
                    {
                        if (source[i + j] == key[j])
                        {
                            flag++;
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (flag == keyLen)
                    {
                        return count + keyLen;
                    }
                }
                count++;
            }
            return 0;
        }
        #endregion

        public void UdpPackageAnalysis(Byte[] buffer)
        {
            Int32 iLastPackageNum = 0;
            Byte[] bytes = buffer;
            Int32 len = bytes.Length;
            Int16 iPackageNum = BitConverter.ToInt16(bytes, 0);
            if (iPackageNum != iLastPackageNum)
            {
                iLastPackageNum = iPackageNum;
                Int16 iPackageCount = BitConverter.ToInt16(bytes, 2);
                Int32 iImgNum = BitConverter.ToInt32(bytes, 4);
                if (iPackageNum == 1)
                {
                    #region 解析第一个包
                    Int32 currentPos = 28;
                    Object obj;
                    for (int i = 1; i < 36; i++)
                    {
                        if (i > 5)
                        {
                            Int32 count = GetCountWithSearchInArray(bytes, currentPos, 0x3b);
                            obj = Convert.ToInt32(BytesToString(GetSegmentInArray(bytes, currentPos, count)));
                            Console.Write(i - 5);

                            switch (i - 5)
                            {
                                case 2:
                                    obj = Convert.ToInt32(BytesToString(GetSegmentInArray(bytes, currentPos, count)));
                                    Console.Write(":");
                                    Console.WriteLine(obj);
                                    break;
                                case 3:
                                    obj = Convert.ToInt32(BytesToString(GetSegmentInArray(bytes, currentPos, count)));
                                    Console.Write(":");
                                    Console.WriteLine(obj);
                                    break;
                                case 4:
                                    obj = Convert.ToInt32(BytesToString(GetSegmentInArray(bytes, currentPos, count)));
                                    Console.Write(":");
                                    Console.WriteLine(obj);
                                    break;
                                case 5:
                                    obj = Convert.ToInt32(BytesToString(GetSegmentInArray(bytes, currentPos, count)));
                                    Console.Write(":");
                                    Console.WriteLine(obj);
                                    break;
                                case 6:
                                    obj = Convert.ToInt32(BytesToString(GetSegmentInArray(bytes, currentPos, count)));
                                    Console.Write(":");
                                    Console.WriteLine(obj);
                                    break;
                                case 7:
                                    obj = Convert.ToInt32(BytesToString(GetSegmentInArray(bytes, currentPos, count)));
                                    Console.Write(":");
                                    Console.WriteLine(obj);
                                    break;
                                case 8:
                                    obj = Convert.ToInt32(BytesToString(GetSegmentInArray(bytes, currentPos, count)));
                                    Console.Write(":");
                                    Console.WriteLine(obj);
                                    break;
                                case 18:
                                    obj = Convert.ToInt32(BytesToString(GetSegmentInArray(bytes, currentPos, count)));
                                    Console.Write(":");
                                    Console.WriteLine(obj);
                                    break;
                                case 23:
                                    obj = Convert.ToUInt32(BytesToString(GetSegmentInArray(bytes, currentPos, count)));
                                    Console.Write(":");
                                    Console.WriteLine(obj);
                                    break;
                                case 24:
                                    obj = Convert.ToUInt32(BytesToString(GetSegmentInArray(bytes, currentPos, count)));
                                    Console.Write(":");
                                    Console.WriteLine(obj);
                                    break;
                                case 25:
                                    obj = Convert.ToUInt32(BytesToString(GetSegmentInArray(bytes, currentPos, count)));
                                    Console.Write(":");
                                    Console.WriteLine(obj);
                                    break;
                                default:
                                    break;
                            }
                            currentPos += count;
                        }
                        else
                        {
                            Int32 count = GetCountWithSearchInArray(bytes, currentPos, 0x0a, 0x3b);
                            obj = BytesToString(GetSegmentInArray(bytes, currentPos, count));
                            Console.WriteLine(obj);
                            //switch (i)
                            //{
                            //    case 1:
                            //        CameraName = BytesToString(GetSegmentInArray(bytes, currentPos, count));
                            //        break;
                            //    case 5:
                            //        CameraIP = BytesToString(GetSegmentInArray(bytes, currentPos, count));
                            //        break;
                            //    default:
                            //        currentPos += count;
                            //        break;
                            //}
                            currentPos += count;
                        }
                    }

                    #endregion
                }

            }
        }
    }

    class Program
    {
        static Int32 fun(int x)
        {
            Int32 count = 0;
            while(x > 0)
            {
                count++;
                x = x & (x - 1);
            }
            return count;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(fun(9999));
            Console.ReadKey();
            //Console.ForegroundColor = ConsoleColor.DarkGreen;
            //String strasdasd = "01000100d50600000000000006455654414350000e0100000500000052756e74696d650a3b2f726f6f742f52756e74696d652f446576696365732f50435f4c6f63616c2f50726f6772616d732f4f4b4e472e636b700a3b456d7074790a3b323031395f31305f31325f30385f35345f34305f3235323037380a3b302e302e302e300a3b313734393b3332303b3235363b313b303b303b313238303b313032343b313b313b333b313b313b313b303b303b313b323b333b353b313b313b303b303b303b33303030303b353935323b3332303b303b303b00430d0000ffd8ffe000104a46494600010100000100010000ffdb004300000000010000000c00000004000000ff000000ff00ff00ffffff00";
            //var tempCharArr = strasdasd.ToCharArray();
            //String[] strarray = strasdasd.Split(' ');
            //List<Byte> bytes = new List<byte>();
            //for (int i = 0; i < tempCharArr.Length / 2; i++)
            //{
            //    var temparr = new Char[2] { tempCharArr[i * 2], tempCharArr[i * 2 + 1] };
            //    Int32 tempint = Convert.ToInt32(new String(temparr), 16);
            //    bytes.Add((byte)tempint);
            //}
            //Byte[] buffer = bytes.ToArray();
            //Test t = new Test();
            //t.UdpPackageAnalysis(buffer);
            //Console.ReadKey();

            //#region 之前代码
            ////Stopwatch sw1 = new Stopwatch();
            ////sw1.Start();
            ////Bitmap target1 = BitmapHelper.GetRGBBitmapFromBuffer(320, 256, buffer);
            ////sw1.Stop();
            ////target1.Save(@"C:\Users\Administrator\Desktop\CAMERA\RGB1.bmp", ImageFormat.Bmp);
            ////Console.WriteLine($"指针法解码总共花费：{sw1.Elapsed}秒\n按任意键结束！");
            ////Stopwatch sw2 = new Stopwatch();
            ////sw2.Start();
            ////Bitmap target = BitmapHelper.GetRGBBitmapFromBufferWithMemory(320, 256, buffer);
            ////sw2.Stop();
            ////target.Save(@"C:\Users\Administrator\Desktop\CAMERA\RGB2.bmp", ImageFormat.Bmp);
            ////Console.WriteLine($"内存法解码总共花费：{sw2.Elapsed}秒\n按任意键结束！");
            ////Console.ReadKey();
            ////using (FileStream fs = new FileStream(@"C:\Users\Administrator\Desktop\CAMERA\14.jpg", FileMode.Create, FileAccess.ReadWrite))
            ////{
            ////    fs.Write(buffer, 0, buffer.Length);
            ////}
            ////Bitmap target8 = BitmapHelper.GetBitmapFromBuffer(320, 256, buffer);
            ////Bitmap target = BitmapHelper.Bit8To24(target8);
            ////target.Save(@"C:\Users\Administrator\Desktop\CAMERA\13.bmp",ImageFormat.Bmp);
            ////byte[] byteArray = System.Text.Encoding.Default.GetBytes(strsource);
            //#endregion
        }

        public static String ShowBuffer(byte[] buffer)
        {
            Int32 count = 0;
            StringBuilder sb = new StringBuilder();
            foreach (var item in buffer)
            {
                sb.AppendFormat("{0:x2}", item);
                sb.Append(" ");
                ++count;
                if (count % 8 == 0)
                {
                    sb.Append("\t");
                    if (count % 32 == 0)
                    {
                        sb.Append("\n");
                    }
                }
            }
            return sb.ToString();
        }

        public static T[] GetSegmentInArray<T>(T[] source, Int32 Start, Int32 Count)
        {
            T[] t = new T[Count];

            for (int i = 0; i < Count; i++)
            {
                t[i] = source[Start + i];
            }

            return t;
        }

        public static Byte[] ReceiveData(Int32 port)
        {
            UdpPackageHelper uph = new UdpPackageHelper();
            //在本机指定的端口接收
            var udpClient = new UdpClient(port);
            IPEndPoint remote = null;
            //接收从远程主机发送过来的信息；
            //udpClient.Connect(IPAddress.Parse("192.168.3.15"), port);
            List<Byte> buffer = new List<byte>();
            Int16 iLastPackageNum = 0;
            Boolean isReceiving = true;
            while (isReceiving)
            {
                //Console.WriteLine($"正在监听端口：{port}");
                try
                {

                    //关闭udpClient时此句会产生异常
                    byte[] bytes = udpClient.Receive(ref remote);
                    if (bytes.Length > 0)
                    {
                        Int32 iImgNum = BitConverter.ToInt32(bytes, 4);
                        Int16 iPackageCount = BitConverter.ToInt16(bytes, 2);
                        Int16 iPackageNum = BitConverter.ToInt16(bytes, 0);
                        uph.UdpPackageAnalysis(bytes);
                        //Console.WriteLine($"iImgNum:{iImgNum}\tiPackageCount:{iPackageCount}\tiPackageNum:{iPackageNum}***************{iImgNum}_{iPackageNum}OK");
                       // var content = System.Text.Encoding.Default.GetBytes($"{iImgNum}_{iPackageNum}OK");
                        //udpClient.Send(content, content.Length, "192.168.3.15", 7778);
                    }

                    //string str = Encoding.UTF8.GetString(bytes, 0, bytes.Length);

                }
                catch
                {
                    continue;
                    //退出循环，结束线程
                    //break;
                }

            }
            return buffer.ToArray();
        }
    }
}
