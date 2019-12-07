using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeGame
{

    class Board
    {
        public int[,] Tiles { get; set; }
        public bool Full
        {
            get
            {
                int tileSum = 0;
                foreach (int tile in Tiles)
                {
                    if (tile != 0) tileSum++;
                }
                return tileSum == 9;
            }
        }

        public Board()
        {
            Reset();
        }

        public void Reset()
        {
            Tiles = new int[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        }

        public void DisplayBoard()
        {
            Console.Clear();
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    if (x == 0) Console.Write(" ");
                    DisplayTile(y, x);
                    if (x < 2)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" | ");
                    }
                }
                if (y < 2)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("-----------");
                }
            }
            Console.WriteLine();
        }

        private void DisplayTile(int y, int x)
        {
            switch (Tiles[y, x])
            {
                case 0: Console.ForegroundColor = ConsoleColor.White; Console.Write((y * 3) + (x + 1 )); break;
                case 1: Console.ForegroundColor = ConsoleColor.Green; Console.Write("X"); break;
                case 2: Console.ForegroundColor = ConsoleColor.Red; Console.Write("O"); break;
            }
        }

        public void PlaceTile(int tileNumber, int playerNumber)
        {
            if (tileNumber <= 0 || tileNumber > 9) throw new Exception("Wrong input, Tile number is between 1 to 9");
            int j = (tileNumber - 1) / 3;
            int i = tileNumber - (j * 3) - 1;
            if (Tiles[j, i] == 0)
                Tiles[j, i] = playerNumber;
            else
                throw new Exception("Tile already occupied");
        }


    }
}
