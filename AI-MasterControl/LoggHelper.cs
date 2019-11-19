using log4net;
using System;
using System.Collections.Generic;
using System.Text;

namespace AI_MasterControl
{
    /// <summary>
    /// 记录日志的类
    /// </summary>
    public static class LoggHelper
    {
        public static ILog logError = LogManager.GetLogger("ErrorLog");

        public static ILog logInfor = LogManager.GetLogger("InforLog");

        /// <summary>
        /// 记录错误日志
        /// </summary>
        public static void WriteLog(string infor, Exception ex)
        {
            if (logError.IsErrorEnabled)
            {
                logError.Error(infor, ex);
            }
        }
        /// <summary>
        /// 记录普通日志
        /// </summary>
        public static void WriteLog(string infor)
        {
            if (logInfor.IsInfoEnabled)
            {
                logInfor.Info(infor);
            }
        }
    }
}
