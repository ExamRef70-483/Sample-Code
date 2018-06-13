using System.Collections.Generic;

namespace LISTING_4_65_List_modification
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            list.Add("add to end of list");      // add to the end of the list
            list.Insert(0, "insert at start");   // insert an item at the start
            list.Insert(1, "insert new item 1"); // insert at position
            list.InsertRange(2, new string[] { "Rob", "Immy" }); // insert a range
            list.Remove("Rob");                  // remove first occurrance of "Rob"
            list.RemoveAt(0);                    // remove element at the start
            list.RemoveRange(1, 2);              // remove two elements 
            list.Clear();                        // clear entire list        }
        }
    }
}
