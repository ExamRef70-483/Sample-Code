using System;

namespace LISTING_3_22_Hashing
{
    class Program
    {
        static void showHash(object source)
        {
            Console.WriteLine("Hash for {0} is: {1:X}", source, source.GetHashCode());
        }

        static void Main(string[] args)
        {
            showHash("Hello world");
            showHash("world Hello");
            showHash("Hemmm world");

            Console.ReadKey();
        }
    }
}
