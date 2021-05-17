using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Threading.Tasks;
using Microsoft.Win32;


namespace GameOf

{
    public partial class MainWindow : Window
    {
        public bool autoStart = false, zellElement = false;
        public int anzahlGeneration = 0, speedStart = 250;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Zellbau_Click(object sender, RoutedEventArgs e)
        {
            int spalteZähler, reiheZähler;
            spalteZähler = IstNummer(Spalte.Text);
            reiheZähler = IstNummer(Reihen.Text);
            if ((spalteZähler != 0) && (reiheZähler != 0))
            {
                autoStart = false;
                Auto_Start.Content = "Starte";
                ZubauZelleClass1 neuZell = new ZubauZelleClass1(reiheZähler, spalteZähler);
                string path = "";
                ZubauZelleClass1.FileRead(path, this, 0);
            }
        }
        public void R_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ((Rectangle)sender).Fill = (((Rectangle)sender).Fill == Brushes.White) ? Brushes.Black : Brushes.White;
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            if (zellElement)
            {
                ZubauZelleClass1.Start_Zelle(this);
            }
        }

        private void Auto_Start_Click(object sender, RoutedEventArgs e)
        {
            if (autoStart)
            {
                autoStart = false;
                Auto_Start.Content = "Starte";
            }
            else
            {
                if (zellElement)
                {
                    autoStart = true;
                    Auto_Start.Content = "Stop";
                    Start_Automatic();
                }
            }

        }
        private void Speed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (IsLoaded)
            {
                speedStart = (Convert.ToInt32(Speed.Value));
            }
        }
        public async void Start_Automatic()
        {
            do
            {
               await Task.Delay(speedStart);
               ZubauZelleClass1.Start_Zelle(this);
            } while (autoStart == true);
        }
        
        private void Speichern_Click(object sender, RoutedEventArgs e)
        {
            if (zellElement)
            {
                autoStart = false;
                Auto_Start.Content = "Starte";
                SaveFileDialog path = new SaveFileDialog();
                path.Filter="txt file|*.txt";
                path.ShowDialog();
                if (path.FileName!="")
                {
                    ZubauZelleClass1.Speichern_(path.FileName, this);
                }


                
            }
        }
        private void Upload_Click(object sender, RoutedEventArgs e)
        {
            autoStart = false;
            Auto_Start.Content = "Starte";
            OpenFileDialog path = new OpenFileDialog();
            path.Filter="txt file|*.txt";
            Nullable<bool> result = path.ShowDialog();
            if (result==true)
            {
                ZubauZelleClass1.FileRead(path.FileName, this, 1);
            }
               
          
        }
        public static int IstNummer(string textString)
        {
            bool istNummer = false;
            int nummer = 0; ;
            char[] charsText = textString.ToCharArray();
            foreach (char ch in charsText)
            {
                istNummer = char.IsNumber(ch);
            }
            if (istNummer) 
            {
                nummer = Convert.ToInt32(textString);
                if ((nummer >= 1) && (nummer <= 100))
                {
                    return (nummer);
                }
                else 
                {
                    MessageBox.Show("Bitte die Zahl soll von 1 bis 100 gewesen worden");
                    return (0);
                }
            }
            else 
            { 
                MessageBox.Show("Bitte schreiben Sie eine Zählen");
                return (0);
            }
        }
        private void Kleine_Groesse_Click(object sender, RoutedEventArgs e)
        {
            bool auto_Start = false;
            string path1 = @"Temp1.txt";
            if (zellElement)
            {
                if (autoStart)
                {
                    auto_Start = true;
                    autoStart = false;
                }
                ZubauZelleClass1.Speichern_(path1, this);
                Contrrol.DoKlein(this);
                ZubauZelleClass1.FileRead(path1, this, 2);
                if (auto_Start)
                {
                    autoStart = true;
                    Start_Automatic();
                }

            }
            else { Contrrol.DoKlein(this); }

        }

        private void Mittlere_Groesse_Click(object sender, RoutedEventArgs e)
        {
            bool auto_Start = false;
            string path1 = @"Temp1.txt";
            if (zellElement)
            {

                if (autoStart)
                {
                    auto_Start = true;
                    autoStart = false;
                }
                ZubauZelleClass1.Speichern_(path1, this);
                Contrrol.DoMittlere(this);
                ZubauZelleClass1.FileRead(path1, this, 2);
                if (auto_Start)
                {
                    autoStart = true;
                    Start_Automatic();
                }
            }
            else { Contrrol.DoMittlere(this); }
        }

        private void Full_Screen_Click(object sender, RoutedEventArgs e)
        {
            bool auto_Start = false;
            string path1 = @"Temp1.txt";
            if (zellElement)
            {
                if (autoStart)
                {
                    auto_Start = true;
                    autoStart = false;
                }
                ZubauZelleClass1.Speichern_(path1, this);
                Contrrol.DoFullScreen(this);
                ZubauZelleClass1.FileRead(path1, this, 2);
                if (auto_Start)
                { 
                    autoStart = true;
                    Start_Automatic();
                }
            }
            else { Contrrol.DoFullScreen(this); }

        }
    }
}
