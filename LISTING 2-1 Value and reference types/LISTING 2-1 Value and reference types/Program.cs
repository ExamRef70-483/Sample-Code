using System;

namespace LISTING_2_1_Value_and_reference_types
{
    class Program
    {
        struct StructStore
        {
            public int Data { get; set; }
        }

        class ClassStore
        {
            public int Data { get; set; }
        }

        static void Main(string[] args)
        {
            StructStore xs, ys;
            ys = new StructStore();
            ys.Data = 99;
            xs = ys;
            xs.Data = 100;
            Console.WriteLine("xStruct: {0}", xs.Data);
            Console.WriteLine("yStruct: {0}", ys.Data);

            ClassStore xc, yc;
            yc = new ClassStore();
            yc.Data = 99;
            xc = yc;
            xc.Data = 100;
            Console.WriteLine("xClass: {0}", xc.Data);
            Console.WriteLine("yClass: {0}", yc.Data);

            Console.ReadKey();
        }
    }
}
