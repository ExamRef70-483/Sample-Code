using System;
using System.Threading;

namespace LISTING_1_20_Threads_and_lambda_functions
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(() =>
            {
                Console.WriteLine("Hello from the thread");
                Thread.Sleep(1000);
            });

            thread.Start();
        }
    }
}
