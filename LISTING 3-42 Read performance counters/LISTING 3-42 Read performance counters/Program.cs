using System;
using System.Diagnostics;
using System.Threading;

namespace LISTING_3_42_Read_performance_counters
{
    class Program
    {
        static void Main(string[] args)
        {
            PerformanceCounter processor = new PerformanceCounter(
                categoryName:"Processor Information", 
                counterName: "% Processor Time",
                instanceName:"_Total");

            Console.WriteLine("Press any key to stop");

            while (true)
            {
                Console.WriteLine("Processor time {0}", processor.NextValue());
                Thread.Sleep(500);
                if (Console.KeyAvailable)
                    break;
            }
        }
    }
}
