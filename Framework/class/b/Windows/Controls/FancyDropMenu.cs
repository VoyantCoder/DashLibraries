// Sector Name:
// Author: Dashie


#pragma warning disable IDE1006


using System;
using System.Linq;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using DashFramework.DashResources;
using DashFramework.ControlTools;
using DashFramework.Runnables;
using DashFramework.Erroring;
using DashFramework.Sorters;
using DashFramework.Data;


namespace DashFramework
{
    namespace DashControls.Customs
    {
	public class FancyItem
	{
	    public DashPanel LicensePlate = new DashPanel();
	    public Label License = new Label();
	}

	public struct Settings
	{
	    public static bool HasCheckBoxInit;
	    public static bool HasItemInit;
	    public static bool HasBaseInit;

	    public static void ToggleInit(int id, string info = "1,2,3")
	    {
		try
		{
		    switch (id)
		    {
			case 3:
			{
			    HasCheckBoxInit = true;
			    break;
			}
			case 1:
			{
			    HasBaseInit = true;
			    break;
			}
			case 2:
			{
			    HasItemInit = true;
			    break;
			}
		    }
		}

		catch
		{
		    throw;
		}
	    }

	    public static bool GetStatus(int id)
	    {
		try
		{
		    switch (id)
		    {
			case 3: return HasCheckBoxInit;
			case 1: return HasBaseInit;
			case 2: return HasItemInit;
		    }

		    return false;
		}

		catch
		{
		    throw;
		}
	    }

	    public static Color ForeColor;
	    public static Color BackColor;

	    public static int ItemHeight;
	    public static int ItemWidth;

	    public static int FontSize = 10;
	    public static int FontId = 1;
	}

	public class FancyDropMenu
	{
	    //Integrator Base 1 (Base Functionality):
	    readonly ControlIntegrator Integrate = new ControlIntegrator();
	    readonly PlainSorters Sorters = new PlainSorters();
	    
	    readonly DashPanel Panel1 = new DashPanel();
	    
	    public virtual void Hide()
	    {
		try
		{
		    Panel1.Hide();
		}

		catch
		{
		    throw;
		}
	    }

	    public virtual void Show()
	    {
		try
		{
	    	    Panel1.BringToFront();
	    	    Panel1.Show();
		}

		catch
		{
		    throw;
		}
	    }

	    public bool Integrator(Control Parent, Point Location, Color BackColor = default(Color), Color ForeColor = default(Color), int ItemWidth = 100)
	    {
		try
		{
		    if (Settings.GetStatus(0))
		    {
			return false;
		    }

		    Sorters.SortCode(("Parameters"), () =>
		    {
			if (BackColor.Equals(default(Color)))
			{
			    BackColor = Color.FromArgb(8, 8, 8);
			}

			if (ForeColor.Equals(default(Color)))
			{
			    ForeColor = Color.White;
			}
		    });

		    Sorters.SortCode(("Container"), () =>
		    {
			Size Size = new Size(ItemWidth + 4, 10);
			Integrate.Panel(Parent, Panel1, Size, Location, BackColor);
		    });
		    
		    Settings.ForeColor = ForeColor;
		    Settings.BackColor = BackColor;
		    Settings.ItemWidth = ItemWidth;

		    Settings.ToggleInit(1);

		    //Hide();
		}

		catch
		{
		    return false;
		}

		return true;
	    }


	    //Integrator Base 2 (Add Children):
	    public readonly List<(FancyItem, Action)> AddedItems = new List<(FancyItem, Action)>();

	    public Point NextLicensePlateLocation()
	    {
		try
		{
		    Point Location = new Point(0, 0);

		    if (AddedItems.Count > 0)
		    {
			var LicensePlateId = AddedItems.Count - 1;
			var LicensePlate = AddedItems[LicensePlateId].Item1.LicensePlate;

			Location = new Point(0, LicensePlate.Top + LicensePlate.Height);
		    }

		    return Location;
		}

		catch
		{
		    return Point.Empty;
		}
	    }

	    public Size LicensePlateSize()
	    {
		try
		{
		    return new Size(Settings.ItemWidth,
			Settings.ItemHeight);
		}

		catch
		{
		    return Size.Empty;
		}
	    }

	    readonly DashPanel Panel2 = new DashPanel();

	    public bool RegisterItemContainer()
	    {
		try
		{
		    Size Size = new Size(Settings.ItemWidth, 6);
		    Point Location = new Point(2, 2);
		    Color BackColor = Settings.BackColor;

		    Integrate.Panel(Panel1, Panel2, Size, Location, BackColor);
		}

		catch
		{
		    return false;
		}

		return true;
	    }

	    readonly Transformer Transform = new Transformer();

