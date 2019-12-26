using System;
using System.Collections.Generic;
using System.Text;

namespace AI_Master_SharedMemory
{
    public class DisplayPictureboxInfo
    {
        private Int32 _index;

        private Int32 _x;

        private Int32 _y;

        private Int32 _width;

        private Int32 _height;

        public DisplayPictureboxInfo()
        {
            X = 0;
            Y = 0;
            Width = 320;
            Height = 256;
        }

        public Int32 Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public Int32 Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public Int32 Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public Int32 X
        {
            get { return _x; }
            set { _x = value; }
        }

        public Int32 Index
        {
            get { return _index; }
            set { _index = value; }
        }
    }
}
