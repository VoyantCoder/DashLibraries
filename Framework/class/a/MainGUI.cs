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
		
		Menu.Integrator(inst.Instance(), new Point(-1, -1), Color.Black,
		    Color.FromArgb(64, 64, 64), Color.FromArgb(8, 8, 8), Color.White, 200, 
		    ("I fluff", () => MessageBox.Show("!")), ("I also fluff", () => MessageBox.Show("!!")),
		    ("I fluff also", () => MessageBox.Show("!!!")), ("I also flufferyyyy", () => MessageBox.Show("!!!!")),
		    ("I flufadadadff", () => MessageBox.Show("!!!!!")), ("I alrrrrrrso fluff", () => MessageBox.Show("!!!!!!")));

		Color Hover = Color.FromArgb(48, 48, 48);
		Color Leave = Color.FromArgb(0, 0, 0);
		Color Down = Color.FromArgb(32, 32, 32);
		Color Up = Color.FromArgb(48, 48, 48);
		
		Menu.SetEventColor(Hover, MenuBarColor.License, MenuBarColorEvent.Enter);
		Menu.SetEventColor(Leave, MenuBarColor.License, MenuBarColorEvent.Leave);
		Menu.SetEventColor(Down, MenuBarColor.License, MenuBarColorEvent.Down);
		Menu.SetEventColor(Up, MenuBarColor.License, MenuBarColorEvent.Up);
	    }

	    catch
	    {
		throw;
	    }
	}
    }
}
