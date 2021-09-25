
// Author: Dashie


using System.Windows.Forms;
using System.Collections.Generic;

using DashFramework.DashControls.Controls;
using DashFramework.DashControls;
using DashFramework.ControlTools;
using DashFramework.Sorters;


namespace DashFramework
{
    namespace Forms
    {
	public enum ToolbarPosition
	{
	    Top, Bottom, Right, Left, Center
	}

	public enum ToolbarTemplate
	{
	    SaveLoadOpen, OkayCancel, Close
	}

	public partial class Toolbar
	{
	    readonly Dictionary<int, Control> ChildCollection = new Dictionary<int, Control>();
	    readonly List<Button> ButtonCache = new List<Button>();

	    readonly DashPanel Panel1 = new DashPanel();
	    readonly DashPanel Panel2 = new DashPanel();

	    readonly Simplifiers.Quickify QuickyInjector = new Simplifiers.Quickify();
	    readonly ControlIntegrator Integrator = new ControlIntegrator();

	    readonly Transformer Transform = new Transformer();
	    readonly PlainSorters Sorters = new PlainSorters();

	    readonly Apply Appliance = new Apply();
	    public delegate void ChildRun();
	}
    }
}