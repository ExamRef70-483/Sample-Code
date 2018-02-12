using System;
using System.Threading;

namespace LISTING_1_18_Creating_threads
{
    class Program
    {
        static void ThreadHello()
        {
            Console.WriteLine("Hello from the thread");
            Thread.Sleep(2000);
        }

        static void Main(string[] args)
        {
            Thread thread = new Thread(ThreadHello);
            thread.Start();
        }
    }
}
