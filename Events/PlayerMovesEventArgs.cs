using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.PlayerInitialize;

namespace TicTacToe.Events
{
    public class PlayerMovesEventArgs : EventArgs
    {
        private readonly string message;
        private readonly int playedBlock;
        private TypeOfSign sign;

        public string Message
        {
            get
            {
                return this.message;
            }
        }

        public int PlayedBlock
        {
            get
            {
                return this.playedBlock;
            }
        }

        public TypeOfSign Sign
        {
            get
            {
                return this.sign;
            }
        }

        public PlayerMovesEventArgs(string message, int playedBlock, TypeOfSign sign)
        {
            this.message = message;

            this.playedBlock = playedBlock;

            this.sign = sign;
        }

    }
}
