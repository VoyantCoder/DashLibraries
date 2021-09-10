// Author: Dashie


using System;
using System.Windows.Forms;
using System.Collections.Generic;


namespace DashFramework
{
    namespace DashControls.Customs
    {
	public partial class CBDropMenu
	{
	    public void SetVisibilityTrigger(bool Show, params Control[] Controls)
	    {
		try
		{
		    void EventHandler(Control Control)
		    {
			try
			{
			    Control.MouseEnter += (s, e) =>
			    {
				try
				{
				    if (Show)
				    {
					this.Show();
				    }

				    else
				    {
					this.Hide();
				    }
				}

				catch
				{
				    throw;
				}
			    };
			}

			catch
			{
			    throw;
			}
		    }

		    foreach (Control Control in Controls)
		    {
			EventHandler(Control);
		    }
		}

		catch
		{
		    throw;
		}
	    }
	}
    }
}