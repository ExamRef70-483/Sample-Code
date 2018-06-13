using System.Collections.Generic;

namespace LISTING_4_67_Set_modification
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> set = new HashSet<string>();
            set.Add("Rob Miles");    // add an item
            set.Remove("Rob Miles"); // remove an item
            set.RemoveWhere(x => x.StartsWith("R")); // remove all items that start with 'R'
        }
    }
}
