using System;

namespace LISTING_2_4_Creating_an_enum
{
    enum AlienState
    {
        sleeping,
        attacking,
        destroyed
    };

    class Program
    {
        static void Main(string[] args)
        {
            AlienState x = AlienState.attacking;
            Console.WriteLine(x.ToString());
            Console.ReadKey();
        }
    }
}
