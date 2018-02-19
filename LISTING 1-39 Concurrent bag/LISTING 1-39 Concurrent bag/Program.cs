using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace LISTING_1_39_Concurrent_bag
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcurrentBag<string> bag = new ConcurrentBag<string>();
            bag.Add("Rob");
            bag.Add("Miles");
            bag.Add("Hull");
            string str;
            if (bag.TryPeek(out str))
                Console.WriteLine("Peek: {0}", str);
            if (bag.TryTake(out str))
                Console.WriteLine("Take: {0}", str);
            Console.ReadKey();
        }
    }
}
