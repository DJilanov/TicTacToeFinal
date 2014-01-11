using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TicTacToe.DataStat;
using TicTacToe.GameLogic;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for Statistics.xaml
    /// </summary>
    public partial class Statistics : Window
    {
        private char[] splitter = { ' ' };

        String[] splitted = new String[3];

        public Statistics()
        {
            InitializeComponent();

            statisticsWindow.Background = Brushes.LightBlue;

            ShowStatistic();
        }

        private void statisticsCloseClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void statisticsResetClick(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < splitted.Length; i++)
            {
                splitted[i] = "0";
            }
            using (StreamWriter writer = new StreamWriter(@"../../saves.txt"))
            {
                writer.WriteLine(splitted[0] + " " + splitted[1] + " " + splitted[2]);
            }

            gamesPlayed.Content = splitted[0];
            gamesWon.Content = splitted[1];
            gamesPercentage.Content = splitted[2] + "%";
        }

        private void ShowStatistic()
        {
            using (StreamReader reader = new StreamReader(@"../../saves.txt"))
            {
                while (reader.Peek() >= 0)
                {
                    splitted = reader.ReadLine().Split(splitter);
                }
            }
            gamesPlayed.Content = splitted[0];
            gamesWon.Content = splitted[1];
            gamesPercentage.Content = splitted[2] + "%";
        }
    }
}
