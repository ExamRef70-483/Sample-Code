using System;
using System.Collections.Generic;

namespace LISTING_4_61_Queue_example
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> demoQueue = new Queue<string>();

            demoQueue.Enqueue("Rob Miles");
            demoQueue.Enqueue("Immy Brown");

            Console.WriteLine(demoQueue.Dequeue());
            Console.WriteLine(demoQueue.Dequeue());

            Console.ReadKey();
        }
    }
}
