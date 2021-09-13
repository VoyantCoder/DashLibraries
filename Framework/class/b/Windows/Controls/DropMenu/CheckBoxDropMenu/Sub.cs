
// Author: Dashie

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace DashFramework
{
    namespace DashControls.Customs
    {
	public partial class CBDropMenu
	{
	    public class SubMenuList : List<CBDropMenu>
	    {
		public CBDropMenu GetMenu(int Id)
		{
		    try
		    {
			if (Count <= Id)
			{
			    return null;
			}

			return this[Id];
		    }

		    catch
		    {
			return null;
		    }
		}
	    }

	    public readonly SubMenuList SubMenus = new SubMenuList();
	   
	    public bool AddSubMenu(int ItemId, Color BackColor1, Color BackColor2, 
		Color BackColor3, Color ForeColor, int MenuWidth, params (string, Action)[] Children)
	    {
		DashPanel Item = DropMenuEntries[ItemId].Item();
		CBDropMenu SubMenu = new CBDropMenu();

		try
		{
		    Sorters.SortCode(("Sub Menu"), () =>
		    {
			Point Location = new Point(Layer2.Width, Item.Top + Layer3.Top - 2);

			SubMenu.Integrator(Layer1, Location, BackColor1,
			    BackColor2, BackColor3, ForeColor, MenuWidth, Children);
		    });

		    Sorters.SortCode(("Hooks"), () =>
		    {
			foreach (Entry Entry in DropMenuEntries)
			{
			    SubMenu.SetVisibilityTrigger(Entry.Item()
				.Equals(Item), Entry.License, Entry.LicensePlate);
			}

			void SetHook(params Control[] Controls)
			{
			    try
			    {
				foreach (Control Control in Controls)
				{
				    Control.MouseEnter += (s, e) =>
				    {
					int a = SubMenu.Layer1.Width;
					int b = Layer1.Width;
					int c = Layer3.Width + Layer3.Left + 2;

					if (b == c)
					{
					    Size Size = new Size(a + b, Layer1.Height);
					    Transform.Resize(Layer1, Size);
					}
				    };
				}
			    }

			    catch
			    {
				throw;
			    }
			}

			Entry Temp = DropMenuEntries[ItemId];
			SetHook(Temp.License, Temp.LicensePlate);
		    });

		    SubMenus.Add(SubMenu);
		}

		catch
		{
		    return false;
		}
		
		return SubMenus.Contains(SubMenu);
	    }

	    public bool AddSubMenu(Entry Item, Color BackColor1, Color BackColor2, 
		Color BackColor3, Color ForeColor, int MenuWidth, params (string, Action)[] Children)
	    {
		try
		{
		    return AddSubMenu(DropMenuEntries.IndexOf(Item), BackColor1,
			BackColor2, BackColor3, ForeColor, MenuWidth, Children);
		}

		catch
		{
		    return false;
		}
	    }
	}
    }
}