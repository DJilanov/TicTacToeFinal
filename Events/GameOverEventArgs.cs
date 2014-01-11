using System;
using System.Linq;
using TicTacToe.GameLogic;

namespace TicTacToe.Events
{
    //Class for storing the GameOver Info for GameOver event
    public class GameOverEventArgs : EventArgs
    {
        private readonly string message;
        private readonly int[] winningBlocks;

        public string Message
        {
            get
            {
                return this.message;
            }
        }

        public int[] WinningBLocks
        {
            get
            {
                if (this.winningBlocks != null)
                {
                    return new int[] { Engine.GetBlockNumber(this.winningBlocks[0], this.winningBlocks[1]),
                    Engine.GetBlockNumber(this.winningBlocks[2], this.winningBlocks[3]),
                    Engine.GetBlockNumber(this.winningBlocks[4], this.winningBlocks[5])};
                }
                else
                {
                    return null;
                }
            }
        }

        public GameOverEventArgs(string message, int[] winningBlocks)
        {
            this.message = message;

            this.winningBlocks = winningBlocks;
        }
    }
}