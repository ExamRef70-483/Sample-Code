using System;

namespace LISTING_2_25_Using_dynamic_variables
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic d = 99;
            d = d + 1;
            Console.WriteLine(d);

            d = "Hello";
            d = d + " Rob";
            Console.WriteLine(d);

            Console.ReadKey();

        }
    }
}
