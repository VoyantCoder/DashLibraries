 
// Author: Dashie


using System.Drawing;
using System.Windows.Forms;


namespace DashFramework
{
    namespace Forms
    {
	public partial class Toolbar
	{
	    public void SetSize(Size Size)
	    {
		try
		{
		    if (Panel1.Parent != null)
		    {
			if (!Panel1.Size.Equals(Size))
			{
			    Transform.Resize(Panel1, Size);
			}
		    }
		}

		catch
		{
		    throw;
		}
	    }

	    public Size GetTotalSize()
	    {
		try
		{
		    if (Panel1.Size != null)
		    {
			return Panel1.Size;
		    }

		    return Size.Empty;
		}

		catch
		{
		    throw;
		}
	    }

	    public int GetHeight()
	    {
		try
		{
		    if (Panel1.Size != null)
		    {
			return Panel1.Height;
		    }

		    return 0;
		}

		catch
		{
		    throw;
		}
	    }

	    public int GetWidth()
	    {
		try
		{
		    if (Panel1.Size != null)
		    {
			return Panel1.Width;
		    }

		    return 0;
		}

		catch
		{
		    throw;
		}
	    }

	    public void SetBackColor(Color Color)
	    {
		try
		{
		    Panel1.BackColor = Color;
		}

		catch
		{
		    throw;
		}
	    }

	    public bool ApplyRounding(int Radius)
	    {
		try
		{
		    if (Panel1.Parent != null)
		    {
			Transform.Round(Panel1, Radius);
		    }

		    return true;
		}

		catch
		{
		    return false;
		}
	    }

	    public bool DrawBorder(Color Color, int Thickness)
	    {
		try
		{
		    if (Thickness > 0)
		    {
			Transform.AddBorderTo(Panel1, Thickness, Color);
		    }

		    return true;
		}

		catch
		{
		    return false;
		}
	    }

	    public void SetDraggability()
	    {
		try
		{
		    if (Panel1.Parent != null)
		    {
			void Apply(Control ToMe)
			{
			    Appliance.ApplyDraggability(ToMe, Panel1.Parent);
			}

			foreach (Control A in Panel1.Controls)
			{
			    foreach (Control B in A.Controls)
			    {
				Apply(B);
			    }

			    Apply(A);
			}

			Apply(Panel1);
		    }
		}

		catch
		{
		    throw;
		}
	    }

	    public void Integrate(Control Parent, Color BackColor, Size Size, Point Location)
	    {
		try
		{
		    Integrator.Panel(Parent, Panel1, Size, Location, BackColor);
		}

		catch
		{
		    throw;
		}
	    }
	}
    }
}