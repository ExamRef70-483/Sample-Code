using System;
using System.Reflection;

namespace LISTING_2_60_Assembly_object
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Console.WriteLine("Full name: {0}", assembly.FullName);
            AssemblyName name = assembly.GetName();
            Console.WriteLine("Major Version: {0}", name.Version.Major);
            Console.WriteLine("Minor Version: {0}", name.Version.Minor);
            Console.WriteLine("In global assembly cache: {0}", assembly.GlobalAssemblyCache);
            foreach (Module assemblyModule in assembly.Modules)
            {
                Console.WriteLine("  Module: {0}", assemblyModule.Name);
                foreach (Type moduleType in assemblyModule.GetTypes())
                {
                    Console.WriteLine("     Type: {0}", moduleType.Name);
                    foreach (MemberInfo member in moduleType.GetMembers())
                    {
                        Console.WriteLine("        Member: {0}", member.Name);
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
