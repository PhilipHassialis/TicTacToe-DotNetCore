using System;

namespace TicTacToeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Play();
            Console.ReadKey();
        }
    }
}
