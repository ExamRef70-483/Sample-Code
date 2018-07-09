using System;

namespace LISTING_2_28_Using_a_property
{
    class Customer
    {
        private string _nameValue;

        public string Name
        {
            get
            {
                return _nameValue;
            }
            set
            {
                if (value == "")
                    throw new Exception("Invalid customer name");

                _nameValue = value;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Customer c = new Customer();
            c.Name = "Rob";
            Console.WriteLine("Customer name: {0}", c.Name);

            Console.ReadKey();
            // this statement will throw an exception
            c.Name = "";
        }
    }
}
