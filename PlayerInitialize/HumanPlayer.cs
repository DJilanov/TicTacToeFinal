using System;

namespace TicTacToe.PlayerInitialize
{
    public class HumanPlayer : Player
    {
        public Boolean IsMyTurn { get; set; }

        public HumanPlayer(String name, short id, TypeOfSign sign)
            : base(name, id, sign)
        { }
    }
}
