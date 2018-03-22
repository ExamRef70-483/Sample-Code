using System;

namespace LISTING_2_23_Type_conversion
{
    class Temperature
    {
        double tempValue;

        // Conversion operator for implicit converstion to int
        public static implicit operator int (Temperature t)
        {
            // Round the result up before returning it
            return (int) (t.tempValue + 0.5);
        }

        public Temperature(double tempValue)
        {
            this.tempValue = tempValue;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Temperature t = new Temperature(20.6);

            int intTemp = (int)t;
            Console.WriteLine("Temperature: {0}", intTemp);

            Console.ReadKey();
        }
    }
}
