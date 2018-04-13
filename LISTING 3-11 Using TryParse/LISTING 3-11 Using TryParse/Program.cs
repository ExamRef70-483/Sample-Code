using System;

namespace LISTING_3_11_Using_TryParse
{
    class Program
    {
        static void Main(string[] args)
        {
            int result;

            if (int.TryParse("99", out result))
                Console.WriteLine("This is a valid number");
            else
                Console.WriteLine("This is not a valid number");

            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}
