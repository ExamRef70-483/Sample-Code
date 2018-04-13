using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISTING_2_66_Stringbuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName = "Rob";
            string secondName = "Miles";

            string fullName = firstName + " " + secondName;

            var v = string.Intern("jim");

            object obj = "Int32";
            string str1 = "Int32";
            string str2 = typeof(int).Name;
            Console.WriteLine(obj == str1); // true
            Console.WriteLine(str1 == str2); // true
            Console.WriteLine(obj == str2); // false !?

            StringBuilder s = new StringBuilder();

            string x = "hel";
            string y = "lo";
            string a = x + y;
            string b = "hello";

            a = String.Intern(a);

            if ((object)a == (object)b)
                Console.WriteLine("Clever compiler");


        }
    } 
}
