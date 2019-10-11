using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace StructTest
{
    public struct MyStruct
    {
        public Char username;
        public Char passwrod;
    }
    
    class Program
    {
        public static object BytesToStruct(byte[] bytes, Type strcutType, int nSize)
        {
            if (bytes == null)
            {

            }
            int size = Marshal.SizeOf(strcutType);
            IntPtr buffer = Marshal.AllocHGlobal(nSize);
            //Debug.LogError("Type: " + strcutType.ToString() + "---TypeSize:" + size + "----packetSize:" + nSize);
            try
            {
                Marshal.Copy(bytes, 0, buffer, nSize);
                return Marshal.PtrToStructure(buffer, strcutType);
            }
            catch (Exception ex)
            {
                //Debug.LogError("Type: " + strcutType.ToString() + "---TypeSize:" + size + "----packetSize:" + nSize);
                return null;
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }

        static void Main(string[] args)
        {
            unsafe
            {
                Byte[] bytes = new Byte[2] { 0x31, 0x32 };
                MyStruct pms = new MyStruct();
                pms = (MyStruct)BytesToStruct(bytes,typeof(MyStruct),bytes.Length);
                Console.WriteLine(pms.username);
                Console.ReadKey();
            }
        }
    }
}
