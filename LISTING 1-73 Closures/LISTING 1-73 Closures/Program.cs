using System;

namespace LISTING_1_73_Closures
{
    class Program
    {
        delegate int GetValue();

        static GetValue getLocalInt;

        static void SetLocalInt()
        {
            // Local variable set to 99
            int localInt = 99;

            // Set delegate getLocalInt to a lambda function that
            // returns the value of localInt
            getLocalInt = () => localInt;
        }

        static void Main(string[] args)
        {
            SetLocalInt();
            Console.WriteLine("Value of localInt {0}", getLocalInt());
            Console.ReadKey();
        }
    }
}
