
// Author: Dashie


using System.Windows.Forms;
using System.Collections.Generic;

using DashFramework.DashResources;
using DashFramework.ControlTools;
using DashFramework.Sorters;


namespace DashFramework
{
    namespace DashControls
    {
	public partial class ControlIntegrator
	{
	    public readonly Dictionary<TextBox, int> TextBoxContainers = new Dictionary<TextBox, int>();

	    readonly ResourceTools ResourceTool = new ResourceTools();
	    readonly Transformer Transform = new Transformer();
	    readonly GenericSorter Sort = new GenericSorter();
	    readonly DataTools DataTool = new DataTools();
	}
    }
}