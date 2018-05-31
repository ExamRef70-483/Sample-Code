using System;
using System.IO;

namespace LISTING_4_12_C_sharp_programs
{
    class Program
    {
        static void FindFiles(DirectoryInfo dir, string searchPattern)
        {
            foreach (DirectoryInfo directory in dir.GetDirectories())
            {
                FindFiles(directory, searchPattern);
            }

            FileInfo[] matchingFiles = dir.GetFiles(searchPattern);
            foreach (FileInfo fileInfo in matchingFiles)
            {
                Console.WriteLine(fileInfo.FullName);
            }
        }
        static void Main(string[] args)
        {
            DirectoryInfo startDir = new DirectoryInfo(@"..\..\..\..");
            string searchString = "*.cs";

            FindFiles(startDir, searchString);

            Console.ReadKey();
        }
    }
}
