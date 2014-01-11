using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using TicTacToe.GameLogic;
using TicTacToe.PlayerInitialize;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for StartUpScreen.xaml
    /// </summary>
    public partial class StartUpScreen : Window
    {
        private Configuration config;

        public StartUpScreen(Configuration config)
        {
            this.config = config;

            InitializeComponent();
            
            startUpScreenGrid.Background = Brushes.DarkCyan;
            listBoxChooseMode.Background = null;
            listBoxSign.Background = null;

            checkBoxSinglePlayer.IsChecked = true;
            checkBoxMultiPlayer.IsChecked = false;

            checkBoxSignX.IsChecked = true;
            checkBoxSignO.IsChecked = false;
        }

        private void buttonStartGameClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void checkBoxSinglePlayerChecked(object sender, RoutedEventArgs e)
        {
            this.config.ChosenMode = "single";

            if (checkBoxSinglePlayer.IsChecked == true)
            {
                checkBoxMultiPlayer.IsChecked = false;
            }
        }

        private void checkBoxMultiPlayerChecked(object sender, RoutedEventArgs e)
        {
            this.config.ChosenMode = "multy";

            if (checkBoxMultiPlayer.IsChecked == true)
            {
                checkBoxSinglePlayer.IsChecked = false;
            }
        }

        private void checkBoxSignXChecked(object sender, RoutedEventArgs e)
        {
            this.config.ChosenSign = TypeOfSign.X;

            if (checkBoxSignX.IsChecked == true)
            {
                checkBoxSignO.IsChecked = false;
            }
        }

        private void checkBoxSignOChecked(object sender, RoutedEventArgs e)
        {
            this.config.ChosenSign = TypeOfSign.O;

            if (checkBoxSignO.IsChecked == true)
            {
                checkBoxSignX.IsChecked = false;
            }
        }
    }
}