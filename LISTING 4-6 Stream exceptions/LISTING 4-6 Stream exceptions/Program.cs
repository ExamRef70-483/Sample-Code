using System;
using System.IO;

namespace LISTING_4_6_Stream_exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string contents = File.ReadAllText(path: "Testfile.txt");
                Console.WriteLine(contents);
            }
            catch (FileNotFoundException notFoundEx)
            {
                // File not found
                Console.WriteLine(notFoundEx.Message);
            }
            catch (Exception ex)
            {
                // Any other exception
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
