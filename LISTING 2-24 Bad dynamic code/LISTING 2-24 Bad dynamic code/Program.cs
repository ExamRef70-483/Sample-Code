using System;

namespace LISTING_2_24_Bad_dynamic_code
{
    class MessageDisplay
    {
        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MessageDisplay m = new MessageDisplay();
            m.DisplayMessage("Hello world");

            dynamic d = new MessageDisplay();
            d.Banana("hello world");
        }
    }
}
