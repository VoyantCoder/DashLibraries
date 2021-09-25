
// Author: Dashie


using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;


namespace DashFramework
{
    namespace Forms
    {
	public partial class Toolbar
	{
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