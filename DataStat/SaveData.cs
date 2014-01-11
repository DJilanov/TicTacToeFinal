using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TicTacToe.DataStat
{
    public class SaveData
    {
        //PlayerStat player = new PlayerStat(0, 0, 0.0); //control field
        static char[] delimer = { ' ' };

        public void Save(Boolean isGameWon)
        {
            int crement = isGameWon ? 1 : 0;
            String[] splitted = new String[3];
            
            using (StreamReader reader = new StreamReader(@"../../saves.txt"))
            {
                while (reader.Peek() >= 0)
                {
                    splitted = reader.ReadLine().Split(delimer, StringSplitOptions.RemoveEmptyEntries);
                }
            }

            //add those 3 values to the statistic window
            int gamesPlayed = int.Parse(splitted[0]);
            gamesPlayed++;
            int gameWon = int.Parse(splitted[1]);
            gameWon += crement;
            double wonPerc = double.Parse(splitted[2]);

            using (StreamWriter writer = new StreamWriter(@"../../saves.txt"))
            {
                writer.WriteLine(gamesPlayed + " " + gameWon + " " + (gameWon == 0 ? 0 : Math.Round((gameWon*1.0 / gamesPlayed*100),2)));
            }

        }
    }
}