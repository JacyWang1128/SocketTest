using System;
using System.Collections.Generic;
using System.Text;

namespace OxTo10
{
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
        List<Byte> ImgBuffer;

        public UdpPackageHelper()
        {
            ImgBuffer = new List<byte>();
        }

        public static Byte[] GetSegmentInArray(Byte[] source, Int32 Start, Int32 Count)
        {
            Byte[] t = new Byte[Count];

            for (int i = 0; i < Count; i++)
            {
                t[i] = source[Start + i];
            }

            return t;
        }

        public void UdpPackageAnalysis(Byte[] bytes)
        {
            Int32 len = bytes.Length;
            Int16 iPackageNum = BitConverter.ToInt16(bytes, 0);
            Int16 iPackageCount = BitConverter.ToInt16(bytes, 2);
            Int32 iImgNum = BitConverter.ToInt32(bytes, 4);
            if(iPackageNum == 1)
            {
                ImgBuffer.Clear();
                ImgBuffer.AddRange(GetSegmentInArray(bytes, len - 52, 24));
            }
            else if(iPackageCount < iPackageNum)
            {
                ImgBuffer.AddRange(GetSegmentInArray(bytes, 28, len - 28));
                //BitmapHelper.SaveBitmap($@"C:\Users\Administrator\Desktop\CAMERA\RGB{iImgNum}.bmp", 320, 256, ImgBuffer.ToArray());
            }
            else
            {
                ImgBuffer.AddRange(GetSegmentInArray(bytes, 28, len - 28));
            }

        }
    }
}
