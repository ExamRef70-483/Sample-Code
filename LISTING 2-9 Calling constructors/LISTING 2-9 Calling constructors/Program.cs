using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISTING_2_9_Calling_constructors
{
    class Alien
    {
        public int X;
        public int Y;
        public int Lives;

        public Alien(int x, int y, int lives)
        {
            if (x < 0 || y < 0)
                throw new ArgumentOutOfRangeException("Invalid position");

            X = x;
            Y = y;
            Lives = lives;
        }

        public Alien(int x, int y) : this(x, y, 3)
        {
        }

        public override string ToString()
        {
            return string.Format("X: {0} Y: {1} Lives: {2}", X, Y, Lives);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Alien x = new Alien(100, 100);
            Console.WriteLine("x {0}", x);

            Console.ReadKey();
        }
    }
}
