using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace WpfApp1
{
    /// <summary>
    /// Interaktionslogik für VierGewinntSpielFeld.xaml
    /// </summary>
    public partial class VierGewinntSpielFeld : Window
    {
        private char zeichen { get; set; }
        private int _breite { get; set; }
        private int _hoehe { get; set; }
        private List<Button> buttons;
        private int X_Score { get; set; }
        private int O_Score { get; set; }
        private int einfügeoperationen { get; set; }
        private int letzteEingefügteZeile { get; set; }



        private Button[,] buttonarray { get; set; }

        public VierGewinntSpielFeld(int breite, int hoehe)
        {
            InitializeComponent();
            _breite = breite;
            _hoehe = hoehe;
            buttons = new List<Button>();
            for (int i = 0; i < _breite; i++)
                gridSpielfeld.ColumnDefinitions.Add(new ColumnDefinition());
            for (int i = 0; i < _hoehe + 1; i++)
                gridSpielfeld.RowDefinitions.Add(new RowDefinition());
            buttonarray = new Button[breite, hoehe];
            zeichen = 'X';
            einfügeoperationen = 0;
            X_Score = 0;
            O_Score = 0;
            createSpielFeld();

           



        }

        

        private bool gewinnerFeststellen(int spalte)//true wenn gewonnen
        {

            string currPlayer = buttonarray[spalte, letzteEingefügteZeile].Content.ToString();

            // Prüfung der Horizontalen
            for (int y = 0; y < _hoehe - 3; y++)
                {
                    for (int x = 0; x < _breite; x++)
                    {
                        
                        if (buttonarray[x, y].Content.ToString() ==currPlayer && buttonarray[x, y + 1].Content.ToString() == currPlayer && buttonarray[x, y + 2].Content.ToString() == currPlayer && buttonarray[x, y + 3].Content.ToString() == currPlayer)
                        {
                              if (currPlayer == "X")
                              {
                                  X_Score++;
                            return true;
                              }
                              else
                              {
                                  O_Score++;
                            return true;
                        }
                        }
                    }
                }

                // Prüfung der Vertikalen
                for (int x = 0; x < _breite - 3; x++)
                {
                    for (int y = 0; y < _hoehe; y++)
                    {
                    if (buttonarray[x, y].Content.ToString() ==currPlayer && buttonarray[x + 1, y].Content.ToString() == currPlayer && buttonarray[x + 2, y].Content.ToString() == currPlayer && buttonarray[x + 3, y].Content.ToString() == currPlayer)
                    {
                        if (currPlayer == "X")
                        {
                            X_Score++;
                            return true;
                        }
                        else
                        {
                            O_Score++;
                            return true;
                        }
                    
                    }
                    }
                }

                // Pfrüfung der Diagonalen (aufsteigend)
                for (int x = 3; x < _breite; x++)
                {
                    for (int y = 0; y < _hoehe - 3; y++)
                    {
                        if (buttonarray[x, y].Content.ToString() ==currPlayer && buttonarray[x - 1, y + 1].Content.ToString() == currPlayer && buttonarray[x - 2, y + 2].Content.ToString() == currPlayer && buttonarray[x - 3, y + 3].Content.ToString() == currPlayer)
                        {
                        if (currPlayer == "X")
                        {
                            X_Score++;
                            return true;
                        }
                        else
                        {
                            O_Score++;
                            return true;
                        }
                    }
                    }
                }

                // Prüfung der Diagonalen (absteigend)
                for (int x = 3; x < _breite; x++)
                {
                    for (int y = 3; y < _hoehe; y++)
                    {
                        if (buttonarray[x, y].Content.ToString() ==currPlayer && buttonarray[x - 1, y - 1].Content.ToString() == currPlayer && buttonarray[x - 2, y - 2].Content.ToString() == currPlayer && buttonarray[x - 3, y - 3].Content.ToString() == currPlayer)
                        {
                        if (currPlayer == "X")
                        {
                            X_Score++;
                            return true;
                        }
                        else
                        {
                            O_Score++;
                            return true;
                        }
                    }
                    }
                }
            return false;
            
        }

        private void createSpielFeld()
        {
            double breiteProElement = gridSpielfeld.ActualWidth / _breite;
            double hoeheProElement = gridSpielfeld.ActualHeight / _hoehe;
            for (int j = 0; j < _hoehe + 1; j++)
                for (int i = 0; i < _breite; i++)
                {

                    Button btn = new Button();
                    if (j != 0)
                    {
                        buttonarray[i, j - 1] = btn;
                    }
                    //  btn.Height = breiteProElement ;
                    // btn.Width = breiteProElement ;
                    // btn.Content = "test";
                    btn.Tag = i;
                    btn.Content = i;
                    if (j != 0)
                    {
                        btn.Content = "";
                        btn.IsEnabled = false;
                    }
                    else
                    {
                        btn.Background = new SolidColorBrush(Colors.BlueViolet);
                    }
                    btn.FontSize = 20;
                    btn.FontWeight = FontWeights.Bold;
                    btn.Click += new RoutedEventHandler(ButtonEingabe);
                    //public Thickness(double left, double top, double right, double bottom);
                    Thickness tmp = new Thickness(i * breiteProElement, 0, 0, 0);
                    // btn.Margin = tmp;
                    //SP.Children.Add(btn);

                    Grid.SetColumn(btn, i);
                    Grid.SetRow(btn, j);
                    Grid.SetColumnSpan(btn, 1);
                    gridSpielfeld.Children.Add(btn);
                }


        }
        private void ButtonEingabe(object sender, RoutedEventArgs e)

        {
            string content = (sender as Button).Content.ToString();
            int m = Int32.Parse(content);
            // buttonarray[m, _hoehe-1].Content = "X";
            // var bc = new BrushConverter();
            //  buttonarray[m, _hoehe - 1].Background = (Brush)bc.ConvertFrom("#ffd426");
            if (einfügeoperationen % 2 == 0)
            {
                zeichen = 'X';
                nextZeichen.Content = 'O';
            }
            else
            {
                zeichen = 'O';
                nextZeichen.Content = 'X';
            }
            
            einfügen(m);
            if (gewinnerFeststellen(m))
            {
                MessageBox.Show("Spiel vorbei");
                scoreupdate();
                resetGame();
                return;
            }



        }

        private void resetGame()
        {
            buttonarray = new Button[_breite, _hoehe];
            zeichen = 'X';
            einfügeoperationen = 0;
            createSpielFeld();
        }

        private void scoreupdate()
        {
            XWins.Content = X_Score;
            Owins.Content = O_Score;
        }
        private bool einfügen(int spalte)//true falls eingefügt wurde
        {
            
            einfügeoperationen++;
            for (int i = _hoehe - 1; i >= 0; i--)
            {
                if (buttonarray[spalte, i].Content.ToString() == "")
                {
                    buttonarray[spalte, i].Content = zeichen;
                    if (zeichen == 'X')
                        buttonarray[spalte, i].Foreground = new SolidColorBrush(Colors.Red);
                    if (zeichen == 'O')
                        buttonarray[spalte, i].Foreground = new SolidColorBrush(Colors.Green);
                    buttonarray[spalte, i].Background = new SolidColorBrush(Colors.CadetBlue);
                    letzteEingefügteZeile = i;
                    return true;
                }
            }
            return false;


        }


        private void button_Click(object sender, RoutedEventArgs e)
        {
            var menuWindow = new MainWindow();
            this.Hide();
            menuWindow.Show();
        }
    }
}
