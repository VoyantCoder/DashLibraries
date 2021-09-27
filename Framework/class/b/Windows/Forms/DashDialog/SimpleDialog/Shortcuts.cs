
// Author: Dashie


using System;
using System.Windows.Forms;

using DashFramework.Erroring;


namespace DashFramework
{
    namespace DashDialogs
    {
	public partial class SimpleDialog
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
    }
}