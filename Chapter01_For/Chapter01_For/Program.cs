using System;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace Chapter01_For
{
    class Program
    {
        static void WorkOnItem(object item)
        {
            Console.WriteLine("Started working on: " + item);
            Thread.Sleep(100);
            Console.WriteLine("Finished working on: " + item);
        }

        static void Main(string[] args)
        {
            var items = Enumerable.Range(0, 500).ToArray();

            Parallel.For(0, items.Count(), i =>
            {
                WorkOnItem(items[i]);
            });

            Console.WriteLine("Finished processing. Press a key to end.");
            Console.ReadKey();
        }
    }
}
