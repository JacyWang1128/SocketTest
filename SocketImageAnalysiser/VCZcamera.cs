using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SocketImageAnalysiser
{
    public enum ImgFormat
    {
        BMP = 1,
        JPEG = 2,
        PNG = 3
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
        public MessageHandle msg;
        public UdpHelper uh;
        public UdpPackageHelper uph;
        public BitmapHelper bh;

        //属性声明
        private String _cameraName;
        private String _cameraIP;
        private Int32 _imgWidth;
        private Int32 _imgHeight;
        private Int32 _roi_x;
        private Int32 _roi_y;
        private Int32 _roi_width;
        private Int32 _roi_height;
        private UInt32 _goodCount;
        private UInt32 _badCount;
        private UInt32 _cycleTime;
        public RotateFlipType rotate;
        public ImgFormat format;
        public ColorDepth colorDepth;

        private Boolean _isShowing = true;
        private Boolean _isNewPhoto = false;

        public Panel showImagePanel;

        //当前图像
        public Bitmap currentImage;
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
        #endregion
        #endregion

        public VCZcamera(MessageHandle msgh, Panel pl,Int32 imgWidth = 320, Int32 imgHeight = 256)
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

        public void Start(Int32 port)
        {
            Thread t1 = new Thread(uh.ListeningPort);
            Thread t2 = new Thread(uph.UdpPackageAnalysis);
            Thread t3 = new Thread(StartShowingInfo);
            Thread t4 = new Thread(bh.StartAnalysising);
            t1.IsBackground = true;
            t2.IsBackground = true;
            t3.IsBackground = true;
            t3.IsBackground = true;
            t1.Start(port);
            t2.Start();
            t3.Start();
            t4.Start();
        }

        public void Stop()
        {
            uh.StopListening();
            uph.StopAnalysising();
            IsShowing = false;
            bh.StopAnalysising();
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
            msg($"当前发送{GoodCount}!");
            msg($"当前解析{count}!");
            count++;
            showImagePanel.BackgroundImage = currentImage;
        }

        public void InitCameraInfo()
        {
            CameraIP = "0.0.0.0";
            CameraName = "";
            ImgWidth = -1;
            ImgHeight = -1;
            Roi_height = -1;
            Roi_width = -1;
            Roi_x = -1;
            Roi_y = -1;
            GoodCount = 0;
            BadCount = 0;
            CycleTime = 0;
            format = (ImgFormat)1;
            rotate = (RotateFlipType)0;
        }

    }
}
