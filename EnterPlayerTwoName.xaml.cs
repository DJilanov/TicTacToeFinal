using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TicTacToe.Exceptions;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for EnterMultyPlayer.xaml
    /// </summary>
    public partial class EnterMultyPlayer : Window
    {
        public bool isChanged = true;

        const string regex = @"[a-zA-Z+]";

        public EnterMultyPlayer()
        {
            InitializeComponent();

            enterPlayerTwoName.Background = Brushes.LightBlue;
        }

        private void buttonEnterPlayerTwoNameClick(object sender, RoutedEventArgs e)
        {
            bool validate = Regex.IsMatch(textBoxPlayerTwoName.Text, regex);

            if (validate == true)
            {
                isChanged = true;
                MainWindow.game.players[0].Name = textBoxPlayerTwoName.Text;
                Close();
            }
            else
            {
                try
                {
                    if (validate == false)
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
        }

        private void buttonClearPlayerTwoNameClick(object sender, RoutedEventArgs e)
        {
            textBoxPlayerTwoName.Clear();
        }

       
    }
}
