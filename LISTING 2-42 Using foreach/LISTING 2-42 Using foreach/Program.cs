using System;

namespace LISTING_2_42_Using_foreach
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (char ch in "Hello world")
                Console.Write(ch);

            Console.ReadKey();
        }
    }
}
