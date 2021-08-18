// Sector Name:
// Author: Dashie


#pragma warning disable IDE1006


using System;
using System.Drawing;
using System.Windows.Forms;

using DashFramework.DashControls.Customs;
using DashFramework.DashResources;
using DashFramework.DashControls;
using DashFramework.ControlTools;
using DashFramework.Erroring;
using DashFramework.Sorters;
using DashFramework.Forms;
using DashFramework.Data;


namespace DashFramework
{
    namespace DialogSet
    {
	namespace Dialogs
	{
	    public class QuickyDialog
	    {
		// rewrite this
	    }
	}


	public class Shortcuts
	{
	    public void MsgBox(string msg, string title = "Dash Notification", MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Information)
	    {
		try
		{
		    MessageBox.Show(msg, title, buttons, icon);
		}

		catch (Exception E)
		{
		    ErrorHandler.GetException(E);
		}
	    }
	}


	public class DashLink// Forms
	{
	    public void CenterDialog(Control Dialog, Control Parent)
	    {
		try
		{
		    Point ParentLoca = Parent.PointToScreen(Point.Empty);

		    int Y = ParentLoca.Y + ((Parent.Height - Dialog.Height) / 2);
		    int X = ParentLoca.X + ((Parent.Width - Dialog.Width) / 2);

		    Dialog.Location = new Point(X, Y);
		}

		catch (Exception E)
		{
		    ErrorHandler.JustDoIt(E);
		}
	    }

	    // Auto Update Ideology: (Future Feature)
	    // - When parent GUI moves update added dialog
	    // - Old Dialog Location on Screen
	    // - Update it by changed value of Parent
	    // - If changed value is higher than old +
	    // - If changed value is lower than old -
	}
    }
}