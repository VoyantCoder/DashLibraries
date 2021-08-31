// Author: Dashie
// Version: 1.0


using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using DashFramework.DashControls.Customs;
using DashFramework.DashControls;
using DashFramework.Sorters;


namespace DashFramework
{
    namespace DashControls
    {
	namespace Customs
	{
	    public class CBDropMenuItems
	    {
		public readonly DashPanel Layer1 = new DashPanel();
		public readonly DashPanel Layer2 = new DashPanel();
		public readonly DashPanel Layer3 = new DashPanel();
		public readonly DashPanel Layer4 = new DashPanel();

		public class CheckBox
		{
		    public readonly DashPanel UpperHeadlight = new DashPanel();
		    public readonly DashPanel InnerHeadlight = new DashPanel();
		}

		public class Entry
		{
		    public readonly DashPanel LicensePlate = new DashPanel();
		    public readonly Button License = new Button();
		}

		public readonly ControlIntegrator Integrate = new ControlIntegrator();
		public readonly PlainSorters Sorters = new PlainSorters();
	    }

	    public class CBDropMenu : CBDropMenuItems
	    {
		public void Integrator(Control Parent, Point Location, Color BackColor, Color ForeColor, int MenuWidth = 110, bool HasHovers = true)
		{
		    try
		    {
			Sorters.SortCode(("Base"), () =>
			{
			    Size Layer1Size = new Size(MenuWidth, 4);

			    Integrate.Panel(Parent, Layer1, Layer1Size, Location, BackColor);
			    Integrate.Panel(Layer1, Layer2, Layer1Size, new Point(0, 0), BackColor);
			});

			Sorters.SortCode(("Layer3"), () =>
			{

			});

			Sorters.SortCode(("Layer4"), () =>
			{

			});
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
