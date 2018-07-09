using System;

namespace LISTING_2_4_Creating_an_enum
{
    enum AlienState
    {
        Sleeping,
        Attacking,
        Destroyed
    };

    class Program
    {
        static void Main(string[] args)
        {
            AlienState x = AlienState.Attacking;
            Console.WriteLine(x.ToString());
            Console.ReadKey();
        }
    }
}