	    public void UpdateContainerSizes()
	    {
		try
		{
		    int Height = NextLicensePlateLocation().Y;
		    int Width = Settings.ItemWidth;

		    Size Size1 = new Size(Width + 4, Height + 4);
		    Size Size2 = new Size(Width, Height);
		    
		    Transform.Resize(Panel1, Size1);
		    Transform.Resize(Panel2, Size2);
		}

		catch
		{
		    throw;
		}
	    }

	    public bool AddItem(string Name, Action Code)
	    {
		try
		{
		    if (!Sorters.SortBooleanCode(("Oh, yes"), () =>
		    {
			if (!Settings.GetStatus(1))
			{
			    return false;
			}

			else
			{
			    if (!Settings.GetStatus(2))
			    {
				if (!RegisterItemContainer())
				{
				    return false;
				}

				Settings.ToggleInit(2);
			    }

			    return true;
			}
		    })) return false;

		    FancyItem MrFancyItem = new FancyItem();

		    Sorters.SortCode(("License Plate"), () =>
		    {
			Point Location = NextLicensePlateLocation();
			Color BackColor = Settings.BackColor;
			Size Size = LicensePlateSize();
			
			Integrate.Panel(Panel2, MrFancyItem.LicensePlate, Size, Location, BackColor);
		    });

		    Sorters.SortCode(("License"), () =>
		    {
			Color BackColor = Settings.BackColor;
			Color ForeColor = Settings.ForeColor;
			Point Location = new Point(-1, -1);

			int FontSize = Settings.FontSize;
			int FontId = Settings.FontId;

			Integrate.Label(MrFancyItem.LicensePlate, MrFancyItem.License, Size.Empty, 
			    Location, BackColor, ForeColor, $"{Name}", FontId, FontSize);

			AddedItems.Add((MrFancyItem, Code));
		    });

		    UpdateContainerSizes();
		}

		catch
		{
		    return false;
		}

		return true;
	    }

	    public bool Integrator(Control Parent, Point Location, Color BackColor, Color ForeColor, Size ItemSize, params string[] ItemNames)
	    {
		try
		{
		    if (!Integrator(Parent, Location, BackColor, ForeColor, ItemSize.Width))
		    {
			return false;
		    }

		    void DefaultRunnable()
		    {
			/*#include <iostream>
		        using namespace std;

			int main(void)
			{
			    std::cout << "Can you believe that?" << std::endl;
			    std::cout << "I cannot, lol." << std::endl;
			    std::cout << "fun fact, C++ is my first language." << std::endl;
			    
			    cout << "so yea, it is quite fun....\n";
			    cout << "I find it unnecessary to setup a standard method.\n";
			    cout << "So I do not ;)\n";

			    return -1;
			}*/
		    }

		    Settings.ItemHeight = ItemSize.Height;
		    Settings.ItemWidth = ItemSize.Width;

		    foreach (string ItemName in ItemNames)
		    {
			AddItem(ItemName, DefaultRunnable);
		    }
		}

		catch
		{
		    return false;
		}

		return true;
	    }


	    //Integrator Base 3 (Add Children with Runnable):
	    public FancyItem GetLatestItem()
	    {
		try
		{
		    FancyItem Item = null;

		    if (AddedItems.Count > 0)
		    {
			Item = AddedItems[AddedItems.Count - 1].Item1;
		    }

		    return Item;
		}

		catch
		{
		    return null;
		}
	    }

	    public void RegisterClickCode(FancyItem Item, Action Code)
	    {
		try
		{
		    void Register(Control Control)
		    {
			Control.Click += (s, e) =>
			{
			    Code();
			};
		    }

		    Register(Item.LicensePlate);
		    Register(Item.License);
		}

		catch
		{
		    throw;
		}
	    }

	    public bool Integrator(Control Parent, Point Location, Color BackColor, Color ForeColor, Size ItemSize, params (string, Action)[] ItemSets)
	    {
		try
		{
		    string[] ItemNames = ItemSets.ToList().ConvertAll(a => a.Item1).ToArray();

		    if (!Integrator(Parent, Location, BackColor, ForeColor, ItemSize, ItemNames))
		    {
			return false;
		    }
		    
		    for (int k = 0; k < ItemSets.Length; k += 1)
		    {
			FancyItem Object = AddedItems[k].Item1;
			Action Code = ItemSets[k].Item2;

			RegisterClickCode(Object, Code);
		    }

		    foreach (var ItemSet in AddedItems)
		    {
			RegisterClickCode(ItemSet.Item1, ItemSet.Item2);
		    }

		    Settings.ItemHeight = ItemSize.Height;
		    Settings.ItemWidth = ItemSize.Width;
		}

		catch
		{
		    return false;
		}

		return true;
	    }
	}
    }
}