using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AI_MasterControl
{
    public class CameraSettings
    {
        private Int32 _controlX;
        private Int32 _controlY;
        private Int32 _controlWidth;
        private Int32 _controlHeight;
        private Int32 _port;
        private Int32 _cmos_Height;
        private Int32 _cmos_Width;
        private String _cameraIP;
        private String _preString;
        private Boolean _isIpAddress;
        private Boolean _isCameraName;
        private Boolean _isDate;
        private Boolean _isRestore;
        private Boolean _isAutoSaving;
        private RotateFlipType _rotateType;
        private Color _infoColor;
        private String _savePath;

        #region 封装字段
        public int ControlX
        {
            get
            {
                return _controlX;
            }

            set
            {
                _controlX = value;
            }
        }

        public int ControlY
        {
            get
            {
                return _controlY;
            }

            set
            {
                _controlY = value;
            }
        }

        public int ControlWidth
        {
            get
            {
                return _controlWidth;
            }

            set
            {
                _controlWidth = value;
            }
        }

        public int ControlHeight
        {
            get
            {
                return _controlHeight;
            }

            set
            {
                _controlHeight = value;
            }
        }

        public int Port
        {
            get
            {
                return _port;
            }

            set
            {
                _port = value;
            }
        }

        public int Cmos_Heigt
        {
            get
            {
                return _cmos_Height;
            }

            set
            {
                _cmos_Height = value;
            }
        }

        public int Cmos_Width
        {
            get
            {
                return _cmos_Width;
            }

            set
            {
                _cmos_Width = value;
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

        public string PreString
        {
            get
            {
                return _preString;
            }

            set
            {
                _preString = value;
            }
        }

        public bool IsRestore
        {
            get
            {
                return _isRestore;
            }

            set
            {
                _isRestore = value;
            }
        }

        public bool IsAutoSaving
        {
            get
            {
                return _isAutoSaving;
            }

            set
            {
                _isAutoSaving = value;
            }
        }

        public RotateFlipType RotateType
        {
            get
            {
                return _rotateType;
            }

            set
            {
                _rotateType = value;
            }
        }

        public Color InfoColor
        {
            get
            {
                return _infoColor;
            }

            set
            {
                _infoColor = value;
            }
        }

        public string SavePath
        {
            get
            {
                return _savePath;
            }

            set
            {
                _savePath = value;
            }
        }

        public bool IsIpAddress
        {
            get
            {
                return _isIpAddress;
            }

            set
            {
                _isIpAddress = value;
            }
        }

        public bool IsCameraName
        {
            get
            {
                return _isCameraName;
            }

            set
            {
                _isCameraName = value;
            }
        }

        public bool IsDate
        {
            get
            {
                return _isDate;
            }

            set
            {
                _isDate = value;
            }
        }
        #endregion

        public CameraSettings()
        {
            ControlX = 0;
            ControlY = 0;
            ControlWidth = 0;
            ControlHeight = 0;
            Port = 0;
            Cmos_Width = 0;
            Cmos_Heigt = 0;
            CameraIP = "0.0.0.0";
            PreString = "";
            IsRestore = false;
            IsAutoSaving = false; ;
            RotateType = RotateFlipType.RotateNoneFlipNone;
            InfoColor = Color.White;
            IsIpAddress = false;
            IsCameraName = true;
            IsDate = false;
        }

        public CameraSettings(Int32 x, Int32 y, Int32 width, Int32 height, Int32 cmos_width, Int32 cmos_height, String ip, Int32 port, String preStr, Boolean isIpaddress,Boolean isCameraname,Boolean isDatetime, Boolean isRestor, Boolean isAutoSave, RotateFlipType rft, Color infoColor)
        {
            ControlX = x;
            ControlY = y;
            ControlWidth = width;
            ControlHeight = height;
            Port = port;
            Cmos_Width = cmos_width;
            Cmos_Heigt = cmos_height;
            CameraIP = ip;
            PreString = preStr;
            IsRestore = isRestor;
            IsAutoSaving = isAutoSave;
            RotateType = rft;
            InfoColor = infoColor;
            IsIpAddress = isIpaddress;
            IsCameraName = isCameraname;
            IsDate = isDatetime;
        }
    }
}
