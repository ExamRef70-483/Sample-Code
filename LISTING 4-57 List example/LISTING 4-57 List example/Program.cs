using System;
using System.Collections.Generic;

namespace LISTING_4_57_List_example
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>();

            names.Add("Rob Miles");
            names.Add("Immy Brown");

            for (int i = 0; i < names.Count; i++)
                Console.WriteLine(names[i]);

            names[0] = "Fred Bloggs";
            foreach (string name in names)
                Console.WriteLine(name);

            Console.ReadKey();
        }
    }
}
