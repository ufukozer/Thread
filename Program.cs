using System;
using System.Threading;

namespace ConsoleApp6
{
    class Program
    {
        public static SemaphoreSlim SemaphoreSlim = new SemaphoreSlim(5);
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            for (int i = 1; i<=1000; i++)
            {
                new Thread(EnterTheClub).Start(i);
                Thread.Sleep(1000);
            }
        }
        public static void EnterTheClub(object id)
        {
            Console.WriteLine(id + " queues up");
            SemaphoreSlim.Wait();
            Console.WriteLine(id + " is in!");
            Thread.Sleep(1000 * (int)id);
            Console.WriteLine(id + " is leaving");
            SemaphoreSlim.Release();
        }
    }
}
