using System;
using System.Collections.Generic;
using System.Dynamic;

namespace LISTING_2_25_Using_dynamic_variables
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic d = 99;
            d = d + 1;
            Console.WriteLine(d);

            d = "Hello";
            d = d + " Rob";
            Console.WriteLine(d);

            dynamic person = new ExpandoObject();

            person.Name = "Rob Miles";
            person.Age = 21;

            Console.WriteLine("Name: {0} Age: {1}", person.Name, person.Age);

            Console.ReadKey();
        }
    }
}
