using System;

namespace LISTING_1_62_The_switch_construction
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter command: ");
            int command = int.Parse(Console.ReadLine());

            switch(command)
            {
                case 1:
                    Console.WriteLine("Command 1 chosen");
                    break;
                case 2:
                    Console.WriteLine("Command 2 chosen");
                    break;
                case 3:
                    Console.WriteLine("Command 3 chosen");
                    break;
                default:
                    Console.WriteLine("Please enter a commannd in the range 1-3");
                    break;
            }
            Console.ReadKey();
        }
    }
}
