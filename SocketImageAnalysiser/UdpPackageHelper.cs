using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SocketImageAnalysiser
{
    /// <summary>
    /// 处理信息包的方法
    /// </summary>
    /// <param name="dic"></param>
    public delegate void MessageHandle(Dictionary<String, String> dic);
    public class UdpPackageHelper
    {
        readonly Byte[] SplitStringArray = new Byte[2] { 0x0a, 0x3b };
        VCZcamera camera;
        List<Byte> ImgBuffer;
        public Queue<Byte[]> UdpPackageBuffer;
        public Queue<Byte[]> ImgBufferQueue;
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

        public UdpPackageHelper(Queue<Byte[]> buffer, MessageHandle msgh, VCZcamera camera)
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

        public String BytesToString(Byte[] source)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in source)
            {
                if(!(item == 0x0a || item == 0x3b))
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

        public void StopAnalysising()
        {
            IsAnalysising = false;
        }

        public void UdpPackageAnalysis()
        {
            IsAnalysising = true;
            //msgh("开始解析数据包");
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
                            #region 解析第一个包
                            Int32 currentPos = 28;
                            for (int i = 1; i < 36; i++)
                            {
                                if (i > 5)
                                {
                                    Int32 count = GetCountWithSearchInArray(bytes, currentPos, 0x3b);
                                    try
                                    {
                                        switch (i - 5)
                                        {
                                            case 2:
                                                camera.ImgWidth = Convert.ToInt32(BytesToString(GetSegmentInArray(bytes, currentPos, count)));
                                                break;
                                            case 3:
                                                camera.ImgHeight = Convert.ToInt32(BytesToString(GetSegmentInArray(bytes, currentPos, count)));
                                                break;
                                            case 4:
                                                camera.colorDepth = (ColorDepth)Convert.ToInt32(BytesToString(GetSegmentInArray(bytes, currentPos, count)));
                                                break;
                                            case 5:
                                                camera.Roi_x = Convert.ToInt32(BytesToString(GetSegmentInArray(bytes, currentPos, count)));
                                                break;
                                            case 6:
                                                camera.Roi_y = Convert.ToInt32(BytesToString(GetSegmentInArray(bytes, currentPos, count)));
                                                break;
                                            case 7:
                                                camera.Roi_width = Convert.ToInt32(BytesToString(GetSegmentInArray(bytes, currentPos, count)));
                                                break;
                                            case 8:
                                                camera.Roi_height = Convert.ToInt32(BytesToString(GetSegmentInArray(bytes, currentPos, count)));
                                                break;
                                            case 10:
                                                //识别ImageSection
                                                camera.ImgSection = Convert.ToInt32(BytesToString(GetSegmentInArray(bytes, currentPos, count)));
                                                break;
                                            case 11:
                                                //识别ImageResolution
                                                camera.ImgResolution = Convert.ToInt32(BytesToString(GetSegmentInArray(bytes, currentPos, count)));
                                                break;
                                            case 18:
                                                camera.format = (ImgFormat)Convert.ToInt32(BytesToString(GetSegmentInArray(bytes, currentPos, count)));
                                                break;
                                            case 23:
                                                camera.GoodCount = Convert.ToUInt32(BytesToString(GetSegmentInArray(bytes, currentPos, count)));
                                                break;
                                            case 24:
                                                camera.BadCount = Convert.ToUInt32(BytesToString(GetSegmentInArray(bytes, currentPos, count)));
                                                break;
                                            case 25:
                                                camera.CycleTime = Convert.ToUInt32(BytesToString(GetSegmentInArray(bytes, currentPos, count)));
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        //msgh(ex.Message);
                                    }
                                   
                                    currentPos += count;
                                }
                                else
                                {
                                    Int32 count = GetCountWithSearchInArray(bytes, currentPos, SplitStringArray);
                                    switch (i)
                                    {
                                        case 1:
                                            camera.CameraName = BytesToString(GetSegmentInArray(bytes, currentPos, count));
                                            break;
                                        default:
                                            break;
                                    }
                                    currentPos += count;
                                }
                            }

                            #endregion

                            //收到第一包后清空图形缓存队列（当前图形缓存队列存放的是上一张图片的数据
                            ImgBuffer.Clear();
                            //装入图形缓存list
                            ImgBuffer.AddRange(GetSegmentInArray(bytes, len - 56, 28));
                            camera.IsNewPhoto = true;
                        }
                        else if (iPackageCount < iPackageNum)
                        {
                            //装入图形缓存list
                            ImgBuffer.AddRange(GetSegmentInArray(bytes, 28, len - 28));
                        }
                        else
                        {
                            //装入图形缓存list
                            ImgBuffer.AddRange(GetSegmentInArray(bytes, 28, len - 28));
                        }
                        if ((iPackageNum - 1) == iPackageCount)
                        {
                            //存入图像缓存队列
                            ImgBufferQueue.Enqueue(ImgBuffer.ToArray());
                        }
                    }
                }

                Thread.Sleep(1);
            }
            //msgh("数据包解析停止");
        }
    }
}
