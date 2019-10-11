using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace SocketImageAnalysiser
{
    public class BitmapHelper
    {
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

        public BitmapHelper(Queue<Byte[]> imgbuffer,MessageHandle msgh)
        {
            ImgBufferQueue = imgbuffer;
            this.msgh = msgh;
        }

        public void StopAnalysising()
        {
            IsAnalysising = false;
        }

        public void StartAnalysising()
        {
            msgh("开始解析图像文件");
            while(_isAnalysising)
            {
                if(ImgBufferQueue.Count > 0)
                {
                    Byte[] buffer = ImgBufferQueue.Dequeue();
                    
                }
            }
            msgh("结束解析图像文件");
        }
        public void SaveBitmap(String path, Int32 width, Int32 height, Byte[] imgbuffer)
        {
            Bitmap bmp = GetRGBBitmapFromBufferWithMemory(width, height, imgbuffer);
            bmp.Save(path,ImageFormat.Bmp);
        }

        //内存拷贝法
        public static Bitmap GetRGBBitmapFromBufferWithMemory(Int32 Width,Int32 Height,Byte[] buffer)
        {
            Bitmap bmp = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);
            BitmapData bmpdata = bmp.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
            Int32 stride = bmpdata.Stride;
            Int32 offset = stride - (Width*3);
            Int32 scanBytes = stride * Height;
            IntPtr iptr = bmpdata.Scan0;
            Int32 posScan = 0, posReal = 0;
            byte[] pixelValues = new byte[scanBytes];
            for (int h = 0; h < Height; h++)
            {
                for (int w = 0; w < Width; w++)
                {
                    try
                    {
                        pixelValues[posScan++] = buffer[posReal++];
                        pixelValues[posScan++] = buffer[posReal++];
                        pixelValues[posScan++] = buffer[posReal++];
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                //posScan += offset;
            }
            System.Runtime.InteropServices.Marshal.Copy(pixelValues, 0, iptr, scanBytes);
            bmp.UnlockBits(bmpdata);
            return bmp;
        }

        public static Bitmap GetGrayscaleBitmapFromBuffer(Int32 Width,Int32 Height,Byte[] buffer)
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
                 for (int i = 0; i<bmp8.Height; i++) 
                 { 
                     for (int j = 0; j<bmp8.Width; j++)
                     {
                         //用8位位图的灰度值填充24位位图的R、G、B值 
                         *ptr24++ = *ptr8; 
                         *ptr24++ = *ptr8; 
                         *ptr24++ = *ptr8++; 
                     } 
                     ptr8 += data8.Stride - bmp8.Width;                    //跳过对齐字节 
                     ptr24 += data24.Stride - bmp8.Width* 3; //跳过对齐字节 
                 } 
             } 
             bmp8.UnlockBits(data8); 
             bmp24.UnlockBits(data24);
            return bmp24;
         }

        /// <summary>
        /// 指针法
        /// </summary>
        /// <param name="curBitmap"></param>
        //public static unsafe Bitmap GetRGBBitmapFromBuffer(Int32 width,Int32 height,Byte[] buffer)
        //{
        //    Bitmap bmp = new Bitmap(width, height, PixelFormat.Format24bppRgb);
        //    Rectangle rect = new Rectangle(0, 0, width, height);
        //    BitmapData bmpData = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);//curBitmap.PixelFormat
        //    byte temp = 0;
        //    int w = bmpData.Width;
        //    int h = bmpData.Height;
        //    int offset = bmpData.Stride - bmpData.Width * 3;//每行读取到最后“有用”数据时，跳过未使用空间XX
        //    byte* ptr = (byte*)(bmpData.Scan0);
        //    for (int i = 0; i < h; i++)
        //    {
        //        for (int j = 0; j < w; j++)
        //        {
        //            ptr[0] = buffer[temp];
        //            ptr[1] = buffer[temp + 1];
        //            ptr[2] = buffer[temp + 2];
        //            ptr +=3;
        //            temp += 3;
        //            //ptr[temp] = buffer[temp++];
        //            //ptr[temp] = buffer[temp++];
        //        }
        //        ptr += offset;
        //    }
        //    bmp.UnlockBits(bmpData);
        //    return bmp;
        //}
    }
}
