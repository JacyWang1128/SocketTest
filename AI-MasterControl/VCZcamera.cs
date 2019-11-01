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
        private UdpHelper uh;
        private UdpPackageHelper uph;
        private BitmapHelper bh;

        //属性声明
        private String _cameraName;
        private String _cameraIP;
        private Int32 _port;
        private Int32 _imgWidth;
        private Int32 _imgHeight;
        private Int32 _roi_x;
        private Int32 _roi_y;
        private Int32 _roi_width;
        private Int32 _roi_height;
        private UInt32 _goodCount;
        private UInt32 _badCount;
        private UInt32 _cycleTime;
        private Int32 _imgSection;
        private Int32 _imgResolution;
        public RotateFlipType rotate;
        public ImgFormat format;
        public ColorDepth colorDepth;
        public ImageFormat SaveImageFormat;
        public Boolean IsSaveing;
        public Boolean IsRestore;
        private Int32 _cmosWidth;
        private Int32 _cmosHeight;

        private Boolean _isShowing = true;
        private Boolean _isNewPhoto = false;

        public PictureBox showImagePanel;
        public String FilePrefix;
        //当前图像
        public Image currentImage;

        //当前图像信息
        public Dictionary<String, String> VCZcameraInfo = new Dictionary<string, string>();

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
        #endregion
        #endregion

        public VCZcamera(MessageHandle msgh, PictureBox pl)
        {
            InitCameraInfo();
            msg = msgh;
            uh = new UdpHelper(msgh,this);
            uph = new UdpPackageHelper(uh.UdpPackageBuffer, msgh, this);
            bh = new BitmapHelper(uph.ImgBufferQueue,msgh, this);
            showImagePanel = pl;
            //uph = new UdpPackageHelper(uh.UdpPackageBuffer);
            //bh = new BitmapHelper();
        }

        public void SetCMOS(Int32 width,Int32 height)
        {
            CmosWidth = width;
            CmosHeight = height;
        }

        public void Start()
        {
            Thread t1 = new Thread(uh.ListeningPort);
            Thread t2 = new Thread(uph.UdpPackageAnalysis);
            Thread t3 = new Thread(StartShowingInfo);
            Thread t4 = new Thread(bh.StartAnalysising);
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
            uh.StopListening();
            uph.StopAnalysising();
            IsShowing = false;
            bh.StopAnalysising();
            isReceiving = false;
        }

        public void StartShowingInfo()
        {
            IsShowing = true;
            while (IsShowing)
            {
                if (IsNewPhoto)
                {
                    NewPhotoMethod();
                    IsNewPhoto = false;
                }
                Thread.Sleep(1);
            }
        }
        Int32 count = 1;
        public void NewPhotoMethod()
        {
            //msg($"{DateTime.Now}当前队列中仍有：{uph.UdpPackageBuffer.Count}包未解析！图片缓冲区有：{uph.ImgBufferQueue.Count}张图片未解析！\n相机名称:{CameraName}，相机地址：{CameraIP}，相片宽度：{ImgWidth}，相片高度：{ImgHeight}，相片取景横坐标：（{Roi_x}，{Roi_y}）,相片取景宽度：{Roi_width}，相片取景高：{Roi_height}，相片Cycle Time：{CycleTime}，相片格式：{format.ToString()}，色彩模式：{colorDepth.ToString()}");

            VCZcameraInfo["CameraIP"] = CameraIP;
            VCZcameraInfo["CameraName"] = CameraName;
            VCZcameraInfo["Roi_x"] = Roi_x.ToString();
            VCZcameraInfo["Roi_y"] = Roi_y.ToString();
            VCZcameraInfo["Roi_height"] = Roi_height.ToString();
            VCZcameraInfo["Roi_width"] = Roi_width.ToString();
            VCZcameraInfo["GoodCount"] = GoodCount.ToString();
            VCZcameraInfo["BadCount"] = BadCount.ToString();
            VCZcameraInfo["CycleTime"] = (Convert.ToDouble(CycleTime) / 1000).ToString();
            VCZcameraInfo["ImgWidth"] = ImgWidth.ToString();
            VCZcameraInfo["ImgHeight"] = ImgHeight.ToString();
            VCZcameraInfo["ImgSection"] = ImgSection.ToString();
            VCZcameraInfo["format"] = format.ToString();
            msg(VCZcameraInfo);
            if (currentImage != null)
            {
                Bitmap showImage = new Bitmap(currentImage);
                showImage.RotateFlip(rotate);
                showImagePanel.Image = showImage;
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
                    if (IsRestore)
                    {
                        Image img = GetSourceImg();
                        img.Save(FilePrefix + count++.ToString() + "." + format, saveformat);
                        img.Dispose();
                    }
                    else
                    {
                        //Bitmap bmp = new Bitmap(currentImage);
                        currentImage.Save(FilePrefix + "_" + count++.ToString() + "." + format, saveformat);
                        //bmp.Dispose();
                    }
                }
                //showImagePanel.Image = GetSourceImg();
            }
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

        public Image GetSourceImg()
        {
            if(CmosHeight < 1 || CmosWidth < 1)
            {
                return new Bitmap(currentImage);
            }
            Bitmap bmp;
            Bitmap now = new Bitmap(currentImage);
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
            
            using(Graphics g = Graphics.FromImage(bmp))
            {
                switch (ImgResolution)
                {
                    case 1:
                        g.DrawImage(now, Roi_x, Roi_y);
                        break;
                    case 2:
                        g.DrawImage(now, Roi_x/2, Roi_y/2);
                        break;
                    case 3:
                        g.DrawImage(now, Roi_x/4, Roi_y/4);
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
