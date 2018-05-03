using System;

namespace LISTING_3_31_Line_numbers
{
    class Program
    {
        static void Exploder()
        {
#line 1 "kapow.ninja"
            throw new Exception("Bang");
#line default
        }
        static void Main(string[] args)
        {
            try
            {
                Exploder();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            Console.ReadKey();
        }
    }
}
