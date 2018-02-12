using System;
using System.Threading;

namespace LISTING_1_24_shared_flag_variable
{
    class Program
    {
        static bool tickRunning = true;  // flag variable 

        static void Main(string[] args)
        {
            tickRunning = true;

            Thread tickThread = new Thread(() =>
            {
                while (tickRunning)
                {
                    Console.WriteLine("Tick");
                    Thread.Sleep(1000);
                }
            });

            tickThread.Start();

            Console.WriteLine("Press a key to stop the clock");
            Console.ReadKey();
            tickRunning = false;
            Console.WriteLine("Press a key to exit");
            Console.ReadKey();
        }
    }
}
