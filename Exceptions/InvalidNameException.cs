using System;
using System.Linq;

namespace TicTacToe.Exceptions
{
    public class InvalidNameException : ApplicationException
    {
        public InvalidNameException(string message, Exception innerEx)
            : base(message, innerEx)
        {
        }

        public InvalidNameException(string message)
            : base(message)
        {
        }
    }
}
