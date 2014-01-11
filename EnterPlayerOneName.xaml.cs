using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Media;
using TicTacToe.Exceptions;
using TicTacToe.PlayerInitialize;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for EnterSinglePlayer.xaml
    /// </summary>
    public partial class EnterSinglePlayer : Window
    {
        public bool isChanged = true;

        const string regex = @"[a-zA-Z+]";

        public EnterSinglePlayer()
        {
            InitializeComponent();

            enterPlayerOneNameWindow.Background = Brushes.LightBlue;
        }

        private void buttonEnterPlayerOneNameClick(object sender, RoutedEventArgs e)
        {
            try
            {
                bool validate = Regex.IsMatch(textBoxPlayerOneName.Text, regex);
                if (validate == true)
                {
                    isChanged = true;
                    MainWindow.game.players[1].Name = textBoxPlayerOneName.Text;
                    Close();
                }
                else
                {
                    throw new InvalidNameException("Invalid Name");
                }
            }
            catch (InvalidNameException ne)
            {
                MessageBox.Show(ne.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                isChanged = false;
            }
        }

        private void buttonClearPlayerOneNameClick(object sender, RoutedEventArgs e)
        {
            textBoxPlayerOneName.Clear();
        }
    }
}