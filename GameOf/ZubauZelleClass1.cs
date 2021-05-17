using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;

namespace GameOf
{
    class ZubauZelleClass1
    {
        public static int heightZähler { get; set; }
        public static int widthZähler { get; set; }
        public static Rectangle[,] felder { get; set; }

        public ZubauZelleClass1(int reihe_Zähler,int spalte_Zähler)
        {
            heightZähler = reihe_Zähler;
            widthZähler = spalte_Zähler;
            felder = new Rectangle[heightZähler, widthZähler];
        }
        public static void FileRead(string path, MainWindow win, int x)
        {
            if (x == 1)
            {                
                A_GenerationSpRei(path, win);
                ZubauZelleClass1 neuZell = new ZubauZelleClass1(heightZähler, widthZähler);
            }
            else if (x == 2)
            {
                A_GenerationSpRei(path, win);
            } 
            else { win.anzahlGeneration = 0; }
            win.AnzahlGeneration.Text = Convert.ToString(win.anzahlGeneration);

            List<string> linesText = new List<string>();
            linesText.Clear();
            if (x == 0)
            {
                widthZähler = Convert.ToInt32(win.Spalte.Text);
                heightZähler = Convert.ToInt32(win.Reihen.Text);
                for (int i = 0; i < heightZähler; i++)
                {
                    string neu_reihen = "";
                    for (int j = 0; j < widthZähler; j++)
                    {
                        neu_reihen += ZufallNummer(zufall);
                    }
                    linesText.Add(neu_reihen);
                }

            }
            else 
            { 
                linesText = File.ReadAllLines(path).ToList();
                linesText.RemoveRange(0,3);                
            }
            Zellebau(win, linesText.Count, linesText); 
        }
        public static void A_GenerationSpRei(string path, MainWindow win)
        {
            List<string> lines_Text = new List<string>();
            lines_Text.Clear();
            lines_Text = File.ReadAllLines(path).ToList();
            win.anzahlGeneration = Convert.ToInt32(lines_Text[0]);
            widthZähler = Convert.ToInt32(lines_Text[1]);
            heightZähler = Convert.ToInt32(lines_Text[2]);
            win.AnzahlGeneration.Text = Convert.ToString(win.anzahlGeneration);
            win.Spalte.Text = Convert.ToString(widthZähler);
            win.Reihen.Text = Convert.ToString(heightZähler);
        }
       public static Random zufall = new Random();
        public static string ZufallNummer(Random zufall)
        {
            int random = 0;
            random = zufall.Next(0, 2);
            return (random.ToString());
        }
        public static void Zellebau(MainWindow win, int reiher, List<string> spalten)
        {
            win.Zeichenfläche.Children.Clear();
            int i = 0;
            foreach (string heighZell in spalten)
            {
             
                    char[] widthZelle = heighZell.ToCharArray();
                    int j = 0;
                foreach (char widthZell in widthZelle)
                {
                    Rectangle r = new Rectangle();
                    r.Width = (win.Zeichenfläche.ActualWidth / widthZelle.Length) - 2;
                    r.Height = (win.Zeichenfläche.ActualHeight / reiher) - 2;
                    if (widthZell == '0')
                    {
                        r.Fill = Brushes.White;
                    }
                    else { r.Fill = Brushes.Black; }
                    win.Zeichenfläche.Children.Add(r);
                    Canvas.SetLeft(r, j * win.Zeichenfläche.ActualWidth / widthZelle.Length);
                    Canvas.SetTop(r, i * win.Zeichenfläche.ActualHeight / reiher);
                    r.MouseDown += win.R_MouseDown;
                    felder[i, j] = r;
                    j++;
                }
                i++;
            }
            win.zellElement = true;
        }
        public static void Speichern_(string path, MainWindow win)
        {
            StreamWriter File = new StreamWriter(path);
            File.WriteLine(win.anzahlGeneration);
            File.WriteLine(widthZähler);
            File.WriteLine(heightZähler);
            for (int i = 0; i < heightZähler; i++)
            {
                for (int j = 0; j < widthZähler; j++)
                {
                    if (felder[i, j].Fill == Brushes.Black)
                    {
                        File.Write(1);

                    }
                    else
                    {
                        File.Write(0);
                    }
                }
                File.Write('\n');
            }
            File.Close();
        }
        public static void Start_Zelle(MainWindow win)
        {
            int[,] anzhlNachbarn = new int[heightZähler, widthZähler];
            for (int i = 0; i < heightZähler; i++)
            {
                for (int j = 0; j < widthZähler; j++)
                {
                    int lebendeNachbaren = 0;

                    int nachbarnVonOben = i - 1;
                    int nachbarnVonUnter = i + 1;
                    int nachbarnVonLinks = j - 1;
                    int nachbarnVonRecht = j + 1;

                    if (nachbarnVonOben < 0) { nachbarnVonOben =  heightZähler - 1; }
                    if (nachbarnVonUnter >=  heightZähler) { nachbarnVonUnter = 0; }
                    if (nachbarnVonLinks < 0) { nachbarnVonLinks = widthZähler - 1; }
                    if (nachbarnVonRecht >=  widthZähler) { nachbarnVonRecht = 0; }

                    // Oben
                    if (felder[nachbarnVonOben, nachbarnVonLinks].Fill == Brushes.Black) { lebendeNachbaren++; };
                    if (felder[nachbarnVonOben, j].Fill == Brushes.Black) { lebendeNachbaren++; };
                    if (felder[nachbarnVonOben, nachbarnVonRecht].Fill == Brushes.Black) { lebendeNachbaren++; };
                    //mitte
                    if (felder[i, nachbarnVonLinks].Fill == Brushes.Black) { lebendeNachbaren++; };
                    if (felder[i, nachbarnVonRecht].Fill == Brushes.Black) { lebendeNachbaren++; };
                    //unter
                    if (felder[nachbarnVonUnter, nachbarnVonLinks].Fill == Brushes.Black) { lebendeNachbaren++; };
                    if (felder[nachbarnVonUnter, j].Fill == Brushes.Black) { lebendeNachbaren++; };
                    if (felder[nachbarnVonUnter, nachbarnVonRecht].Fill == Brushes.Black) { lebendeNachbaren++; };

                    anzhlNachbarn[i, j] = lebendeNachbaren;
                }
            }
            for (int i = 0; i <  heightZähler; i++)
            {
                for (int j = 0; j <  widthZähler; j++)
                {
                    if (anzhlNachbarn[i, j] < 2 || anzhlNachbarn[i, j] > 3)
                    {
                        felder[i, j].Fill = Brushes.White;
                    }
                    else if (anzhlNachbarn[i, j] == 3)
                    {
                        felder[i, j].Fill = Brushes.Black;
                    }

                }
            }
            win.anzahlGeneration++;
            win.AnzahlGeneration.Text = Convert.ToString(win.anzahlGeneration);
        }
    }
}
