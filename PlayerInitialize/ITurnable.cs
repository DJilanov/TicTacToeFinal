using System;

namespace TicTacToe.PlayerInitialize
{
    public interface ITurnable
    {
        Boolean IsMyTurn { get; set; }
    }
}
