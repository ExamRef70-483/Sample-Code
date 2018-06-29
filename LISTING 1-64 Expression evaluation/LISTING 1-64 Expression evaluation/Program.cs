using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISTING_1_64_Expression_evaluation
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0; // create i and set to 0

            // Monadic operators - one operand
            i++; // monadic ++ operator increment - i now 1
            i--; // monadic -- operator decrement - i now 0

            // Postfix monadic operator - peform after value given
            Console.WriteLine(i++); // writes 0 and sets i to 1
            // Prefix monadic operator - perform before value given
            Console.WriteLine(++i); // writes 2 and sets i to 2

            // Binary operators - two operands
            i = 1 + 1; // sets i to 2 
            i = 1 + 2 * 3; // sets i to 7 because * performed first
            i = (1 + 2) * 3; // sets i to 9 because + peformed first

            string str = "";

            str = str + "Hello"; // + performs string addition

            // ternary operators - three operands
            i = true ? 0 : 1; // sets i to 0 because condition is true

            Console.ReadKey();
        }
    }
}
