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
using System.Text.RegularExpressions;

namespace WpfApp1
{
    /// <summary>
    /// Interaktionslogik für VierGewinntMenu.xaml
    /// </summary>
    public partial class VierGewinntMenu : Window
    {
        private bool korrekteEngabe { get; set; }
        private int breite { get; set; }
        private int hoehe { get; set; }

        public VierGewinntMenu()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void breiteEingabe_Copy_TextChanged(object sender, TextChangedEventArgs e)
        {
           

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                int numVal = Int32.Parse(breiteEingabe.Text);
                int numVal2 = Int32.Parse(hoeheEingabe.Text);
                if (numVal < 4 || numVal > 20)
                {
                    MessageBox.Show("Bitte nur Zahlen zwischen 4 und 20 eingeben");
                    korrekteEngabe = false;
                    return;
                }
                else
                {
                    korrekteEngabe = true;
                    breite = numVal;
                }
                if (numVal2 < 4 || numVal2 > 20)
                {
                    MessageBox.Show("Bitte nur Zahlen zwischen 4 und 20 eingeben");
                    korrekteEngabe = false;
                    return;
                }
                else
                {
                    korrekteEngabe = true;
                    hoehe = numVal2;
                }

            }
            catch
            {
                MessageBox.Show("Bitte nur zahlen eingeben");
            }
            if (korrekteEngabe)
            {
                var window = new VierGewinntSpielFeld(breite,hoehe);
                this.Hide();
                window.Show();
            }

        }
    }
}
