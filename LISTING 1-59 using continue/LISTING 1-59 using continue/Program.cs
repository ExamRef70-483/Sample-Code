using System;

namespace LISTING_1_59_using_continue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Rob", "Mary", "David", "Jenny", "Chris", "Imogen" };

            for (int index = 0; index < names.Length; index++)
            {
                if (names[index] == "David")
                    continue;

                Console.WriteLine(names[index]);
            }
            Console.ReadKey();
        }
    }
}
