using System;

namespace LISTING_1_54_for_loops
{
    class Program
    {
        static int counter;

        static void initalize()
        {
            Console.WriteLine("Initialize called");
            counter = 0;
        }

        static void update()
        {
            Console.WriteLine("Update called");
            counter = counter + 1;
        }

        static bool test()
        {
            Console.WriteLine("Test called");
            return counter < 5;
        }
        static void Main(string[] args)
        {
            for(initalize(); test();  update())
            {
                Console.WriteLine("Hello {0}", counter);
            }
            Console.ReadKey();
        }
    }
}
