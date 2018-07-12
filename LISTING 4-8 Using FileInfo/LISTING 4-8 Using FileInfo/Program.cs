using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISTING_4_8_Using_FileInfo
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
            Console.WriteLine("Attributes: {0}", info.Attributes);

            Console.WriteLine("Make the file read only");
            info.Attributes |= FileAttributes.ReadOnly;
            Console.WriteLine("Attributes: {0}", info.Attributes);

            Console.WriteLine("Remove the read only attribute");
            info.Attributes &= ~FileAttributes.ReadOnly;
            Console.WriteLine("Attributes: {0}", info.Attributes);

            Console.WriteLine("Make the file archive");
            info.Attributes |= FileAttributes.Archive;
            Console.WriteLine("Attributes: {0}", info.Attributes);

            Console.WriteLine("Remove the archive  attribute");
            info.Attributes &= ~FileAttributes.Archive;
            Console.WriteLine("Attributes: {0}", info.Attributes);

            Console.WriteLine("Make the file hidden");
            info.Attributes |= FileAttributes.Hidden;
            Console.WriteLine("Attributes: {0}", info.Attributes);

            Console.WriteLine("Remove the hidden  attribute");
            info.Attributes &= ~FileAttributes.Hidden;
            Console.WriteLine("Attributes: {0}", info.Attributes);

            Console.ReadKey();
        }
    }
}
