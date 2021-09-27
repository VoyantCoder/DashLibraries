
// Author: Dashie


using System.Windows.Forms;
using System.Collections.Generic;

using DashFramework.Sorters;
using DashFramework.ControlTools;

namespace DashFramework
{
    namespace Forms
    {
	public enum DashWindowPosition
	{
	    Left, Right, Top, Bottom, Center, None
	}

	public enum DashWindowRoundRadius
	{
	    Slightly, MoreSo, Extreme
	}

	public partial class DashWindow
	{
	    readonly Dictionary<int, Control> ChildIdentifiers = new Dictionary<int, Control>();

	    readonly PlainSorters Sorters = new PlainSorters();
	    readonly Transformer Transform = new Transformer();

	    readonly MenuBar MenubarInstance = new MenuBar();
	    readonly Form WindowInstance = new Form();

	    public bool Initialized = false;
	}
    }
}