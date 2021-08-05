// Sector Name:
// Author: Dashie


#pragma warning disable IDE1006


using System;
using System.Drawing;

using DashFramework.Dialogs.Dialog;


namespace DashFramework
{
    namespace Erroring
    {
	public class ErrorHandler
	{
	    public static void JustDoIt(Exception E, string title = ("Error Handler")) => Utilize(GetRawFormat(E), title);
	    public static Exception GetException(Exception E) => new Exception(GetRawFormat(E));


	    public static string ErrorFormat = string.Format
	    (
		"----------------------\r\n" +
		"[A]\r\n" +
		"----------------------\r\n" +
		"[B]\r\n" +
		"----------------------\r\n" +
		"[C]\r\n"
	    );

	    public static string GetRawFormat(Exception E)
	    {
		return ErrorFormat.Replace("[A]", $"{E.StackTrace}")
		    .Replace("[B]", $"{E.Message}")
		    .Replace("[C]", $"{E.Source}");
	    }


	    public static void Utilize(string description, string title)
	    {
		DashDialog ErrorDialog = new DashDialog();

		Color ContainerBCol = Color.FromArgb(9, 39, 66);
		Color MenuBarBCol = Color.FromArgb(19, 36, 64);
		Color AppBCol = Color.FromArgb(6, 17, 33);

		ErrorDialog.Show(AppBCol, Color.White, Size.Empty, description, title, DashDialog.Buttons.OK);

		Environment.Exit(-1);
	    }
	}
    }
}