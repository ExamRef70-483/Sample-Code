using System;
using System.IO;

namespace LISTING_2_68_StringWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            StringWriter writer = new StringWriter();

            writer.WriteLine("Hello World");

            writer.Close();

            Console.Write(writer.ToString());

            Console.ReadKey();
        }
    }
}
