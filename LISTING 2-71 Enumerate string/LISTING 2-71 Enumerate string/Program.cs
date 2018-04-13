using System;

namespace LISTING_2_71_Enumerate_string
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach(char ch in "Hello world")
            {
                Console.WriteLine(ch);
            }
            Console.ReadKey();
        }
    }
}
