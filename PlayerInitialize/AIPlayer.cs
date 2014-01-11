using System;
using System.Collections.Generic;
using TicTacToe.GameField;
using TicTacToe.GameLogic;

namespace TicTacToe.PlayerInitialize
{
    public class AIPlayer : Player, IThinkfull
    {
        private Field gameField;

        private List<int> possibleLevelOneMoves;

        public AIPlayer(String name, short id, TypeOfSign sign)
            : base(name, id, sign)
        {   }

        //Make a decision for the next move based on the input field
        public int MakeDecision(Field inputField)
        {
            gameField = inputField;

            possibleLevelOneMoves = new List<int>();

            //Used to store the moves that can be done, starting from teh most important
            SortedDictionary<int, int> actions = new SortedDictionary<int, int>();
            
            //For each configuration check how many free, my and enemy cells are there
            CheckRows(actions);
            CheckColumns(actions);
            CheckDiagonals(actions);

            return TakeBestAction(actions);
        }

        private int TakeBestAction(SortedDictionary<int, int> actions)
        {
            if (actions.ContainsKey(3))
            {
                return actions[3];
            }
            else if (actions.ContainsKey(2))
            {
                return actions[2];
            }
            else
            {
                //Take random action level one
                //return actions[1];
                Random randomGenerator = new Random();
                return possibleLevelOneMoves[randomGenerator.Next(possibleLevelOneMoves.Count)];
            }
        }

        private void CheckRows(SortedDictionary<int, int> actions)
        {
            int freeCells = 0;
            int myCells = 0;
            int myCellPos = 0;
            int enemyCells = 0;

            //For each row
            for (int i = 0; i < gameField.Size; i++)
            {
                freeCells = 0;
                myCells = 0;
                myCellPos = 0;
                enemyCells = 0;
                for (int j = 0; j < gameField.Size; j++)
                {
                    if (gameField[i, j].Sign == TypeOfSign.Undefined)
                    {
                        ++freeCells;
                        myCellPos = j;
                    }
                    else if (gameField[i, j].Sign == this.Sign)
                    {
                        ++myCells;
                    }
                    else
                    {
                        ++enemyCells;
                    }
                }
                //Check situation
                ProvideAction(freeCells, myCells, i, myCellPos, enemyCells, actions);
                
            }
        }

        //Check Columns
        private void CheckColumns(SortedDictionary<int, int> actions)
        {
            int freeCells = 0;
            int myCells = 0;
            int myCellPos = 0;
            int enemyCells = 0;

            //For each col
            for (int i = 0; i < gameField.Size; i++)
            {
                freeCells = 0;
                myCells = 0;
                myCellPos = 0;
                enemyCells = 0;
                for (int j = 0; j < gameField.Size; j++)
                {
                    if (gameField[j, i].Sign == TypeOfSign.Undefined)
                    {
                        ++freeCells;
                        myCellPos = j;
                    }
                    else if (gameField[j, i].Sign == this.Sign)
                    {
                        ++myCells;
                    }
                    else
                    {
                        ++enemyCells;
                    }
                }
                //Check situation
                ProvideAction(freeCells, myCells, myCellPos, i, enemyCells, actions);
            }
        }

        //CheckDiagonals
        private void CheckDiagonals(SortedDictionary<int, int> actions)
        {
            int freeCells = 0;
            int myCells = 0;
            int myCellPos = 0;
            int enemyCells = 0;

            //Check main diagonal
            for (int i = 0; i < gameField.Size; i++)
            {
                if (gameField[i, i].Sign == TypeOfSign.Undefined)
                    {
                        ++freeCells;
                        myCellPos = i;
                    }
                    else if (gameField[i, i].Sign == this.Sign)
                    {
                        ++myCells;
                    }
                    else
                    {
                        ++enemyCells;
                    }
            }

            //Check situation
            ProvideAction(freeCells, myCells, myCellPos, myCellPos, enemyCells, actions);

            //Check secondary diagonal
            freeCells = 0;
            myCells = 0;
            myCellPos = 0;
            enemyCells = 0;

            for (int i = 0; i < gameField.Size; i++)
            {
                if (gameField[i, gameField.Size - 1 - i].Sign == TypeOfSign.Undefined)
                {
                    ++freeCells;
                    myCellPos = i;
                }
                else if (gameField[i, gameField.Size - 1 - i].Sign == this.Sign)
                {
                    ++myCells;
                }
                else
                {
                    ++enemyCells;
                }
            }

            //Check situation
            ProvideAction(freeCells, myCells, myCellPos, gameField.Size - 1 - myCellPos, enemyCells, actions);

        }

        private void ProvideAction(int freeCells, int myCells, int myCellPosX, int myCellPosY, int enemyCells, SortedDictionary<int, int> actions)
        {
            if (freeCells > 0)
            {
                switch (CheckSituation(freeCells, myCells, enemyCells))
                {
                    case 3:
                        {
                            //Going to win
                            if (!actions.ContainsKey(3))
                                actions.Add(3, Engine.GetBlockNumber(myCellPosX, myCellPosY));
                            break;
                        }
                    case 2:
                        {
                            //Stopping the other player to win
                            if (!actions.ContainsKey(2))
                                actions.Add(2, Engine.GetBlockNumber(myCellPosX, myCellPosY));
                            break;
                        }
                    default:
                        {
                            //Other situation
                            if (!actions.ContainsKey(1))
                            {
                                actions.Add(1, Engine.GetBlockNumber(myCellPosX, myCellPosY));
                            }

                            possibleLevelOneMoves.Add(Engine.GetBlockNumber(myCellPosX, myCellPosY));

                            break;
                        }
                }
            }
        }


        private int CheckSituation(int freeCells, int myCells, int enemyCells)
        {
            if (myCells == 2 && freeCells == 1)
            {
                return 3;
            }

            if (enemyCells == 2 && freeCells == 1)
            {
                return 2;
            }

            return 1;
        }

        public void Draw()
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }
    }
}
