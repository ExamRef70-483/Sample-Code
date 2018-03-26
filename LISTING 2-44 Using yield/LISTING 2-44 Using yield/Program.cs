using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISTING_2_44_Using_yield
{
    class EnumeratorThing : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 1; i < 10; i++)
                yield return i;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private int limit;

        public EnumeratorThing(int limit)
        {
            this.limit = limit;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            EnumeratorThing e = new EnumeratorThing(10);

            foreach (int i in e)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }
    }
}
