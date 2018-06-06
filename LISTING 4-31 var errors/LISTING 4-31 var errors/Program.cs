namespace LISTING_4_31_var_errors
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Rob Miles";
            int age = 21;
            int silly = age - name;

            var namev = "Rob Miles";
            var agev = 21;
            var sillyv = agev - namev;
        }
    }
}
