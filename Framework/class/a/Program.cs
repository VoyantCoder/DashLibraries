using System;
using System.Drawing;
using System.Windows.Forms;

using DashFramework.Erroring;
using DashFramework.Forms;

namespace DashFramework
{
    static class Program
    {
	static DashWindow Window;
	static MainGUI MainGUI;

	[STAThread]
	static void Main()
	{
	    Application.EnableVisualStyles();
	    Application.SetCompatibleTextRenderingDefault(false);

	    try
	    {
		Window = new DashWindow();

		Size AppSize = new Size(475, 400);

		string AppTitle = ("DashFramework");

		Color AppMCol = Color.FromArgb(8, 34, 46);
		Color AppBCol = Color.White;

		Window.InitializeWindow(AppSize, AppTitle, AppBCol, AppMCol, barClose: false);
		Window.values.ResizeTitle(9);

		Window.values.onControlClick(1, () => Environment.Exit(-1));
		Window.FormClosing += (s, e) => Environment.Exit(-1);

		MainGUI = new MainGUI();
		MainGUI.Initiator(Window);

		Application.Run(Window);
	    }

	    catch (Exception E)
	    {
		ErrorHandler.JustDoIt(E);
	    }
	}
    }
}
