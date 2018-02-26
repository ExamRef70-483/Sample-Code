using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISTING_1_56_iterate_with_foreach
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Rob", "Mary", "David", "Jenny", "Chris", "Imogen" };

            foreach(string name in names)
            {
                Console.WriteLine(name);
            }

            Console.ReadKey();
        }
    }
}
