
// Author: Dashie


using System;
using System.Drawing;
using System.Windows.Forms;


namespace DashFramework
{
    namespace DashControls.Controls
    {
	public partial class CBDropMenu
	{
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

	    void AddChild(string Name, Action OnClick, Color ForeColor, Color BackColor1, Color BackColor2, Color BackColor3)
	    {
		try
		{
		    Point EntryLocation = GetNextItemLocation();
		    int EntryHeight() => 30;

		    Sort.Sort("License Plate", () =>
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

		    Sort.Sort("Check Box", () =>
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