using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.GameField;

namespace TicTacToe.PlayerInitialize
{
    public interface IThinkfull
    {
        int MakeDecision(Field inputField);
    }
}
