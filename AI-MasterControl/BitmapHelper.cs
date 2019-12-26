using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace AI_MasterControl
{
    public class BitmapHelper
    {
        Queue<KeyValuePair<ImageInfo, Byte[]>> ImgBufferQueue;
        MessageHandle msgh;
        VCZcamera camera;
        private Boolean _isAnalysising = true;
        Queue<KeyValuePair<ImageInfo, Image>> SaveImageQueue;

        //static Byte[] header8;

        public BitmapHelper(Queue<KeyValuePair<ImageInfo, Byte[]>> imgbuffer, MessageHandle msgh, VCZcamera camera)
        {
            this.msgh = msgh;
            this.camera = camera;
            ImgBufferQueue = imgbuffer;
            SaveImageQueue = new Queue<KeyValuePair<ImageInfo, Image>>();
            //测试用
            //header8 = new byte[1078];
            //var bytes = new FileStream(@"C: \Users\Administrator\Desktop\图像保存测试\10_2019_10_28_10_55_10_601.bmp", FileMode.Open, FileAccess.Read).Read(header8,0,1078);
        }

        #region 测试用
        /*static Byte[] header = new Byte[] { 0x42  ,0x4D  ,0x36  ,0x04  ,0x30  ,0x00  ,0x00  ,0x00   ,0x00  ,0x00  ,0x36  ,0x04  ,0x00  ,0x00  ,0x28  ,0x00,
 0x00  ,0x00  ,0x00  ,0x08  ,0x00  ,0x00  ,0x00  ,0x06   ,0x00  ,0x00  ,0x01  ,0x00  ,0x08  ,0x00  ,0x00  ,0x00,
 0x00  ,0x00  ,0x00  ,0x00  ,0x00  ,0x00  ,0x00  ,0x00   ,0x00  ,0x00  ,0x00  ,0x00  ,0x00  ,0x00  ,0x00  ,0x00,
 0x00 ,0x00 ,0x00 ,0x00 ,0x00 ,0x00 };
        static Byte[] header24 = new Byte[]{0x42 ,0x4D ,0x36 ,0x00 ,0x90 ,0x00 ,0x00 ,0x00  ,
                                          0x00 ,0x00 ,0x36 ,0x00 ,0x00 ,0x00 ,0x28 ,0x00,
                                          0x00 ,0x00 ,0x00 ,0x08 ,0x00 ,0x00 ,0x00 ,0x06  ,
                                          0x00 ,0x00 ,0x01 ,0x00 ,0x18 ,0x00 ,0x00 ,0x00,
                                          0x00 ,0x00 ,0x00 ,0x00 ,0x90 ,0x00 ,0xC4 ,0x0E  ,
                                          0x00 ,0x00 ,0xC4 ,0x0E ,0x00 ,0x00 ,0x00 ,0x00,
                                          0x00 ,0x00 ,0x00 ,0x00 ,0x00 ,0x00 };*/
        #endregion

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

        public BitmapHelper(Queue<KeyValuePair<ImageInfo, Byte[]>> imgbuffer, MessageHandle msgh)
        {
            ImgBufferQueue = imgbuffer;
            this.msgh = msgh;
        }

        public void StopAnalysising()
        {
            IsAnalysising = false;
        }

        Stopwatch sw = new Stopwatch();

        public void ThreadSaveImage()
        {
            while (_isAnalysising)
            {
                if (SaveImageQueue.Count > 0)
                {
                    var temp = SaveImageQueue.Dequeue();
                    #region 保存图片模块
                    if (camera.IsSaveing)
                    {
                        ImageFormat saveformat;
                        Image currentImage;
                        if (temp.Value != null)
                        {


                            lock (temp.Value)
                            {
                                currentImage = (Image)temp.Value.Clone();
                            }

                            switch (temp.Key.ImgFormat)
                            {
                                case 1:
                                    saveformat = ImageFormat.Bmp;
                                    break;
                                case 2:
                                    saveformat = ImageFormat.Jpeg;
                                    break;
                                case 3:
                                    saveformat = ImageFormat.Png;
                                    break;
                                default:
                                    saveformat = ImageFormat.Png;
                                    break;
                            }
                            camera.GetFilePre();
                            try
                            {
                                if (camera.IsRestore)
                                {
                                    Image img = camera.GetSourceImg();
                                    switch (camera.ImgStatus)
                                    {
                                        case -2:
                                            if (camera.IsSaveWarning)
                                            {
                                                img.Save(camera.PathWarning.ToString() + "." + (ImgFormat)temp.Key.ImgFormat, saveformat);
                                            }
                                            else
                                            {
                                                if ((!camera.IsSaveOK) && (!camera.IsSaveNG))
                                                {
                                                    img.Save(camera.FilePrefix.ToString() + "." + (ImgFormat)temp.Key.ImgFormat, saveformat);
                                                }
                                            }
                                            break;
                                        case -1://NG
                                            if (camera.IsSaveNG)
                                            {
                                                img.Save(camera.PathNG.ToString() + "." + (ImgFormat)temp.Key.ImgFormat, saveformat);
                                            }
                                            else
                                            {
                                                if ((!camera.IsSaveOK) && (!camera.IsSaveWarning))
                                                {
                                                    img.Save(camera.FilePrefix.ToString() + "." + (ImgFormat)temp.Key.ImgFormat, saveformat);
                                                }
                                            }
                                            break;
                                        case 0://OK
                                            if (camera.IsSaveOK)
                                            {
                                                img.Save(camera.PathOK.ToString() + "." + (ImgFormat)temp.Key.ImgFormat, saveformat);
                                            }
                                            else
                                            {
                                                if ((!camera.IsSaveNG) && (!camera.IsSaveWarning))
                                                {
                                                    img.Save(camera.FilePrefix.ToString() + "." + (ImgFormat)temp.Key.ImgFormat, saveformat);
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
                                    switch (camera.ImgStatus)
                                    {
                                        case -2:
                                            if (camera.IsSaveWarning)
                                            {
                                                currentImage.Save(camera.PathWarning.ToString() + "." + (ImgFormat)temp.Key.ImgFormat, saveformat);
                                            }
                                            else
                                            {
                                                if ((!camera.IsSaveOK) && (!camera.IsSaveNG))
                                                {
                                                    currentImage.Save(camera.FilePrefix.ToString() + "." + (ImgFormat)temp.Key.ImgFormat, saveformat);
                                                }
                                            }
                                            break;
                                        case -1:
                                            if (camera.IsSaveNG)
                                            {
                                                currentImage.Save(camera.PathNG.ToString() + "." + (ImgFormat)temp.Key.ImgFormat, saveformat);
                                            }
                                            else
                                            {
                                                if (((!camera.IsSaveOK)) && ((!camera.IsSaveWarning)))
                                                {
                                                    currentImage.Save(camera.FilePrefix.ToString() + "." + (ImgFormat)temp.Key.ImgFormat, saveformat);
                                                }
                                            }
                                            break;
                                        case 0:
                                            if (camera.IsSaveOK)
                                            {
                                                currentImage.Save(camera.PathOK.ToString() + "." + (ImgFormat)temp.Key.ImgFormat, saveformat);
                                            }
                                            else
                                            {
                                                if ((!camera.IsSaveNG) && (!camera.IsSaveWarning))
                                                {
                                                    currentImage.Save(camera.FilePrefix.ToString() + "." + (ImgFormat)temp.Key.ImgFormat, saveformat);
                                                }
                                            }
                                            break;
                                        default:
                                            break;
                                    }

                                }
                            }

                            catch (Exception ex)
                            {
                                LoggHelper.WriteLog("图像显示异常", ex);
                            }
                        }
                        if (SaveImageQueue.Count > 10)
                        {
                            while (SaveImageQueue.Count > 10)
                            {
                                SaveImageQueue.Dequeue();
                            }
                        }
                    }

                    #endregion
                }
                Thread.Sleep(1);
            }
        }

        public void StartAnalysising()
        {
            IsAnalysising = true;
            //msgh("开始解析图像文件");
            sw.Start();
            Thread t = new Thread(ThreadSaveImage);
            t.Priority = ThreadPriority.Lowest;
            t.Start();
            while (_isAnalysising)
            {
                try
                {

                    if (ImgBufferQueue.Count > 0)
                    {
                        TimeSpan ts = sw.Elapsed;
                        var temp = ImgBufferQueue.Dequeue();
                        Byte[] buffer = temp.Value;
                        //Byte[] buffer = ImgBufferQueue.Dequeue().Value;///////////////////////////////////////////////在这停顿
                        ImageFormat format = GetImgbufferFormat(buffer);
                        if (camera.format == ImgFormat.bmp)//format == ImageFormat.Bmp)
                        {
                            switch (camera.colorDepth)
                            {
                                case ColorDepth.GrayScale:
                                    Image imgGrayBmp = Bit8To24(GetGrayscaleBitmapFromBuffer(camera.ImgWidth, camera.ImgHeight, buffer));
                                    Bitmap bmpGrayBmp = new Bitmap(imgGrayBmp);
                                    SaveImageQueue.Enqueue(new KeyValuePair<ImageInfo, Image>(temp.Key, new Bitmap(bmpGrayBmp)));
                                    camera.currentImage = new Bitmap(bmpGrayBmp);
                                    imgGrayBmp.Dispose();
                                    camera.IsNewPhoto = true;
                                    break;
                                case ColorDepth.RGB:
                                    Image imgRGBBmp = GetRGBBitmapFromBufferWithMemory(camera.ImgWidth, camera.ImgHeight, buffer);
                                    Bitmap bmpRGBBmp = new Bitmap(imgRGBBmp);
                                    SaveImageQueue.Enqueue(new KeyValuePair<ImageInfo, Image>(temp.Key, new Bitmap(bmpRGBBmp)));
                                    camera.currentImage = new Bitmap(bmpRGBBmp);
                                    imgRGBBmp.Dispose();
                                    camera.IsNewPhoto = true;
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            Image img = GetImageInBuffer(buffer);
                            Bitmap bmp = new Bitmap(img);
                            camera.currentImage = bmp;
                            SaveImageQueue.Enqueue(new KeyValuePair<ImageInfo, Image>(temp.Key, new Bitmap(bmp)));
                            camera.IsNewPhoto = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    LoggHelper.WriteLog("图片解析错误", ex);
                    //camera.IsNewPhoto = false;
                }
                Thread.Sleep(1);
            }
        }

        private ImageFormat GetImgbufferFormat(Byte[] buffer)
        {
            Int32 len = buffer.Length;
            if (buffer[4] == 0xff && buffer[5] == 0xd8 && buffer[6] == 0xff)
            {
                return ImageFormat.Jpeg;
            }
            else if (buffer[4] == 0x89 && buffer[5] == 0x50 && buffer[6] == 0x4e && buffer[7] == 0x47)
            {
                return ImageFormat.Png;
            }
            else
            {
                return ImageFormat.Bmp;
            }
        }

        public void SaveBitmap(String path, Int32 width, Int32 height, Byte[] imgbuffer)
        {
            Bitmap bmp = GetRGBBitmapFromBufferWithMemory(width, height, imgbuffer);
            bmp.Save(path, ImageFormat.Bmp);
        }

        //PNG、JPGE
        public Image GetImageInBuffer(Byte[] buffer)
        {
            Image img;
            using (MemoryStream ms = new MemoryStream())
            {
                ms.Write(buffer, 4, buffer.Length - 4);
                img = Image.FromStream(ms);
            }
            return img;
        }

        #region 测试用代码
        /*
        //临时BMP创建流
        public static Stream GetBMPStream(Byte[] buffer)
        {
            List<Byte> imgbytes = new List<Byte>();
            imgbytes.AddRange(header8);
            imgbytes.AddRange(buffer);
            var temp = imgbytes.ToArray();
            MemoryStream ms = new MemoryStream();
            ms.Seek(0, SeekOrigin.Begin);
            ms.Write(temp, 0, temp.Length);
            //ms.Write(buffer,0,buffer.Length);
            return ms;
        }
        public Bitmap BytesToImg(Int32 Width, Int32 Height, byte[] bytes)
        {

            Bitmap bmp = new Bitmap(Width, Height, PixelFormat.Format8bppIndexed);
            BitmapData bd = bmp.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
            IntPtr ptr = bd.Scan0;
            int bmpLen = bd.Stride * bd.Height;
            Marshal.Copy(bytes, 0, ptr, bmpLen);
            bmp.UnlockBits(bd);
            return bmp;
        }
        */
        #endregion

        //BMP RGB内存拷贝法
        public static Bitmap GetRGBBitmapFromBufferWithMemory(Int32 Width, Int32 Height, Byte[] buffer)
        {
            Bitmap bmp = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);
            BitmapData bmpdata = bmp.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
            Int32 stride = bmpdata.Stride;
            Int32 offset = stride - (Width * 3);
            Int32 scanBytes = stride * Height;
            IntPtr iptr = bmpdata.Scan0;
            Int32 posScan = 0, posReal = 0;
            byte[] pixelValues = new byte[scanBytes];
            for (int h = 0; h < Height; h++)
            {
                for (int w = 0; w < Width; w++)
                {
                    pixelValues[posScan++] = buffer[posReal++];
                    pixelValues[posScan++] = buffer[posReal++];
                    pixelValues[posScan++] = buffer[posReal++];
                }
                posScan += offset;
            }
            System.Runtime.InteropServices.Marshal.Copy(pixelValues, 0, iptr, scanBytes);
            bmp.UnlockBits(bmpdata);
            return bmp;
        }


        //BMP Grayscale
        public static Bitmap GetGrayscaleBitmapFromBuffer(Int32 Width, Int32 Height, Byte[] buffer)
        {
            Bitmap bmp = new Bitmap(Width, Height, PixelFormat.Format8bppIndexed);
            BitmapData bmpdata = bmp.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);
            Int32 stride = bmpdata.Stride;
            Int32 offset = stride - Width;
            IntPtr iptr = bmpdata.Scan0;
            Int32 scanBytes = stride * Height;
            Int32 posScan = 0, posReal = 0;
            byte[] pixelValues = new Byte[scanBytes];
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    pixelValues[posScan++] = buffer[posReal++];
                }
                posScan += offset;
            }
            System.Runtime.InteropServices.Marshal.Copy(pixelValues, 0, iptr, scanBytes);
            bmp.UnlockBits(bmpdata);
            ColorPalette tempPalette;
            using (Bitmap tempBmp = new Bitmap(1, 1, PixelFormat.Format8bppIndexed))
            {
                tempPalette = tempBmp.Palette;
            }
            for (int i = 0; i < 256; i++)
            {
                tempPalette.Entries[i] = Color.FromArgb(i, i, i);
            }
            bmp.Palette = tempPalette;
            //bmp.Save(@"C:\Users\Administrator\Desktop\CAMERA\8.bmp");
            return bmp;
        }

        public static Bitmap Bit8To24(Bitmap bmp8)
        {
            //Bitmap bmp8 = new Bitmap(filepath);
            BitmapData data8 = bmp8.LockBits(new Rectangle(0, 0, bmp8.Width, bmp8.Height), ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed);
            Bitmap bmp24 = new Bitmap(bmp8.Width, bmp8.Height, PixelFormat.Format24bppRgb);
            BitmapData data24 = bmp24.LockBits(new Rectangle(0, 0, bmp24.Width, bmp24.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
            unsafe
            {
                byte* ptr8 = (byte*)data8.Scan0.ToPointer();
                byte* ptr24 = (byte*)data24.Scan0.ToPointer();
                for (int i = 0; i < bmp8.Height; i++)
                {
                    for (int j = 0; j < bmp8.Width; j++)
                    {
                        //用8位位图的灰度值填充24位位图的R、G、B值 
                        *ptr24++ = *ptr8;
                        *ptr24++ = *ptr8;
                        *ptr24++ = *ptr8++;
                    }
                    ptr8 += data8.Stride - bmp8.Width;                    //跳过对齐字节 
                    ptr24 += data24.Stride - bmp8.Width * 3; //跳过对齐字节 
                }
            }
            bmp8.UnlockBits(data8);
            bmp24.UnlockBits(data24);
            return bmp24;
        }
    }
}
