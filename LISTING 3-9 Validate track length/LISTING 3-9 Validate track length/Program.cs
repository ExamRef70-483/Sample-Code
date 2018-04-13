using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LISTING_3_9_Validate_track_length
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "Rob Miles:My Way:120";

            string regexToMatch = @".+:.+:[0-9]+$";

            if (Regex.IsMatch(input, regexToMatch))
            {
                Console.WriteLine("Valid music track description");
            }
            else
            {
                Console.WriteLine("Invalid music track");
            }
            Console.ReadKey();
        }
    }
}
