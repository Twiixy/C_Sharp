using System;
using System.Collections.Generic;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaktionslogik für TicTacToeSpielFeld.xaml
    /// </summary>
    public partial class TicTacToeSpielFeld : Window
    {
        private int difficultie { get; set; }
        private char currenPlayer { get; set; }
        private int size { get; set; }

        private TTTProgramm programm { get; set; }
        private ComputerZug computerTurn {get;set;}

        private int myScore { get; set; }
        private int botScore { get; set; }

        private static Button[,] buttonArray { get; set; }

        private char[][] spielfeld { get; set; }
        public TicTacToeSpielFeld(Level schwierigkeitsgrad)
        {
            InitializeComponent();
            difficultie = schwierigkeitsgrad.currentLevel ;
            myScore = 0;
            botScore = 0;
            buttonArray = new Button[,] { { btn0, btn1, btn2 }, { btn3, btn4, btn5 }, { btn6, btn7, btn8 } };

            currenPlayer = 'X';
            
            
           
            schwierigkeitsgradLabel.Content = schwierigkeitsgrad.getLevelAsString();
            UserScoreLabel.Content = myScore;
            ComputerScoreLabel.Content = botScore;

            spielfeld =new char[3][];
            spielfeld[0] = new char[3];
            spielfeld[1] = new char[3];
            spielfeld[2] = new char[3];
            size = 9;
            programm = new TTTProgramm(spielfeld);
            computerTurn = new ComputerZug();


        }

        private void updateScore()
        {
            myScore = programm.X_Siege;
            botScore = programm.O_Siege;
            UserScoreLabel.Content = myScore;
            ComputerScoreLabel.Content = botScore;
        }

        private void resetGame()
        {
            spielfeld = new char[3][];
            spielfeld[0] = new char[3];
            spielfeld[1] = new char[3];
            spielfeld[2] = new char[3];
            size = 9;
            programm.Spielfeld = spielfeld;
            computerTurn = new ComputerZug();
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    buttonArray[i, j].Content = "";
                    buttonArray[i, j].IsEnabled = true;
                }
            }


        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            btn0.Content = currenPlayer;
            btn0.Foreground = new SolidColorBrush(Colors.Red);
            spielfeld[0][0] = 'X';
            size--;
            btn0.IsEnabled = false;
            if (programm.GewinnerFeststellen())
            {
                MessageBox.Show("Spiel ende!");
                updateScore();
                resetGame();
            }
            else
            {
                if (size != 0)
                {
                    int[] pos = computerTurn.GetNextZug(difficultie + 1, spielfeld);
                    buttonArray[pos[0] - 1, pos[1] - 1].Content = "O";
                    buttonArray[pos[0] - 1, pos[1] - 1].IsEnabled = false;
                    buttonArray[pos[0] - 1, pos[1] - 1].Foreground = new SolidColorBrush(Colors.Green);
                    spielfeld[pos[0] - 1][pos[1] - 1] = 'O';

                    size--;
                    if (programm.GewinnerFeststellen())
                    {
                        MessageBox.Show("Spiel ende!");
                        updateScore();
                        resetGame();
                    }
                }
                else
                {
                    MessageBox.Show("Unentschieden DingDingDing!");
                    updateScore();
                    resetGame();
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            btn1.Content = currenPlayer;
            btn1.Foreground = new SolidColorBrush(Colors.Red);
            spielfeld[0][1] = 'X';
            size--;
            btn1.IsEnabled = false;
            if (programm.GewinnerFeststellen())
            {
                MessageBox.Show("Spiel ende!");
                updateScore();
                resetGame();
            }
            else
            {
                if (size != 0)
                {
                    int[] pos = computerTurn.GetNextZug(difficultie + 1, spielfeld);
                    buttonArray[pos[0] - 1, pos[1] - 1].Content = "O";
                    buttonArray[pos[0] - 1, pos[1] - 1].IsEnabled = false;
                    buttonArray[pos[0] - 1, pos[1] - 1].Foreground = new SolidColorBrush(Colors.Green);
                    spielfeld[pos[0] - 1][pos[1] - 1] = 'O';
                    size--;
                    if (programm.GewinnerFeststellen())
                    {
                        MessageBox.Show("Spiel ende!");
                        updateScore();
                        resetGame();
                    }
                }
                else
                {
                    MessageBox.Show("Unentschieden DingDingDing!");
                    updateScore();
                    resetGame();
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            btn2.Content = currenPlayer;
            btn2.Foreground = new SolidColorBrush(Colors.Red);
            spielfeld[0][2] = 'X';
            size--;
            btn2.IsEnabled = false;
            if (programm.GewinnerFeststellen())
            {
                MessageBox.Show("Spiel ende!");
                updateScore();
                resetGame();
            }
            else
            {
                if (size != 0)
                {
                    int[] pos = computerTurn.GetNextZug(difficultie + 1, spielfeld);
                    buttonArray[pos[0] - 1, pos[1] - 1].Content = "O";
                    buttonArray[pos[0] - 1, pos[1] - 1].IsEnabled = false;
                    buttonArray[pos[0] - 1, pos[1] - 1].Foreground = new SolidColorBrush(Colors.Green);
                    spielfeld[pos[0] - 1][pos[1] - 1] = 'O';

                    size--;
                    if (programm.GewinnerFeststellen())
                    {
                        MessageBox.Show("Spiel ende!");
                        updateScore();
                        resetGame();
                    }
                }
                else
                {
                    MessageBox.Show("Unentschieden DingDingDing!");
                    updateScore();
                    resetGame();
                }
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            btn3.Content = currenPlayer;
            btn3.Foreground = new SolidColorBrush(Colors.Red);
            spielfeld[1][0] = 'X';
            size--;
            btn3.IsEnabled = false;
            if (programm.GewinnerFeststellen())
            {
                MessageBox.Show("Spiel ende!");
                updateScore();
                resetGame();
            }
            else
            {
                if (size != 0)
                {
                    int[] pos = computerTurn.GetNextZug(difficultie + 1, spielfeld);
                    buttonArray[pos[0] - 1, pos[1] - 1].Content = "O";
                    buttonArray[pos[0] - 1, pos[1] - 1].IsEnabled = false;
                    buttonArray[pos[0] - 1, pos[1] - 1].Foreground = new SolidColorBrush(Colors.Green);
                    spielfeld[pos[0] - 1][pos[1] - 1] = 'O';

                    size--;
                    if (programm.GewinnerFeststellen())
                    {
                        MessageBox.Show("Spiel ende!");
                        updateScore();
                        resetGame();
                    }
                }
                else
                {
                    MessageBox.Show("Unentschieden DingDingDing!");
                    updateScore();
                    resetGame();
                }
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            btn4.Content = currenPlayer;
            btn4.Foreground = new SolidColorBrush(Colors.Red);
            spielfeld[1][1] = 'X';
            size--;
            btn4.IsEnabled = false;
            if (programm.GewinnerFeststellen())
            {
                MessageBox.Show("Spiel ende!");
                updateScore();
                resetGame();
            }
            else
            {
                if (size != 0)
                {
                    int[] pos = computerTurn.GetNextZug(difficultie + 1, spielfeld);
                    buttonArray[pos[0] - 1, pos[1] - 1].Content = "O";
                    buttonArray[pos[0] - 1, pos[1] - 1].IsEnabled = false;
                    buttonArray[pos[0] - 1, pos[1] - 1].Foreground = new SolidColorBrush(Colors.Green);
                    spielfeld[pos[0] - 1][pos[1] - 1] = 'O';

                    size--;
                    if (programm.GewinnerFeststellen())
                    {
                        MessageBox.Show("Spiel ende!");
                        updateScore();
                        resetGame();
                    }
                }
                else
                {
                    MessageBox.Show("Unentschieden DingDingDing!");
                    updateScore();
                    resetGame();
                }
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            btn5.Content = currenPlayer;
            btn5.Foreground = new SolidColorBrush(Colors.Red);
            spielfeld[1][2] = 'X';
            size--;
            btn5.IsEnabled = false;
            if (programm.GewinnerFeststellen())
            {
                MessageBox.Show("Spiel ende!");
                updateScore();
                resetGame();
            }
            else
            {
                if (size != 0)
                {
                    int[] pos = computerTurn.GetNextZug(difficultie + 1, spielfeld);
                    buttonArray[pos[0] - 1, pos[1] - 1].Content = "O";
                    buttonArray[pos[0] - 1, pos[1] - 1].IsEnabled = false;
                    buttonArray[pos[0] - 1, pos[1] - 1].Foreground = new SolidColorBrush(Colors.Green);
                    spielfeld[pos[0] - 1][pos[1] - 1] = 'O';

                    size--;
                    if (programm.GewinnerFeststellen())
                    {
                        MessageBox.Show("Spiel ende!");
                        updateScore();
                        resetGame();
                    }
                }
                else
                {
                    MessageBox.Show("Unentschieden DingDingDing!");
                    updateScore();
                    resetGame();
                }
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            btn6.Content = currenPlayer;
            btn6.Foreground = new SolidColorBrush(Colors.Red);
            spielfeld[2][0] = 'X';
            size--;
            btn6.IsEnabled = false;
            if (programm.GewinnerFeststellen())
            {
                MessageBox.Show("Spiel ende!");
                updateScore();
                resetGame();
            }
            else
            {
                if (size != 0)
                {
                    int[] pos = computerTurn.GetNextZug(difficultie + 1, spielfeld);
                    buttonArray[pos[0] - 1, pos[1] - 1].Content = "O";
                    buttonArray[pos[0] - 1, pos[1] - 1].IsEnabled = false;
                    buttonArray[pos[0] - 1, pos[1] - 1].Foreground = new SolidColorBrush(Colors.Green);
                    spielfeld[pos[0] - 1][pos[1] - 1] = 'O';

                    size--;
                    if (programm.GewinnerFeststellen())
                    {
                        MessageBox.Show("Spiel ende!");
                        updateScore();
                        resetGame();
                    }
                }
                else
                {
                    MessageBox.Show("Unentschieden DingDingDing!");
                    updateScore();
                    resetGame();
                }
            }
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            btn7.Content = currenPlayer;
            btn7.Foreground = new SolidColorBrush(Colors.Red);
            spielfeld[2][1] = 'X';
            size--;
            btn7.IsEnabled = false;
            if (programm.GewinnerFeststellen())
            {
                MessageBox.Show("Spiel ende!");
                updateScore();
                resetGame();
            }
            else
            {
                if (size != 0)
                {
                    size--;
                    int[] pos = computerTurn.GetNextZug(difficultie + 1, spielfeld);
                    buttonArray[pos[0] - 1, pos[1] - 1].Content = "O";
                    buttonArray[pos[0] - 1, pos[1] - 1].IsEnabled = false;
                    buttonArray[pos[0] - 1, pos[1] - 1].Foreground = new SolidColorBrush(Colors.Green);
                    spielfeld[pos[0] - 1][pos[1] - 1] = 'O';
                    if (programm.GewinnerFeststellen())
                    {
                        MessageBox.Show("Spiel ende!");
                        updateScore();
                        resetGame();
                    }

                }
                else
                {
                    MessageBox.Show("Unentschieden DingDingDing!");
                    updateScore();
                    resetGame();
                }
            }
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            btn8.Content = currenPlayer;
            btn8.Foreground = new SolidColorBrush(Colors.Red);
            spielfeld[2][2] = 'X';
            size--;
            btn8.IsEnabled = false;
            if (programm.GewinnerFeststellen())
            {
                MessageBox.Show("Spiel ende!");
                updateScore();
                resetGame();
            }
            else
            {
                if (size != 0)
                {
                    size--;
                    int[] pos = computerTurn.GetNextZug(difficultie + 1, spielfeld);
                    buttonArray[pos[0] - 1, pos[1] - 1].Content = "O";
                    buttonArray[pos[0] - 1, pos[1] - 1].IsEnabled = false;
                    buttonArray[pos[0] - 1, pos[1] - 1].Foreground = new SolidColorBrush(Colors.Green);
                    spielfeld[pos[0] - 1][pos[1] - 1] = 'O';
                    if (programm.GewinnerFeststellen())
                    {
                        MessageBox.Show("Spiel ende!");
                        updateScore();
                        resetGame();
                    }

                }
                else
                {
                    MessageBox.Show("Unentschieden DingDingDing!");
                    updateScore();
                    resetGame();
                }
            }
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            var menuWindow = new MainWindow();
            this.Hide();
            menuWindow.Show();
        }
    }
}
