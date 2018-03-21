using System;

namespace LISTING_2_16_Indexed_properties
{
    class IntArrayWrapper
    {
        // Create an array to store the values
        private int[] array = new int[100];

        // Decleare an indexer property
        public int this[int i]
        {
            get { return array[i]; }
            set { array[i] = value; }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IntArrayWrapper x = new IntArrayWrapper();

            x[0] = 99;

            Console.WriteLine(x[0]);

            Console.ReadKey();
        }
    }
}
