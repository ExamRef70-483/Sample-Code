using System;
using System.Collections.Generic;

namespace LISTING_4_60_Set_example
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> t1Styles = new HashSet<string>();
            t1Styles.Add("Electronic");
            t1Styles.Add("Disco");
            t1Styles.Add("Fast" );

            HashSet<string> t2Styles = new HashSet<string>();
            t2Styles.Add("Orchestral");
            t2Styles.Add("Classical");
            t2Styles.Add("Fast");

            HashSet<string> search = new HashSet<string>();
            search.Add("Fast");
            search.Add("Disco");

            if (search.IsSubsetOf(t1Styles))
                Console.WriteLine("All search styles present in T1");

            if (search.IsSubsetOf(t2Styles))
                Console.WriteLine("All search styles present in T2");

            Console.ReadKey();
        }
    }
}
