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
    namespace DashControls
    {
	namespace Customs
	{
	    public class FancyDropMenu
	    {
		readonly ControlIntegrator Integrator = new ControlIntegrator();
		readonly PlainSorters Sorters = new PlainSorters();

		readonly DashPanel EntryContainer = new DashPanel();
		readonly DashPanel MainContainer = new DashPanel();
		
		public void RegisterShowTrigger(params Control[] Targets)
		{
		    try
		    {
			foreach (Control Target in Targets)
			{
			    Target.MouseEnter += (s, e) =>
			    {
				if (!MainContainer.Visible)
				{
				    MainContainer.Show();
				}
			    };
			}
		    }

		    catch
		    {
			throw;
		    }
		}

		public void RegisterHideTrigger(params Control[] Targets)
		{
		    try
		    {
			foreach (Control Target in Targets)
			{
			    Target.MouseEnter += (s, e) =>
			    {
				if (MainContainer.Visible)
				{
				    MainContainer.Hide();
				}
			    };
			}
		    }

		    catch
		    {
			throw;
		    }
		}

		public void INTEGRATE(Control Parent, Point Location, Color BackColor1, Color BackColor2, bool Visible = false)
		{ //backcolor1=basis, backcolor2=checkboxcontainer, backcolor3=itemcontainer
		    try
		    {
			Sorters.SortCode(("basis"), () =>
			{
			    if (Location.X <= -1)
			    {
				Location.X = (Parent.Width - 170) / 2;
			    }

			    if (Location.Y <= -1)
			    {
				Location.Y = (Parent.Height - 28) / 2;
			    }

			    Integrator.Panel(Parent, MainContainer, new Size(170, 28), Location, BackColor1);
			});

			Sorters.SortCode(("entry"), () =>
			{
			    Size PanelSize = new Size(MainContainer.Width - 4, MainContainer.Height - 4);
			    Point PanelLocation = new Point(2, 2);

			    Integrator.Panel(MainContainer, EntryContainer, PanelSize, PanelLocation, BackColor2);
			});

			MainContainer.Visible = Visible;
		    }

		    catch
		    {
			throw;
		    }
		}
	    }
	}
    }
}