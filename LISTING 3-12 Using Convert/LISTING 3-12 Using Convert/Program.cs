using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISTING_3_12_Using_Convert
{
    class Program
    {
        static void Main(string[] args)
        {
            string stringValue = "99";

            int intValue = Convert.ToInt32(stringValue);
            Console.WriteLine("intValue: {0}", intValue);


           // intValue = int.Parse(null);
            bool b = int.TryParse(null, out intValue);
            intValue = Convert.ToInt32("boom");

            stringValue = "True";
            bool boolValue = Convert.ToBoolean(null);
            Console.WriteLine("boolValue: {0}", boolValue);

            Console.ReadKey();

        }
    }
}
