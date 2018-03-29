using System;

namespace LISTING_2_65_The_dispose_pattern
{
    class ResourceHolder : IDisposable
    {

        // Flag to indicate when the object has been
        // disposed
        bool disposed = false;

        public void Dispose()
        {
            // Call dispose and tell it that
            // it is being called from a Dispose call
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            // Give up if already disposed
            if (disposed)
                return;

            if(disposing)
            {
                // free any managed objects here
            }

            // Free any unmanaged objects here
        }

        ~ResourceHolder()
        {
            // Dispose only of unmanaged objects
            Dispose(false);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ResourceHolder r = new ResourceHolder();

            r.Dispose();
        }
    }
}
