using System;

namespace LISTING_2_23_Type_conversion
{
    class Miles
    {
        public double Distance { get; }

        // Conversion operator for implicit converstion to Kilometers
        public static implicit operator Kilometers(Miles t)
        {
            Console.WriteLine("Implicit conversion from miles to kilometers");
            return new Kilometers( t.Distance * 1.6);
        }

        public static explicit operator int(Miles t)
        {
            Console.WriteLine("Explicit conversion from miles to int");
            return (int)(t.Distance + 0.5);
        }

        public Miles(double miles)
        {
            Distance = miles;
        }
    }

    class Kilometers
    {
        public double Distance { get; }

        public Kilometers(double kilometers)
        {
            Distance = kilometers;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Miles m = new Miles(100);

            Kilometers k = m; // implicity convert miles to km
            Console.WriteLine("Kilometers: {0}", k.Distance);

            int intMiles = (int)m;  // explicitly convert miles to int
            Console.WriteLine("Int miles: {0}", intMiles);
            Console.ReadKey();
        }
    }
}
