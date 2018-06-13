using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LISTING_4_59_Word_counter
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> counters = new Dictionary<string, int>();

            string text = File.ReadAllText("input.txt");

            string[] words = text.Split(new char[] { ' ', '.', ',' }, 
                StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                string lowWord = word.ToLower();
                if (counters.ContainsKey(lowWord))
                        counters[lowWord]++;
                    else
                        counters.Add(lowWord, 1);
            }

            var items = from pair in counters
                        orderby pair.Value descending
                        select pair;

            foreach (var pair in items)
            {
                Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
            }

            Console.ReadKey();
        }
    }
}
