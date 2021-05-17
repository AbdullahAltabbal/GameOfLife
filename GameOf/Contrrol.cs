using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace GameOf
{
    static class Contrrol
    {
        static bool kleineGroesse = true, mittlereGroesse = false, fullScreen = false ;
        public static void DoFullScreen(Window win)
        {
            if (fullScreen == false)
            {
                FullScreen(win);
                mittlereGroesse = false;
                kleineGroesse = false;
                fullScreen = true;
            }
        }
        public static void DoKlein(Window win)
        {
            if (kleineGroesse == false)
            {
                KleineSize(win);
                mittlereGroesse = false;
                fullScreen = false;
                kleineGroesse = true;
            }
        }
        public static void DoMittlere(Window win)
        {
            if (mittlereGroesse == false)
            {

                MittlereSize(win);
                mittlereGroesse = true;
                fullScreen = false;
                kleineGroesse = false;
            }
        }
        static void FullScreen (Window win)
        {
            if (win.WindowState == WindowState.Normal)
            {
                win.WindowState = WindowState.Maximized;
            }
        }
        static void MittlereSize(Window win)
        {
            win.WindowState = WindowState.Normal;
            win.Width = 1000;
            win.Height = 800;
        }
        static void KleineSize(Window win)
        {
            win.WindowState = WindowState.Normal;
            win.Width = 450;
            win.Height = 600;
        }

    }
}
