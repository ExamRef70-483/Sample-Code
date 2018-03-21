using System;

namespace ExtensionMethods
{
    public static class MyExtensions
    {
        public static int LineCount(this String str)
        {
            return str.Split(new char[] { '\n' },
                             StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}

namespace LISTING_2_13_Extension_method
{
    using ExtensionMethods;

    class Program
    {
        static void Main(string[] args)
        {
            string text = @"A rocket explorer called Wright,
Once travelled much faster than light,
He set out one day,
In a relative way,
And returned on the previous night";
            Console.WriteLine(text.LineCount());
            Console.ReadKey();
        }
    }
}
