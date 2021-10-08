
// Author: Dashie


using System.Drawing;

using DashFramework.ControlTools;
using DashFramework.Sorters;


namespace DashFramework
{
    namespace DashControls.Controls
    {
	public partial class DashCheckBox
	{
	    //Controls:
	    readonly DashPanel Panel1 = new DashPanel();
	    readonly DashPanel Panel2 = new DashPanel();
	    
	    //Obtainers:
	    public DashPanel CheckBoxOutter() => Panel1;
	    public DashPanel CheckBoxInner() => Panel2;
	    
	    //Color Presets:
	    public Color CheckBoxUncheckedColor = Color.Black;
	    public Color CheckBoxDefaultColor = Color.Gray;
	    public Color CheckBoxCheckedColor = Color.Gray;

	    public Color MarkBoxUncheckedColor = Color.Navy;
	    public Color MarkBoxDefaultColor = Color.DarkGray;
	    public Color MarkBoxCheckedColor = Color.Green;

	    //Sizing:
	    public int CheckBoxHeight = 16, CheckBoxWidth = 16;
	    public int MarkBoxHeight = 8, MarkBoxWidth = 8;

	    readonly ControlIntegrator Integrate = new ControlIntegrator();
	    readonly Transformer Transform = new Transformer();
	    readonly GenericSorter Sort = new GenericSorter();
	}
    }
}