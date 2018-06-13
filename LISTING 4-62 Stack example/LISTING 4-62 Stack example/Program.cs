using System;
using System.Collections.Generic;

namespace LISTING_4_62_Stack_example
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> demoStack = new Stack<string>();

            demoStack.Push("Rob Miles");
            demoStack.Push("Immy Brown");

            Console.WriteLine(demoStack.Pop());
            Console.WriteLine(demoStack.Pop());

            Console.ReadKey();  
        }
    }
}
