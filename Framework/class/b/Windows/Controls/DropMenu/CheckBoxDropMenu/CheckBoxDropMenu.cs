
// Author: Dashie
// Version: 1.0


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
    namespace DashControls.Customs
    {
	public partial class CBDropMenu
	{
	    public struct ExcessInfo
	    {
		public bool Added;

		public void Toggle()
		{
		    Added = (Added == 
			true ? false : true);
		}
	    } ExcessInfo ExInfo;

	    // Integrator 1:
	    public bool Integrator(Control Parent, Point Location, Color BackColor, int MenuWidth = 110)
	    {
		try
		{
		    if (ExInfo.Added)
		    {
			return false;
		    }

		    Sorters.SortCode(("Base"), () =>
		    {
			Size Size = new Size(MenuWidth, 40);
			Integrate.Panel(Parent, Layer1, Size, Location, Color.Transparent);
			Integrate.Panel(Layer1, Layer2, Size, new Point(0, 0), BackColor);
		    });

		    Sorters.SortCode(("Layer3"), () =>
		    {
			Size Size = new Size(MenuWidth - 30 - 6, Layer1.Height - 4);
			Point _Location = new Point(MenuWidth - Size.Width - 2, 2);
			Integrate.Panel(Layer2, Layer3, Size, _Location, BackColor);
		    });

		    Sorters.SortCode(("Layer4"), () =>
		    {
			Size Size = new Size(30, Layer1.Height - 4);
			Point _Location = new Point(2, 2);
			Integrate.Panel(Layer2, Layer4, Size, _Location, BackColor);
		    });

		    ExInfo.Toggle();
		    Hide(true);
		}

		catch
		{
		    return false;
		}

		return true;
	    }


	    // Integrator 2:
	    Point GetNextItemLocation()
	    {
		try
		{
		    Point Location = new Point(0, 0);

		    if (DropMenuEntries.Count > 0)
		    {
			Entry Entry = DropMenuEntries[DropMenuEntries.Count - 1];
			Location.Y = (Entry.LicensePlate.Top + Entry.LicensePlate.Height);
		    }

		    return Location;
		}

		catch
		{
		    return Point.Empty;
		}
	    }

	    readonly Transformer Transform = new Transformer();

	    void UpdateContainerSizes(bool SubMenu = false)//For future.
	    {
		try
		{
		    int Layer12Height = GetNextItemLocation().Y + 4;
		    int Layer34Height = Layer12Height - 2;
		    int Layer12Width = Layer2.Width;

		    Size Layer12Size = new Size(Layer12Width, Layer12Height);
		    Size Layer3Size = new Size(Layer3.Width, Layer34Height);
		    Size Layer4Size = new Size(Layer4.Width, Layer34Height);

		    Transform.Resize(Layer1, Layer12Size);
		    Transform.Resize(Layer2, Layer12Size);
		    Transform.Resize(Layer3, Layer3Size);
		    Transform.Resize(Layer4, Layer4Size);
		}

		catch
		{
		    throw;
		}
	    }

	    public void RegisterCheckBoxClickEvent(CheckBox CheckBox, Action OnClick)
	    {
		try
		{
		    void Register(Control Control)
		    {
			try
			{
			    Control.Click += (s, e) =>
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

			catch
			{
			    throw;
			}
		    }

		    Register(CheckBox.OutterHeadlight);
		    Register(CheckBox.BasisHeadlight);
		    Register(CheckBox.InnerHeadlight);
		}

		catch
		{
		    throw;
		}
	    }

	    readonly DataTools DataTool = new DataTools();

	    void AddChild(string Name, Action OnClick, Color ForeColor, Color BackColor1, Color BackColor2, Color BackColor3)
	    {
		try
		{
		    Point EntryLocation = GetNextItemLocation();
		    int EntryHeight() => 30;

		    Sorters.SortCode("License Plate", () =>
		    {
			Size Size = new Size(Layer3.Width, EntryHeight());

			Point Location2 = new Point(0, 0);
			Point Location1 = EntryLocation;

			int FontTypeId = 1;
			int FontSize = 10;

			Entry Entry = new Entry();

			Integrate.Label(Entry.LicensePlate, Entry.License, Size, Location2, BackColor1, ForeColor, Name, FontTypeId, FontSize);
			Integrate.Panel(Layer3, Entry.LicensePlate, Size, Location1, BackColor1);

			DropMenuEntries.Add(Entry);
		    });

		    Sorters.SortCode("Check Box", () =>
		    {
			Size GetBaseSize(int Width, int Height)
			{
			    try
			    {
				if (Width < 24 || Height < 24)
				{
				    return Size.Empty;
				}

				return new Size(Width, Height);
			    }

			    catch
			    {
				return Size.Empty;
			    }
			}

			Point Location2 = new Point(-1, -1);
			Point Location3 = new Point(-1, -1);
			Point Location1 = EntryLocation;

			Size Size1 = GetBaseSize(Layer4.Width, EntryHeight());
			Size Size2 = new Size(24, 24);
			Size Size3 = new Size(14, 14);

			if (Size1 == Size.Empty)
			{
			    throw new Exception();
			}

			CheckBox CheckBox = new CheckBox();

			Integrate.Panel(Layer4, CheckBox.BasisHeadlight, Size1, Location1, BackColor1);
			Integrate.Panel(CheckBox.BasisHeadlight, CheckBox.OutterHeadlight, Size2, Location2, BackColor2);
			Integrate.Panel(CheckBox.OutterHeadlight, CheckBox.InnerHeadlight, Size3, Location3, BackColor3);

			RegisterCheckBoxClickEvent(CheckBox, OnClick);
			DropMenuBoxes.Add(CheckBox);
			UpdateContainerSizes();
		    });
		}

		catch
		{
		    throw;
		}
	    }

	    public bool Integrator(Control Parent, Point Location, Color BackColor1, Color BackColor2, Color BackColor3, Color ForeColor, int MenuWidth, params (string, Action)[] Children)
	    {
		try
		{
		    if (Integrator(Parent, Location, BackColor1, MenuWidth))
		    {
			foreach ((string, Action) Child in Children)
			{
			    AddChild(Child.Item1, Child.Item2, ForeColor, BackColor1, BackColor2, BackColor3);
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
	}
    }
}
