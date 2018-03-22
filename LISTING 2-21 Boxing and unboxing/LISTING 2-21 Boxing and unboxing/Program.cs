using System;

namespace LISTING_2_21_Boxing_and_unboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            // the value 99 is boxed into an object
            object o = 99;

            // the boxed object is unboxed back into an int
            int oVal = (int)o;

            Console.WriteLine(oVal);

            Console.ReadKey();
        }
    }
}
