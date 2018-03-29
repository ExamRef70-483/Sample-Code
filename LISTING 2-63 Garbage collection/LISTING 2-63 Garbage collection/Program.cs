namespace LISTING_2_63_Garbage_collection
{
    class Person
    {
        long[] personArray = new long[1000000];
    }

    class Program
    {
        static void Main(string[] args)
        {
            for ( long i=0;i<100000000000;i++)
            {
                Person p = new Person();
                System.Threading.Thread.Sleep(3);
            }
        }
    }
}
