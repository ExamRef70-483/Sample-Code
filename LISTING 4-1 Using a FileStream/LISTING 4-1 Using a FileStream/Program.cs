using System;
using System.IO;
using System.Text;

namespace LISTING_4_1_Using_a_FileStream
{
    class Program
    {
        static void Main(string[] args)
        {
            // Writing to a file
            FileStream outputStream = new FileStream("OutputText.txt", FileMode.OpenOrCreate, FileAccess.Write);
            string outputMessageString = "Hello world";
            byte[] outputMessageBytes = Encoding.UTF8.GetBytes(outputMessageString);
            outputStream.Write(outputMessageBytes, 0, outputMessageBytes.Length);
            outputStream.Close();

            FileStream inputStream = new FileStream("OutputText.txt", FileMode.Open, FileAccess.Read);
            long fileLength = inputStream.Length;
            byte[] readBytes = new byte[fileLength];
            inputStream.Read(readBytes, 0, (int)fileLength);
            inputStream.Close();
            string readString = Encoding.UTF8.GetString(readBytes);
            Console.WriteLine("Read message: {0}", readString);
            Console.ReadKey();
        }
    }
}
