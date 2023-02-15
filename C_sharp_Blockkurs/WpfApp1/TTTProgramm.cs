using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class TTTProgramm
    {
        private char[][] spielfeld;
        private static int _zaeler = 1;
        public static int _o_siege = 0;
        public static int _x_siege = 0;


        public TTTProgramm(char[][] spielfeld)
        {
            this.spielfeld = spielfeld;
        }

        public char[][] Spielfeld
        {
            get => spielfeld;
            set => spielfeld = value;
        }
        public int X_Siege
        {
            get => _x_siege;
            set => _x_siege = value;
        }
        public int Zaeler
        {
            get => _zaeler;
            set => _zaeler = value;
        }
        public int O_Siege
        {
            get => _o_siege;
            set => _o_siege = value;
        }

        public bool GewinnerFeststellen()
        {
            int p1 = 0;//anzahl der anliegenden zeichen 'X'
            int p2 = 0;//anzahl der anliegenden zeichen 'O'
            bool p1_win = false;
            bool p2_win = false;
            //Spieler 1 hat X
            //Spieler 2 hat O
            int max_i = spielfeld.Length;
            int max_j = spielfeld[0].Length;
            if (max_i == 3 && max_j == 3)//3x3 Spielfeld prüfen
            {
                //Mitte waagerecht prüfen
                if (spielfeld[1][1] == spielfeld[1][2] && spielfeld[1][1] == spielfeld[1][0])
                {
                    if (spielfeld[1][1] == 'X')
                    {
                        p1_win = true;
                    }
                    else if (spielfeld[1][1] == 'O')
                    { p2_win = true; }
                }
                //Mitte senkrechte prüfen
                else if (spielfeld[1][1] == spielfeld[2][1] && spielfeld[1][1] == spielfeld[0][1])
                {
                    if (spielfeld[1][1] == 'X')
                    {
                        p1_win = true;
                    }
                    else if (spielfeld[1][1] == 'O')
                    { p2_win = true; }
                }
                //[0,0] schräge bis [2,2] prüfen
                else if (spielfeld[1][1] == spielfeld[0][0] && spielfeld[1][1] == spielfeld[2][2])
                {
                    if (spielfeld[1][1] == 'X')
                    {
                        p1_win = true;
                    }
                    else if (spielfeld[1][1] == 'O')
                    { p2_win = true; }
                }
                //[0,2] schräge bis [2,20 prüfen
                else if (spielfeld[1][1] == spielfeld[0][2] && spielfeld[1][1] == spielfeld[2][0])
                {
                    if (spielfeld[1][1] == 'X')
                    {
                        p1_win = true;
                    }
                    else if (spielfeld[1][1] == 'O')
                    { p2_win = true; }
                }
                //[1,0] waagerechte  prüfen
                else if (spielfeld[1][0] == spielfeld[0][0] && spielfeld[1][0] == spielfeld[2][0])
                {
                    if (spielfeld[1][0] == 'X')
                    {
                        p1_win = true;
                    }
                    else if (spielfeld[1][0] == 'O')
                    { p2_win = true; }
                }
                //[1,2] waagerechte  prüfen
                else if (spielfeld[1][2] == spielfeld[0][2] && spielfeld[1][2] == spielfeld[2][2])
                {
                    if (spielfeld[1][2] == 'X')
                    {
                        p1_win = true;
                    }
                    else if (spielfeld[1][2] == 'O')
                    { p2_win = true; }
                }
                //[0,1] senkrechte prüfen
                else if (spielfeld[0][1] == spielfeld[0][0] && spielfeld[0][1] == spielfeld[0][2])
                {
                    if (spielfeld[0][1] == 'X')
                    {
                        p1_win = true;
                    }
                    else if (spielfeld[0][1] == 'O')
                    { p2_win = true; }
                }
                //[2,1] senkrechte prüfen
                else if (spielfeld[2][1] == spielfeld[2][0] && spielfeld[2][1] == spielfeld[2][2])
                {
                    if (spielfeld[2][1] == 'X')
                    {
                        p1_win = true;
                    }
                    else if (spielfeld[2][1] == 'O')
                    { p2_win = true; }
                }
            }

            else
            {
                // Spielfeld > 3x3
                for (int i = 0; i < max_i; i++)
                {
                    for (int j = 0; j < spielfeld.GetLength(1); j++)
                    {

                    }
                }
            }

            //Ausgabe beim beenden des Spiels:
            if (p1_win)
            {
                Console.WriteLine("Spieler 1 hat gewonnen (3 'X' in folge)");
                _x_siege++;
                return true;
            }
            if (p2_win)
            {
                Console.WriteLine("Spieler 2 hat gewonnen (3 'O' in folge)");
                _o_siege++;
                return true;
            }
            return false;
        }
        public void ZelleEintragen(int zeile, int spalte)
        {
            //Erster Spieler bekommt X, zweiter Spieler bekommt O
            if (_zaeler % 2 == 1)
                spielfeld[zeile - 1][spalte - 1] = 'X';
            else
                spielfeld[zeile - 1][spalte - 1] = 'O';
            _zaeler++;

        }
        public bool ZellenVerfügbarkeit(int zeile, int spalte)
        {
            //wenn \0 in der Zelle ist kann man reinschreiben
            if (spielfeld[zeile - 1][spalte - 1] == '\0')
                return true;
            return false;
        }
        public override string ToString()
        {
            string result = "";
            result += "-------------\n";
            for (int i = 0; i < spielfeld.Length; i++)
            {
                for (int j = 0; j < spielfeld[i].Length; j++)
                {
                    result += "| ";
                    if (spielfeld[i][j] == '0')
                        result += " ";
                    else
                        result += spielfeld[i][j] + " ";
                }
                result += "|\n-------------\n";
            }
            return result;
        }

    }
}
