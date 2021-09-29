
// Author: Dashie


using System;
using System.Drawing;
using System.Windows.Forms;

using DashFramework.Data;
using DashFramework.Forms;
using DashFramework.ControlTools;
using DashFramework.DashControls;


namespace DashFramework
{
    namespace DashDialogs
    {
	public enum DiagColorType
	{
	    UIMenuBar, UI, UIText
	}

	public partial class SimpleDialog
	{
	    readonly DashWindow Window = new DashWindow();
	    readonly Button CloseBttn = new Button();
	    readonly Label HeadLabel = new Label();
	    readonly Label BodyLabel = new Label();
	    
	    Color UIMenubarBackColor = Color.FromArgb(8, 8, 8);
	    Color UIButtonColor = Color.FromArgb(12, 12, 12);
	    Color UIBackColor = Color.FromArgb(24, 24, 24);
	    Color UITextForeColor = Color.White;

	    Action CloseCode = () => Environment.Exit(-1);

	    readonly ControlIntegrator Integrate = new ControlIntegrator();
	    readonly Transformer Transform = new Transformer();
	    readonly DataTools DataTool = new DataTools();

	    bool RoundSides = true;
	}
    }
}