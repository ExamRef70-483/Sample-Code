using System;
using System.Threading;
using System.Threading.Tasks;

namespace LISTING_1_12_Run_a_task
{
    class Program
    {
        public static void DoWork()
        {
            Console.WriteLine("Work starting");
            Thread.Sleep(2000);
            Console.WriteLine("Work finished");
        }

        static void Main(string[] args)
        {
            Task newTask = Task.Run(() => DoWork());
            newTask.Wait();
        }
    }
}
