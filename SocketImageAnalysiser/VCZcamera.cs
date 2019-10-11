using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

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
        MessageHandle msg;
        UdpHelper uh;
        UdpPackageHelper uph;
        BitmapHelper bh;

        //属性声明
        String CameraName;
        String CameraIP;
        Int32 imgWidth;
        Int32 imgHeight;
        Int32 roi_x;
        Int32 roi_y;
        Int32 roi_widht;
        Int32 roi_height;
        UInt32 goodCount;
        UInt32 badCount;
        UInt32 cycleTime;
        ImgFormat format;
        ColorDepth colorDepth;

        //当前图像
        Bitmap currentImage;
        #endregion

        public VCZcamera(MessageHandle msgh,Int32 imgWidth = 320,Int32 imgHeight = 256)
        {
            msg = msgh;
            uh = new UdpHelper(msg);
            //uph = new UdpPackageHelper(uh.UdpPackageBuffer);
            //bh = new BitmapHelper();
        }

    }
}
