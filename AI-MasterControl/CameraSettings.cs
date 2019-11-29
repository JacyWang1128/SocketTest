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
        private Boolean _isDistinguished;
        private Boolean _isSaveNG;
        private Boolean _isSaveOK;
        private Boolean _isSaveWarning;
        private RotateFlipType _rotateType;
        private Color _infoColor;
        private String _preStringOK;
        private String _preStringNG;
        private String _preStringWarning;

        #region 封装字段
        /// <summary>
        /// AIMaster控件左上角的横坐标x
        /// </summary>
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
        /// <summary>
        /// AIMaster控件左上角的纵坐标y
        /// </summary>
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
        /// <summary>
        /// AIMaster控件的宽度
        /// </summary>
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
        /// <summary>
        /// AIMaster控件的高度
        /// </summary>
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
        /// <summary>
        /// AIMaster控件监听的端口号
        /// </summary>
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
        /// <summary>
        /// AIMaster相机CMOS的分辨率高度
        /// </summary>
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
        /// <summary>
        /// AIMaster相机CMOS的分辨率宽度
        /// </summary>
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
        /// <summary>
        /// AIMaster相机的IP地址
        /// </summary>
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
        /// <summary>
        /// AIMaster相机的保存前缀（包括路径，否则为相对路径）
        /// </summary>
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
        /// <summary>
        /// AIMaster控件是否根据CMOS设置大小保存复原相片（true为修复，false为不修复）
        /// </summary>
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
        /// <summary>
        /// AIMaster控件是否保存照片（true为修复，false为不修复）
        /// </summary>
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
        /// <summary>
        /// AIMaster控件显示照片的旋转角度
        /// </summary>
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
        /// <summary>
        /// AIMaster控件在全屏显示时相机信息水印的颜色
        /// </summary>
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
        /// <summary>
        /// AIMaster控件保存照片文件时文件名是否加入IP地址（在前缀之后）（true为是，false为否）（顺序为IP_NAME_DATE)
        /// </summary>
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
        /// <summary>
        /// AIMaster控件保存照片文件时文件名是否加入相机名称（在前缀之后）（true为是，false为否）（顺序为IP_NAME_DATE)
        /// </summary>
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
        /// <summary>
        /// AIMaster控件保存照片文件时文件名是否加入保存时间（yyyy_MM_dd_hh_MM_ss_ffff）（在前缀之后）（true为是，false为否）（顺序为IP_NAME_DATE)
        /// </summary>
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
        /// <summary>
        /// AIMaster控件保存照片文件时文件名是否区分OK和NG并保存在相应文件夹中，文件夹自动生成（true为是，false为否）
        /// </summary>
        public bool IsDistinguished
        {
            get
            {
                return _isDistinguished;
            }

            set
            {
                _isDistinguished = value;
            }
        }
        /// <summary>
        /// 设置OK照片的保存前缀（包括路径）
        /// </summary>
        public string PreStringOK
        {
            get
            {
                return _preStringOK;
            }

            set
            {
                _preStringOK = value;
            }
        }
        /// <summary>
        /// 设置NG照片的保存前缀（包括路径）
        /// </summary>
        public string PreStringNG
        {
            get
            {
                return _preStringNG;
            }

            set
            {
                _preStringNG = value;
            }
        }
        /// <summary>
        /// AIMaster控件是否保存NG文件(仅在区分OK/NG时有效)（true为是，false为否）
        /// </summary>
        public bool IsSaveNG
        {
            get
            {
                return _isSaveNG;
            }

            set
            {
                _isSaveNG = value;
            }
        }
        /// <summary>
        /// AIMaster控件是否保存OK文件(仅在区分OK/NG时有效)（true为是，false为否）
        /// </summary>
        public bool IsSaveOK
        {
            get
            {
                return _isSaveOK;
            }

            set
            {
                _isSaveOK = value;
            }
        }

        public bool IsSaveWarning
        {
            get
            {
                return _isSaveWarning;
            }

            set
            {
                _isSaveWarning = value;
            }
        }

        public string PreStringWarning
        {
            get
            {
                return _preStringWarning;
            }

            set
            {
                _preStringWarning = value;
            }
        }
        #endregion
        /// <summary>
        /// 默认初始化函数
        /// 属性如下：
        /// 控件x,y坐标为(0,0),控件宽高为(320,256),控件监听端口:4557,CMOS默认分辨率:1280*1024,相机IP地址:192.168.3.15,保存前缀为空
        /// 是否复原照片为否,是否自动保存为否,照片旋转角度为不旋转,水印颜色为白色,保存照片是否加入ip地址为否,保存照片是否加入相机名为否
        /// 保存照片是否加入日期为否，是否区分OK/NG照片为否,OK照片前缀为空,NG照片前缀为空,是否保存NG照片为否，是否保存OK照片为否
        /// </summary>
        public CameraSettings()
        {
            ControlX = 0;
            ControlY = 0;
            ControlWidth = 320;
            ControlHeight = 256;
            Port = 4557;
            Cmos_Width = 1280;
            Cmos_Heigt = 1024;
            CameraIP = "192.168.3.15";
            PreString = "";
            IsRestore = false;
            IsAutoSaving = false; ;
            RotateType = RotateFlipType.RotateNoneFlipNone;
            InfoColor = Color.White;
            IsIpAddress = false;
            IsCameraName = false;
            IsDate = true;
            IsDistinguished = false;
            PreStringNG = "";
            PreStringOK = "";
            PreStringWarning = "";
            IsSaveNG = false;
            IsSaveOK = false;
            IsSaveWarning = false;
        }
        /// <summary>
        /// 初始化相机设置
        /// </summary>
        /// <param name="x">控件横坐标</param>
        /// <param name="y">控件纵坐标</param>
        /// <param name="width">控件宽度</param>
        /// <param name="height">控件高度</param>
        /// <param name="cmos_width">CMOS分辨率宽度</param>
        /// <param name="cmos_height">CMOS分辨率高度</param>
        /// <param name="ip">相机IP</param>
        /// <param name="port">照片接收端口</param>
        /// <param name="preStr">保存前缀</param>
        /// <param name="preStrOK">保存OK文件前缀</param>
        /// <param name="preStrNG">保存NG文件前缀</param>
        /// <param name="isIpaddress">保存文件名是否包含IP地址</param>
        /// <param name="isCameraname">保存文件名是否包含相机名称</param>
        /// <param name="isDatetime">保存文件名是否包含日期</param>
        /// <param name="isRestor">保存照片是否根据CMOS还原大小</param>
        /// <param name="isAutoSave">是否自动保存照片</param>
        /// <param name="isDistinguished">保存照片是否区分OK/NG</param>
        /// <param name="isSaveOK">是否保存OK照片（区分OK/NG时有效）</param>
        /// <param name="isSaveNG">是否保存NG照片（区分OK/NG时有效）</param>
        /// <param name="rft">照片显示旋转角度</param>
        /// <param name="infoColor">照片水印信息颜色</param>
        public CameraSettings(Int32 x, Int32 y, Int32 width, Int32 height, Int32 cmos_width, Int32 cmos_height, String ip, Int32 port, String preStr, String preStrOK,String preStrNG,String preStrWarning,Boolean isIpaddress,Boolean isCameraname,Boolean isDatetime, Boolean isRestor, Boolean isAutoSave, Boolean isDistinguished, Boolean isSaveOK,Boolean isSaveNG,Boolean isSaveWarning,RotateFlipType rft, Color infoColor)
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
            PreStringOK = preStrOK;
            PreStringNG = preStrNG;
            PreStringWarning = preStrWarning;
            IsRestore = isRestor;
            IsAutoSaving = isAutoSave;
            RotateType = rft;
            InfoColor = infoColor;
            IsIpAddress = isIpaddress;
            IsCameraName = isCameraname;
            IsDate = isDatetime;
            IsDistinguished = isDistinguished;
            IsSaveOK = isSaveOK;
            IsSaveNG = isSaveNG;
            IsSaveWarning = isSaveWarning;
        }
    }
}
