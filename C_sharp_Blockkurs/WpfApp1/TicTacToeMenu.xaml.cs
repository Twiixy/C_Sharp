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
    /// Interaktionslogik für TicTacToeMenu.xaml
    /// </summary>
    public partial class TicTacToeMenu : Window
    {
       
        private  Level currentLevel;

        public TicTacToeMenu()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)//leicht
        {
            currentLevel = new Level();
            currentLevel.currentLevel = 0;
            var spielFeld = new TicTacToeSpielFeld(currentLevel);
            this.Hide();
            spielFeld.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//mittel
        {
            currentLevel = new Level();
            currentLevel.currentLevel = 1;
            var spielFeld = new TicTacToeSpielFeld(currentLevel);
            this.Hide();
            spielFeld.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)//schwer
        {
            currentLevel = new Level();
            currentLevel.currentLevel = 2;
            var spielFeld = new TicTacToeSpielFeld(currentLevel);
            this.Hide();
            spielFeld.Show();
        }
    }
}
