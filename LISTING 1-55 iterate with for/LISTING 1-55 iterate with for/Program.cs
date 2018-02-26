using System;

namespace LISTING_1_55_iterate_with_for
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Rob", "Mary", "David", "Jenny", "Chris", "Imogen" };

            for (int index = 0; index < names.Length; index++)
                Console.WriteLine(names[index]);

            Console.ReadKey();
        }
    }
}
