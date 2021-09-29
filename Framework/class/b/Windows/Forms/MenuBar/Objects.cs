
// Author: Dashie


using System.Windows.Forms;
using System.Collections.Generic;

using DashFramework.DashControls.Controls;
using DashFramework.DashResources;
using DashFramework.DashControls;
using DashFramework.ControlTools;
using DashFramework.Sorters;


namespace DashFramework
{
    namespace Forms
    {
	public enum TitlePosition
	{
	    Top, Bottom, Right, Left,
	    TopMiddle, BottomMiddle, Center,
	    LeftMiddle, RightMiddle,
	}

	public enum IconPosition
	{
	    Top, Bottom, Right, Left,
	    TopMiddle, BottomMiddle, Center,
	    LeftMiddle, RightMiddle
	}

	public enum ButtonSet
	{
	    Close, CloseMinimize, Custom
	}

	public partial class MenuBar
	{
	    public int BorderRadius = 8;
	    public int FontPoints = 10;
	    public int FontTypeId = 1;

	    readonly List<Button> CustomButtons = new List<Button>();

	    readonly PictureBox Icon1 = new PictureBox();
	    readonly PictureBox Icon2 = new PictureBox();

	    readonly DashPanel Panel1 = new DashPanel();

	    readonly Button Button1 = new Button();
	    readonly Button Button2 = new Button();

	    readonly Label Label1 = new Label();

	    readonly ControlIntegrator Integrator = new ControlIntegrator();
	    readonly ResourceTools ResourceTool = new ResourceTools();
	    readonly Transformer Transform = new Transformer();
	    readonly GenericSorter Sort = new GenericSorter();
	    readonly Appliance Appliance = new Appliance();
	}
    }
}