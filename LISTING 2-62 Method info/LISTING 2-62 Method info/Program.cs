using System;
using System.Reflection;

namespace LISTING_2_62_Method_info
{

    public class MethodLibrary
    {
        public int addInt ( int v1, int v2)
        {
            return v1 + v2;
        }

        public int multInt(int v1, int v2)
        {
            return v1 * v2;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(MethodLibrary);

            foreach (MethodInfo m in type.GetMethods())
            {
                Console.WriteLine("Method name: {0}", m.Name);
                Console.WriteLine("Return type: {0}", m.ReturnType);
                foreach (ParameterInfo paramInfo in  m.GetParameters())
                {
                    Console.WriteLine("  Parameter: {0}", paramInfo.Name);
                    Console.WriteLine("     Type: {0}", paramInfo.ParameterType);

                }
                MethodBody body = m.GetMethodBody();
                if (body != null)
                {
                    Console.WriteLine("Method body IL instructions");
                    foreach (byte b in body.GetILAsByteArray())
                    {
                        Console.Write(" {0:X}", b);
                    }
                    Console.WriteLine();
                }
            }

            Console.ReadKey();
        }
    }
}
