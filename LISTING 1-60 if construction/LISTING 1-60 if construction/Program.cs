using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISTING_1_60_if_construction
{
    class Program
    {
        static void Main(string[] args)
        {
            if (true)
            {
                Console.WriteLine("This statement is always performed");
            }
            else
            {
                Console.WriteLine("This statement is never performed");
            }

            if (true)
            {
                Console.WriteLine("This statement is always performed");
                if (true)
                {
                    Console.WriteLine("This statement is always performed");
                }
                else
                {
                    Console.WriteLine("This statement is never performed");
                }
            }

            if (true)
            {
                Console.WriteLine("This statement is always performed");
                if (true)
                {
                    Console.WriteLine("This statement is always performed");
                }
            }
            else
            {
                Console.WriteLine("This statement is never performed");
            }
        }
    }
}
