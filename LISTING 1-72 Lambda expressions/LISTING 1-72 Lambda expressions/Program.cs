using System;

namespace LISTING_1_72_Lambda_expressions
{
    class Program
    {
        delegate int IntOperation(int a, int b);

        static IntOperation add = (a, b) => a + b;

        delegate int op(int i);

        static op square = i => i * i;

        static void Main(string[] args)
        {
            Console.WriteLine("Calling add {0}", add(2, 2));
            Console.WriteLine("Calling square {0}", square(2));

            add = (a, b) =>
            {
                Console.WriteLine("Add called");
                return a + b;
            };

            Console.ReadKey();
        }
    }
}
