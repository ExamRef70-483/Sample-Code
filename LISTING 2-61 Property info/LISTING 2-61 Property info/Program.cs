using System;
using System.Reflection;

namespace LISTING_2_61_Property_info
{
    public class Person
    {
        public String Name { get; set; }

        public String Age { get; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(Person);

            foreach (PropertyInfo p in type.GetProperties())
            {
                Console.WriteLine("Property name: {0}", p.Name);
                if(p.CanRead)
                {
                    Console.WriteLine("Can read");
                    Console.WriteLine("Set method: {0}", p.GetMethod);
                }
                if (p.CanWrite)
                {
                    Console.WriteLine("Can write");
                    Console.WriteLine("Set method: {0}", p.SetMethod);
                }
            }

            Console.ReadKey();
        }
    }
}
