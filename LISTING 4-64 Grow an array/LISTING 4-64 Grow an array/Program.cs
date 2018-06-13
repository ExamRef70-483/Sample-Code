using System;
using System.Collections;

namespace LISTING_4_64_Grow_an_array
{
    class Program
    {
        static void Dump(ICollection items)
        {
            Console.WriteLine(items.GetType().Name);
            int count = 0;
            foreach (var item in items)
            {
                Console.Write("{0}: ", count++);
                Console.WriteLine(item);
            }
        }

        static void Main(string[] args)
        {
            int[] dataArray = { 1, 2, 3, 4 };
            int[] tempArray = new int[5];
            dataArray.CopyTo(tempArray, 0);
            dataArray = tempArray;

            Dump(dataArray);

            Console.ReadKey();
        }
    }
}
