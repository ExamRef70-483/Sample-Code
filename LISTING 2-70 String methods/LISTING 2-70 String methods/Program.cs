using System;
using System.Globalization;
using System.Threading;

namespace LISTING_2_70_String_methods
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Contains");
            string input = "      Rob Miles";

            if (input.Contains("Rob"))
            {
                Console.WriteLine("Input contains Rob");
            }


            Console.WriteLine("StartsWith and EndsWith");
            string trimmedString = input.TrimStart();

            if (trimmedString.StartsWith("Rob"))
            {
                Console.WriteLine("Starts with Rob");
            }

            Console.WriteLine("IndexOf and SubString");
            int RobStart = input.IndexOf("Rob");
            string Rob = input.Substring(RobStart, 3);
            Console.Write(Rob);


            Console.WriteLine("Replace");
            string informalString = "Rob Miles";
            string formalString = informalString.Replace("Rob", "Robert");
            Console.WriteLine(formalString);

            Console.WriteLine("Split");
            string sentence = "The cat sat on the mat.";
            string[] words = sentence.Split(' ');
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }

            Console.WriteLine("Culture");

            // Default comparison fails becase the strings are different
            if (!"encyclopædia".Equals("encyclopaedia"))
                Console.WriteLine("Unicode encyclopaedias are not equal");
            // Set the curent culture for this thread to EN-US
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            // Using the current culture the strings are equal
            if ("encyclopædia".Equals("encyclopaedia", StringComparison.CurrentCulture))
                Console.WriteLine("Culture comparison encyclopaedias are equal");
            // We can use the IgnoreCase option to perform comparisions that ignore case
            if ("encyclopædia".Equals("ENCYCLOPAEDIA", StringComparison.CurrentCultureIgnoreCase))
                Console.WriteLine("Case culture comparison encyclopaedias are equal");
            if (!"encyclopædia".Equals("ENCYCLOPAEDIA", StringComparison.OrdinalIgnoreCase))
                Console.WriteLine("Ordinal comparison encyclopaedias are not equal");

            Console.ReadKey();
        }
    }
}
