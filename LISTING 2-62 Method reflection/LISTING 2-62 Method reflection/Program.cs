using System;
using System.Reflection;

namespace LISTING_2_62_Method_reflection
{
    public class Calculator
    {
        public int AddInt(int v1, int v2)
        {
            return v1 + v2;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Get the type information for the Calculator class");
            Type type = typeof(Calculator);

            Console.WriteLine("Get the method info for the AddInt method");
            MethodInfo AddIntMethodInfo = type.GetMethod("AddInt");

            Console.WriteLine("Get the IL instructions for the AddInt method");
            MethodBody AddIntMethodBody = AddIntMethodInfo.GetMethodBody();

            // Print the IL instructions. 
            foreach (byte b in AddIntMethodBody.GetILAsByteArray())
            {
                Console.Write(" {0:X}", b);
            }
            Console.WriteLine();

            Console.WriteLine("Create Calculator instance");
            Calculator calc = new Calculator();

            Console.WriteLine("Create parameter array for the method");
            object[] inputs = new object[] { 1, 2 };

            Console.WriteLine("Call Invoke on the method info");
            Console.WriteLine("Cast the result to an integer");
            int result = (int) AddIntMethodInfo.Invoke(calc, inputs);
            Console.WriteLine("Result of: {0}", result);

            Console.WriteLine("Call InvokeMember on the type");
            result = (int) type.InvokeMember("AddInt",
                        BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public,
                        null,
                        calc,
                        inputs);
            Console.WriteLine("Result of: {0}", result);

            Console.ReadKey(); 
        }
    }
}
