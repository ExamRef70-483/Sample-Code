using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISTING_1_52_while_loops
{
    class Program
    {
        static void Main(string[] args)
        {
            while (false)
            {
                Console.WriteLine("Hello");
            }

            int count = 0;
            while(count < 10)
            {
                Console.WriteLine("Hello {0}", count);
                count = count + 1;
            }

            while (true)
            {
                Console.WriteLine("Hello");
            }
        }
    }
}
