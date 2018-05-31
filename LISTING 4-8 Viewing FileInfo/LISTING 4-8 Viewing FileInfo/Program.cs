using System;
using System.IO;

namespace LISTING_4_8_Viewing_FileInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "TextFile.txt";

            File.WriteAllText(path: filePath, contents: "This text goes in the file");
            FileInfo info = new FileInfo(filePath);
            Console.WriteLine("Name: {0}", info.Name);
            Console.WriteLine("Full Path: {0}", info.FullName);
            Console.WriteLine("Last Access: {0}", info.LastAccessTime);
            Console.WriteLine("Length: {0}", info.Length);
            Console.ReadKey();
        }
    }
}
