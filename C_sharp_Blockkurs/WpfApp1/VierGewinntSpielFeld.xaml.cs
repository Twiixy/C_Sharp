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
    /// Interaktionslogik für VierGewinntSpielFeld.xaml
    /// </summary>
    public partial class VierGewinntSpielFeld : Window
    {
        private int _breite { get; set; }
        private int _hoehe { get; set; }
        private List<Button> buttons;


        private Button[,] buttonarray { get; set; }

        public VierGewinntSpielFeld(int breite,int hoehe)
        {
            InitializeComponent();
            _breite = breite;
            _hoehe = hoehe;
            buttons = new List<Button>();
            for (int i = 0; i < _breite; i++)
                gridSpielfeld.ColumnDefinitions.Add(new ColumnDefinition());
            for (int i = 0; i < _hoehe+1; i++)
                gridSpielfeld.RowDefinitions.Add(new RowDefinition());
            buttonarray = new Button[breite, hoehe];
            createSpielFeld();

            






        }

        private void createSpielFeld()
        {
            double breiteProElement = gridSpielfeld.ActualWidth / _breite;
            double hoeheProElement = gridSpielfeld.ActualHeight / _hoehe;
            for(int j=0;j<_hoehe+1;j++)
            for(int i = 0; i < _breite; i++)
            {
                    
                Button btn = new Button();
                    if (j != 0)
                    {
                        buttonarray[i, j-1] = btn;
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
                btn.FontSize = 20;
                btn.FontWeight = FontWeights.Bold;
                btn.Click += new RoutedEventHandler(DrawCircleButton_Click);
                //public Thickness(double left, double top, double right, double bottom);
                Thickness tmp = new Thickness(i * breiteProElement, 0, 0,0);
               // btn.Margin = tmp;
                //SP.Children.Add(btn);
               
                Grid.SetColumn(btn, i);
                Grid.SetRow(btn, j);
                Grid.SetColumnSpan(btn, 1);
                gridSpielfeld.Children.Add(btn);
            }

           
        }
        private void DrawCircleButton_Click(object sender, RoutedEventArgs e)

        {
            string content = (sender as Button).Content.ToString();
            int m = Int32.Parse(content);
            buttonarray[m, _hoehe-1].Content = "X";
            var bc = new BrushConverter();
            buttonarray[m, _hoehe - 1].Background = (Brush)bc.ConvertFrom("#ffd426");


        }


    }
}
