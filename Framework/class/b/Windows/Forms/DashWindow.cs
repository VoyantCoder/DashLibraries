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
    namespace Forms
    {
	public enum DashWindowPosition
	{
	    Left, Right, Top, Bottom, Center, None
	}

	public enum DashWindowRoundRadius
	{
	    Slightly, MoreSo, Extreme
	}
	

	public class DashWindow
	{
	    readonly Form WindowInstance = new Form();

	    public Form Instance()
	    {
		try
		{
		    return WindowInstance;
		}

		catch
		{
		    return null;
		}
	    }

	    public bool Initialized = false;

	    public bool Registered()
	    {
		try
		{
		    return Initialized;
		}

		catch
		{
		    throw;
		}
	    }

	    public void SetWindowBorderStyle(FormBorderStyle BorderStyle)
	    {
		try
		{
		    WindowInstance.FormBorderStyle = BorderStyle;
		    WindowInstance.Update();
		}

		catch
		{
		    throw;
		}
	    }

	    readonly PlainSorters Sorters = new PlainSorters();

	    public Point GetWindowLocation(DashWindowPosition Position, Size Size = default(Size))
	    {
		try
		{
		    Point WindowLocation = Point.Empty;

		    void SetLocation(int x = -20, int y = -20)
		    {
			try
			{
			    if (x == -20)
			    {
				x = 0;
			    }

			    if (y == -20)
			    {
				y = 0;
			    }

			    WindowLocation = new Point(x, y);
			}

			catch
			{
			    throw;
			}
		    }

		    int MonitorHeight = SystemInformation.PrimaryMonitorSize.Height;
		    int MonitorWidth = SystemInformation.PrimaryMonitorSize.Width;

		    if (Size == default(Size))
		    {
			Size = WindowInstance.Size;
		    }

		    void Hook1()
		    {
			try
			{
			    Sorters.SortCode(("Bottom"), () =>
			    {
				int y = MonitorHeight - Size.Height - 30;
				int x = (MonitorWidth - Size.Width) / 2;

				if (x >= 0 && y >= 0)
				{
				    SetLocation(x, y);
				}
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
			    Sorters.SortCode(("Center"), () =>
			    {
				int y = (MonitorHeight - Size.Height) / 2;
				int x = (MonitorWidth - Size.Width) / 2;

				if (x >= 0 && y >= 0)
				{
				    SetLocation(x, y);
				}
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
			    Sorters.SortCode(("Right"), () =>
			    {
				int y = (MonitorHeight - Size.Height) / 2;
				int x = MonitorWidth - Size.Width - 30;

				if (x >= 0)
				{
				    SetLocation(x);
				}
			    });
			}

			catch
			{
			    throw;
			}
		    }

		    void Hook4()
		    {
			try
			{
			    Sorters.SortCode(("Left"), () =>
			    {
				int y = (MonitorWidth - Size.Width) / 2;

				if (y >= 0)
				{
				    SetLocation(y: y);
				}
			    });
			}

			catch
			{
			    throw;
			}
		    }

		    void Hook5()
		    {
			try
			{
			    Sorters.SortCode(("Top"), () =>
			    {
				int x = (MonitorWidth - Size.Width) / 2;
				SetLocation(x + 30);
			    });
			}

			catch
			{
			    throw;
			}
		    }

		    switch (Position)
		    {
			case DashWindowPosition.Bottom: Hook1(); break;
			case DashWindowPosition.Center: Hook2(); break;
			case DashWindowPosition.Right: Hook3(); break;
			case DashWindowPosition.Left: Hook4(); break;
			case DashWindowPosition.Top: Hook5(); break;
		    }

		    return WindowLocation;
		}

		catch
		{
		    return Point.Empty;
		}
	    }

	    readonly Transformer Transform = new Transformer();

	    public void Integrate(DashWindowPosition Position, Size Size, Color BackColor, bool DisableWindowsBorder = true)
	    {
		try
		{
		    Point WindowLocation = GetWindowLocation(Position, Size);

		    if (!WindowLocation.Equals(Point.Empty))
		    {
			WindowInstance.Location = WindowLocation;
		    }

		    WindowInstance.StartPosition = FormStartPosition.Manual;
		    WindowInstance.BackColor = BackColor;
		    WindowInstance.Icon = resources.Resources.ICON;

		    if (DisableWindowsBorder)
		    {
			SetWindowBorderStyle(FormBorderStyle.None);
		    }

		    Transform.Resize(WindowInstance, Size);

		    if (!Initialized)
		    {
			Initialized = true;
		    }
		}

		catch
		{
		    throw;
		}
	    }


	    // Bordering Integration:
	    readonly MenuBar MenubarInstance = new MenuBar();

	    public MenuBar Menubar()
	    {
		try
		{
		    if (MenubarInstance.HasMenubarBeenAdded())
		    {
			return MenubarInstance;
		    }

		    return null;
		}

		catch
		{
		    throw;
		}
	    }

	    public void DrawWindowBorder(Color Color, int Thickness)
	    {
		try
		{
		    Size Size = new Size(WindowInstance.Width - (Thickness - 1), WindowInstance.Height - (Thickness - 1));
		    Point Location = new Point(0, 0);

		    if (Menubar() != null)
		    {
			Location.Y = Menubar().GetMenubarSize().Height + Menubar().GetMenubarLocation().Y;
		    }

		    Transform.PaintRectangle(WindowInstance, Thickness, Size, Location, Color);
		}

		catch
		{
		    throw;
		}
	    }

	    public void Integrate(DashWindowPosition Position, Size Size, Color BackColor, Color BorderColor, bool DisableWindowsBorder = true)
	    {
		try
		{
		    Sorters.SortCode(("dependency"), () =>
		    {
			Integrate(Position, Size, BackColor, DisableWindowsBorder);
		    });


		    Sorters.SortCode(("integration extension"), () =>
		    {
			if (BorderColor != null)
			{
			    DrawWindowBorder(BorderColor, 2);
			}
		    });
		}

		catch
		{
		    throw;
		}
	    }

	    
	    // Rounding Integration:
	    public void SetWindowRounding(DashWindowRoundRadius RoundRadius)
	    {
		try
		{
		    int Radius = 4;

		    switch ((int) RoundRadius)
		    {
			case 1: Radius = 6; break;
			case 2: Radius = 8; break;
		    }

		    Transform.Round(WindowInstance, Radius);
		}

		catch
		{
		    throw;
		}
	    }

	    public void Integrate(DashWindowPosition Position, Size Size, Color BackColor, Color BorderColor, bool RoundSides, DashWindowRoundRadius RoundRadius, bool DisableWindowsBorder = true)
	    {
		try
		{
		    Sorters.SortCode(("dependency"), () =>
		    {
			Integrate(Position, Size, BackColor, BorderColor, DisableWindowsBorder);
		    });

		    Sorters.SortCode(("integration extension"), () =>
		    {
			if (RoundSides)
			{
			    SetWindowRounding(RoundRadius);
			}
		    });
		}

		catch
		{
		    throw;
		}
	    }


	    // Menubar Integration:
	    public void Integrate(DashWindowPosition Position, Size Size, Color BackColor, Color BorderColor, bool RoundSides, DashWindowRoundRadius RoundRadius, Color MenuBarBackColor, Color MenuBarForeColor, Image MenuBarIcon, string MenuBarTitle, bool DisableWindowsBorder = true)
	    {
		try
		{
		    Sorters.SortCode(("dependency"), () =>
		    {
			Integrate(Position, Size, BackColor, BorderColor, RoundSides, RoundRadius, DisableWindowsBorder);
		    });

		    Sorters.SortCode(("integration extension"), () =>
		    {
			Size MenubarSize = new Size(Size.Width, 28);
			Point MenubarLocation = new Point(0, 0);

			MenubarInstance.Integrate(WindowInstance, MenubarSize, MenubarLocation, MenuBarBackColor, MenuBarTitle,
			    MenuBarForeColor, TitlePosition.LeftMiddle, MenuBarIcon, IconPosition.LeftMiddle, ButtonSet.Close);

			Menubar().SetMenubarDraggability();
		    });
		}

		catch
		{
		    throw;
		}
	    }

	    
	    // Visibility Integration:
	    public virtual bool Show()
	    {
		try
		{
		    if (!WindowInstance.Visible)
		    {
			WindowInstance.Show();
		    }

		    return true;
		}

		catch
		{
		    return false;
		}
	    }

	    public virtual bool Hide()
	    {
		try
		{
		    if (WindowInstance.Visible)
		    {
			WindowInstance.Hide();
		    }

		    return true;
		}

		catch
		{
		    return false;
		}
	    }

	    public bool IsVisible()
	    {
		try
		{
		    return WindowInstance.Visible;
		}

		catch
		{
		    return false;
		}
	    }

	    public bool SendToBack()
	    {
		try
		{
		    WindowInstance.SendToBack();
		    return true;
		}

		catch
		{
		    return false;
		}
	    }

	    public bool BringToFront()
	    {
		try
		{
		    WindowInstance.BringToFront();
		    return true;
		}

		catch
		{
		    return false;
		}
	    }


	    // Unnamed Integration:
	    public bool ChangeParent(Control NewParent)
	    {
		try
		{
		    WindowInstance.Parent = NewParent;
		    return (WindowInstance.Parent == NewParent);
		}

		catch
		{
		    return false;
		}
	    }


	    // Control Integration:
	    readonly Dictionary<int, Control> ChildIdentifiers = new Dictionary<int, Control>();

	    public bool RemoveChild(int cid)
	    {
		try
		{
		    if (ChildIdentifiers.ContainsKey(cid))
		    {
			ChildIdentifiers[cid].Parent.Controls.Remove(ChildIdentifiers[cid]);
			ChildIdentifiers[cid].Dispose();
			ChildIdentifiers.Remove(cid);
		    }

		    return ChildIdentifiers.ContainsKey(cid);
		}

		catch
		{
		    return false;
		}
	    }

	    public bool AddChild(Control child, int cid)
	    {
		try
		{
		    if (!ChildIdentifiers.ContainsKey(cid))
		    {
			WindowInstance.Controls.Add(child);

			if (WindowInstance.Controls.Contains(child))
			{
			    ChildIdentifiers.Add(cid, child);
			    return true;
			}
		    }

		    return false;
		}

		catch
		{
		    throw;
		}
	    }

	    public IEnumerable<Control> GetChildren(params int[] cids)
	    {
		foreach (int cid in cids)
		{
		    if (ChildIdentifiers.ContainsKey(cid))
		    {
			yield return ChildIdentifiers[cid];
		    }
		}
	    }

	    public Control GetChild(int cid)
	    {
		try
		{
		    if (ChildIdentifiers.ContainsKey(cid))
		    {
			return ChildIdentifiers[cid];
		    }

		    return null;
		}

		catch
		{
		    throw;
		}
	    }


	    // Resize Integration:
	    public Size GetWindowSize()
	    {
		try
		{
		    return WindowInstance.Size;
		}

		catch
		{
		    return Size.Empty;
		}
	    }

	    
	    // Coloring Integration:
	    public void SetWindowBackColor(Color Color)
	    {
		try
		{
		    Instance().BackColor = Color;
		}

		catch
		{
		    throw;
		}
	    }
	}
    }
}