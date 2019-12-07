using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeGame
{
    class Game
    {
        private Board board;
        private int currentPlayer;

        public Game()
        {
            ResetGame();
        }

        public void ResetGame()
        {
            board = new Board();
            currentPlayer = 1;
        }

        public void Play()
        {
            do
            {
                board.DisplayBoard();
                GetPlayerInput();


            } while (!board.Full && !Won());
            board.DisplayBoard();
            Console.WriteLine("Game Over!");
        }

        private void GetPlayerInput()
        {
            int tileNumber = 0;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Please enter a free tile number from 1 to 9: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out tileNumber))
                {
                    try
                    {
                        board.PlaceTile(tileNumber, currentPlayer);
                        currentPlayer = currentPlayer == 1 ? 2 : 1;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message + " - press any key to input tile");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Wrong input. Please enter a free tile number from 1 to 9");
                }
            } while (tileNumber == 0);
        }

        private bool Won()
        {
            for (int i = 0; i < 3; i++)
            {
                if (board.Tiles[i,0]!=0 && board.Tiles[i, 0] == board.Tiles[i, 1] && board.Tiles[i, 2] == board.Tiles[i, 2])
                {
                    Console.WriteLine("Victory on row {0}", i);
                    return true;
                }
                if (board.Tiles[0,i]!=0 && board.Tiles[0, i] == board.Tiles[1, i] && board.Tiles[2, i] == board.Tiles[i, 2])
                {
                    Console.WriteLine("Victory on column {0}", i);
                    return true;
                }
            }
            if (board.Tiles[0,0]!=0 && board.Tiles[0, 0] == board.Tiles[1, 1] && board.Tiles[1, 1] == board.Tiles[2, 2]) return true;
            if (board.Tiles[0,2]!=0 && board.Tiles[0, 2] == board.Tiles[1, 1] && board.Tiles[1, 1] == board.Tiles[2, 0]) return true;

            return false;
        }

    }
}
