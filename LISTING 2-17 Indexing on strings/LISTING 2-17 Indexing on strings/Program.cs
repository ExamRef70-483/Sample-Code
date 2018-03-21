using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISTING_2_17_Indexing_on_strings
{
    class NamedIntArray
    {
        // Create an array to store the values
        private int[] array = new int[100];

        // Decleare an indexer property
        public int this[string name]
        {
            get
            {
                switch (name)
                {
                    case "zero":
                        return array[0];
                    case "one":
                        return array[1];
                    default:
                        return -1;
                }
            }
            set
            {
                switch (name)
                {
                    case "zero":
                        array[0] = value;
                        break;
                    case "one":
                        array[1] = value;
                        break;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            NamedIntArray x = new NamedIntArray();

            x["zero"] = 99;

            Console.WriteLine(x["zero"]);

            Console.ReadKey();
        }
    }
}
