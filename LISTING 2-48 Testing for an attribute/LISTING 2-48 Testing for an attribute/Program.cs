using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISTING_2_48_Testing_for_an_attribute
{
    [Serializable]
    public class Person
    {
        public string Name;

        public int Age;

        [NonSerialized]
        // No need to save this
        private int screenPosition;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
            screenPosition = 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            if (Attribute.IsDefined(typeof(Person), typeof(SerializableAttribute)))
                Console.WriteLine("Person can be serialized");

            Console.ReadKey();
        }
    }
}
