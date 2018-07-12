using System;
using System.IO;

namespace LISTING_4_8_Viewing_FileInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "TextFile.txt";
            FileInfo info = new FileInfo(filePath);
            info.IsReadOnly = false;

            File.WriteAllText(path: filePath, contents: "This text goes in the file");
            Console.WriteLine("Name: {0}", info.Name);
            Console.WriteLine("Full Path: {0}", info.FullName);
            Console.WriteLine("Last Access: {0}", info.LastAccessTime);
            Console.WriteLine("Length: {0}", info.Length);
            Console.WriteLine("Attributes: {0}", info.Attributes);
            Console.WriteLine("Make the file read only");
            //info.IsReadOnly = true;
            info.Attributes |= FileAttributes.ReadOnly;
            Console.WriteLine("Attributes: {0}", info.Attributes);
            
            Console.ReadKey();
        }
    }
}
