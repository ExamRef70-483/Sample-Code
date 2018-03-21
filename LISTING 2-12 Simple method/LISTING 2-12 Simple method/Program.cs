using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISTING_2_12_Simple_method
{

class Alien
{
    public int X;
    public int Y;
    public int Lives;

    public bool RemoveLives(int livesToRemove)
    {
        Lives = Lives - livesToRemove;

        if (Lives <= 0)
        {
            Lives = 0;
            X = -1000;
            Y = -1000;
            return false;
        }
        else
        {
            return true;
        }
    }

    public Alien(int x, int y, int lives)
    {
        if (x < 0 || y < 0)
            throw new Exception("Invalid position");

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
            if (x.RemoveLives(2))
            {
                Console.WriteLine("Still alive");
            }
            else
            {
                Console.WriteLine("Alien destroyed");
            }

            Console.WriteLine("x {0}", x);

            Console.ReadKey();
        }
    }
}
