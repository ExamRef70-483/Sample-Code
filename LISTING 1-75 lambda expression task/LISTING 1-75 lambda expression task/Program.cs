using System;
using System.Threading;
using System.Threading.Tasks;

namespace LISTING_1_75_lambda_expression_task
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run( () =>
           {
               for (int i = 0; i < 5 ; i++)
               {
                   Console.WriteLine(i);
                   Thread.Sleep(500);
               }
           });

            Console.WriteLine("Task running..");
            Console.ReadKey();
        }
    }
}
