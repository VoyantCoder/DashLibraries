using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using DashFramework.Erroring;
using DashFramework.Forms;

namespace DashFramework
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                DashWindow Window = new DashWindow();

                HelperGUI gui = new HelperGUI();
                gui.Show(true);

                //Window.Integrate(DashWindowPosition.Center, new Size(675, 400), Color.White, Color.FromArgb(8, 34, 46), false, 0, Color.FromArgb(8, 34, 46), Color.White, resources.Resources.LOGO, $"Dash Framework");
           
                //MainGUI MainGUI = new MainGUI();
                //MainGUI.Initiator(Window);

                //Application.Run(Window.Instance);
            }

            catch (Exception E)
            {
                HandleError handle = new HandleError();
                handle.Handle(E);
            }
        }
    }
}
