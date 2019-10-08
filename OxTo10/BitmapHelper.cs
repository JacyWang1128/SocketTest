using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace OxTo10
{
    public static class BitmapHelper
    {
        public static Bitmap GetBitmapFromBuffer(Int32 Width,Int32 Height,Byte[] buffer)
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

    }
}
