// Sector Name:
// Author: Dashie


#pragma warning disable IDE1006


using System;
using System.Drawing;
using System.Windows.Forms;

using DashFramework.DashControls.Customs;
using DashFramework.DashControls;
using DashFramework.ControlTools;
using DashFramework.Erroring;
using DashFramework.Data;

using DashFramework.resources;


namespace DashFramework
{
    namespace Forms
    {
	public enum TitleLocation { Top, Bottom, Right, Left, TopMiddle, BottomMiddle, Center }
	public enum IconLocation { Top, Bottom, Right, Left, TopMiddle, BottomMiddle, Center }
	public enum ButtonSet { Close, CloseMinimize, Custom }

	public class MenuBar
	{
	    // button controls here, publicly.
	    // add setting for add buttons.
	    // setting method makes use of booleans.

	    readonly DashPanel Panel1 = new DashPanel();
	    readonly DashPanel Panel2 = new DashPanel();

	    public void Integrate(Control Parent, Size BarSize, Point BarLoca, Color BarBColor)
	    {
		try
		{
		    // Bar Container, Bar
		}

		catch
		{
		    throw;
		}
	    }


	    readonly Label Label1 = new Label();

	    public void Integrate(Control Parent, Size BarSize, Point BarLoca, Color BarBColor, string TitleText, Color TitleFColor, TitleLocation TitleLoca)
	    {
		try
		{
		    // Add enum values:  Left, Right, TopMiddle, BottomMiddle, Center same for icon

		    Integrate(Parent, BarSize, BarLoca, BarBColor);

		    // Integrate title etc.
		}

		catch
		{
		    throw;
		}
	    }


	    readonly PictureBox Icon1 = new PictureBox();
	    readonly PictureBox Icon2 = new PictureBox();

	    public void UpdateIconLayers()
	    {
		try
		{
		    if (Icon2.Parent.BackColor.Equals(Icon2.BackColor))
		    {
			if (Icon2.Parent != null)
			{
			    Icon2.BackColor = Icon2.Parent.BackColor;
			}
		    }
		}

		catch
		{
		    throw;
		}
	    }

	    public void Integrate(Control Parent, Size BarSize, Point BarLoca, Color BarBColor, string TitleText, Color TitleFColor, TitleLocation TitleLoca, Icon Icon, IconLocation IconLoca)
	    {
		try
		{
		    Integrate(Parent, BarSize, BarLoca, BarBColor, TitleText, TitleFColor, TitleLoca);

		    // Integrate Icon etc.
		}

		catch
		{
		    throw;
		}
	    }



	    public void Integrate(Control Parent, Size BarSize, Point BarLoca, Color BarBColor, string TitleText, Color TitleFColor, TitleLocation TitleLoca, Icon Icon, IconLocation IconLoca, ButtonSet Buttons)
	    {
		try
		{

		    // Integrate Buttons
		}

		catch
		{
		    throw;
		}
	    }
	}
    }
}