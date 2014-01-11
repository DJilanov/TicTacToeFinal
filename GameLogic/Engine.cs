using System;
using System.Linq;
using TicTacToe.PlayerInitialize;
using System.Windows.Controls;
using System.Collections.Generic;
using TicTacToe.Events;
using TicTacToe.GameField;

namespace TicTacToe.GameLogic
{
    public class Engine
    {
        //events
        public event EventHandler<GameOverEventArgs> GameOverEvent;
        public event EventHandler<PlayerMovesEventArgs> PlayerMovesEvent;

        private Field area = null;
        public List<Player> players = new List<Player>();
       
        private int indexCurrentPlayer = 0;
        private int numberOfPlayers = 2;
        private int numberOfHumanPlayers = 0;

        //Storing the indexes of the winning Blocks
        private int[] winningBlocks;

        //GameOver flag
        private int isOver = 0;

        public int NumberOfHumanPlayers
        {
            get
            {
                return this.numberOfHumanPlayers;
            }
        }

        public Engine(List<Player> inputPlayers, int sizeGameField)
        {
            this.players = inputPlayers;

            //We could make multiplayer for more than 2 players, logic will not be much different
            this.numberOfPlayers = inputPlayers.Count;

            //The Game starts from the first player in the input List
            this.indexCurrentPlayer = 0;

            //We could make game fields with different sizes
            this.area = new GameField.Field();

            //Checking how many human players are going to play
            int tempNumberOfHumanPLayers = 0;
            
            foreach (Player player in players)
            {
                if (player is HumanPlayer)
                {
                    ++tempNumberOfHumanPLayers;
                }
            }

            this.numberOfHumanPlayers = tempNumberOfHumanPLayers;

            ////If the AI is first
            //if (players[0] is AIPlayer)
            //{
            //    PlayAITurn();
            //}
        }

        private void PlayAITurn()
        {
            int aiDecision = (players[indexCurrentPlayer] as AIPlayer).MakeDecision(this.area.CopyField());

            PlayMove(aiDecision);
        }

        //Main play method
        private void PlayMove(int blockIndex)
        {
            //Do nothing if the game is over
            if (isOver != 0)
            {
                return;
            }

            InputToMatrix(blockIndex, players[indexCurrentPlayer].Sign);

            //Notify GUI for the changes
            RaisePlayerMovesEvent(new PlayerMovesEventArgs(players[indexCurrentPlayer].Name + "played.",
                blockIndex, players[indexCurrentPlayer].Sign));

            //Check if the Game is over
            isOver = CheckIfOver();

            //If the Game is over raise GameOver event
            if (isOver == 1)
            {
                //dont touch, you will brake the magic!
                
                    RaiseGameOverEvent(new GameOverEventArgs(players[indexCurrentPlayer].Name + " with sign " +
                                                             players[indexCurrentPlayer].Sign + " has won the game.", winningBlocks));
                
                //magic.. do not touch ... it's a very powerful necromantic magic! voodoo secrets
                DataStat.SaveData d = new DataStat.SaveData();
                if (players[indexCurrentPlayer] is HumanPlayer)
                {
                    d.Save(false);
                }
                else if(players[indexCurrentPlayer] is AIPlayer)
                {
                    d.Save(true);
                }
                return;
            }
            else if (isOver == -1)
            {
                RaiseGameOverEvent(new GameOverEventArgs("Game ends with a tie.", null));

                DataStat.SaveData d = new DataStat.SaveData();
                d.Save(false);
                return;
            }

            //The next players is the next one in the list of players or the first if at the end of the list
            indexCurrentPlayer = ++indexCurrentPlayer % numberOfPlayers;

            //If the Next player to play is AIPLayer then let him play
            if (players[indexCurrentPlayer] is AIPlayer)
            {
                PlayAITurn(); 
            }
        }

        /// <summary>
        ///     Method called from the GUI on human player move
        /// </summary>
        /// <param name="cubePosition">Which cube was clicked from the 3x3 area</param>
        internal void DrawSign(int cubePosition)
        {
            if (players[indexCurrentPlayer] is HumanPlayer)
            {
                PlayMove(cubePosition);
            }
        }

