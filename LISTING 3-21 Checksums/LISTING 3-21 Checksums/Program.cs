using System;

namespace LISTING_3_21_Checksums
{
    class Program
    {
        static int calculateChecksum(string source)
        {
            int total = 0;
            foreach (char ch in source)
                total = total + (int)ch;
            return total;
        }

        static void showChecksum(string source)
        {
            Console.WriteLine("Checksum for {0} is {1}",
                source, calculateChecksum(source));
        }

        static void Main(string[] args)
        {
            showChecksum("Hello world");
            showChecksum("world Hello");
            showChecksum("Hemmm world");

            Console.ReadKey();
        }
    }
}
