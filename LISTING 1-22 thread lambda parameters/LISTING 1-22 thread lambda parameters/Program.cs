using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LISTING_1_22_thread_lambda_parameters
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
            Thread thread = new Thread((data) =>
            {
                WorkOnData(data);
            });
            thread.Start(99);
        }
    }
}
