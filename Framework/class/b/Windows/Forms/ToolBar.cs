
using System;
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

	public class Toolbar
	{
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

	    readonly Transformer Transform = new Transformer();

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

	    readonly Apply Appliance = new Apply();

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

	    readonly ControlIntegrator Integrator = new ControlIntegrator();

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
	    public void SetLocation(Point Location)
	    {
		try
		{
		    Panel1.Location = Location;
		}

		catch
		{
		    throw;
		}
	    }

	    public Point GetPosition(ToolbarPosition Position, Control Parent = default(Control), Size Size = default(Size))
	    {
		try
		{
		    if (Parent == default(Control))
		    {
			if (Panel1.Parent == null)
			{
			    return Point.Empty;
			}

			Parent = Panel1.Parent;
		    }

		    if (Size == default(Size))
		    {
			if (Panel1.Parent == null)
			{
			    return Point.Empty;
			}

			Size = Panel1.Size;
		    }

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

		    return Location;
		}

		catch
		{
		    throw;
		}
	    }

	    public void SetPosition(ToolbarPosition Position)
	    {
		try
		{
		    SetLocation(GetPosition(Position, null, Size.Empty));
		}

		catch
		{
		    throw;
		}
	    }

	    public void Integrate(Control Parent, Color BackColor, Size Size, ToolbarPosition Position)
	    {
		try
		{
		    Integrate(Parent, BackColor, Size, GetPosition(Position, Parent, Size));
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

	    readonly PlainSorters Sorters = new PlainSorters();

	    public void SetChildColors(Color[] OnHover, Color[] OnDown, Color[] OnClick, string info = "[0=default,1=new]", params Type[] Types)
	    {
		try
		{
		    void RegisterColorHook(int id)
		    {
			try
			{
			    void SetColor(Control Cntrl, Color Color)
			    {
				try
				{
				    Cntrl.BackColor = Color;
				}

				catch
				{
				    throw;
				}
			    }

			    void Hook1(Control Cntrl)
			    {
				try
				{
				    Sorters.SortCode(("On Hover"), () => 
				    {
					Cntrl.MouseEnter += (s, e) => SetColor(Cntrl, OnHover[1]);
					Cntrl.MouseLeave += (s, e) => SetColor(Cntrl, OnHover[0]);
				    });
				}

				catch
				{
				    throw;
				}
			    }

			    void Hook2(Control Cntrl)
			    {
				try
				{
				    Sorters.SortCode(("On Down"), () =>
				    {
					Cntrl.MouseDown += (s, e) => SetColor(Cntrl, OnDown[1]);
					Cntrl.MouseUp += (s, e) => SetColor(Cntrl, OnDown[0]);
				    });
				}

				catch
				{
				    throw;
				}
			    }

			    void Hook3(Control Cntrl)
			    {
				try
				{
				    Sorters.SortCode(("On Click"), () =>
				    {
					Cntrl.Click += (s, e) => SetColor(Cntrl, OnDown[1]);
					Cntrl.MouseUp += (s, e) => SetColor(Cntrl, OnDown[0]);
				    });
				}

				catch
				{
				    throw;
				}
			    }

			    void CallHook(Control Cntrl)
			    {
				try
				{
				    switch (id)
				    {
					case 0: Hook1(Cntrl); break;
					case 1: Hook2(Cntrl); break;
					case 2: Hook3(Cntrl); break;
				    }
				}

				catch
				{
				    throw;
				}
			    }

			    var TypeFilter = Types.ToList();

			    foreach (Control A in Panel1.Controls)
			    {
				if (!TypeFilter.Contains(A.GetType()))
				{
				    foreach (Control B in A.Controls)
				    {
					if (TypeFilter.Contains(B.GetType()))
					{
					    CallHook(B);
					}
				    }

				    continue;
				}

				CallHook(A);
			    }
			}

			catch
			{
			    throw;
			}
		    }

		    if (OnHover != null && OnHover.Length >= 2)
			RegisterColorHook(0);

		    if (OnClick != null && OnClick.Length >= 2)
			RegisterColorHook(2);

		    if (OnDown != null && OnDown.Length >= 2)
			RegisterColorHook(1);
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