using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LISTING_1_82_Conditional_clauses
{
    class CalcException : Exception, ISerializable
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
                throw new CalcException("Calc failed", CalcException.CalcErrorCodes.DivideByZero);
            }
            catch (CalcException ce) when (ce.Error == CalcException.CalcErrorCodes.DivideByZero)
            {
                Console.WriteLine("Divide by zero error");
            }
            Console.ReadKey();
        }
    }
}
