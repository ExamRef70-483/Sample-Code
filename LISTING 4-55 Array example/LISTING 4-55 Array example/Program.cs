using System;

namespace LISTING_4_55_Array_example
{
    class Program
    {
        static void Main(string[] args)
        {
                // Array of integers
                int[] intArray = new int[5];

                intArray[0] = 99; // put 99 in the first element
                intArray[4] = 100; // put 100 in the last element

                // Use an index to work through the array     
                for (int i = 0; i < intArray.Length; i++)
                    Console.WriteLine(intArray[i]);

                // Initilaise a new array
                intArray = new int[] { 1, 2, 3, 4 };

                // Use a foreach to work through the array
                foreach (int intValue in intArray)
                    Console.WriteLine(intValue);

            string[,] compass = new string[3, 3]
            {
                { "NW","N","NE" },
                {"W", "C", "E" },
                { "SW", "S", "SE" }
            };

            Console.WriteLine(compass[0, 0]);  // prints NW
            Console.WriteLine(compass[2, 2]);  // prints SE

            Console.ReadKey();
        }
    }
}
