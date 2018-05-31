using System;
using JokeClient.JokeService;

namespace JokeClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (JokeOfTheDayServiceClient jokeClient = new JokeOfTheDayServiceClient())
            {
                Console.WriteLine(jokeClient.GetJoke(1));
            }

            Console.ReadKey();
        }
    }
}
