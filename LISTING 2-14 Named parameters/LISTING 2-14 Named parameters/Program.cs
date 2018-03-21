using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISTING_2_14_Named_parameters
{
    class Program
    {
        static int ReadValue(
            int low,    // lowest allowed value
            int high,    // highest allowed value
            string prompt // prompt for the user 
            )
        {
            while(true)
            {
                Console.Write(prompt);

                int number;

                if (!int.TryParse(Console.ReadLine(), out number))
                {
                    Console.WriteLine("Invalid number text");
                    continue;
                }

                if (number < low || number > high)
                {
                    Console.WriteLine("Number should be less than {0} and greater than {1}", high, low);
                    continue;
                }
                return number;
            }
        }

        static void Main(string[] args)
        {
            int age = ReadValue(low: 1, high: 100, prompt: "Enter your age: ");
            Console.WriteLine("Your age is: {0}", age);
            Console.ReadKey();
        }
    }
}
