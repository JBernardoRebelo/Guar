using System;

namespace Guar
{
    public class Program
    {
        private static void Main(string[] args)
        {
            // Call start
            GameFlow game = new GameFlow();
            game.Start();

            Console.ReadLine();
        }
    }
}

