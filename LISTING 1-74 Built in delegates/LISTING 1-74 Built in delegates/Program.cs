using System;

namespace LISTING_1_74_Built_in_delegates
{
    class Program
    {
        static Func<int, int, int> add = (a, b) => a + b;

        static Action<string> logMessage = (message) => Console.WriteLine(message);

        static Predicate<int> dividesByThree = (i) => i % 3 == 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Add called for 2 + 2: {0}", add(2, 2));
            logMessage("Log message called");
            Console.WriteLine("Divide by three called for 9: {0}", dividesByThree(9));
            Console.WriteLine("Divide by three called for 10: {0}", dividesByThree(10));
            Console.ReadKey();
        }
    }
}
