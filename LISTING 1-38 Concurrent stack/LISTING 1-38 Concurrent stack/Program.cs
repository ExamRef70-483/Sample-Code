using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace LISTING_1_38_Concurrent_stack
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcurrentStack<string> stack = new ConcurrentStack<string>();
            stack.Push("Rob");
            stack.Push("Miles");
            string str;
            if (stack.TryPeek(out str))
                Console.WriteLine("Peek: {0}", str);
            if (stack.TryPop(out str))
                Console.WriteLine("Pop: {0}", str);
            Console.ReadKey();
        }
    }
}
