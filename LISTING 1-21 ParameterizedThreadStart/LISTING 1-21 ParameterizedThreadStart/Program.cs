using System;
using System.Threading;

namespace LISTING_1_21_ParameterizedThreadStart
{
    class Program
    {
        static void WorkOnData(object data)
        {
            Console.WriteLine("Working on: {0}", data);
            Thread.Sleep(1000);
        }
        static void Main(string[] args)
        {
            ParameterizedThreadStart ps = new ParameterizedThreadStart(WorkOnData);

            Thread thread = new Thread(ps);

            thread.Start(99);
        }
    }
}
