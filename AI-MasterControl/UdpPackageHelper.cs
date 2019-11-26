using AI_MasterControl.Element;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AI_MasterControl
{
    /// <summary>
    /// 处理信息包的方法
    /// </summary>
    /// <param name="dic"></param>
    public class UdpPackageHelper
    {
        readonly Byte[] SplitStringArray = new Byte[2] { 0x0a, 0x3b };
        VCZcamera camera;
        List<Byte> ImgBuffer;
        public Queue<Byte[]> UdpPackageBuffer;
        public Queue<Byte[]> ImgBufferQueue;
        MessageHandle msgh;
        private Boolean _isAnalysising = true;
        List<Element.Element> ElementBuffer = new List<Element.Element>();
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

        public void StopAnalysising()
        {
            IsAnalysising = false;
        }
        Boolean imgTransferComplete = false;
        public void UdpPackageAnalysis()
        {
            IsAnalysising = true;
            //msgh("开始解析数据包");
            Int32 iLastPackageNum = 0;
            while (IsAnalysising)
            {
                if (UdpPackageBuffer.Count > 0)
                {
                    try
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
                                if(ImgBuffer.Count > 0)
                                {
                                    if (imgTransferComplete)
                                    {
                                        //存入图像缓存队列
                                        ImgBufferQueue.Enqueue(ImgBuffer.ToArray());
                                        camera.lstElement = new List<Element.Element>(ElementBuffer);
                                        imgTransferComplete = false;
                                        ElementBuffer.Clear();
                                    }
                                }
                                
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
                                                    switch (camera.ImgResolution)
                                                    {
                                                        case 1:
                                                            camera.ComprehensionRate = 1;
                                                            break;
                                                        case 2:
                                                            camera.ComprehensionRate = 2;
                                                            break;
                                                        case 3:
                                                            camera.ComprehensionRate = 4;
                                                            break;
                                                        default:
                                                            break;
                                                    }
                                                    break;
                                                case 15:
                                                    Int32 temp = Convert.ToInt32(BytesToString(GetSegmentInArray(bytes, currentPos, count)));
                                                    break;
                                                case 16:
                                                    Int32 temp1 = Convert.ToInt32(BytesToString(GetSegmentInArray(bytes, currentPos, count)));
                                                    break;
                                                case 18:
                                                    camera.format = (ImgFormat)Convert.ToInt32(BytesToString(GetSegmentInArray(bytes, currentPos, count)));
                                                    break;
                                                case 23:
                                                    UInt32 tempGC = Convert.ToUInt32(BytesToString(GetSegmentInArray(bytes, currentPos, count)));
                                                    camera.GoodCount = tempGC;
                                                    break;
                                                case 24:
                                                    UInt32 tempBC = Convert.ToUInt32(BytesToString(GetSegmentInArray(bytes, currentPos, count)));
                                                    camera.BadCount = tempBC;
                                                    break;
                                                case 25:
                                                    camera.CycleTime = Convert.ToUInt32(BytesToString(GetSegmentInArray(bytes, currentPos, count)));
                                                    break;
                                                case 30:
                                                    var result = Convert.ToInt32(BytesToString(GetSegmentInArray(bytes, currentPos, count)));
                                                    if(0 == result)
                                                    {
                                                        camera.IsOK = true;
                                                    }
                                                    else
                                                    {
                                                        camera.IsOK = false;
                                                    }
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
                            }
                            else if (iPackageNum > iPackageCount)
                            {
                                if (iPackageNum > iPackageCount + 1)
                                {
                                    ElementBuffer.AddRange(GetElements(GetSegmentInArray(bytes, 28, len - 28)));
                                    imgTransferComplete = true;
                                }
                                else
                                {
                                    //装入图形缓存list
                                    ImgBuffer.AddRange(GetSegmentInArray(bytes, 28, len - 28));
                                }
                            }
                            else
                            {
                                //if ((iPackageNum - 1) == iPackageCount)
                                //{
                                //    //装入图形缓存list
                                ImgBuffer.AddRange(GetSegmentInArray(bytes, 28, len - 28));
                                //}
                                //else
                                //{
                                    //camera.lstElement.AddRange(GetElements(GetSegmentInArray(bytes, 28, len - 28)));
                                //}
                            }
                            //if ((iPackageNum - 1) == iPackageCount)
                            //{
                            //    //存入图像缓存队列
                            //    ImgBufferQueue.Enqueue(ImgBuffer.ToArray());
                            //}
                        }
                    }
                    catch (Exception ex)
                    {
                        LoggHelper.WriteLog("数据包异常", ex);
                    }
                }
                Thread.Sleep(1);
            }
            //msgh("数据包解析停止");
        }

        public List<Element.Element> GetElements(Byte[] package)
        {
            List<Element.Element> res = new List<Element.Element>();
            Int32 startpostion = 0;
            while (startpostion < package.Length)
            {
                Int16 type = BitConverter.ToInt16(package, startpostion);
                switch (type)
                {
                    case 1:
                        res.Add(new ElementPoint((Int32)type, 
                            (Int32)BitConverter.ToInt16(package, startpostion + 4), 
                            (Int32)BitConverter.ToInt16(package, startpostion + 6), 
                            (ElementColor)(Int32)BitConverter.ToInt16(package, startpostion + 2)));
                        startpostion += 8;
                        break;
                    case 2:
                        res.Add(new ElementLine((Int32)type,
                            (Int32)BitConverter.ToInt16(package, startpostion + 4),
                            (Int32)BitConverter.ToInt16(package, startpostion + 6),
                            (ElementColor)(Int32)BitConverter.ToInt16(package, startpostion + 2),
                            (Int32)BitConverter.ToInt16(package,startpostion + 8),
                            (Int32)BitConverter.ToInt16(package,startpostion + 10)));
                        startpostion += 12;
                        break;
                    case 3:
                        res.Add(new ElementCircle((Int32)type,
                            (Int32)BitConverter.ToInt16(package, startpostion + 4),
                            (Int32)BitConverter.ToInt16(package, startpostion + 6),
                            (ElementColor)(Int32)BitConverter.ToInt16(package, startpostion + 2),
                            (Int32)BitConverter.ToInt16(package, startpostion + 8),
                            (Int32)BitConverter.ToInt16(package, startpostion + 10)));
                        startpostion += 12;
                        break;
                    case 4:
                        res.Add(new ElementEllipse((Int32)type,
                            (Int32)BitConverter.ToInt16(package, startpostion + 4),
                            (Int32)BitConverter.ToInt16(package, startpostion + 6),
                            (ElementColor)(Int32)BitConverter.ToInt16(package, startpostion + 2),
                            (Int32)BitConverter.ToInt16(package, startpostion + 8),
                            (Int32)BitConverter.ToInt16(package, startpostion + 10)));
                        startpostion += 12;
                        break;
                    case 5:
                        res.Add(new ElementWindow((Int32)type,
                            (Int32)BitConverter.ToInt16(package, startpostion + 4),
                            (Int32)BitConverter.ToInt16(package, startpostion + 6),
                            (ElementColor)(Int32)BitConverter.ToInt16(package, startpostion + 2),
                            (Int32)BitConverter.ToInt16(package, startpostion + 8),
                            (Int32)BitConverter.ToInt16(package, startpostion + 10)));
                        startpostion += 12;
                        break;
                    case 6:
                        Int32 flag = 0;
                        StringBuilder sb = new StringBuilder();
                        while(package[startpostion + 10 + flag] != 0x00)
                        {
                            sb.Append((char)package[startpostion + 10 + flag]);
                            flag++;
                        }
                        res.Add(new ElementString((Int32)type,
                         (Int32)BitConverter.ToInt16(package, startpostion + 4),
                         (Int32)BitConverter.ToInt16(package, startpostion + 6),
                         (ElementColor)(Int32)BitConverter.ToInt16(package, startpostion + 2),
                         (Int32)BitConverter.ToInt16(package,startpostion + 8),
                         sb.ToString()));
                        startpostion += sb.Length + 10 + 1;
                        break;
                    case 7:
                        Int32 step = (Int32)BitConverter.ToInt16(package, startpostion + 8);
                        startpostion += 10 + step * 2;
                        break;
                    case 8:
                        res.Add(new ElementArc((Int32)type,
                            (Int32)BitConverter.ToInt16(package, startpostion + 4),
                            (Int32)BitConverter.ToInt16(package, startpostion + 6),
                            (ElementColor)(Int32)BitConverter.ToInt16(package, startpostion + 2),
                            (Int32)BitConverter.ToInt16(package,startpostion + 8),
                            (Int32)BitConverter.ToInt16(package,startpostion + 10),
                            (float)BitConverter.ToSingle(package,startpostion + 12),
                            (float)BitConverter.ToSingle(package,startpostion + 14)));
                        startpostion += 20;
                        break;
                    case 9:
                        res.Add(new ElementArrow((Int32)type,
                            (Int32)BitConverter.ToInt16(package, startpostion + 4),
                            (Int32)BitConverter.ToInt16(package, startpostion + 6),
                            (ElementColor)(Int32)BitConverter.ToInt16(package, startpostion + 2),
                            (Int32)BitConverter.ToInt16(package,startpostion + 8),
                            (Int32)BitConverter.ToInt16(package,startpostion + 10),
                            (Int32)BitConverter.ToInt16(package, startpostion + 12),
                            (Int32)BitConverter.ToInt16(package, startpostion + 14)));
                        startpostion += 16;
                        break;
                    default:
                        break;
                }
            }
            return res;
        }
    }
}
