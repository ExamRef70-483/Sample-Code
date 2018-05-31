using System;
using System.IO;

namespace LISTING_4_11_Using_Path
{
    class Program
    {
        static void Main(string[] args)
        {

            string fullName = @"c:\users\rob\Documents\test.txt";

            string dirName = Path.GetDirectoryName(fullName);
            string fileName = Path.GetFileName(fullName);
            string fileExtension = Path.GetExtension(fullName);
            string lisName = Path.ChangeExtension(fullName, ".lis");
            string newTest = Path.Combine(dirName, "newtest.txt");

            Console.WriteLine("Full name: {0}", fullName);
            Console.WriteLine("File directory: {0}", dirName);
            Console.WriteLine("File name: {0}", fileName);
            Console.WriteLine("File extension: {0}", fileExtension);
            Console.WriteLine("File with lis extension: {0}", lisName);
            Console.WriteLine("New test: {0}", newTest);

            Console.ReadKey();

        }
    }
}
