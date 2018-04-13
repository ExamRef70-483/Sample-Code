using System;
using System.Globalization;

namespace LISTING_2_74_Format_provider
{
    class Program
    {
        static void Main(string[] args)
        {
            double bankBalance = 123.45;
                CultureInfo usProvider = new CultureInfo("en-US");
                Console.WriteLine("US balance: {0}", bankBalance.ToString("C", usProvider));
            CultureInfo ukProvider = new CultureInfo("en-GB");
            Console.WriteLine("UK balance: {0}", bankBalance.ToString("C", ukProvider));

            Console.ReadKey();
        }
    }
}
