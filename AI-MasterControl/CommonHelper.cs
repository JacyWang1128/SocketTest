using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
namespace AI_MasterControl
{
    public static class CommonHelper
    {
        [DllImport("kernel32.dll")]
        static extern uint GetTickCount();
        public static void Delay(uint ms)
        {
            uint start = GetTickCount();
            while (GetTickCount() - start < ms)
            {
                return;
            }
        }
    }
}
