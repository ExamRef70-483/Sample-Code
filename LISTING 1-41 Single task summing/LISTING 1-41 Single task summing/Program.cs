using System;
using System.Linq;

namespace LISTING_1_41_Single_task_summing
{
    class Program
    {
        // make an array that holds the values 0 to 5000000
        static int[] items = Enumerable.Range(0, 500001).ToArray();

        static void Main(string[] args)
        {
            long total = 0;

            for (int i = 0; i < items.Length; i++)
                total = total + items[i];

            Console.WriteLine("The total is: {0}", total);
            Console.ReadKey();
        }
    }
}
