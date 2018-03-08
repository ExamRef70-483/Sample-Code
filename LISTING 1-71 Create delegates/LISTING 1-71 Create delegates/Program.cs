using System;

namespace LISTING_1_71_Create_delegates
{
    class Program
    {
        delegate int IntOperation(int a, int b);

        static int Add(int a, int b)
        {
            Console.WriteLine("Add called");
            return a + b;
        }

        static int Subtract(int a, int b)
        {
            Console.WriteLine("Subtract called");
            return a - b;
        }

        static void Main(string[] args)
        {
            IntOperation op;

            // Explicitly create the delegate
            op = new IntOperation(Add);

            Console.WriteLine(op(2, 2));

            // Delegate is created automatically
            // from method 

            op = Subtract;
            Console.WriteLine(op(2, 2));

            Console.ReadKey();
        }
    }
}
