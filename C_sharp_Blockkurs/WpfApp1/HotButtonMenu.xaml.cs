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
using System.Threading;

namespace WpfApp1
{
    /// <summary>
    /// Interaktionslogik für HotButtonMenu.xaml
    /// </summary>
    public partial class HotButtonMenu : Window
    {
        string path = @"C:\Users\di461643\source\repos\C_Sharp_Projekt_gitVersion\C_Sharp\C_sharp_Blockkurs\WpfApp1\HotButtonScore.txt";
        private List<ScoreData> highscoreList { get; set; }
        private int _Clicks { get; set; }
        Thread timerThread;
        private static Mutex global_mutex { get; set; }
        public HotButtonMenu()
        {
            InitializeComponent();
            _Clicks = 0;
            hotButton.IsEnabled = false;
            global_mutex = new Mutex();
            highscoreList = new List<ScoreData>();
            loadListData();
            //create grind row
            for (int i = 0; i < highscoreList.Count(); i++)
                gridScore.RowDefinitions.Add(new RowDefinition());
        }

        private void HotButtonClick(object sender, RoutedEventArgs e)
        {
            _Clicks++;
        }

        

        private void BackButton(object sender, RoutedEventArgs e)
        {
            var menuWindow = new MainWindow();
            this.Hide();
            menuWindow.Show();
        }

      

        private void StartGameButton(object sender, RoutedEventArgs e)
        {
            resetGame();
            
            hotButton.IsEnabled = true;
            _Clicks = 0;
            startButton.IsEnabled = false;
            //Thread thread = new Thread(Waiting);
            // thread.Start();
            if (timerThread != null)
                timerThread.Start();

        }

        private void resetGame()
        {
            resetTimerThread();
            pbStatus.Value = 0;
        }

        private void resetTimerThread()//ToDo: vlt in reset und start umbenennen
        {
            //if (timerThread != null && timerThread.IsAlive)
               // timerThread.Abort();

            timerThread = new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(delegate ()
                    {
                        pbStatus.Value += 10;
                    }));
                    Thread.Sleep(1000);//hier zeit einstellen
                }

                // ProgressComplete();
            });
            timerThread.IsBackground = true;
        }

       

        private void pbStatus_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (pbStatus.Value == 100)
            {
                startButton.IsEnabled = true;
                MessageBox.Show($"Anzahl der Klicks: {_Clicks}");
                string txt;
                if (userNamebox.Text == "" || userNamebox.Text == null)
                    txt = "Unknown";
                else
                    txt = userNamebox.Text;
                addHighScore(txt,_Clicks);
                writeListData(txt, _Clicks);
                hotButton.IsEnabled = false;
            }
        }

        private void loadListData()
        {
            string[] tmp;
            try
            {
                foreach (string line in System.IO.File.ReadLines(path))
                {
                    tmp = line.Split(';');
                    addHighScore(tmp[0], Int32.Parse(tmp[1]));

                }
            }
            catch
            {
                MessageBox.Show("Text Laden fehlgeschlagen");
            }


        }
        private async void writeListData(string name,int clicks)
        {
            try
            {
                // using (System.IO.StreamWriter sw = System.IO.File.AppendText(path))
                //{
                //   sw.WriteLine(name + ";" + clicks);
                // }

                using System.IO.StreamWriter file = new(path, append: true);
                await file.WriteLineAsync(name + "; " + clicks);
            }
            catch
            {
                MessageBox.Show("Schreiben Fehlgeschlagen");
            }
        }




        private void loadHighScore()
        {
            var ab = from item in highscoreList
                   orderby item._Clicks descending
                   select item;
            List<ScoreData> sortList = ab.ToList();

            gridScore.Children.Clear();
            for (int i = 0; i < sortList.Count(); i++)
            {
                
                TextBlock tb = new TextBlock();
                tb.Text = sortList[i]._Name +"  "+ sortList[i]._Clicks;
            //Grid.SetColumn(btn, i);
                Grid.SetRow(tb, i);
                Grid.SetColumn(tb, i);
                Grid.SetRow(tb, i);
                Grid.SetColumnSpan(tb, 1);
                Grid.SetRowSpan(tb, 1);
                // Grid.SetColumnSpan(btn, 1);
                gridScore.Children.Add(tb);
                
            }
               

        }

        private void addHighScore(string Name, int Clicks)
        {
            highscoreList.Add(new ScoreData(Name, Clicks));
            gridScore.RowDefinitions.Add(new RowDefinition());
            loadHighScore();


        }

        private void ScrollBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
}
