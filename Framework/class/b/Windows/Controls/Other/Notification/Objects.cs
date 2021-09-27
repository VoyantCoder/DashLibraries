﻿
// Author: Dashie


using System.Windows.Forms;

using DashFramework.ControlTools;
using DashFramework.Sorters;


namespace DashFramework
{
    namespace DashControls.Controls
    {
	public partial class Notification
	{
	    readonly DashPanel Panel1 = new DashPanel();

	    readonly Label Label1 = new Label();
	    readonly Label Label2 = new Label();

	    readonly ControlIntegrator Integrator = new ControlIntegrator();
	    readonly Transformer transform = new Transformer();
	    readonly PlainSorters Sorter = new PlainSorters();
	    readonly DataTools DataTool = new DataTools();
	}
    }
}