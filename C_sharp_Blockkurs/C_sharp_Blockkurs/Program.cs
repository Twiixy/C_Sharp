using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace C_sharp_Blockkurs
{


//==================
// Name, Matr.nr.
//==================


        static class Program
        {

            static void Main()
            {

                Console.WriteLine("A1\n---");

                const int number = 20;
                // --- A1 a) b) ---
                // IZufallszahlen rnd16 = new Lkg(17,43,64,1,6,13);
             

                // --- A1 d) ---
                Console.Write("Test 1: { ");
                // for (int i = 0; i < number; ++i) Console.Write($"{rnd16.Zahl} ");
                Console.WriteLine("...}");

                // --- A1 e) ---
                // rnd16.Reset();
                // --- A1 f) ---
                Console.Write("Test 2: { ");
                // foreach (var z in rnd16.Menge(number)) Console.Write($"{z} ");
                Console.WriteLine("...}");

                // Falls rnd16.Menge als Erweiterung nicht funktioniert, füllen Sie eine Datenstruktur 
                // oder implementieren Sie eine Membefunktion und arbeiten auf dieser weiter.

                // --- A1 g1) --- LINQ
                // rnd16.Reset();
                // var oneOrSix = ...
                Console.Write("Test 3: { ");
                // foreach (var z in oneOrSix) Console.Write($"{z} ");
                Console.WriteLine("...}");

                // --- A1 g2) --- LINQ
                // rnd16.Reset();
                // var evenOrOdd = ...
                // foreach (var group in evenOrOdd) {
                //     Console.Write($"Test 4: (Rest ...) {{ ");
                //     foreach (var n in ...) Console.Write($"{n} ");
                //     Console.WriteLine("...}");
                // }

                Console.WriteLine("\nA2\n---");

                // --- A2 a) --- ctor mit Einlesen, Pfad ggf. anpassen
                Wetterprognose W = new Wetterprognose("../../../vorlage.txt");

            Console.WriteLine(W.ErzeugeBericht());

                // --- A2 b) c) --- Properties
                // Console.WriteLine($"Vorlage:\n{W.TextVorlage}\n");
                // Console.WriteLine($"Generator:\n{W.TextGenerator}\n");

                // --- A2 d) --- Bericht 
                // Console.WriteLine($"Bericht:\n{W.ErzeugeBericht()}");
            }

            #region Aufgabe A1

            // --- A1 a) --- Interface IZufallszahlen

            // --- A1 b) --- Klasse Lkg, implementiert IZufallszahlen
         public interface IZufallszahlen
        {
             int Zahl { get;  }
             void reset()
            {

            }

        }

            public class Lkg : IZufallszahlen
            {
                private readonly int _a, _b, _m, _min, _max, _z0;
                private int _z;


            

            // --- A1 b),c) --- ctor(a,b,m,min,max,start), exception
            Lkg(int a, int b, int m, int min, int max ,int z0)
            {
                if (max < min)
                {
                    throw new ArithmeticException("Max muss >= Min sein");
                }
                _a = a;
                _b = b;
                _m = m;
                _min = min;
                _max = max;
                _z0 = z0;
                
            }

                // --- A1 d) --- Property Zahl, nur getter

            //interface Methoden
                public int Zahl
            {
                get
                {
                    return 1;
                }
            }
            void reset() 
            {
                _z = _z0;
            }

            // --- A1 e) --- Reset

        }

            // --- A1 f) --- Erweiterungsfunktion Menge
            // public static *Rückgabetyp* Menge(*Argumente*)

            #endregion

            #region Aufgabe A2

            public class Wetterprognose
            {
            string TextVorlage;
            string TextGenerator;
            private string _textGenerator="";
            List<string[]> Optionen = new List<string[]>();
                // --- A2 a) --- ctor
                public Wetterprognose(String fileName) 
            {
                LadeVorlage(fileName);
            }

                // --- A2 a) --- LadeVorlage(String fileName), TextVorlage gefüllt
                private void LadeVorlage(String fileName) 
            {
                string tmp="";
                try
                {
                    foreach (string line in System.IO.File.ReadLines(fileName))
                    {
                        tmp += line;
                    }
                    TextGenerator = tmp;
                    TextVorlage = tmp;
                    set_textGenerator();
                }
                catch
                {
                    Console.WriteLine("Fehler beim einlesen");
                }
            }

                public static string TestVorlage = "Heute {früh,am Morgen} ist es im " +
                                                   "{Norden,Süden,Westen,Osten} zunächst noch {strichweise,stellenweise} " +
                                                   "{heiter,locker,düster,kühl} mit Werten zwischen {xy} Grad, bis mittags " +
                                                   "um die {x} Grad.";

                // --- A2 b) --- Properties TextVorlage, TextGenerator, Optionen
                // public string TextVorlage ...
                // private ... Optionen 

                // --- A2 b) c) --- spezieller setter
                // public string TextGenerator
                private void set_textGenerator()
            {
                for(int i=0;i< TextVorlage.Length; i++)
                {
                    if (TextVorlage[i] == '{')
                    {
                        string tmp="";
                        int counter2=1;
                        while (TextVorlage[i+counter2] != '}')
                        {
                            
                            tmp += TextVorlage[i+counter2];
                            counter2++;
                        }
                        Optionen.Add(tmp.Split(','));
                        i += counter2;
                        _textGenerator += " # ";
                    }
                    else
                    {
                        _textGenerator += TextVorlage[i];
                    }
                }
                Console.WriteLine(_textGenerator+"\n" + "\n" + "\n");
            }

                // --- A2 d) --- Bericht
                // public string ErzeugeBericht() { }
            public string ErzeugeBericht()
            {
                string ausgabe = "";
                int counter = 0;
                int rdmNumber;
                Random rand = new Random();
                for (int i=0;i< _textGenerator.Length; i++)
                {
                    if (_textGenerator[i] == '#')
                    {
                        if (Optionen[counter][0][0] == 'x')
                        {
                            // 15…40 x
                            rdmNumber = rand.Next(25) + 16;
                            ausgabe += rdmNumber;
                        }
                        else if (Optionen[counter][0][0] == 'x'&& Optionen[counter][0][1] == 'y')
                        {
                            //15…25 x
                            // 25…40 y
                            rdmNumber = rand.Next(10) + 16;
                            ausgabe += rdmNumber + " und ";
                            rdmNumber = rand.Next(15) + 26;
                            ausgabe += rdmNumber;
                        }
                        else
                        {
                            //rand.Next(3) + 1;//erzeugt eine zufaellige zahl zwischen 1 und 3
                            rdmNumber = rand.Next(Optionen[counter].Length);
                            ausgabe += Optionen[counter][rdmNumber];
                        }
                        counter++;

                    }
                    else
                    {
                        ausgabe += _textGenerator[i];
                    }
                }

                return ausgabe;
            }
            }

            #endregion

      
    }
}
