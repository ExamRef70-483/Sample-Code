using System;
using System.IO;

namespace LISTING_4_5_The_File_class
{
    class Program
    {
        static void Main(string[] args)
        {
            File.WriteAllText(path: "TextFile.txt", contents: "This text goes in the file");

            File.AppendAllText(path: "TextFile.txt", contents: " - This goes on the end");

            if (File.Exists("TextFile.txt"))
                Console.WriteLine("Text File exists");

            string contents = File.ReadAllText(path: "TextFile.txt");
            Console.WriteLine("File contents: {0}", contents);

            if (File.Exists("CopyTextFile.txt"))
                File.Delete("CopyTextFile.txt");

            File.Copy(sourceFileName: "TextFile.txt", destFileName: "CopyTextFile.txt");

            using (TextReader reader = File.OpenText(path: "CopyTextFile.txt"))
            {
                string text = reader.ReadToEnd();
                Console.WriteLine("Copied text: {0}", text);
            }

            Console.ReadKey();
        }
    }
}
