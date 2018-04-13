using System;
using System.IO;

namespace LISTING_2_69_StringReader
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataString =
@"Rob Miles
21";
            StringReader dataStringReader = new StringReader(dataString);

            string name = dataStringReader.ReadLine();
            int age = int.Parse(dataStringReader.ReadLine());

            dataStringReader.Close();

            Console.WriteLine("Name: {0} Age: {1}", name, age);

            Console.ReadKey();
        }
    }
}
