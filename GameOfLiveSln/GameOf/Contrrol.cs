using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace GameOf
{
    static class Contrrol
    {
        static bool kleineGroesse = false, mittlereGroesse = false, fullScreen = false;
        static double defuleLocTop = 0, defuleLocLeft = 0, defuleSizeWidth = 0, defuleSizeHeight = 0;

        public static void DoFullScreen(Window win)
        {
            if (fullScreen == false)
            {
                if (defuleLocTop == 0)
                {
                    defuleLocTop = win.Top;
                }
                if (defuleLocLeft == 0)
                {
                    defuleLocLeft = win.Left;
                }
                if (defuleSizeWidth == 0)
                {
                    defuleSizeWidth = win.Width;
                }
                if (defuleSizeHeight == 0)
                {
                    defuleSizeHeight = win.Height;
                }
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
                if (defuleLocTop == 0)
                {
                    defuleLocTop = win.Top;
                }
                if (defuleLocLeft == 0)
                {
                    defuleLocLeft = win.Left;
                }
                if (defuleSizeWidth == 0)
                {
                    defuleSizeWidth = win.Width;
                }
                if (defuleSizeHeight == 0)
                {
                    defuleSizeHeight = win.Height;
                }
                win.Top = defuleLocTop;
                win.Left = defuleLocLeft;
                win.Width = defuleSizeWidth;
                win.Height = defuleSizeHeight;
                mittlereGroesse = false;
                fullScreen = false;
                kleineGroesse = true;
            }
        }
        public static void DoMittlere(Window win)
        {
            if (mittlereGroesse == false)
            {
                if (defuleLocTop == 0)
                {
                    defuleLocTop = win.Top;
                }
                if (defuleLocLeft == 0)
                {
                    defuleLocLeft = win.Left;
                }
                if (defuleSizeWidth == 0)
                {
                    defuleSizeWidth = win.Width;
                }
                if (defuleSizeHeight == 0)
                {
                    defuleSizeHeight = win.Height;
                }
                MittlereSize(win);
                mittlereGroesse = false;
                kleineGroesse = false;
                mittlereGroesse = true;
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

    }
}
