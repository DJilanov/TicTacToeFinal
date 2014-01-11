using System;
using TicTacToe.PlayerInitialize;

namespace TicTacToe.GameField
{
    public struct Block
    {
        private TypeOfSign sign;

        public TypeOfSign Sign 
        {
            get { return this.sign; }
            set { this.sign = value; } 
        }

        public Block(TypeOfSign sign)
            : this()
        {
            Sign = sign;
        }
    }
}
