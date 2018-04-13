using System;
using System.Text;

namespace LISTING_2_67_Stringbuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName = "Rob";
            string secondName = "Miles";

            string fullNameString = firstName + " " + secondName;

            StringBuilder fullNameBuilder = new StringBuilder();
            fullNameBuilder.Append(firstName);
            fullNameBuilder.Append(" ");
            fullNameBuilder.Append(secondName);

            Console.WriteLine(fullNameBuilder.ToString());

            Console.ReadKey();
        }
    }
}
