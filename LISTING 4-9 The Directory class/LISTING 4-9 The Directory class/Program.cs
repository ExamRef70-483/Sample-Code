using System;
using System.IO;

namespace LISTING_4_9_The_Directory_class
{
    class Program
    {
        static void Main(string[] args)
        {
            Directory.CreateDirectory("TestDir");

            if (Directory.Exists("TestDir"))
                Console.WriteLine("Directory created successfully");

            Directory.Delete("TestDir");

            Console.WriteLine("Directory deleted successfully");

            Console.ReadKey();
        }
    }
}
