using System;
using System.Text.RegularExpressions;

namespace LISTING_3_6_Simple_regular_expression
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "Rob Mary David Jenny Chris Imogen Rodney";

            string patternToMatch = " ";
            string patternToReplace = ",";

            string replaced = Regex.Replace(input, patternToMatch, patternToReplace);

            Console.WriteLine(replaced);
            Console.ReadKey();
        }
    }
}
