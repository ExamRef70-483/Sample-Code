using System;

namespace LISTING_2_45_Using_IDisposable
{
    class CrucialConnection : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("Dispose called");
        }

        public void ThrowException()
        {
            throw new Exception("Bang");
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            using (CrucialConnection c = new CrucialConnection())
            {
                // do something with the crucial connection
            }

            Console.ReadKey();
        }
    }
}
