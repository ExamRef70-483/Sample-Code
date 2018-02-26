using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISTING_1_57_uppercase_Person
{
    class Program
    {
        class Person
        {
            public string Name { get; set; }

            public Person(string name)
            {
                Name = name;
            }
        }

        static void Main(string[] args)
        {
            Person[] people = new Person[] {
                new Person("Rob"), new Person("Mary"),
                new Person("David"), new Person("Jenny"),
                new Person("Chris"), new Person("Imogen") };

            foreach (Person person in people)
                person.Name = person.Name.ToUpper();

            foreach (Person person in people)
                Console.WriteLine(person.Name);

            Console.ReadKey();
        }
    }
}
