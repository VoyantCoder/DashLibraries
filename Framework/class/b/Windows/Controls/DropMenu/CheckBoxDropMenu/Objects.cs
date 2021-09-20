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
	    readonly DashPanel Layer1 = new DashPanel();//Sub Holder
	    readonly DashPanel Layer2 = new DashPanel();//Main Holder
	    readonly DashPanel Layer3 = new DashPanel();//Item Holder
	    readonly DashPanel Layer4 = new DashPanel();//CheckBox Holder

	    public readonly List<CheckBox> DropMenuBoxes = new List<CheckBox>();
	    public readonly List<Entry> DropMenuEntries = new List<Entry>();

	    public class CheckBox
	    {
		public readonly DashPanel BasisHeadlight = new DashPanel();
		public readonly DashPanel OutterHeadlight = new DashPanel();
		public readonly DashPanel InnerHeadlight = new DashPanel();
	    }

	    public class Entry
	    {
		public readonly DashPanel LicensePlate = new DashPanel();
		public readonly Label License = new Label();

		public DashPanel Item() => LicensePlate;

		public Entry()
		{
		    try
		    {
			License.TextAlign = ContentAlignment.MiddleCenter;
		    }

		    catch
		    {
			throw;
		    }
		}
	    }

	    readonly ControlIntegrator Integrate = new ControlIntegrator();
	    readonly PlainSorters Sorters = new PlainSorters();
	}
    }
}
