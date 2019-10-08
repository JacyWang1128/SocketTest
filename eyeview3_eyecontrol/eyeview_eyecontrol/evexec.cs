using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using System.Diagnostics;
using System.Runtime.InteropServices;

namespace EVT
{

    public struct PROCESS_INFORMATION
    {

        public IntPtr hProcess;
        public IntPtr hThread;
        public uint dwProcessId;
        public uint dwThreadId;

    }

    public struct STARTUPINFO
    {

        public uint cb;
        public string lpReserved;
        public string lpDesktop;
        public string lpTitle;
        public uint dwX;
        public uint dwY;
        public uint dwXSize;
        public uint dwYSize;
        public uint dwXCountChars;
        public uint dwYCountChars;
        public uint dwFillAttribute;
        public uint dwFlags;
        public short wShowWindow;
        public short cbReserved2;
        public IntPtr lpReserved2;
        public IntPtr hStdInput;
        public IntPtr hStdOutput;
        public IntPtr hStdError;

    }

    public struct SECURITY_ATTRIBUTES
    {

        public int length;
        public IntPtr lpSecurityDescriptor;
        public bool bInheritHandle;

    }

    class ExecuteEyeVision
    {
        STARTUPINFO m_si;
        PROCESS_INFORMATION m_pi;
        string m_path;

        public ExecuteEyeVision(string processname)
        {
            m_path = processname;
            m_si = new STARTUPINFO();
            m_pi = new PROCESS_INFORMATION();
        }

        ~ExecuteEyeVision()
        {
        }

        public int launchEyeVision()
        {
            string lpCommandLine = "eyevision.exe -e Application.Appearance.WindowState=1";
            bool ret = CreateProcess(m_path, lpCommandLine, IntPtr.Zero, IntPtr.Zero, false, 0, IntPtr.Zero, null, ref m_si, out m_pi);
            return 0;
        }

        public int killEyeVision()
        {
            TerminateProcess(m_pi.hProcess, 0);
            return 0;
        }

        [DllImport("kernel32.dll")]
        static extern bool TerminateProcess(IntPtr handle, uint flags);

        [DllImport("kernel32.dll")]
        static extern bool CreateProcess(string lpApplicationName, string lpCommandLine, IntPtr lpProcessAttributes, IntPtr lpThreadAttributes,
                                bool bInheritHandles, uint dwCreationFlags, IntPtr lpEnvironment,
                                string lpCurrentDirectory, ref STARTUPINFO lpStartupInfo, out PROCESS_INFORMATION lpProcessInformation);
    }

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        ExecuteEyeVision launcher = new ExecuteEyeVision("EyeVision.exe");
    //        if (0 != launcher.launchEyeVision())
    //        {
    //            return;
    //        }
    //        Thread.Sleep (15000);
    //        launcher.killEyeVision();
    //        return;

    //    }
    //}
}
