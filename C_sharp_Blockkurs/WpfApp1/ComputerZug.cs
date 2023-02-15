using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class ComputerZug
    {
        private int _schwierigkeitsgrad;

        public ComputerZug() { }

        public int[] GetNextZug(int schwierigkeitsgrad, char[][] spielfeld)
        {
            _schwierigkeitsgrad = schwierigkeitsgrad;
            if (schwierigkeitsgrad == 1)
                return nextSpielfled_level_1(spielfeld);
            if (schwierigkeitsgrad == 2)
                return nextSpielfled_level_2(spielfeld);
            if (schwierigkeitsgrad == 3)
                return nextSpielfled_level_3(spielfeld);

            return new int[] { 1, 1 };

        }

        public int[] nextSpielfled_level_1(char[][] spielfeld)
        {

            int zeile, spalte;
            int zaeler = 0;
            Random rand = new Random();

            while (true)
            {

                zaeler++;
                zeile = rand.Next(3) + 1;//erzeugt eine zufaellige zahl zwischen 1 und 3
                spalte = rand.Next(3) + 1;
                if (spielfeld[zeile - 1][spalte - 1] == '\0' && spielfeld[zeile - 1][spalte - 1] != 'X')//prueft ob die Zelle frei ist
                {
                    int[] result = new int[2];
                    result[0] = zeile; result[1] = spalte;
                    return result;//gibt die Position zurueck
                }
                if (zaeler == 1000)
                { return new int[] { 1, 1 }; }//gibt 1,1 zurück falls man mit random keine freie Zelle findet (nach n versuchen)
            }

        }
        public int[] nextSpielfled_level_2(char[][] spielfeld)//Konzentriert sich auf das Verteidigen (Reallisiert nicht wenn er gewinnen koennte & beruecktsicht nicht alle faelle)
        {

            if (spielfeld[1][1] == '\0')
            { return new int[] { 2, 2 }; }//wenn die Mitte frei ist wird sie belegt



            if (_schwierigkeitsgrad == 3)
            {
                //2Randpunkte 'O' und dazwischen frei.
                if (spielfeld[0][0] == 'X' && spielfeld[2][0] == 'X' && spielfeld[1][0] == '\0')//oben links und unten links
                { return new int[] { 2, 1 }; }
                //2Randpunkte 'O' und dazwischen frei.
                if (spielfeld[0][0] == 'X' && spielfeld[0][2] == 'X' && spielfeld[0][1] == '\0')//oben links und oben rechts 
                { return new int[] { 1, 2 }; }
                //2Randpunkte 'O' und dazwischen frei.
                if (spielfeld[2][2] == 'X' && spielfeld[2][0] == 'X' && spielfeld[2][1] == '\0')//unten links und unten rechts
                { return new int[] { 3, 2 }; }
                //2Randpunkte 'O' und dazwischen frei.
                if (spielfeld[0][2] == 'X' && spielfeld[2][2] == 'X' && spielfeld[1][2] == '\0')//oben rechts und unten rechts
                { return new int[] { 2, 3 }; }
            }

            //--------------------------------------------------
            if (spielfeld[0][0] == 'X')//obenlinks 
            {
                if (spielfeld[0][1] == 'X')//1 nach rechts
                {
                    if (spielfeld[0][2] == '\0')//wenn frei
                        return new int[] { 1, 3 };
                }//-----------------------------------------------------------------------
                else if (spielfeld[1][0] == 'X')//1 nach unten
                {
                    if (spielfeld[2][0] == '\0')//wenn frei
                        return new int[] { 3, 1 };
                }//-----------------------------------------------------------------------
                else if (spielfeld[1][1] == 'X')//1 quer unten rechts
                {
                    if (spielfeld[2][2] == '\0')//wenn frei
                        return new int[] { 3, 3 };
                }//-----------------------------------------------------------------------
            }
            //--------------------------------------------------
            if (spielfeld[0][2] == 'X')//oben rechts
            {
                if (spielfeld[0][1] == 'X')//1 nach links
                {
                    if (spielfeld[0][0] == '\0')//wenn frei
                        return new int[] { 1, 1 };
                }//-----------------------------------------------------------------------
                else if (spielfeld[1][2] == 'X')//1 nach unten
                {
                    if (spielfeld[2][2] == '\0')//wenn frei
                        return new int[] { 3, 3 };
                }//-----------------------------------------------------------------------
                else if (spielfeld[1][1] == 'X')//1 quer unten links
                {
                    if (spielfeld[2][0] == '\0')//wenn frei
                        return new int[] { 3, 1 };
                }//-----------------------------------------------------------------------
            }
            //--------------------------------------------------
            if (spielfeld[2][0] == 'X')//untenlinks 
            {
                if (spielfeld[1][0] == 'X')//1 nach oben
                {
                    if (spielfeld[0][0] == '\0')//wenn frei
                        return new int[] { 1, 1 };
                }//-----------------------------------------------------------------------
                else if (spielfeld[2][1] == 'X')//1 nach rechts
                {
                    if (spielfeld[2][2] == '\0')//wenn frei
                        return new int[] { 3, 3 };
                }//-----------------------------------------------------------------------
                else if (spielfeld[1][1] == 'X')//1 quer oben rechts
                {
                    if (spielfeld[0][2] == '\0')//wenn frei
                        return new int[] { 1, 3 };
                }//-----------------------------------------------------------------------
            }
            //-------------------------------------------------
            if (spielfeld[2][2] == 'X')//untenrechts
            {
                if (spielfeld[1][2] == 'X')//1 nach oben
                {
                    if (spielfeld[0][2] == '\0')//wenn frei
                        return new int[] { 1, 3 };
                }//-----------------------------------------------------------------------
                else if (spielfeld[2][1] == 'X')//1 nach links
                {
                    if (spielfeld[2][0] == '\0')//wenn frei
                        return new int[] { 3, 1 };
                }//-----------------------------------------------------------------------
                else if (spielfeld[1][1] == 'X')//1 quer oben links
                {
                    if (spielfeld[0][0] == '\0')//wenn frei
                        return new int[] { 1, 1 };
                }//-----------------------------------------------------------------------
            }
            //-------------------------------------------------
            if (spielfeld[0][1] == 'X')//oben mitte
            {
                if (spielfeld[1][1] == 'X')//1 nach unten
                {
                    if (spielfeld[2][1] == '\0')//wenn frei
                        return new int[] { 3, 2 };
                }//-----------------------------------------------------------------------

            }
            //-------------------------------------------------
            if (spielfeld[1][0] == 'X')//links mitte
            {
                if (spielfeld[1][1] == 'X')//1 nach rechts
                {
                    if (spielfeld[1][2] == '\0')//wenn frei
                        return new int[] { 2, 3 };
                }//-----------------------------------------------------------------------
                 //-------------------------------------------------
                if (spielfeld[1][2] == 'X')//rechts mitte
                {
                    if (spielfeld[1][1] == 'X')//1 nach links
                    {
                        if (spielfeld[1][0] == '\0')//wenn frei
                            return new int[] { 2, 1 };
                    }//-----------------------------------------------------------------------
                     //-------------------------------------------------
                    if (spielfeld[2][1] == 'X')//unten mitte
                    {
                        if (spielfeld[1][1] == 'X')//1 nach oben
                        {
                            if (spielfeld[0][1] == '\0')//wenn frei
                                return new int[] { 1, 2 };
                        }//-----------------------------------------------------------------------

                    }

                }
            }

            return this.nextSpielfled_level_1(spielfeld);//random posi

        }

        public int[] nextSpielfled_level_3(char[][] spielfeld)//Kann einen Sieg reallisiert, beruecktsicht nicht alle faelle (da sonst jedes Spiel min. Unentschieden wäre)
        {

            if (spielfeld[1][1] == '\0')
            { return new int[] { 2, 2 }; }//wenn die Mitte frei ist wird sie belegt


            //--------------------------------------------------
            if (spielfeld[0][0] == 'O')//obenlinks 
            {
                if (spielfeld[0][1] == 'O')//1 nach rechts
                {
                    if (spielfeld[0][2] == '\0')//wenn frei
                        return new int[] { 1, 3 };
                }//-----------------------------------------------------------------------
                else if (spielfeld[1][0] == 'O')//1 nach unten
                {
                    if (spielfeld[2][0] == '\0')//wenn frei
                        return new int[] { 3, 1 };
                }//-----------------------------------------------------------------------
                else if (spielfeld[1][1] == 'O')//1 quer unten rechts
                {
                    if (spielfeld[2][2] == '\0')//wenn frei
                        return new int[] { 3, 3 };
                }//-----------------------------------------------------------------------
            }
            //--------------------------------------------------
            if (spielfeld[0][2] == 'O')//oben rechts
            {
                if (spielfeld[0][1] == 'O')//1 nach links
                {
                    if (spielfeld[0][0] == '\0')//wenn frei
                        return new int[] { 1, 1 };
                }//-----------------------------------------------------------------------
                else if (spielfeld[1][2] == 'O')//1 nach unten
                {
                    if (spielfeld[2][2] == '\0')//wenn frei
                        return new int[] { 3, 3 };
                }//-----------------------------------------------------------------------
                else if (spielfeld[1][1] == 'O')//1 quer unten links
                {
                    if (spielfeld[2][0] == '\0')//wenn frei
                        return new int[] { 3, 1 };
                }//-----------------------------------------------------------------------
            }
            //--------------------------------------------------
            if (spielfeld[2][0] == 'O')//untenlinks 
            {
                if (spielfeld[1][0] == 'O')//1 nach oben
                {
                    if (spielfeld[0][0] == '\0')//wenn frei
                        return new int[] { 1, 1 };
                }//-----------------------------------------------------------------------
                else if (spielfeld[2][1] == 'O')//1 nach rechts
                {
                    if (spielfeld[2][2] == '\0')//wenn frei
                        return new int[] { 3, 3 };
                }//-----------------------------------------------------------------------
                else if (spielfeld[1][1] == 'O')//1 quer oben rechts
                {
                    if (spielfeld[0][2] == '\0')//wenn frei
                        return new int[] { 1, 3 };
                }//-----------------------------------------------------------------------
            }
            //-------------------------------------------------
            if (spielfeld[2][2] == 'O')//untenrechts
            {
                if (spielfeld[1][2] == 'O')//1 nach oben
                {
                    if (spielfeld[0][2] == '\0')//wenn frei
                        return new int[] { 1, 3 };
                }//-----------------------------------------------------------------------
                else if (spielfeld[2][1] == 'O')//1 nach links
                {
                    if (spielfeld[2][0] == '\0')//wenn frei
                        return new int[] { 3, 1 };
                }//-----------------------------------------------------------------------
                else if (spielfeld[1][1] == 'O')//1 quer oben links
                {
                    if (spielfeld[0][0] == '\0')//wenn frei
                        return new int[] { 1, 1 };
                }//-----------------------------------------------------------------------
            }
            //-------------------------------------------------
            if (spielfeld[0][1] == 'O')//oben mitte
            {
                if (spielfeld[1][1] == 'O')//1 nach unten
                {
                    if (spielfeld[2][1] == '\0')//wenn frei
                        return new int[] { 3, 2 };
                }//-----------------------------------------------------------------------

            }
            //-------------------------------------------------
            if (spielfeld[1][0] == 'O')//links mitte
            {
                if (spielfeld[1][1] == 'O')//1 nach rechts
                {
                    if (spielfeld[1][2] == '\0')//wenn frei
                        return new int[] { 2, 3 };
                }//-----------------------------------------------------------------------
                 //-------------------------------------------------
                if (spielfeld[1][2] == 'O')//rechts mitte
                {
                    if (spielfeld[1][1] == 'O')//1 nach links
                    {
                        if (spielfeld[1][0] == '\0')//wenn frei
                            return new int[] { 2, 1 };
                    }//-----------------------------------------------------------------------
                     //-------------------------------------------------
                    if (spielfeld[2][1] == 'O')//unten mitte
                    {
                        if (spielfeld[1][1] == 'O')//1 nach oben
                        {
                            if (spielfeld[0][1] == '\0')//wenn frei
                                return new int[] { 1, 2 };
                        }//-----------------------------------------------------------------------

                    }

                }
            }
            //2Randpunkte 'O' und dazwischen frei.
            if (spielfeld[0][0] == 'O' && spielfeld[2][0] == 'O' && spielfeld[1][0] == '\0')//oben links und unten links
            { return new int[] { 2, 1 }; }
            //2Randpunkte 'O' und dazwischen frei.
            if (spielfeld[0][0] == 'O' && spielfeld[0][2] == 'O' && spielfeld[0][1] == '\0')//oben links und oben rechts 
            { return new int[] { 1, 2 }; }
            //2Randpunkte 'O' und dazwischen frei.
            if (spielfeld[2][2] == 'O' && spielfeld[2][0] == 'O' && spielfeld[2][1] == '\0')//unten links und unten rechts
            { return new int[] { 3, 2 }; }
            //2Randpunkte 'O' und dazwischen frei.
            if (spielfeld[0][2] == 'O' && spielfeld[2][2] == 'O' && spielfeld[1][2] == '\0')//oben rechts und unten rechts
            { return new int[] { 2, 3 }; }


            return nextSpielfled_level_2(spielfeld);
        }


    }

}
