using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace GameOf
{
    public partial class MainWindow : Window
    {
        const int reiheZähler = 20, spalteZähler = 20;
        Rectangle[,] felder = new Rectangle[reiheZähler, spalteZähler];
        bool autoStart = false;
        DispatcherTimer startAutomatisch = new DispatcherTimer();
        int anzahlGeneration = 0;

        public MainWindow()
        {
            InitializeComponent();
            startAutomatisch.Interval = TimeSpan.FromSeconds(0.1);
            startAutomatisch.Tick += StartAutomatisch_Tick;
        }
        private void Zellbau_Click(object sender, RoutedEventArgs e)
        {
            string path = @"File.txt";
            FileRead(path, this, 0);
        }
        private void StartAutomatisch_Tick(object sender, EventArgs e)
        {

            int[,] anzhlNachbarn = new int[reiheZähler, spalteZähler];
            for (int i = 0; i < reiheZähler; i++)
            {
                for (int j = 0; j < spalteZähler; j++)
                {
                    int lebendeNachbaren = 0;

                    int nachbarnVonOben = i - 1;
                    int nachbarnVonUnter = i + 1;
                    int nachbarnVonLinks = j - 1;
                    int nachbarnVonRecht = j + 1;

                    if (nachbarnVonOben < 0) { nachbarnVonOben = reiheZähler - 1; }
                    if (nachbarnVonUnter >= reiheZähler) { nachbarnVonUnter = 0; }
                    if (nachbarnVonLinks < 0) { nachbarnVonLinks = spalteZähler - 1; }
                    if (nachbarnVonRecht >= spalteZähler) { nachbarnVonRecht = 0; }

                    // Oben
                    if (felder[nachbarnVonOben, nachbarnVonLinks].Fill == Brushes.Red) { lebendeNachbaren++; };
                    if (felder[nachbarnVonOben, j].Fill == Brushes.Red) { lebendeNachbaren++; };
                    if (felder[nachbarnVonOben, nachbarnVonRecht].Fill == Brushes.Red) { lebendeNachbaren++; };
                    //mitte
                    if (felder[i, nachbarnVonLinks].Fill == Brushes.Red) { lebendeNachbaren++; };
                    if (felder[i, nachbarnVonRecht].Fill == Brushes.Red) { lebendeNachbaren++; };
                    //unter
                    if (felder[nachbarnVonUnter, nachbarnVonLinks].Fill == Brushes.Red) { lebendeNachbaren++; };
                    if (felder[nachbarnVonUnter, j].Fill == Brushes.Red) { lebendeNachbaren++; };
                    if (felder[nachbarnVonUnter, nachbarnVonRecht].Fill == Brushes.Red) { lebendeNachbaren++; };

                    anzhlNachbarn[i, j] = lebendeNachbaren;
                }
            }
            for (int i = 0; i < reiheZähler; i++)
            {
                for (int j = 0; j < spalteZähler; j++)
                {
                    if (anzhlNachbarn[i, j] < 2 || anzhlNachbarn[i, j] > 3)
                    {
                        felder[i, j].Fill = Brushes.Cyan;
                    }
                    else if (anzhlNachbarn[i, j] == 3)
                    {
                        felder[i, j].Fill = Brushes.Red;
                    }

                }
            }
            anzahlGeneration++;
            AnzahlGeneration.Text = Convert.ToString(anzahlGeneration);
        }

        private void R_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ((Rectangle)sender).Fill = (((Rectangle)sender).Fill == Brushes.Cyan) ? Brushes.Red : Brushes.Cyan;
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            int[,] anzhlNachbarn = new int[reiheZähler, spalteZähler];
            for (int i = 0; i < reiheZähler; i++)
            {
                for (int j = 0; j < spalteZähler; j++)
                {
                    int lebendeNachbaren = 0;

                    int nachbarnVonOben = i - 1;
                    int nachbarnVonUnter = i + 1;
                    int nachbarnVonLinks = j - 1;
                    int nachbarnVonRecht = j + 1;

                    if (nachbarnVonOben < 0) { nachbarnVonOben = reiheZähler - 1; }
                    if (nachbarnVonUnter >= reiheZähler) { nachbarnVonUnter = 0; }
                    if (nachbarnVonLinks < 0) { nachbarnVonLinks = spalteZähler - 1; }
                    if (nachbarnVonRecht >= spalteZähler) { nachbarnVonRecht = 0; }

                    // Oben
                    if (felder[nachbarnVonOben, nachbarnVonLinks].Fill == Brushes.Red) { lebendeNachbaren++; };
                    if (felder[nachbarnVonOben, j].Fill == Brushes.Red) { lebendeNachbaren++; };
                    if (felder[nachbarnVonOben, nachbarnVonRecht].Fill == Brushes.Red) { lebendeNachbaren++; };
                    //mitte
                    if (felder[i, nachbarnVonLinks].Fill == Brushes.Red) { lebendeNachbaren++; };
                    if (felder[i, nachbarnVonRecht].Fill == Brushes.Red) { lebendeNachbaren++; };
                    //unter
                    if (felder[nachbarnVonUnter, nachbarnVonLinks].Fill == Brushes.Red) { lebendeNachbaren++; };
                    if (felder[nachbarnVonUnter, j].Fill == Brushes.Red) { lebendeNachbaren++; };
                    if (felder[nachbarnVonUnter, nachbarnVonRecht].Fill == Brushes.Red) { lebendeNachbaren++; };

                    anzhlNachbarn[i, j] = lebendeNachbaren;
                }
            }
            for (int i = 0; i < reiheZähler; i++)
            {
                for (int j = 0; j < spalteZähler; j++)
                {
                    if (anzhlNachbarn[i, j] < 2 || anzhlNachbarn[i, j] > 3)
                    {
                        felder[i, j].Fill = Brushes.Cyan;
                    }
                    else if (anzhlNachbarn[i, j] == 3)
                    {
                        felder[i, j].Fill = Brushes.Red;
                    }

                }
            }
            anzahlGeneration++;
            AnzahlGeneration.Text = Convert.ToString(anzahlGeneration);
        }

        private void Auto_Start_Click(object sender, RoutedEventArgs e)
        {
            if (autoStart)
            {
                autoStart = false;
                Auto_Start.Content = "Starte Automatisch";
                startAutomatisch.Stop();


            }
            else
            {
                autoStart = true;
                Auto_Start.Content = "Stop Automatisch";
                startAutomatisch.Start();
            }

        }

        private void Kleine_Groesse_Click(object sender, RoutedEventArgs e)
        {
            Contrrol.DoKlein(this);
        }

        private void Mittlere_Groesse_Click(object sender, RoutedEventArgs e)
        {
            Contrrol.DoMittlere(this);
        }

        private void Full_Screen_Click(object sender, RoutedEventArgs e)
        {
            Contrrol.DoFullScreen(this);
        }

        private void Speichern_Click(object sender, RoutedEventArgs e)
        {
            autoStart = false;
            Auto_Start.Content = "Starte Automatisch";
            startAutomatisch.Stop();

            StreamWriter File1 = new StreamWriter("File1.txt");
            for (int i = 0; i < reiheZähler; i++)
            {
                for (int j = 0; j < spalteZähler; j++)
                {
                    if (felder[i, j].Fill == Brushes.Cyan)
                    {
                        File1.Write(0);

                    }
                    else
                    {
                        File1.Write(1);
                    }
                }
                File1.Write('\n');
            }
            File1.Close();
            StreamWriter File2 = new StreamWriter("File2.txt");
            File2.Write(anzahlGeneration);
            File2.Close();
        }

        private void Upload_Click(object sender, RoutedEventArgs e)
        {
 
            autoStart = false;
            Auto_Start.Content = "Starte Automatisch";
            startAutomatisch.Stop();
            string path = @"File1.txt";
            FileRead(path, this, 1);
                

        }
        public static void FileRead(string path, MainWindow win, int x)
        {
            List<string> linesText = new List<string>();
            linesText.Clear();
            linesText = File.ReadAllLines(path).ToList();
            Zellebau(win, linesText.Count, linesText);
            if (x == 1) 
            {
                string generation = File.ReadAllText(@"File2.txt");
                win.anzahlGeneration = Convert.ToInt32(generation);
            } else { win.anzahlGeneration = 0; }
            win.AnzahlGeneration.Text = Convert.ToString(win.anzahlGeneration);

        }
        public static void Zellebau(MainWindow win, int reiher, List<string> spalten)
        {
            int i = 0;
            foreach (string spalte in spalten)
            {
                char[] charspalten = spalte.ToCharArray();
                int j = 0;
                foreach (char charspalte in charspalten)
                {
                    Rectangle r = new Rectangle();
                    r.Width = (win.Zeichenfläche.ActualWidth / charspalten.Length) - 2;
                    r.Height = (win.Zeichenfläche.ActualHeight / reiher) - 2;
                    if (charspalte == '0')
                    {
                        r.Fill = Brushes.Cyan;
                    }
                    else { r.Fill = Brushes.Red; }
                    win.Zeichenfläche.Children.Add(r);
                    Canvas.SetLeft(r, j * win.Zeichenfläche.ActualWidth / charspalten.Length);
                    Canvas.SetTop(r, i * win.Zeichenfläche.ActualHeight / reiher);
                    r.MouseDown += win.R_MouseDown;
                    win.felder[i, j] = r;
                    j++;
                }
                i++;
            }
        }

    }
}
