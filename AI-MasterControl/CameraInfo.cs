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

        /// <summary>
        /// bad计数
        /// </summary>
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
        /// <summary>
        /// good计数
        /// </summary>
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
        /// <summary>
        /// 循环时间
        /// </summary>
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
        /// <summary>
        /// 相机IP
        /// </summary>
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
        /// <summary>
        /// 相机名称
        /// </summary>
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
        /// <summary>
        /// ROI高度
        /// </summary>
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
        /// <summary>
        /// ROI宽度
        /// </summary>
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
        /// <summary>
        /// ROI横坐标
        /// </summary>
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
        /// <summary>
        /// ROI纵坐标
        /// </summary>
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
