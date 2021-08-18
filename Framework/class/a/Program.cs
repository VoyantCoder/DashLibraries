using System;
using System.Drawing;
using System.Windows.Forms;

using DashFramework.DialogSet.Dialogs;
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

		Color AppMCol = Color.FromArgb(8, 34, 46);
		Color AppBCol = Color.White;
		Size AppSize = new Size(475, 400);
		string AppTitle = ("DashFramework");

		Window.Integrate(DashWindowPosition.Center, AppSize, AppBCol, AppMCol, 
		    false, 0, AppMCol, Color.White, resources.Resources.LOGO, $"{AppTitle}");

		MainGUI = new MainGUI();
		MainGUI.Initiator(Window);

		Application.Run(Window.Instance());
	    }

	    catch (Exception E)
	    {
		ErrorHandler.JustDoIt(E);
	    }
	}
    }
}
