using System;
using System.Collections;

namespace LISTING_4_69_ICollection_interface
{
    class CompassCollection : ICollection
    {
        // Array containing values in this collection
        string[] compassPoints = { "North", "South", "East", "West" };

        // Count property to return the length of the collection
        public int Count
        {
            get { return compassPoints.Length; }
        }

        // Returns an object that can be used to syncrhonise 
        // access to this object
        public object SyncRoot
        {
            get { return this; }
        }

        // Returns true if the collection is thread safe
        // This collection is not
        public bool IsSynchronized
        {
            get { return false; }
        }

        // Provide a copyto behavior
        public void CopyTo(Array array, int index)
        {
            foreach (string point in compassPoints)
            {
                array.SetValue(point, index);
                index = index + 1;
            }
        }

        // Required for IEnumerate
        // Returns the enumerator from the embedded array
        public IEnumerator GetEnumerator()
        {
            return compassPoints.GetEnumerator();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CompassCollection compass = new CompassCollection();


            foreach (string point in compass)
                Console.WriteLine(point);

            Console.ReadKey();
        }
    }
}
