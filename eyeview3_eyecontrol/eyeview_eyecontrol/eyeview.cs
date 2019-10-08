// -----------------------------------------------------------------------
// <copyright file="Eye.cs" company="keine">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace EVT
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Enumeration of all parameters TO SET for the eye vision camera system.
    /// </summary>
    internal enum IMG_RECV_PAR
    {
        IMG_RECV_PAR_PORT_ADDRESS = 1,
        IMG_RECV_PAR_DISPLAY_IMAGE = 2,
        IMG_RECV_PAR_DISPLAY_SYMBOLIC_OVERLAY = 3,
        IMG_RECV_PAR_DISPLAY_IMAGE_SIZE = 4,
        IMG_RECV_PAR_FLIP_IMAGE_VERTICAL = 5,
        IMG_RECV_PAR_IMG_FORMAT_TYPE = 6,
        IMG_RECV_PAR_FILENAME_USE_PREFIX = 7,
        IMG_RECV_PAR_FILENAME_PREFIX = 8,
        IMG_RECV_PAR_FILENAME_USE_CAMERA_NAME = 9,
        IMG_RECV_PAR_FILENAME_USE_PROGRAM_NAME = 10,
        IMG_RECV_PAR_RECORDING_PATH = 11,
        IMG_RECV_PAR_RECORDING_ACTIVE = 12,
        IMG_RECV_PAR_ESTIMATED_PACKET_LOSS = 13,
        IMG_RECV_PAR_FLIP_IMAGE_HORIZONTAL = 14,
        IMG_RECV_PAR_SEND_UDP_ACKNOWLEDGEMENT = 15,
        IMG_RECV_PAR_REC_WITH_SYMBOLIC_OVERLAY = 16,
        IMG_RECV_PAR_FILENAME_USE_GLOBAL_STRING = 17,
        IMG_RECV_PAR_FILENAME_USE_TIMESTAMP = 18,
        IMG_RECV_PAR_FILENAME_USE_CYCLIC = 19,
        IMG_RECV_PAR_FILENAME_CYCLIC_NOIMAGES = 20,
        IMG_RECV_PAR_RESULT_DISPLAY_RESULT = 21,
        IMG_RECV_PAR_RESULT_STRING = 22,
        IMG_RECV_PAR_FILENAME_USE_RESULT = 23,
        IMG_RECV_PAR_FILENAME_POS_PREFIX = 24,
        IMG_RECV_PAR_FILENAME_POS_CAMERA_NAME = 25,
        IMG_RECV_PAR_FILENAME_POS_PROGRAM_NAME = 26,
        IMG_RECV_PAR_FILENAME_POS_GLOBAL_STRING = 27,
        IMG_RECV_PAR_FILENAME_POS_TIMESTAMP = 28,
        IMG_RECV_PAR_FILENAME_POS_IMAGE_NUMBER = 29,
        IMG_RECV_PAR_FILENAME_POS_RESULT = 30,
    }

    /// <summary>
    /// Enumeration of all results TO RECEIVE for the eye vision camera system.
    /// </summary>
    internal enum IMG_RECV_RES_TYPE
    {
        IMG_RECV_RES_MIN = 0,
        IMG_RECV_RES_PAKET_NUMBER = 1,            //For internal use only
        IMG_RECV_RES_UDP_PAKETS = 2,              //For internal use only
        IMG_RECV_RES_IMAGE_NUMBER = 3,
        IMG_RECV_RES_NUMBER_OVERLAY_PAKETS = 4,   //For internal use only
        IMG_RECV_RES_PROTOCOL_VERSION = 5,
        IMG_RECV_RES_CAMERA_NAME = 6,
        IMG_RECV_RES_CURRENT_PROGRAM = 7,
        IMG_RECV_RES_GLOBAL_STRING = 8,
        IMG_RECV_RES_TIMESTAMP = 9,
        IMG_RECV_RES_CAMERA_IP = 10,
        IMG_RECV_RES_TRANSFER_WIDTH = 11,
        IMG_RECV_RES_TRANSFER_HEIGHT = 12,
        IMG_RECV_RES_TRANSFER_COLOR_DEPTH = 13,
        IMG_RECV_RES_ROI_POS_X = 14,
        IMG_RECV_RES_ROI_POS_Y = 15,
        IMG_RECV_RES_ROI_WIDTH = 16,
        IMG_RECV_RES_ROI_HEIGHT = 17,
        IMG_RECV_RES_ORIG_COLOR_DEPTH = 18,
        IMG_RECV_RES_IMAGE_AREA_TYPE = 19,
        IMG_RECV_RES_IMAGE_RESOLUTION_TYPE = 20,
        IMG_RECV_RES_IP_MOD = 21,
        IMG_RECV_RES_TIMING_TYPE = 22,
        IMG_RECV_RES_IMAGE_BUFFER_TYPE = 23,
        IMG_RECV_RES_ERR_BUFFER_NUM = 24,
        IMG_RECV_RES_IM_NUM = 25,
        IMG_RECV_RES_TRANSMISSION_FORMAT = 26,
        IMG_RECV_RES_COMPRESSION_TYPE = 27,
        IMG_RECV_RES_OVERLAY_TYPE = 28,
        IMG_RECV_RES_LINE_NUMBER = 29,
        IMG_RECV_RES_INT_CONDITION = 30,
        IMG_RECV_RES_EXT_CONDITION = 31,
        IMG_RECV_RES_GOOD_COUNTER = 32,
        IMG_RECV_RES_BAD_COUNTER = 33,
        IMG_RECV_RES_CYCLUS_TIME = 34,
        IMG_RECV_RES_UDP_PACKET_SIZE = 35,
        IMG_RECV_RES_PCONLAN_PORT = 36,
        IMG_RECV_RES_INFO_STRING = 37,
        IMG_RECV_RES_OWN_IP_ADDRESS = 38,
        IMG_RECV_RES_MAX = 39,
    }

    /// <summary>
    /// Enumeration of function returns.
    /// </summary>
    internal enum EVHD_RET
    {
        EVHD_SUCCESS = 0,
        EVHD_ERROR = -1,
        EVHD_ERR_PARM = -3,
    }

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public static class EyeView
    {
        public const Int32 TIMING_TYPE_NOW = 1;
        public const Int32 TIMING_TYPE_END_OF_PROGRAM = 2;
        public const Int32 EXTERNAL_CONDITION_SEND_ALWAYS = 1;
        public const Int32 EXTERNAL_CONDITION_SEND_ON_REQUEST = 2;
        public const Int32 INTERNAL_CONDITION_SEND_ON_IO = 1;
        public const Int32 INTERNAL_CONDITION_SEND_ON_NIO = 2;
        public const Int32 INTERNAL_CONDITION_SEND_ALWAYS = 3;
        public const Int32 TRANSFER_BUFFER_TYPE_STD_IM = 1;
        public const Int32 TRANSFER_BUFFER_TYPE_ERROR_IM = 2;
        public const Int32 IMAGE_AREA_TYPE_FULL_IMAGE = 1;
        public const Int32 IMAGE_AREA_TYPE_STATIC_ROI = 2;
        public const Int32 IMAGE_AREA_TYPE_DYNAMIC_ROI = 3;
        public const Int32 DYNAMIC_ROI_FROM_REGISTER = 1;
        public const Int32 DYNAMIC_ROI_FROM_PICKUP_LIST = 2;
        public const Int32 IMAGE_RESOLUTION_TYPE_ORIGINAL = 1;
        public const Int32 IMAGE_RESOLUTION_TYPE_QUARTER = 2;
        public const Int32 IMAGE_RESOLUTION_TYPE_SIXTEENTH = 3;
        public const Int32 OVERLAY_TYPE_NONE = 1;
        public const Int32 OVERLAY_TYPE_EMBEDDED = 2;
        public const Int32 OVERLAY_TYPE_SYMBOLIC = 3;
        public const Int32 TRANSMISSION_IMAGE_FORMAT_TYPE_GREY = 1;
        public const Int32 TRANSMISSION_IMAGE_FORMAT_TYPE_COLOR = 2;
        public const Int32 TRANSMISSION_IMAGE_COMPRESSION_TYPE_NONE = 1;
        public const Int32 TRANSMISSION_IMAGE_COMPRESSION_TYPE_JPEG = 2;

        #region Importing kernel32.dll methods:
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr LoadLibrary(string lpFileName);
        #endregion

        #region Importing EyeView DLL methods:

        [DllImport("EyeView.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 EVInitEyeVisionSubsystem(IntPtr lImgHandle);

        [DllImport("EyeView.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 EVDeinitEyeVisionSubsystem();

        [DllImport("EyeView.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 EVInitImgRecvVars();

        [DllImport("EyeView.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 EVParameterRequest(Int32 lCameraIndex);

        [DllImport("EyeView.dll", CallingConvention = CallingConvention.StdCall)]
       
        public static extern Int32 EVAddCameraDisplay(IntPtr lhWndImage, string sIPAddress, 
            Int32 lIM, Int32 lIDC, Int32 lWindowDX, Int32 lWindowDY, Int32 lNOfOverlayElements, Int32 lFitMode);

        [DllImport("EyeView.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 EVStartImgRecvThread();

        [DllImport("EyeView.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 EVStopImgRecvThread();

        [DllImport("EyeView.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 EVSetParString(Int32 lParType, string sString, Int32 lLen);

        [DllImport("EyeView.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 EVSetParLong(Int32 lParType, Int32 lLong);

        [DllImport("EyeView.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 EVGetParString(Int32 lParType, string sString);

        [DllImport("EyeView.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 EVGetParLong(Int32 lParType, ref Int32 lLong);

        [DllImport("EyeView.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 EVInitializeSharedMemory(Int32 shmCount, Int32 shmImgSize);
        
        #endregion EyeView DLL methods:
    }
}
