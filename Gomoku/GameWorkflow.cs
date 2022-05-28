using System;
using Gomoku.Players;
using Gomoku.Game;
namespace Gomoku
{
    public class GameWorkflow
    {
        private GomokuEngine _service;
        public void Run()
        {
            ConsoleUI.DisplayWelcome();

            IPlayer p1 = GetPlayer();
            IPlayer p2 = GetPlayer();
            _service = new GomokuEngine(p1, p2);

            Console.WriteLine("\n(Randomizing)\n");

            Console.WriteLine($"{ _service.Current.Name} goes first.\n\n");

            DisplayMove();
        }

        private static IPlayer GetPlayer()
        {
            // Declared (not instantiated)
            IPlayer player;
            int playerType = ConsoleUI.GetPlayerType();

            if (playerType == 1)
            {
                string playerName = Validation.PromptUser("\nPlease enter a name: ");
                Console.WriteLine();

                player = new HumanPlayer(playerName);
            }
            else
            {
                player = new RandomPlayer();
                Console.WriteLine($"\nPlayer name is: {player.Name}");
            }

            return player;

        }

        private char[,] MakeBoard()
        {
            char[,] board = new char[15, 15];

            foreach (Stone stone in _service.Stones)
            {
                board[stone.Row, stone.Column] = stone.IsBlack ? 'X' : 'O';
            }
            return board;
        }

        public void DisplayBoard()
        {
            Console.WriteLine("   01 02 03 04 05 06 07 08 09 10 11 12 13 14 15");

            char[,] boardDisplay = MakeBoard();

            for (int row = 0; row < boardDisplay.GetLength(0); row++)
            {
                Console.Write($"{row + 1:00}");
                for (int col = 0; col < boardDisplay.GetLength(1); col++)
                {
                    //terinary - use \0 represents an empty char
                    if (boardDisplay[row, col] == 'X' || boardDisplay[row,col]=='O')
                    {
                        Console.Write($" "+boardDisplay[row,col]+" ");
                    }
                    
                    else
                    {
                        Console.Write($"{(boardDisplay[row, col] == '\0' ? " _ " : boardDisplay[row, col]) }");
                    }
                    }
                Console.WriteLine();
            }
            Console.WriteLine();

        }

        public void DisplayMove()
        {

            Result result;

            do
            {
                Console.WriteLine($"{_service.Current.Name}'s turn.");
                Stone stone = _service.Current.GenerateMove(_service.Stones);
                if (stone == null)
                {
                    int row = ConsoleUI.GetRow() - 1;
                    int col = ConsoleUI.GetColumn() - 1;
                    stone = new Stone(row, col, _service.IsBlacksTurn);
                }

                result = _service.Place(stone);
                DisplayBoard();
                if (!result.IsSuccess)
                {
                    Console.Clear();
                    Console.WriteLine($"{result.Message}");

                }

            }
            while (!_service.IsOver);

            if (_service.IsOver == true)
            {
                Console.WriteLine($"{result.Message}");
                string newGame = Validation.PromptUser("Play Again? [y/n]: ");
                if (newGame == "y")
                {
                    Console.WriteLine();
                    Run();
                }
                else
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}

