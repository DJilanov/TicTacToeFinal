using System;

namespace TicTacToe.PlayerInitialize
{
    public abstract class Player
    {
        public String Name { get; set; }
        public short UniqueNumber { get; private set; }
        public TypeOfSign Sign { get; set; }

        public Player(String name, short number, TypeOfSign sign)
        {
            Name = name;
            UniqueNumber = number;
            Sign = sign;
        }
    }
}
