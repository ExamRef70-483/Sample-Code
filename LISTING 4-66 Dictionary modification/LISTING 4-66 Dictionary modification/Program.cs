using System.Collections.Generic;

namespace LISTING_4_66_Dictionary_modification
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary.Add(1, "Rob Miles");  // add an entry
            dictionary.Remove(1);            // remove the entry with the given key
        }
    }
}
