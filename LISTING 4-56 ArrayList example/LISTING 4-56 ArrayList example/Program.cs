using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISTING_4_56_ArrayList_example
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(1);
            arrayList.Add(2);
            arrayList.Add(3);

            for (int i = 0; i < arrayList.Count; i++)
                Console.WriteLine(arrayList[i]);


            ArrayList messyList = new ArrayList();
            messyList.Add(1); // add an integer to the list
            messyList.Add("Rob Miles"); // add a string to the list
            messyList.Add(new ArrayList());  //add an ArrayList to the list

            int messyInt = (int)messyList[0];
            
            Console.ReadKey();

        }
    }
}
