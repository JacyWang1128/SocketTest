using System;
using System.Collections.Generic;
using System.Text;

namespace AI_MasterControl
{
    public class ImageInfo
    {
        private Int32 _imgStatus;
        private Int32 _imgFormat;

        public ImageInfo(Int32 status,Int32 format)
        {
            ImgStatus = status;
            ImgFormat = format;
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

        public int ImgFormat //1bmp         2jpg          3png
        {
            get
            {
                return _imgFormat;
            }

            set
            {
                _imgFormat = value;
            }
        }
    }
}
