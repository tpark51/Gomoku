using System;
using Gomoku.Players;
using Gomoku.Game;
namespace Gomoku
{
    public class ConsoleUI
    {
        public static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to Gomoku\n=================\n");

        }

        public static int GetPlayerType()
        {        //i want it to say player 1, player 2
            return Validation.PromptUser4Int(@"Player 1 is a:
1. Human
2. Random
Select [1-2]: ", 1, 2);
        }

        public void DisplayBoard()
        {
            Console.WriteLine("  01 02 03 04 05 06 07 08 09 10 11 12 13 14 15");
        }

        public static int GetRow()
        {
            return Validation.PromptUser4Int("Enter a row: ", 1, 15);
        }

        public static int GetColumn()
        {
            return Validation.PromptUser4Int("Enter a column: ", 1, 15);
        }


    }
}
