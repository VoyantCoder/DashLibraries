
// Author: Dashie


using System.Drawing;
using System.Windows.Forms;

using DashFramework.DashControls;
using DashFramework.ControlTools;
using DashFramework.Sorters;
using DashFramework.Forms;


namespace DashFramework
{
    namespace DashDialogs
    {
	public enum QuickDialogTemplate
	{
	    OkayCancel, YesNo, Okay, Close
	}

	public partial class SimpleDialog
	{
	    readonly ControlIntegrator Integrator = new ControlIntegrator();
	    readonly GenericSorter Sort = new GenericSorter();

	    readonly DashWindow WindowInstance = new DashWindow();

	    readonly Label Title = new Label();
	    readonly Label Description = new Label();

	    public Color DefaultLabelBackColor = Color.FromArgb(10, 10, 10);
	    public Color DefaultMenubarBackColor = Color.FromArgb(4, 4, 4);
	    public Color DefaultAppBackColor = Color.FromArgb(10, 10, 10);
	    public Color DefaultLabelForeColor = Color.White;
	    
	    readonly Transformer Transform = new Transformer();
	    readonly DataTools DataTool = new DataTools();
	}
    }
}