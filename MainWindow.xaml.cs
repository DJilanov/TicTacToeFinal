using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TicTacToe.GameLogic;
using TicTacToe.PlayerInitialize;
using TicTacToe.Exceptions;
using TicTacToe.GameField;
using TicTacToe.DataStat;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Configuration config;
        public static Engine game; //turned static to access it's members from static methods

        private Button[] gameFieldUI;

        //init
        public MainWindow()
        {
            config = new Configuration();

            StartUpScreen startUpScreen = new StartUpScreen(config);
            startUpScreen.ShowDialog();

            CreateGameLogic(config);

            game.GameOverEvent += HandleGameOver;
            game.PlayerMovesEvent += HandlePlayerMoves;

            InitializeComponent();
            
            AdjustUIPlayersNames();

            //The UI should easily update Buttons when an event is sent from the Engine(on GameOver or PLayerMoves)
            gameFieldUI = new Button[9];

            gameFieldUI[0] = this.One;
            gameFieldUI[1] = this.Two;
            gameFieldUI[2] = this.Three;
            gameFieldUI[3] = this.Four;
            gameFieldUI[4] = this.Five;
            gameFieldUI[5] = this.Six;
            gameFieldUI[6] = this.Seven;
            gameFieldUI[7] = this.Eight;
            gameFieldUI[8] = this.Nine;

            
        }

        private void HandlePlayerMoves(object sender, Events.PlayerMovesEventArgs e)
        {
            ErrorBox.Text = e.Message;

            gameFieldUI[e.PlayedBlock].Content = e.Sign;
        }

        private void HandleGameOver(object sender, Events.GameOverEventArgs e)
        {
            MessageBox.Show(e.Message);

            ErrorBox.Text = e.Message;

            PaintWinningButtons(e.WinningBLocks);
        }

        //Marking the winning blocks
        private void PaintWinningButtons(int[] winningBlocks)
        {
            //If there is no tie
            if (winningBlocks != null)
            {
                for (int i = 0; i < winningBlocks.Length; i++)
                {
                    //TODO
                    //Color the winning blocks
                    //gameFieldUI[winningBlocks[i]].BorderThickness = new Thickness(10);
                }
            }
        }

        //Creating a custom Game depending on User choice
        private void CreateGameLogic(Configuration config)
        {
            if (config.ChosenMode.Equals("multy"))
            {
                if (config.ChosenSign.Equals(TypeOfSign.X))
                {
                    game = new GameLogic.Engine(new List<Player>()
                    {
                        new HumanPlayer("Player 2", 0, TypeOfSign.O),
                        new HumanPlayer("Player 1", 1, TypeOfSign.X)
                    }, 3);

                }
                else
                {
                    game = new GameLogic.Engine(new List<Player>()
                    {
                        new HumanPlayer("Player 2", 0, TypeOfSign.X),
                        new HumanPlayer("Player 1", 1, TypeOfSign.O)
                    }, 3);
                }
                return;
            }
            else
            {
                if (config.ChosenSign.Equals(TypeOfSign.X))
                {
                    game = new GameLogic.Engine(new List<Player>()
                    {
                        new HumanPlayer("Player 1", 0, TypeOfSign.X),
                        new AIPlayer("AI Player", 1, TypeOfSign.O)
                    }, 3);
                }
                else 
                {
                    game = new GameLogic.Engine(new List<Player>()
                    {
                        new HumanPlayer("Player 1", 0, TypeOfSign.O),
                        new AIPlayer("AI PLayer", 1, TypeOfSign.X)
                    }, 3);
                }

                return;
            }
        }

        //  

        //onClickEventsForGameArea
        private void One_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (One.Content.Equals(TypeOfSign.O) || One.Content.Equals(TypeOfSign.X))
                {
                    throw new InvalidMoveException("Invalid Move");
                }
                game.DrawSign(0);
                DeactivateChangePlayerNameButtons();
            }
            catch (InvalidMoveException me)
            {
                MessageBox.Show(me.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
          
           
        }

        private void Two_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Two.Content.Equals(TypeOfSign.O) || Two.Content.Equals(TypeOfSign.X))
                {
                    throw new InvalidMoveException("Invalid Move");
                }
                game.DrawSign(1);
                DeactivateChangePlayerNameButtons();
            }
            catch (InvalidMoveException me)
            {
                MessageBox.Show(me.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }

           
        }

        private void Three_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Three.Content.Equals(TypeOfSign.O) || Three.Content.Equals(TypeOfSign.X))
                {
                    throw new InvalidMoveException("Invalid Move");
                }
                game.DrawSign(2);
                DeactivateChangePlayerNameButtons();
            }
            catch (InvalidMoveException me)
            {
                MessageBox.Show(me.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void Four_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Four.Content.Equals(TypeOfSign.O) || Four.Content.Equals(TypeOfSign.X))
                {
                    throw new InvalidMoveException("Invalid Move");
                }
                game.DrawSign(3);
                DeactivateChangePlayerNameButtons();
            }
            catch (InvalidMoveException me)
            {
                MessageBox.Show(me.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Five_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Five.Content.Equals(TypeOfSign.O) || Five.Content.Equals(TypeOfSign.X))
                {
                    throw new InvalidMoveException("Invalid Move");
                }
                game.DrawSign(4);
                DeactivateChangePlayerNameButtons();
            }
            catch (InvalidMoveException me)
            {
                MessageBox.Show(me.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void Six_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Six.Content.Equals(TypeOfSign.O) || Six.Content.Equals(TypeOfSign.X))
                {
                    throw new InvalidMoveException("Invalid Move");
                }

                game.DrawSign(5);
                DeactivateChangePlayerNameButtons();
            }
            catch (InvalidMoveException me)
            {
                MessageBox.Show(me.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void Seven_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Seven.Content.Equals(TypeOfSign.O) || Seven.Content.Equals(TypeOfSign.X))
                {
                    throw new InvalidMoveException("Invalid Move");
                }
                game.DrawSign(6);
                DeactivateChangePlayerNameButtons();
            }
            catch (InvalidMoveException me)
            {
                MessageBox.Show(me.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void Eight_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Eight.Content.Equals(TypeOfSign.O) || Eight.Content.Equals(TypeOfSign.X))
                {
                    throw new InvalidMoveException("Invalid Move");
                }
                game.DrawSign(7);
                DeactivateChangePlayerNameButtons();
            }
            catch (InvalidMoveException me)
            {
                MessageBox.Show(me.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void Nine_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Nine.Content.Equals(TypeOfSign.O) || Nine.Content.Equals(TypeOfSign.X))
                {
                    throw new InvalidMoveException("Invalid Move");
                }

                game.DrawSign(8);
                DeactivateChangePlayerNameButtons();
            }
            catch (InvalidMoveException me)
            {
                MessageBox.Show(me.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //do not touch the stuff below
        private void buttonChangePlayerOneNameClick(object sender, RoutedEventArgs e)
        {
            EnterSinglePlayer enterFirstPlayerName = new EnterSinglePlayer();
            enterFirstPlayerName.ShowDialog();
            if (enterFirstPlayerName.isChanged)
            {
                playerOneDefaultName.Content = enterFirstPlayerName.textBoxPlayerOneName.Text;
            }
        }

        private void buttonChangePlayerTwoNameClick(object sender, RoutedEventArgs e)
        {
            EnterMultyPlayer enterSecondPlayerName = new EnterMultyPlayer();
            enterSecondPlayerName.ShowDialog();
            if (enterSecondPlayerName.isChanged)
            {
                playerTwoDefaultName.Content = enterSecondPlayerName.textBoxPlayerTwoName.Text;
            }
        }

        /// <summary>
        /// New game works at some extend:
        /// TO DO:
        /// call it from method, better handling and last game import to history
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuNewGameClick(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            config = new Configuration();

            StartUpScreen startUpScreen = new StartUpScreen(config);
            startUpScreen.ShowDialog();

            CreateGameLogic(config);

            game.GameOverEvent += HandleGameOver;
            game.PlayerMovesEvent += HandlePlayerMoves;

            InitializeComponent();

            AdjustUIPlayersNames();

            //The UI should easily update Buttons when an event is sent from the Engine(on GameOver or PLayerMoves)
            gameFieldUI = new Button[9];

            gameFieldUI[0] = this.One;
            gameFieldUI[1] = this.Two;
            gameFieldUI[2] = this.Three;
            gameFieldUI[3] = this.Four;
            gameFieldUI[4] = this.Five;
            gameFieldUI[5] = this.Six;
            gameFieldUI[6] = this.Seven;
            gameFieldUI[7] = this.Eight;
            gameFieldUI[8] = this.Nine;

            #region clearing button content and activating buttons change name
            
            One.Content = "";
            Two.Content = "";
            Three.Content = "";
            Four.Content = "";
            Five.Content = "";
            Six.Content = "";
            Seven.Content = "";
            Eight.Content = "";
            Nine.Content = "";
            buttonChangePlayerOneName.IsEnabled = true;
            if (startUpScreen.checkBoxMultiPlayer.IsChecked==true)
            {
                buttonChangePlayerTwoName.IsEnabled = true;
            }
            #endregion

        }

        private void menuStatisticsClick(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {

            Statistics statistic = new Statistics();
            statistic.ShowDialog();
        }

        private void menuExitClick(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            Exit();
        }

        private void AdjustUIPlayersNames()
        {
            if (config.ChosenMode == "single")
            {
                buttonChangePlayerTwoName.IsEnabled = false;
            }
        }

        private void radButtonCloseClick(object sender, RoutedEventArgs e)
        {
            Exit();
        }
  
        private void Exit()
        {
            MessageBoxResult result = MessageBox.Show("Do you really want to quit the game?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        //Drag Window
        private void mainWindowMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void DeactivateChangePlayerNameButtons()
        {
            buttonChangePlayerOneName.IsEnabled = false;

            buttonChangePlayerTwoName.IsEnabled = false;
        }
    }
}
