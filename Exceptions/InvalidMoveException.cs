using System;
using System.Linq;

namespace TicTacToe.Exceptions
{
    public class InvalidMoveException : ApplicationException
    {
        public InvalidMoveException(string message, Exception innerEx)
            : base(message, innerEx)
        {
        }

        public InvalidMoveException(string message)
            : base(message)
        {
        }
    }
}
