using System;

namespace LISTING_1_76_try_catch
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter an integer: ");
                string numberText = Console.ReadLine();
                int result;
                result = int.Parse(numberText);
                Console.WriteLine("You entered {0}", result);
            }
            catch
            {
                Console.WriteLine("Invalid number entered");
            }

            Console.ReadKey();
        }
    }
}
