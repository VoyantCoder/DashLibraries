// Sector Name:
// Author: Dashie


#pragma warning disable IDE1006


using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using DashFramework.DashControls.Customs;
using DashFramework.DashControls;
using DashFramework.ControlTools;
using DashFramework.Erroring;
using DashFramework.Sorters;
using DashFramework.Data;

using DashFramework.resources;


namespace DashFramework
{
    namespace Forms
    {
	public enum TitleLocation
	{
	    Top, Bottom, Right, Left,
	    TopMiddle, BottomMiddle, Center
	}

	public enum IconLocation
	{
	    Top, Bottom, Right, Left,
	    TopMiddle, BottomMiddle, Center
	}

	public enum ButtonSet
	{
	    Close, CloseMinimize, Custom
	}


	public class MenuBar
	{
	    readonly ControlIntegrator Integrator = new ControlIntegrator();
	    readonly DashPanel Panel1 = new DashPanel();
	    
	    public void Integrate(Control Parent, Size BarSize, Point BarLoca, Color BarBColor)
	    {
		try
		{
		    Integrator.Panel(Parent, Panel1, BarSize, BarLoca, BarBColor);
		}

		catch
		{
		    throw;
		}
	    }


	    // Title Integration:
	    readonly Label Label1 = new Label();

	    public int FontPoints = 10;
	    public int FontTypeId = 1;

	    public void Integrate(Control Parent, Size BarSize, Point BarLoca, Color BarBColor, string TitleText, Color TitleFColor, TitleLocation TitleLoca)
	    {
		try
		{
		    Integrate(Parent, BarSize, BarLoca, BarBColor);

		    // Integrate title etc.
		}

		catch
		{
		    throw;
		}
	    }


	    // Icon Integration:
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

			Icon2.BringToFront();
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


	    // Button Integration:
	    readonly List<Button> CustomButtons = new List<Button>();

	    public void AddCustomButtons(bool Cleanup = false, params Button[] Buttons)
	    {
		try
		{
		    if (Cleanup)
		    {
			CustomButtons.Clear();
		    }

		    CustomButtons.AddRange(Buttons);
		}

		catch
		{
		    throw;
		}
	    }

	    readonly Button Button1 = new Button();
	    readonly Button Button2 = new Button();

	    public void SetButtonLocation(ButtonSet Button, Point[] Loca)
	    {
		try
		{
		    void SetCustomButtonLocation()
		    {
			if (Loca.Length > CustomButtons.Count)
			{
			    return;
			}

			for (int k = 0; k < CustomButtons.Count; k += 1)
			{
			    CustomButtons[k].Location = Loca[k];
			}
		    }

		    switch (Button)
		    {
			case ButtonSet.Custom: SetCustomButtonLocation(); break;
			case ButtonSet.Close: Button1.Location = Loca[0]; break;

			case ButtonSet.CloseMinimize:
			{
			    Button1.Location = Loca[0];
			    Button2.Location = Loca[1];
			    break;
			}
		    }
		}

		catch
		{
		    throw;
		}
	    }

	    public void SetButtonLocation(ButtonSet Button, Point Loca)
	    {
		try
		{
		    SetButtonLocation(Button, new Point[] { Loca });
		}

		catch
		{
		    throw;
		}
	    }

	    public void ResetExistingButtons()
	    {
		try
		{
		    if (Button1 == null || Button1.Parent == null)
		    {
			return;
		    }

		    for (int k = Button1.Parent.Controls.Count; k > 0; k -= 1)
		    {
			if (Button1.Parent.Controls[k] is Button)
			{
			    Button1.Parent.Controls.RemoveAt(k);
			}
		    }
		}

		catch
		{
		    throw;
		}
	    }

	    readonly PlainSorters Sorters = new PlainSorters();

	    public void Integrate(Control Parent, Size BarSize, Point BarLoca, Color BarBColor, string TitleText, Color TitleFColor, TitleLocation TitleLoca, Icon Icon, IconLocation IconLoca, ButtonSet Buttons)
	    {
		try
		{
		    Integrate(Parent, BarSize, BarLoca, BarBColor, TitleText, TitleFColor, TitleLoca, Icon, IconLoca);

		    void Hook1()
		    {
			try
			{
			    Sorters.SortCode(("Close Button"), () =>
			    {
				ResetExistingButtons();

				Size ButtonSize = new Size(100, Panel1.Height);
				Point ButtonLoca = new Point(Panel1.Width - 100, 0);

				Integrator.Button(Panel1, Button1, ButtonSize, ButtonLoca, 
				    BarBColor, TitleFColor, FontTypeId, FontPoints, "X");
			    });
			}

			catch
			{
			    throw;
			}
		    }
		    
		    void Hook2()
		    {
			try
			{
			    Sorters.SortCode(("Close & Minimize Buttons"), () =>
			    {
				Size ButtonSize = new Size(100, Panel1.Height);
				Point ButtonLoca = new Point(Panel1.Width - 200, 0);

				Integrator.Button(Panel1, Button2, ButtonSize, ButtonLoca, 
				    BarBColor, TitleFColor, FontTypeId, FontPoints, "-");

				Hook1();
			    });
			}

			catch
			{
			    throw;
			}
		    }

		    void Hook3()
		    {
			try
			{
			    Sorters.SortCode(("Custom Button(s)"), () =>
			    {
				ResetExistingButtons();
				
				for (int k = 0; k < CustomButtons.Count; k += 1)
				{
				    Panel1.Controls.Add(CustomButtons[k]);
				}
			    });
			}

			catch
			{
			    throw;
			}
		    }

		    switch (Buttons)
		    {
			case ButtonSet.CloseMinimize: Hook2(); break;
			case ButtonSet.Custom: Hook3(); break;
			case ButtonSet.Close: Hook1(); break;
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