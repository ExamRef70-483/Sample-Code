using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISTING_2_5_Creating_a_reference
{
    class Alien
    {
        public int X;
        public int Y;
        public int Lives;

        public Alien(int x, int y)
        {
            X = x;
            Y = y;
            Lives = 3;
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

            Alien[] swarm = new Alien[100];

            for (int i = 0; i < swarm.Length; i++)
                swarm[i] = new Alien(0, 0);

            Console.WriteLine("swarm [0] {0}", swarm[0]);

            Console.ReadKey();
        }
    }
}
