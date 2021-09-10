// Author: Dashie
// Version: 1.0


using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;

using DashFramework.DashControls.Customs;
using DashFramework.ControlTools;
using DashFramework.Sorters;
using DashFramework.Forms;


namespace DashFramework
{
    public partial class MainGUI
    {
	public void Initiator(DashWindow inst)
	{
	    try
	    {
		CBDropMenu Menu = new CBDropMenu();

		Color Color1 = Color.Black;
		Color Color2 = Color.FromArgb(64, 64, 64);
		Color Color3 = Color.FromArgb(8, 8, 8);
		Color Color4 = Color.White;

		void Default() => MessageBox.Show("!");

		var Children = new List<(string, Action)>()
		{
		    ("I also flufferyyyy", Default),
		    ("I alrrrrrrso fluff", Default),
    		    ("I flufadadadff", Default),
		    ("I also fluff", Default),
		    ("I fluff also", Default),
	    	    ("I fluff", Default),
		};

		Menu.Integrator(inst.Instance(), new Point(-1, -1), Color1, Color2, Color3, Color4, 200, Children.ToArray());

		var MoreChildren = new List<(string, Action)>()
		{
		    ("Sub Item1", Default),
		    ("Sub Item2", Default),
		    ("Sub Item3", Default),
		};
		
		Menu.AddSubMenu(0, Color1, Color2, Color3, Color4, 150, MoreChildren.ToArray());

		Color Hover = Color.FromArgb(48, 48, 48);
		Color Leave = Color.FromArgb(0, 0, 0);
		Color Down = Color.FromArgb(32, 32, 32);
		Color Up = Color.FromArgb(48, 48, 48);

		foreach (CBDropMenu Menuu in new List<CBDropMenu>() { Menu, Menu.SubMenus.GetMenu(0) })
		{
		    Menuu.SetEventColor(Hover, MenuBarColor.License, MenuBarColorEvent.Enter);
		    Menuu.SetEventColor(Leave, MenuBarColor.License, MenuBarColorEvent.Leave);
		    Menuu.SetEventColor(Down, MenuBarColor.License, MenuBarColorEvent.Down);
		    Menuu.SetEventColor(Up, MenuBarColor.License, MenuBarColorEvent.Up);
		}
	    }

	    catch
	    {
		throw;
	    }
	}
    }
}
