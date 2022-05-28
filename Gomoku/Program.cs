using System;
using Gomoku.Players;
using Gomoku.Game;

namespace Gomoku
{
    class Program
    {
        static void Main(string[] args)
        {
            GameWorkflow gw = new GameWorkflow();
            gw.Run();
        }

    }
}
