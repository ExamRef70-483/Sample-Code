using System;
using System.Reflection;

namespace LISTING_2_53_Investigating_a_type
{
    class Person
    {
        public string Name { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            System.Type type;

            Person p = new Person();
            type = p.GetType();

            foreach(MemberInfo member in type.GetMembers() )
            {
                Console.WriteLine(member.ToString());
            }

            Console.ReadKey();
        }
    }
}
