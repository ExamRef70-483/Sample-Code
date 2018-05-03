//#undef DEBUG

using System;
using System.Diagnostics;

namespace LISTING_3_30_Conditional_attribute
{
    class Program
    {
        [Conditional("DEBUG")]
        static void display(string message)
        {
            Console.WriteLine(message);

        }
        static void Main(string[] args)
        {
            display("Message for the user");

            Console.ReadKey();
        }
    }
}
