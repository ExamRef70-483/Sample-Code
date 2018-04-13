using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace LISTING_2_46_The_serializable_atribute
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
        }
    }
}
