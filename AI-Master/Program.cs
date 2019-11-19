using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AI_Master
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoggHelper.WriteLog("打开程序");
            Application.Run(new MainForm());
            //Application.Run(new AddCamera(new AI_MasterControl.CameraSettings()));
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            LoggHelper.WriteLog("未处理的错误", (Exception)e.ExceptionObject);
        }
    }
}
