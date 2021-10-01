
// Author: Dashie


using System.Windows.Forms;
using System.Collections.Generic;

using DashFramework.ControlTools.Simplifiers;
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
	    
	    readonly ControlIntegrator Integrator = new ControlIntegrator();
	    readonly Transformer Transform = new Transformer();
	    readonly GenericSorter Sort = new GenericSorter();
	    readonly Quickify QuickyInjector = new Quickify();

	    readonly Appliance Appliance = new Appliance();
	    public delegate void ChildRun();
	}
    }
}