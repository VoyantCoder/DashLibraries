// Author: Dashie

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
	public enum DashWindowPosition
	{
	    Left, Right, Top, Bottom, Center, None
	}

	public enum DashWindowRoundRadius
	{
	    Slightly, MoreSo, Extreme
	}

	//
	// 1) 
	//
	// 2)
	//
	// 3)
	//
	// 4)
	//

	public class DashWindow : MenuBar
	{
	    readonly ControlIntegrator Integrator = new ControlIntegrator();
	    readonly Transformer Transform = new Transformer();
	    readonly PlainSorters Sorters = new PlainSorters();

	    readonly Form WindowInstance = new Form();

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

		    if (DisableWindowsBorder)
		    {
			SetWindowBorderStyle(FormBorderStyle.None);
		    }

		    Transform.Resize(WindowInstance, Size);
		}

		catch
		{
		    throw;
		}
	    }


	    // Bordering Integration:
	    public void DrawWindowBorder(Color Color, int Thickness)
	    {
		try
		{
		    Size Size = new Size(WindowInstance.Width - 2, WindowInstance.Height - 2);
		    Point Location = new Point(0, 0);

		    if (HasMenubarBeenAdded())
		    {
			Location.Y = GetMenubarSize().Height + GetMenubarLocation().Y;
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
		    Integrate(Position, Size, BackColor, DisableWindowsBorder);

		    if (BorderColor != null)
		    {
			DrawWindowBorder(BorderColor, 2);
		    }
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
		    if (RoundSides)
		    {
			SetWindowRounding(RoundRadius);
		    }
		}

		catch
		{
		    throw;
		}
	    }


	    // Menubar Integration:
	    public MenuBar Integrate(DashWindowPosition Position, Size Size, Color BackColor, Color BorderColor, bool RoundSides, Color MenuBarBackColor, Color MenuBarForeColor, Icon MenuBarIcon, string MenuBarTitle, bool DisableWindowsBorder = true)
	    {
		try
		{
		    // Add Menubar etc
		    return new MenuBar();
		}

		catch
		{
		    return null;
		}
	    }

	    
	    // Other Integration:
	    public virtual void Show()
	    {
		try
		{
		    if (!WindowInstance.Visible)
		    {
			WindowInstance.Show();
		    }
		}

		catch
		{
		    throw;
		}
	    }

	    public virtual void Hide()
	    {
		try
		{
		    if (WindowInstance.Visible)
		    {
			WindowInstance.Hide();
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