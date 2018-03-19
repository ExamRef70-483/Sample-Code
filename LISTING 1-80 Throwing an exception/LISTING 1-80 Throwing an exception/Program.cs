using System;

namespace LISTING_1_80_Throwing_an_exception
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                throw new Exception("I think you should know that I'm feeling very depressed.");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.HelpLink);
                Console.WriteLine(ex.HResult);
                Console.WriteLine(ex.Source);
            }
            Console.ReadKey();
        }
    }
}
