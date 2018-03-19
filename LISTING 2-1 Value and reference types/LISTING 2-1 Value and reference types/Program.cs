using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISTING_2_1_Value_and_reference_types
{
    class Program
    {
        struct valueStore
        {
            public int data;
        }

        class referenceStore
        {
            public int data;
        }

        static void Main(string[] args)
        {
            valueStore xValue, yValue;
            yValue = new valueStore();
            yValue.data = 99;
            xValue = yValue;
            xValue.data = 100;
            Console.WriteLine("xValue: {0}", xValue.data);
            Console.WriteLine("yValue: {0}", yValue.data);

            referenceStore xReference, yReference;
            yReference = new referenceStore();
            yReference.data = 99;
            xReference = yReference;
            xReference.data = 100;
            Console.WriteLine("xReference: {0}", xReference.data);
            Console.WriteLine("yReference: {0}", yReference.data);

            Console.ReadKey();
        }
    }
}
