using System;

namespace LISTING_2_50_Controlling_attribute_access
{
    [AttributeUsage(AttributeTargets.Class)]
    class ProgrammerAttribute : Attribute
    {
        private string programmerValue;

        public ProgrammerAttribute(string programmer)
        {
            programmerValue = programmer;
        }

        public string Programmer
        {
            get
            {
                return programmerValue;
            }
        }
    }

    [ProgrammerAttribute(programmer: "Fred")]
    class Person
    {
        // This would cause a compilation error as we 
        // are only allowed to apply this attribute to classes
        // [ProgrammerAttribute(programmer: "Fred")]
        public string Name { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
