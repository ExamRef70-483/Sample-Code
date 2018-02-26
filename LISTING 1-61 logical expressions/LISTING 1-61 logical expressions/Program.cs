using System;

namespace LISTING_1_61_logical_expressions
{
    class Program
    {
        static int mOne()
        {
            Console.WriteLine("mOne called");
            return 1;
        }

        static int mTwo()
        {
            Console.WriteLine("mTwo called");
            return 1;
        }

        static void Main(string[] args)
        {
            if (mOne() == 2 && mTwo() == 1)
                Console.WriteLine("Hello world");

            Console.ReadKey();
        }
    }
}
