
// Author: Dashie

using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace DashFramework
{
    namespace DashControls.Customs
    {
	public partial class CBDropMenu
	{
	    public class SubMenus : List<CBDropMenu>
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

	    readonly SubMenus SubMenu = new SubMenus();

	    public bool AddSubMenu(int ItemId, Color BackColor1, Color BackColor2, 
		Color BackColor3, Color ForeColor, int MenuWidth, params (string, Action)[] Children)
	    {
		DashPanel Item = DropMenuEntries[ItemId].Item();
		CBDropMenu SubMenu = new CBDropMenu();

		try
		{
		    Sorters.SortCode(("Sub Menu"), () =>
		    {
			Point Location = new Point(0, Item.Top + Layer3.Top);

			SubMenu.Integrator(Layer1, Location, BackColor1,
			    BackColor2, BackColor3, ForeColor, MenuWidth, Children);
		    });

		    Sorters.SortCode(("Hooks"), () =>
		    {
			foreach (Entry Entry in DropMenuEntries)
			{
			    if (Entry.Item().Equals(Item))
			    {
				Entry.Item().MouseEnter += (s, e) =>
				{
				    Layer1.Show();
				};

				void Hook(params Control[] Controls)
				{
				    try
				    {
					foreach (Control Control in Controls)
					{
					    Control.MouseEnter += (s, e) =>
					    {
						try
						{
						    // See if E == the object now hovering or not.
						    MessageBox.Show($"{e.GetType().ToString()}");
						    SubMenu.Hide();
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

				Hook(Layer1, Layer2, Layer3, Layer4);
			    }
			}
		    });

		    this.SubMenu.Add(SubMenu);
		}

		catch
		{
		    return false;
		}
		
		return this.SubMenu.Contains(SubMenu);
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