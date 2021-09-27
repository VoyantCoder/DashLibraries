
// Author: Dashie


using System.Drawing;
using System.Windows.Forms;


namespace DashFramework
{
    namespace Forms
    {
	public partial class MenuBar
	{
	    public bool HasMenubarBeenAdded()
	    {
		return Panel1.Parent != null;
	    }

	    public void SetMenubarSize(Size NewSize)
	    {
		try
		{
		    if (Panel1.Parent != null)
		    {
			if (!NewSize.Equals(Panel1.Size))
			{
			    Transform.Resize(Panel1, NewSize);
			}
		    }
		}

		catch
		{
		    throw;
		}
	    }

	    public Size GetMenubarSize()
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

	    public Point GetMenubarLocation()
	    {
		try
		{
		    if (Panel1.Location != null)
		    {
			return Panel1.Location;
		    }

		    return Point.Empty;
		}

		catch
		{
		    throw;
		}
	    }

	    public void SetMenubarDraggability()
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

	    public void Integrate(Control Parent, Size BarSize, Point BarLoca, Color BarBColor)
	    {
		try
		{
		    BarLoca.Y = (BarLoca.Y == -1 ? (Parent.Height - BarSize.Height) / 2 : BarLoca.Y);
		    BarLoca.X = (BarLoca.X == -1 ? (Parent.Width - BarSize.Width) / 2 : BarLoca.X);

		    Integrator.Panel(Parent, Panel1, BarSize, BarLoca, BarBColor);
		}

		catch
		{
		    throw;
		}
	    }
	}
    }
}