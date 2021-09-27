 
// Author: Dashie


using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using DashFramework.ControlTools;
using DashFramework.Sorters;


namespace DashFramework
{
    namespace DashControls.Controls
    {
	public partial class RegularDropMenu
	{
	    public virtual void Hide()
	    {
		try
		{
		    Panel1.Hide();
		}

		catch
		{
		    throw;
		}
	    }

	    public virtual void Show()
	    {
		try
		{
		    Panel1.BringToFront();
		    Panel1.Show();
		}

		catch
		{
		    throw;
		}
	    }

	    public bool Integrator(Control Parent, Point Location, Color BackColor = default(Color), Color ForeColor = default(Color), int ItemWidth = 100)
	    {
		try
		{
		    if (Settings.GetStatus(0))
		    {
			return false;
		    }

		    Color def = default(Color);

		    if (BackColor.Equals(def))
		    {
			BackColor = Color.FromArgb(8, 8, 8);
		    }

		    if (ForeColor.Equals(def))
		    {
			ForeColor = Color.White;
		    }
		    
		    Integrate.Panel(Parent, Panel1, new Size
			(ItemWidth + 4, 10), Location, BackColor);

		    Settings.ForeColor = ForeColor;
		    Settings.BackColor = BackColor;
		    Settings.ItemWidth = ItemWidth;
		    Settings.ToggleInit(1);

		    Hide();
		}

		catch
		{
		    return false;
		}

		return true;
	    }
	}
    }
}