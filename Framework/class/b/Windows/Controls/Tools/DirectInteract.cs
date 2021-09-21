
// Author: Dashie


using System;
using System.Drawing;
using System.Windows.Forms;

using DashFramework.DashResources;
using DashFramework.Erroring;


namespace DashFramework
{
    namespace ControlTools
    {
	public class DirectInteract
	{
	    readonly Externalities Extern = new Externalities();

	    public void SetUrl(Control Object, string Destination)
	    {
		try
		{
		    Object.Click += (s, e) =>
		    {
			try
			{
			    Extern.OpenUrl(Destination);
			}

			catch (Exception E)
			{
			    throw (ErrorHandler.GetException(E));
			}
		    };
		}

		catch (Exception E)
		{
		    throw (ErrorHandler.GetException(E));
		}
	    }


	    public delegate void Holder();

	    public void RegisterClickEvent(Control For, Holder This)
	    {
		try
		{
		    For.Click += (s, e) =>
		    {
			try
			{
			    This();
			}

			catch (Exception E)
			{
			    throw (ErrorHandler.GetException(E));
			}
		    };
		}

		catch (Exception E)
		{
		    throw (ErrorHandler.GetException(E));
		}
	    }


	    public void SetButtonColors(Button Bttn, Color OnHover, Color OnDown, Color OnLeave, Color RightNow)
	    {
		try
		{
		    void SetButtonColor(Color Color)
		    {
			Bttn.BackColor = Color;
		    }

		    Bttn.MouseHover += (s, e) => SetButtonColor(OnHover);
		    Bttn.MouseLeave += (s, e) => SetButtonColor(OnLeave);
		    Bttn.MouseDown += (s, e) => SetButtonColor(OnDown);
		    Bttn.FlatAppearance.MouseDownBackColor = OnDown;

		    SetButtonColor(RightNow);
		}

		catch (Exception E)
		{
		    throw (ErrorHandler.GetException(E));
		}
	    }


	    readonly ResourceTools ResourceTool = new ResourceTools();
	    public void SetTxtBoxContents(TextBox TxtBox, string such, bool isResource = false)
	    {
		try
		{
		    if (isResource)
		    {
			such = ResourceTool.GetStringFrom($"{such}");
		    }

		    TxtBox.Text = ($"{such}");
		}

		catch (Exception E)
		{
		    throw (ErrorHandler.GetException(E));
		}
	    }


	    public void SetDock(Control For, DockStyle DockStyle)
	    {
		try
		{
		    For.Dock = DockStyle;
		}

		catch (Exception E)
		{
		    throw (ErrorHandler.GetException(E));
		}
	    }


	    public void AlignContainerTextBoxes(Control container, HorizontalAlignment alignment)
	    {
		try
		{
		    foreach (Control a1 in container.Controls)
		    {
			foreach (Control a2 in a1.Controls)
			{
			    if (a2 is TextBox)
			    {
				((TextBox)a2).TextAlign = alignment;
			    }
			}
		    }
		}

		catch (Exception E)
		{
		    throw (ErrorHandler.GetException(E));
		}
	    }
	}
    }
}