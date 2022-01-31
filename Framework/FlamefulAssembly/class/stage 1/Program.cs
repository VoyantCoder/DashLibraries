using FlamefulAssembly.Erroring;
using FlamefulAssembly.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FlamefulAssembly
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                DashWindow Window = new DashWindow();

                Window.Integrate(DashWindowPosition.Center, new Size(675, 400), Color.White, Color.FromArgb(8, 34, 46), false, 0, Color.FromArgb(8, 34, 46), Color.White, resources.Resources.LOGO, $"Dash Framework");

                MainGUI MainGUI = new MainGUI();
                MainGUI.Initiator(Window);

                Application.Run(Window.Instance);
            }

            catch (Exception E)
            {
                new HandleError().Handle(E);
            }
        }
    }
}
