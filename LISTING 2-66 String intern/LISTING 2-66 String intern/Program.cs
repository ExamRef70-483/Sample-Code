using System;

namespace LISTING_2_66_String_intern
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create hello at compile time
            string s1 = "hello";
            string s2 = "hello";

            if ((object)s1 == (object)s2)
                Console.WriteLine("s1 and s2 are the same object");

            // Create "hello" at runtime
            string h1 = "he";
            string h2 = "llo";
            string s3 = h1 + h2;

            if ((object)s1 != (object)s3)
                Console.WriteLine("s1 and s3 are differnent objects");

            // Intern s3
                
            if ((object)s1 == (object)s3)
                Console.WriteLine("s1 and s3 are the same object");

            Console.ReadKey();
        }
    }
}