        //Fully Implemented Method, usable for 3x3 and 4x4 fields
        private int CheckIfOver()
        {
            TypeOfSign s;

            this.winningBlocks = null;

            //Check the center blocks
            for (int i = 1; i < area.Size - 1; i++)
            {
                for (int j = 1; j < area.Size - 1; j++)
                {
                    s = area[i, j].Sign;
                    if (s.Equals(TypeOfSign.Undefined))
                    {
                        continue;
                    }
                    //Check if the current cell is part of an equal triple
                    if (s.Equals(area[i, j + 1].Sign) && s.Equals(area[i, j - 1].Sign))
                    {
                        winningBlocks = new int[] { i, j, i, j + 1, i, j - 1 };
                        return 1;
                    }
                    if (s.Equals(area[i + 1, j].Sign) && s.Equals(area[i - 1, j].Sign))
                    {
                        winningBlocks = new int[] { i, j, i + 1, j, i - 1, j };
                        return 1;
                    }
                    
                    if (s.Equals(area[i + 1, j + 1].Sign) && s.Equals(area[i - 1, j - 1].Sign))
                    {
                        winningBlocks = new int[] { i, j, i + 1, j + 1, i - 1, j - 1 };
                        return 1;
                    }
                            
                    if (s.Equals(area[i - 1, j + 1].Sign) && s.Equals(area[i + 1, j - 1].Sign))
                    {
                        winningBlocks = new int[] { i, j, i + 1, j + 1, i - 1, j - 1 };
                        return 1;
                    }
                }
            }

            //Check the remaining side blocks
            //fix - added check for TypeOfSign.Undefined - working properly now, good job anyway :)
            for (int i = 0; i < area.Size - 2; i++)
            {
                s = area[0, i].Sign;
                if (s.Equals(area[0, i + 1].Sign) && s.Equals(area[0, i + 2].Sign) && s != TypeOfSign.Undefined)
                {
                    winningBlocks = new int[] { 0, i, 0, i + 1, 0, i + 2 };
                    return 1;
                }

                s = area[area.Size - 1, i].Sign;
                if (s.Equals(area[area.Size - 1, i + 1].Sign) && s.Equals(area[area.Size - 1, i + 2].Sign) && s != TypeOfSign.Undefined)
                {
                    winningBlocks = new int[] { area.Size - 1, i, area.Size - 1, i + 1, area.Size - 1, i + 2 };
                    return 1;
                }

                s = area[i, 0].Sign;
                if (s.Equals(area[i + 1, 0].Sign) && s.Equals(area[i + 2, 0].Sign) && s != TypeOfSign.Undefined)
                {
                    winningBlocks = new int[] { i, 0, i + 1, 0, i + 2, 0 };
                    return 1;
                }

                s = area[i, area.Size - 1].Sign;
                if (s.Equals(area[i + 1, area.Size - 1].Sign) && s.Equals(area[i + 2, area.Size - 1].Sign) && s != TypeOfSign.Undefined)
                {
                    winningBlocks = new int[] { i, area.Size - 1, i + 1, area.Size - 1, i + 2, area.Size - 1 };
                    return 1;
                }
            }

            bool freeBlockAvailable = false;

            //Check if there are free blocks
            for (int i = 0; i < area.Size; i++)
            {
                for (int j = 0; j < area.Size; j++)
                {
                    if (area[i, j].Sign == TypeOfSign.Undefined)
                    {
                        freeBlockAvailable = true;
                    }
                }
            }

            if (freeBlockAvailable)
            {
                return 0;
            }

            return -1;
        }

        /// <summary>
        ///    Here we're initializing the cube with the signs of the players
        /// </summary>
        /// //Only a sign will be entered
        private void InputToMatrix(int cubePosition, TypeOfSign sign)
        {
            switch (cubePosition)
            {
                case 0:
                    area[0, 0] = new GameField.Block(sign);
                    break;
                case 1:
                    area[0, 1] = new GameField.Block(sign);
                    break;
                case 2:
                    area[0, 2] = new GameField.Block(sign);
                    break;
                case 3:
                    area[1, 0] = new GameField.Block(sign);
                    break;
                case 4:
                    area[1, 1] = new GameField.Block(sign);
                    break;
                case 5:
                    area[1, 2] = new GameField.Block(sign);
                    break;
                case 6:
                    area[2, 0] = new GameField.Block(sign);
                    break;
                case 7:
                    area[2, 1] = new GameField.Block(sign);
                    break;
                case 8:
                    area[2, 2] = new GameField.Block(sign);
                    break;
            }
        }

        /// <summary>
        ///    Checking if the Block was not already set with a sign by another player
        /// </summary>
        private static bool CheckIfFieldWasPlayed(Button button)
        {
            if (button.Content.Equals(TypeOfSign.O) || button.Content.Equals(TypeOfSign.X))
            {
                return true;
            }
            else
                return false;
        }
  
        //On Game Over
        private void RaiseGameOverEvent(GameOverEventArgs e)
        {
            EventHandler<GameOverEventArgs> handler = GameOverEvent;

            // Event will be null if there are no subscribers 
            if (handler != null)
            {
                handler(this, e);
            }
        }

        //On Player Move
        private void RaisePlayerMovesEvent(PlayerMovesEventArgs e)
        {
            EventHandler<PlayerMovesEventArgs> handler = PlayerMovesEvent;

            // Event will be null if there are no subscribers 
            if (handler != null)
            {
                handler(this, e);
            }
        }

        //Converts x,y coordinated into linear array index
        public static int GetBlockNumber(int myCellPosX, int myCellPosY)
        {
            return myCellPosX * 3 + myCellPosY;
        }
    }
}