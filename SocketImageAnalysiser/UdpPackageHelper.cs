using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SocketImageAnalysiser
{
    public delegate void MessageHandle(String text);
    struct PackageHeader
    {
        public short packageNumber;
        public short packageCount;
        public Int32 imageNumber;
        public Int32 unkonwnMeta;
        public char proctcolNumber;
        public Int32 packageLength;
        public Int32 attemptCount;
    }
    public class UdpPackageHelper
    {
        readonly Byte[] SplitStringArray = new Byte[2] { 0x0a, 0x3b };
        VCZcamera camera;
        List<Byte> ImgBuffer;
        Queue<Byte[]> UdpPackageBuffer;
        Queue<Byte[]> ImgBufferQueue;
        MessageHandle msgh;
        private Boolean _isAnalysising = true;

        public bool IsAnalysising
        {
            get
            {
                return _isAnalysising;
            }

            set
            {
                _isAnalysising = value;
            }
        }

        public UdpPackageHelper(Queue<Byte[]> buffer, MessageHandle msgh,VCZcamera camera)
        {
            ImgBuffer = new List<byte>();
            ImgBufferQueue = new Queue<byte[]>();
            UdpPackageBuffer = buffer;
            this.msgh = msgh;
            this.camera = camera;
        }

        public Byte[] GetSegmentInArray(Byte[] source, Int32 Start, Int32 Count)
        {
            Byte[] t = new Byte[Count];

            for (int i = 0; i < Count; i++)
            {
                t[i] = source[Start + i];
            }

            return t;
        }

        public Int32 GetCountWithSearchInArray(Byte[] source, Int32 start, params Byte[] key)
        {
            Int32 count = 0;
            Int32 len = source.Length - start;
            Int32 keyLen = key.Length;
            for (int i = start; i < len; i++)
            {
                if(source[i] == key[0])
                {
                    Int32 flag = 1;
                    for (int j = 1; j < keyLen; j++)
                    {
                        if(source[i + j] == key[j])
                        {
                            flag++;
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if(flag == keyLen)
                    {
                        return count;
                    }
                }
                count++;
            }
            return 0;
        }

        public void StopAnalysising()
        {
            IsAnalysising = false;
        }

        public void UdpPackageAnalysis()
        {
            msgh("开始解析数据包");
            Int32 iLastPackageNum = 0;
            while (IsAnalysising)
            {
                if (UdpPackageBuffer.Count > 0)
                {
                    Byte[] bytes = UdpPackageBuffer.Dequeue();
                    Int32 len = bytes.Length;
                    Int16 iPackageNum = BitConverter.ToInt16(bytes, 0);
                    if (iPackageNum != iLastPackageNum)
                    {
                        iLastPackageNum = iPackageNum;
                        Int16 iPackageCount = BitConverter.ToInt16(bytes, 2);
                        Int32 iImgNum = BitConverter.ToInt32(bytes, 4);
                        if (iPackageNum == 1)
                        {
                            Int32 currentPos = 28;
                            for (int i = 1; i < 30; i++)
                            {
                                if(i > 5)
                                {

                                }
                                else
                                {
                                    Int32 count = GetCountWithSearchInArray(bytes, currentPos, SplitStringArray);

                                    currentPos += (count + 2);
                                }
                            }
                            ImgBuffer.Clear();
                            ImgBuffer.AddRange(GetSegmentInArray(bytes, len - 52, 24));
                        }
                        else if (iPackageCount < iPackageNum)
                        {
                            ImgBuffer.AddRange(GetSegmentInArray(bytes, 28, len - 28));
                            //BitmapHelper.SaveBitmap($@"C:\Users\Administrator\Desktop\CAMERA\RGB{iImgNum}.bmp", 320, 256, ImgBuffer.ToArray());
                        }
                        else
                        {
                            ImgBuffer.AddRange(GetSegmentInArray(bytes, 28, len - 28));
                        }
                        if((iPackageNum - 1) == iPackageCount)
                        {
                            ImgBufferQueue.Enqueue(ImgBuffer.ToArray());
                        }
                    }
                }
            }
            msgh("数据包解析停止");
        }
    }
}
