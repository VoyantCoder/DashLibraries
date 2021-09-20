// Sector Name:
// Author: Dashie


#pragma warning disable IDE1006


using System;
using System.Windows.Forms;

using DashFramework.Erroring;


namespace DashFramework
{
    namespace DashControls.Customs
    {
	public class DashPanel : Panel
	{
	    public void AddChild(Control control)
	    {
		try
		{
		    Controls.Add(control);
		}

		catch (Exception E)
		{
		    throw (ErrorHandler.GetException(E));
		}
	    }
	}
    }
}