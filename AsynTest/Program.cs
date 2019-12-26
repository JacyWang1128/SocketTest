using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsynTest
{
    class Program
    {
        static void Main(string[] args)
        {
        //    Console.WriteLine($"14：{Thread.CurrentThread.ManagedThreadId}");
        //    CallerWithAsync("jack");
        //    Console.WriteLine($"16：{Thread.CurrentThread.ManagedThreadId}");
        //    Console.ReadKey();
        //}
        //async static void CallerWithAsync(string name)
        //{
        //    Console.WriteLine($"21：{Thread.CurrentThread.ManagedThreadId}");
        //    string result = await SayHiAsync(name);
        //    Console.WriteLine($"23：{Thread.CurrentThread.ManagedThreadId}");
        //    Console.WriteLine(result);
        //}
        //static Task<string> SayHiAsync(string name)
        //{
        //    return Task.Run<string>(() => { return SayHi(name); });
        //}
        //static string SayHi(string name)
        //{
        //    Task.Delay(2000).Wait();//异步等待2s
        //    Console.WriteLine($"33：{Thread.CurrentThread.ManagedThreadId}");
        //    return $"34Hello,{name}";
        }
    }
}
