using System;
using System.IO;
using System.Text;

namespace LISTING_4_2_FileStream_and_IDisposable
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream outputStream = new FileStream("OutputText.txt", FileMode.OpenOrCreate, FileAccess.Write))
            {
                string outputMessageString = "Hello world";
                byte[] outputMessageBytes = Encoding.UTF8.GetBytes(outputMessageString);
                outputStream.Write(outputMessageBytes, 0, outputMessageBytes.Length);
            }
        }
    }
}
