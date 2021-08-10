
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using DashFramework.DashControls.Customs;
using DashFramework.DashControls;
using DashFramework.ControlTools;
using DashFramework.Sorters;
using DashFramework.Data;

namespace DashFramework
{
    namespace Forms
    {
	public enum ToolbarPosition
	{
	    Top, Bottom, Right, Left, Center
	}

	public class ToolBar
	{
	    readonly ControlIntegrator Integrator = new ControlIntegrator();
	    readonly DashPanel Panel1 = new DashPanel();

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


	    // Position Integration:
	    public void Integrate(Control Parent, Color BackColor, Size Size, ToolbarPosition Position)
	    {
		try
		{
		    Point Location = new Point(-2, -2);

		    switch (Position)
		    {
			case ToolbarPosition.Top:
			{ 
			    Location.Y = 0;
			    break;
			}

			case ToolbarPosition.Bottom:
			{ 
			    Location.Y = Parent.Height - Size.Height;
			    break;
			}

			case ToolbarPosition.Right:
			{
			    Location.X = Parent.Width - Size.Width;
			    break;
			}

			case ToolbarPosition.Left:
			{
			    Location.X = 0;
			    break;
			}
		    }

		    Integrate(Parent, BackColor, Size, Location);
		}

		catch
		{
		    throw;
		}
	    }


	    // Children Integration:
	    public readonly Dictionary<int, Control> ChildCollection = new Dictionary<int, Control>();
	    public delegate void ChildRun();

	    public void SetChildClickEvent(ChildRun OnClick, params int[] ChildIds)
	    {
		try
		{
		    foreach (int ChildId in ChildIds)
		    {
			if (!ChildCollection.ContainsKey(ChildId))
			{
			    continue;
			}

			ChildCollection[ChildId].Click += (s, e) =>
			{
			    try
			    {
				OnClick();
			    }

			    catch
			    {
				throw;
			    }
			};
		    }
		}

		catch
		{
		    throw;
		}
	    }

	    public Control GetChild(int ChildId)
	    {
		try
		{
		    if (ChildCollection.Keys.Contains(ChildId))
		    {
			return ChildCollection[ChildId];
		    }

		    return null;
		}

		catch
		{
		    return null;
		}
	    }

	    public bool RemoveChild(Control Child)
	    {
		try
		{
		    if (ChildCollection.Values.Contains(Child) && Child.Parent != null)
		    {
			ChildCollection.Values.ToList().Remove(Child);

			if (Child.Parent.Controls.Contains(Child))
			{
			    Child.Parent.Controls.Remove(Child);
			    Child.Dispose();
			}

			return true;
		    }

		    return false;
		}

		catch
		{
		    return false;
		}
	    }

	    public bool RemoveChild(int ChildId)
	    {
		try
		{
		    if (ChildCollection.ContainsKey(ChildId))
		    {
			return RemoveChild(ChildCollection[ChildId]);
		    }

		    return false;
		}

		catch
		{
		    return false;
		}
	    }

	    public int GetChildCount()
	    {
		try
		{
		    return ChildCollection.Count;
		}

		catch
		{
		    throw;
		}
	    }

	    public bool AddChild(Control Child)
	    {
		try
		{
		    if (Panel1 != null)
		    {
			if (Child != null && Child.Size != Size.Empty)
			{
			    Panel1.Controls.Add(Child);
			    ChildCollection.Add(GetChildCount(), Child);
			}
		    }

		    return true;
		}

		catch
		{
		    return false;
		}
	    }

	    public bool AddChildren(params Control[] Children)
	    {
		try
		{
		    if (Panel1 != null)
		    {
			foreach (Control Child in Children)
			{
			    if (Child != null && Child.Size != Size.Empty)
			    {
				Panel1.Controls.Add(Child);
				ChildCollection.Add(GetChildCount(), Child);
			    }
			}
		    }

		    return true;
		}

		catch
		{
		    return false;
		}
	    }

	    public void Integrate(Control Parent, Color BackColor, Size Size, ToolbarPosition Position, params Control[] Children)
	    {
		try
		{
		    Integrate(Parent, BackColor, Size, Position);
		    
		    if (Children.Length > 0)
		    {
			AddChildren(Children);
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