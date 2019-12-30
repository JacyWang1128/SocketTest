using AI_MasterControl.Element;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AI_MasterControl
{
    public enum ImgFormat
    {
        bmp = 1,
        jpg = 2,
        png = 3
    }
    public enum ColorDepth
    {
        GrayScale = 1,
        RGB = 3
    }

    public class VCZcamera
    {
        #region 声明
        //子类声明
        private MessageHandle msg;
        public UdpHelper uh;
        private UdpPackageHelper uph;
        private BitmapHelper bh;

        //属性声明
        private String _cameraName;              //相机名称
        private String _cameraIP;                //相机IP
        private Int32 _port;                     //相机接口
        private Int32 _imgWidth;                 //图片宽度
        private Int32 _imgHeight;                //图片高度
        private Int32 _roi_x;                    //roi_x
        private Int32 _roi_y;                    //roi_y
        private Int32 _roi_width;                //roi_width
        private Int32 _roi_height;               //roi_height
        private UInt32 _goodCount;               //good计数
        private UInt32 _badCount;                //bad计数
        private UInt32 _cycleTime;               //循环时间
        private Int32 _imgSection;               //图片传输方式（全部/部份）
        private Int32 _imgResolution;          
        private Boolean _isOK;                   //图片状态OK
        private Int32 _imgStatus;                //照片状态 0 Good 1 Bad 2 Warning
        private String _pathOK;                  //OK的保存路径
        private String _pathNG;                  //NG的保存路径
        private String _pathWarning;             //WARNING的保存路径
        public RotateFlipType rotate;            //图片旋转方式
        public ImgFormat format;                 //图片格式
        public ColorDepth colorDepth;            //色彩模式
        public ImageFormat SaveImageFormat;      //图片格式
        public Boolean IsSaveing;                //是否保存
        public Boolean IsRestore;                //是否还原
        public Boolean IsDistinguish;            //是否区分OK NG WARNING
        public Boolean IsSaveOK;                 //是否保存OK
        public Boolean IsSaveNG;                 //是否保存NG
        public Boolean IsSaveWarning;            //是否保存WARNING
        public CameraInfo camInfo;               //相机信息POCO
        private Int32 _cmosWidth;                //相机分辨率宽度
        private Int32 _cmosHeight;               //相机分辨率高度

        private Boolean _isShowing = true;
        private Boolean _isNewPhoto = false;
        private FilePreEventHandler getFilePre;
        public PictureBox showImagePanel;
        public String FilePrefix;
        //当前图像
        public Image currentImage;
        public List<Element.Element> lstElement;
        //当前图像信息
        public Dictionary<String, String> VCZcameraInfo = new Dictionary<string, string>();
        public Int32 ComprehensionRate = 1;
        public Boolean isReceiving = false;
        #region 封装字段
        public string CameraName
        {
            get
            {
                return _cameraName;
            }

            set
            {
                _cameraName = value;
            }
        }

        public string CameraIP
        {
            get
            {
                return _cameraIP;
            }

            set
            {
                _cameraIP = value;
            }
        }

        public int ImgWidth
        {
            get
            {
                return _imgWidth;
            }

            set
            {
                _imgWidth = value;
            }
        }

        public int ImgHeight
        {
            get
            {
                return _imgHeight;
            }

            set
            {
                _imgHeight = value;
            }
        }

        public int Roi_x
        {
            get
            {
                return _roi_x;
            }

            set
            {
                _roi_x = value;
            }
        }

        public int Roi_y
        {
            get
            {
                return _roi_y;
            }

            set
            {
                _roi_y = value;
            }
        }

        public int Roi_width
        {
            get
            {
                return _roi_width;
            }

            set
            {
                _roi_width = value;
            }
        }

        public int Roi_height
        {
            get
            {
                return _roi_height;
            }

            set
            {
                _roi_height = value;
            }
        }

        public uint GoodCount
        {
            get
            {
                return _goodCount;
            }

            set
            {
                _goodCount = value;
            }
        }

        public uint BadCount
        {
            get
            {
                return _badCount;
            }

            set
            {
                _badCount = value;
            }
        }

        public uint CycleTime
        {
            get
            {
                return _cycleTime;
            }

            set
            {
                _cycleTime = value;
            }
        }

        public bool IsShowing
        {
            get
            {
                return _isShowing;
            }

            set
            {
                _isShowing = value;
            }
        }

        public bool IsNewPhoto
        {
            get
            {
                return _isNewPhoto;
            }

            set
            {
                _isNewPhoto = value;
            }
        }

        public int ImgSection
        {
            get
            {
                return _imgSection;
            }

            set
            {
                _imgSection = value;
            }
        }

        public int ImgResolution
        {
            get
            {
                return _imgResolution;
            }

            set
            {
                _imgResolution = value;
            }
        }

        public int CmosWidth
        {
            get
            {
                return _cmosWidth;
            }

            set
            {
                _cmosWidth = value;
            }
        }

        public int CmosHeight
        {
            get
            {
                return _cmosHeight;
            }

            set
            {
                _cmosHeight = value;
            }
        }

        public int Port
        {
            get
            {
                return _port;
            }

            set
            {
                _port = value;
            }
        }

        public bool IsOK
        {
            get
            {
                return _isOK;
            }

            set
            {
                _isOK = value;
            }
        }

        public string PathOK
        {
            get
            {
                return _pathOK;
            }

            set
            {
                _pathOK = value;
            }
        }

        public string PathNG
        {
            get
            {
                return _pathNG;
            }

            set
            {
                _pathNG = value;
            }
        }

        public int ImgStatus
        {
            get
            {
                return _imgStatus;
            }

            set
            {
                _imgStatus = value;
            }
        }

        public string PathWarning
        {
            get
            {
                return _pathWarning;
            }

            set
            {
                _pathWarning = value;
            }
        }
        #endregion
        #endregion

        //在此处修改预定义颜色
        Color[] EleColors = { Color.FromArgb(255, 0, 0), Color.FromArgb(0, 255, 0), Color.FromArgb(255, 0, 255), Color.FromArgb(255, 255, 58) };

        //元素队列
        private Queue<Element.Element[]> ElementQueue;
        
        //初始化函数
        public VCZcamera(MessageHandle msgh, PictureBox pl, FilePreEventHandler fpeh)
        {
            InitCameraInfo();
            msg = msgh;
            uh = new UdpHelper(msgh, this);
            uph = new UdpPackageHelper(uh.UdpPackageBuffer, msgh, this);
            bh = new BitmapHelper(uph.ImgBufferQueue, msgh, this);
            getFilePre = fpeh;
            showImagePanel = pl;
            lstElement = new List<Element.Element>();

            ElementQueue = new Queue<Element.Element[]>();
            uph.ElementQuee = ElementQueue;
        }

        public void SetCMOS(Int32 width, Int32 height)
        {
            CmosWidth = width;
            CmosHeight = height;
        }


        ~VCZcamera()
        {
            uh = null;
            uph = null;
            bh = null;
        }

        public void Start()
        {
            Thread t1 = new Thread(uh.ListeningPort);
            Thread t2 = new Thread(uph.UdpPackageAnalysis);
            Thread t3 = new Thread(StartShowingInfo);
            Thread t4 = new Thread(bh.StartAnalysising);
            t1.Priority = ThreadPriority.Lowest;
            t2.Priority = ThreadPriority.Lowest;
            t3.Priority = ThreadPriority.Lowest;
            t4.Priority = ThreadPriority.Lowest;
            t1.IsBackground = true;
            t2.IsBackground = true;
            t3.IsBackground = true;
            t3.IsBackground = true;
            t1.Start(Port);
            t2.Start();
            t3.Start();
            t4.Start();
            isReceiving = true;
        }

        public void Stop()
        {
            try
            {
                Console.WriteLine("即将结束UDP接收");
                uh.StopListening();
            }
            catch (Exception)
            {

            }
            Thread.Sleep(1);
            Console.WriteLine("即将结束UDP数据包解析");
            try
            {
                uph.StopAnalysising();
            }
            catch (Exception)
            {

            }
            Thread.Sleep(1);
            try
            {
                Console.WriteLine("即将结束图片显示");
                IsShowing = false;
                Thread.Sleep(1);
                Console.WriteLine("即将结束图片分析");
                bh.StopAnalysising();
            }
            catch (Exception)
            {

            }
            Thread.Sleep(1);
            Console.WriteLine("图片接收结束");
            //isReceiving = false;
            Thread.Sleep(1);
        }

        public void StartShowingInfo()
        {
            IsShowing = true;
            while (IsShowing)
            {
                if (IsNewPhoto)
                {
                    lock (this)
                    {
                        NewPhotoMethod();
                    }
                    IsNewPhoto = false;
                    lstElement.Clear();
                }
                Thread.Sleep(1);
                //CommonHelper.Delay(1);
            }
        }

        public void NewPhotoMethod()
        {
            camInfo.CameraIp = CameraIP;
            camInfo.CameraName = CameraName;
            camInfo.RoiX = Roi_x.ToString();
            camInfo.RoiY = Roi_y.ToString();
            camInfo.RoiHeight = Roi_height.ToString();
            camInfo.RoiWidth = Roi_width.ToString();
            camInfo.GoodCount = GoodCount.ToString();
            camInfo.BadCount = BadCount.ToString();
            camInfo.CycleTime = (Convert.ToDouble(CycleTime) / 1000).ToString();

            if (currentImage != null)
            {
                try
                {
                    Bitmap showImage;
                    lock (currentImage)
                    {
                        showImage = new Bitmap(currentImage);
                    }
                    showImage.RotateFlip(rotate);

                    #region 绘制Overlay元素

                    if (ElementQueue.Count > 0)
                    {
                        //List<Element.Element> temp = new List<Element.Element>(ElementQueue.Dequeue());

                        var temp = ElementQueue.Dequeue();
                        if (ElementQueue.Count > 0)
                        {
                            lock (ElementQueue)
                            {
                                ElementQueue.Clear();
                            }
                        }
                        using (Bitmap bmp = new Bitmap(showImage.Width, showImage.Height))
                        {
                            using (Graphics ele = Graphics.FromImage(bmp))
                            {
                                ele.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                                //ele.Clear(Color.Transparent);
                                foreach (var item in temp)
                                {
                                    if (item != null)
                                    {
                                        //画笔颜色定义（EleColors为颜色定义数组EleColors双击按F12即可跳转定义，若修改颜色请把箭头颜色同样修改
                                        //方法说明：Pen(颜色,粗细);
                                        Pen p;
                                        if((Int32)item.color >= EleColors.Length)
                                        {
                                            p = new Pen(EleColors[EleColors.Length - 1], 8);
                                        }
                                        else
                                        {
                                            p = new Pen(EleColors[(Int32)item.color], 8);
                                        }

                                        switch (item.type)
                                        {

                                            case 1://点
                                                ele.DrawEllipse(p,
                                                    item.x / ComprehensionRate,
                                                    item.y / ComprehensionRate,
                                                    1,
                                                    1);
                                                break;
                                            case 2://线
                                                ele.DrawLine(p,
                                                    (item as ElementLine).x / ComprehensionRate,
                                                    (item as ElementLine).y / ComprehensionRate,
                                                    (item as ElementLine).dx / ComprehensionRate,
                                                    (item as ElementLine).dy / ComprehensionRate);
                                                break;
                                            case 3://圆
                                                ele.DrawEllipse(p,
                                                    ((item as ElementEllipse).x - (item as ElementEllipse).rx) / ComprehensionRate,
                                                    ((item as ElementEllipse).y - (item as ElementEllipse).ry) / ComprehensionRate,
                                                    2 * (item as ElementEllipse).rx / ComprehensionRate,
                                                    2 * (item as ElementEllipse).ry / ComprehensionRate);
                                                break;
                                            case 4://椭圆
                                                ele.DrawEllipse(p,
                                                    ((item as ElementEllipse).x - (item as ElementEllipse).rx) / ComprehensionRate,
                                                    ((item as ElementEllipse).y - (item as ElementEllipse).ry) / ComprehensionRate,
                                                    2 * (item as ElementEllipse).rx / ComprehensionRate,
                                                    2 * (item as ElementEllipse).ry / ComprehensionRate);
                                                break;
                                            case 5://矩形
                                                ele.DrawRectangle(p,
                                                    (item as ElementWindow).x / ComprehensionRate,
                                                    (item as ElementWindow).y / ComprehensionRate,
                                                    (item as ElementWindow).dx / ComprehensionRate,
                                                    (item as ElementWindow).dy / ComprehensionRate);
                                                break;
                                            case 6://字符串
                                                ele.DrawString((item as ElementString).content,
                                                    new Font("Thaoma", (item as ElementString).fontsize / ComprehensionRate, GraphicsUnit.Pixel), new SolidBrush(EleColors[(Int32)item.color]),
                                                    (item as ElementString).x / ComprehensionRate,
                                                    (item as ElementString).y / ComprehensionRate);
                                                break;
                                            case 7://图案pattern
                                                break;
                                            case 8://圆弧
                                                ele.DrawArc(p,
                                                    ((item as ElementArc).x - (item as ElementArc).rx) / ComprehensionRate,
                                                    ((item as ElementArc).y - (item as ElementArc).ry) / ComprehensionRate,
                                                    2 * ((item as ElementArc).rx) / ComprehensionRate,
                                                    2 * ((item as ElementArc).ry) / ComprehensionRate,
                                                    (float)(item as ElementArc).Start_angle,
                                                    (float)((item as ElementArc).End_anlge - (item as ElementArc).Start_angle));
                                                break;
                                            case 9://箭头
                                                Pen arrowPen;
                                                if ((Int32)item.color >= EleColors.Length)
                                                {
                                                    arrowPen = new Pen(EleColors[EleColors.Length - 1], 16);
                                                }
                                                else
                                                {
                                                    arrowPen = new Pen(EleColors[(Int32)item.color], 16);
                                                }
                                                if ((item as ElementArrow).ad > 0)
                                                {
                                                    arrowPen.StartCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                                                }
                                                if((item as ElementArrow).ap > 0)
                                                {
                                                    arrowPen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                                                }
                                                ele.DrawLine(arrowPen,
                                                    (item as ElementArrow).x / ComprehensionRate,
                                                    (item as ElementArrow).y / ComprehensionRate,
                                                    (item as ElementArrow).dx / ComprehensionRate,
                                                    (item as ElementArrow).dy / ComprehensionRate);
                                                

                                                break;
                                            default:
                                                break;
                                        }
                                        ele.Flush(System.Drawing.Drawing2D.FlushIntention.Flush);
                                    }
                                }
                            }

                            using (Graphics g = Graphics.FromImage(showImage)/*showImagePanel.CreateGraphics()*/)
                            {
                                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                                g.DrawImage(bmp, 0, 0);
                                g.Flush(System.Drawing.Drawing2D.FlushIntention.Flush);
                            }
                        }
                    }

                    #endregion



                    showImagePanel.Image = showImage;
                }
                catch (Exception)
                {

                }

                /*
                 * 
                #region 保存图片模块
                if (IsSaveing)
                {
                    ImageFormat saveformat;
                    switch (format)
                    {
                        case ImgFormat.bmp:
                            saveformat = ImageFormat.Bmp;
                            break;
                        case ImgFormat.jpg:
                            saveformat = ImageFormat.Jpeg;
                            break;
                        case ImgFormat.png:
                            saveformat = ImageFormat.Png;
                            break;
                        default:
                            saveformat = ImageFormat.Png;
                            break;
                    }
                    getFilePre();
                    try
                    {
                        if (IsRestore)
                        {
                            Image img = GetSourceImg();

                            #region 原代码

                            //相片状态
                            //if (IsOK)//OK
                            //{
                            //    if (IsSaveOK)
                            //    {
                            //        img.Save(PathOK.ToString() + "." + format, saveformat);
                            //    }
                            //    else
                            //    {
                            //        if (IsSaveNG)
                            //        {
                            //            img.Save(FilePrefix.ToString() + "." + format, saveformat);
                            //        }
                            //    }
                            //}
                            //else     //NG
                            //{
                            //    if (IsSaveNG)
                            //    {
                            //        img.Save(PathNG.ToString() + "." + format, saveformat);
                            //    }
                            //    else
                            //    {
                            //        if (IsSaveOK)
                            //        {
                            //            img.Save(FilePrefix.ToString() + "." + format, saveformat);
                            //        }
                            //    }
                            //}

                            #endregion

                            switch (ImgStatus)
                            {
                                case -2:
                                    if (IsSaveWarning)
                                    {
                                        img.Save(PathWarning.ToString() + "." + format, saveformat);
                                    }
                                    else
                                    {
                                        if ((!IsSaveOK) && (!IsSaveNG))
                                        {
                                            img.Save(FilePrefix.ToString() + "." + format, saveformat);
                                        }
                                    }
                                    break;
                                case -1://NG
                                    if (IsSaveNG)
                                    {
                                        img.Save(PathNG.ToString() + "." + format, saveformat);
                                    }
                                    else
                                    {
                                        if ((!IsSaveOK) && (!IsSaveWarning))
                                        {
                                            img.Save(FilePrefix.ToString() + "." + format, saveformat);
                                        }
                                    }
                                    break;
                                case 0://OK
                                    if (IsSaveOK)
                                    {
                                        img.Save(PathOK.ToString() + "." + format, saveformat);
                                    }
                                    else
                                    {
                                        if ((!IsSaveNG) && (!IsSaveWarning))
                                        {
                                            img.Save(FilePrefix.ToString() + "." + format, saveformat);
                                        }
                                    }
                                    break;
                                default:
                                    break;
                            }

                            img.Dispose();
                        }
                        else
                        {
                            #region 原代码

                            ////Bitmap bmp = new Bitmap(currentImage);if (IsDistinguish)
                            //if (IsDistinguish)
                            //{
                            //    if (IsOK)
                            //    {
                            //        if (!(IsSaveOK || IsSaveNG))
                            //        {
                            //            currentImage.Save(PathOK.ToString() + "." + format, saveformat);
                            //        }
                            //        else
                            //        {
                            //            if (IsSaveOK)
                            //                currentImage.Save(PathOK.ToString() + "." + format, saveformat);
                            //        }
                            //    }
                            //    else
                            //    {
                            //        if (!(IsSaveOK || IsSaveNG))
                            //        {
                            //            currentImage.Save(PathNG.ToString() + "." + format, saveformat);
                            //        }
                            //        else
                            //        {
                            //            if (IsSaveNG)
                            //                currentImage.Save(PathNG.ToString() + "." + format, saveformat);
                            //        }
                            //    }
                            //}
                            //else
                            //{
                            //    if (!(IsSaveOK || IsSaveNG))
                            //    {
                            //        currentImage.Save(FilePrefix.ToString() + "." + format, saveformat);
                            //    }
                            //    else
                            //    {
                            //        if (IsOK)
                            //        {
                            //            if (IsSaveOK)
                            //                currentImage.Save(FilePrefix.ToString() + "." + format, saveformat);
                            //        }
                            //        else
                            //        {
                            //            if (IsSaveNG)
                            //                currentImage.Save(FilePrefix.ToString() + "." + format, saveformat);
                            //        }
                            //    }
                            //}
                            //相片状态
                            //if (IsOK)//OK
                            //{
                            //    if (IsSaveOK)
                            //    {
                            //        currentImage.Save(PathOK.ToString() + "." + format, saveformat);
                            //    }
                            //    else
                            //    {
                            //        if (!IsSaveNG)
                            //        {
                            //            currentImage.Save(FilePrefix.ToString() + "." + format, saveformat);
                            //        }
                            //    }
                            //}
                            //else     //NG
                            //{
                            //    if (IsSaveNG)
                            //    {
                            //        currentImage.Save(PathNG.ToString() + "." + format, saveformat);
                            //    }
                            //    else
                            //    {
                            //        if (!IsSaveOK)
                            //        {
                            //            currentImage.Save(FilePrefix.ToString() + "." + format, saveformat);
                            //        }
                            //    }
                            //}
                            #endregion

                            switch (ImgStatus)
                            {
                                case -2:
                                    if (IsSaveWarning)
                                    {
                                        currentImage.Save(PathWarning.ToString() + "." + format, saveformat);
                                    }
                                    else
                                    {
                                        if ((!IsSaveOK) && (!IsSaveNG))
                                        {
                                            currentImage.Save(FilePrefix.ToString() + "." + format, saveformat);
                                        }
                                    }
                                    break;
                                case -1:
                                    if (IsSaveNG)
                                    {
                                        currentImage.Save(PathNG.ToString() + "." + format, saveformat);
                                    }
                                    else
                                    {
                                        if (((!IsSaveOK)) && ((!IsSaveWarning)))
                                        {
                                            currentImage.Save(FilePrefix.ToString() + "." + format, saveformat);
                                        }
                                    }
                                    break;
                                case 0:
                                    if (IsSaveOK)
                                    {
                                        currentImage.Save(PathOK.ToString() + "." + format, saveformat);
                                    }
                                    else
                                    {
                                        if ((!IsSaveNG) && (!IsSaveWarning))
                                        {
                                            currentImage.Save(FilePrefix.ToString() + "." + format, saveformat);
                                        }
                                    }
                                    break;
                                default:
                                    break;
                            }

                            
                            //currentImage.Save(FilePrefix + "_" + count++.ToString() + "." + format, saveformat);
                            //bmp.Dispose();
                        }
                    }
                    catch (Exception ex)
                    {
                        LoggHelper.WriteLog("图像显示异常", ex);
                    }
                    
                
                    
                }
                #endregion
                
                */
                //showImagePanel.Image = GetSourceImg();
            }
        }

        public void GetFilePre()
        {
            getFilePre();
        }

        public void InitCameraInfo()
        {
            FilePrefix = "";
            CameraIP = "0.0.0.0";
            CameraName = "";
            Port = 0;
            ImgWidth = -1;
            ImgHeight = -1;
            ImgSection = -1;
            Roi_height = -1;
            Roi_width = -1;
            Roi_x = -1;
            Roi_y = -1;
            GoodCount = 0;
            BadCount = 0;
            CycleTime = 0;
            format = (ImgFormat)1;
            rotate = (RotateFlipType)0;
            CmosWidth = -1;
            CmosHeight = -1;
            IsSaveing = false;
            IsRestore = false;

            camInfo = new CameraInfo();
            camInfo.CameraIp = CameraIP;
            camInfo.CameraName = CameraName;
            camInfo.RoiX = Roi_x.ToString();
            camInfo.RoiY = Roi_y.ToString();
            camInfo.RoiHeight = Roi_height.ToString();
            camInfo.RoiWidth = Roi_width.ToString();
            camInfo.GoodCount = GoodCount.ToString();
            camInfo.BadCount = BadCount.ToString();
            camInfo.CycleTime = CycleTime.ToString();

            VCZcameraInfo["CameraIP"] = CameraIP;
            VCZcameraInfo["CameraName"] = CameraName;
            VCZcameraInfo["Roi_x"] = Roi_x.ToString();
            VCZcameraInfo["Roi_y"] = Roi_y.ToString();
            VCZcameraInfo["Roi_height"] = Roi_height.ToString();
            VCZcameraInfo["Roi_width"] = Roi_width.ToString();
            VCZcameraInfo["GoodCount"] = GoodCount.ToString();
            VCZcameraInfo["BadCount"] = BadCount.ToString();
            VCZcameraInfo["CycleTime"] = CycleTime.ToString();
            VCZcameraInfo["ImgWidth"] = ImgWidth.ToString();
            VCZcameraInfo["ImgHeight"] = ImgHeight.ToString();
            VCZcameraInfo["ImgSection"] = ImgSection.ToString();
            VCZcameraInfo["format"] = format.ToString();
        }

        public Image GetSourceImg(Image img = null)
        {
            if (CmosHeight < 1 || CmosWidth < 1)
            {
                if (img == null)
                {
                    return new Bitmap(currentImage);
                }
                else
                {
                    return new Bitmap(img);
                }
            }
            Bitmap bmp;
            Bitmap now;
            if (img == null)
            {
                now = new Bitmap(currentImage);
            }
            else
            {
                now = new Bitmap(img);
            }
            switch (ImgResolution)
            {
                case 1:
                    bmp = new Bitmap(CmosWidth, CmosHeight, PixelFormat.Format24bppRgb);
                    break;
                case 2:
                    bmp = new Bitmap(CmosWidth / 2, CmosHeight / 2, PixelFormat.Format24bppRgb);
                    break;
                case 3:
                    bmp = new Bitmap(CmosWidth / 4, CmosHeight / 4, PixelFormat.Format24bppRgb);
                    break;
                default:
                    bmp = new Bitmap(CmosWidth, CmosHeight, PixelFormat.Format24bppRgb);
                    break;
            }

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                switch (ImgResolution)
                {
                    case 1:
                        g.DrawImage(now, Roi_x, Roi_y);
                        break;
                    case 2:
                        g.DrawImage(now, Roi_x / 2, Roi_y / 2);
                        break;
                    case 3:
                        g.DrawImage(now, Roi_x / 4, Roi_y / 4);
                        break;
                    default:
                        g.DrawImage(now, Roi_x, Roi_y);
                        break;
                }
            }
            return bmp;
        }

    }
}
