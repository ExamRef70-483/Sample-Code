using System;

namespace LISTING_1_81_Custom_exceptions
{
    class CalcException : Exception
    {
        public enum CalcErrorCodes
        {
            InvalidNumberText,
            DivideByZero
        }

        public CalcErrorCodes Error { get; set; }

        public CalcException(string message, CalcErrorCodes error) : base(message)
        {
            Error = error;
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                throw new CalcException("Calc failed", CalcException.CalcErrorCodes.InvalidNumberText);
            }
            catch (CalcException ce) 
            {
                Console.WriteLine("Error: {0}", ce.Error);
            }
            Console.ReadKey();
        }
    }
}
