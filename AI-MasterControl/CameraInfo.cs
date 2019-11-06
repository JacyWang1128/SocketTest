using System;
using System.Collections.Generic;
using System.Text;

namespace AI_MasterControl
{
    /// <summary>
    /// 相机信息包
    /// </summary>
    public class CameraInfo
    {
        private String _badCount;
        private String _goodCount;
        private String _cycleTime;
        private String _cameraIp;
        private String _cameraName;
        private String _roiHeight;
        private String _roiWidth;
        private String _roiX;
        private String _roiY;

        public string BadCount
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

        public string GoodCount
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

        public string CycleTime
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

        public string CameraIp
        {
            get
            {
                return _cameraIp;
            }

            set
            {
                _cameraIp = value;
            }
        }

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

        public string RoiHeight
        {
            get
            {
                return _roiHeight;
            }

            set
            {
                _roiHeight = value;
            }
        }

        public string RoiWidth
        {
            get
            {
                return _roiWidth;
            }

            set
            {
                _roiWidth = value;
            }
        }

        public string RoiX
        {
            get
            {
                return _roiX;
            }

            set
            {
                _roiX = value;
            }
        }

        public string RoiY
        {
            get
            {
                return _roiY;
            }

            set
            {
                _roiY = value;
            }
        }
    }
}
