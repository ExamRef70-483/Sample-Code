using System;
using System.IO;


namespace LISTING_4_10_The_DirectoryInfo_class
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo localDir = new DirectoryInfo("TestDir");

            localDir.Create();

            if (localDir.Exists)
                Console.WriteLine("Directory created successfully");

            localDir.Delete();

            Console.WriteLine("Directory deleted successfully");

            Console.ReadKey();
        }
    }
}
