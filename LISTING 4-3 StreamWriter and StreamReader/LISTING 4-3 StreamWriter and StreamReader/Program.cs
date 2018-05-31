using System;
using System.IO;

namespace LISTING_4_3_StreamWriter_and_StreamReader
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamWriter writeStream = new StreamWriter("OutputText.txt"))
            {
                writeStream.Write("Hello world");
            }

            using (StreamReader readStream = new StreamReader("OutputText.txt"))
            {
                string readSTring = readStream.ReadToEnd();
                Console.WriteLine("Text read: {0}", readSTring);
            }

            Console.ReadKey();
        }
    }
}
