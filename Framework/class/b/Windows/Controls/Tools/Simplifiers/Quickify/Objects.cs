
// Author: Dashie


using System.Drawing;
using System.Windows.Forms;

using DashFramework.DashControls;
using DashFramework.Data;


namespace DashFramework
{
    namespace ControlTools.Simplifiers
    {
	public partial class Quickify
	{
	    readonly ControlIntegrator Controls = new ControlIntegrator();
	    readonly Transformer Transform = new Transformer();
	    readonly DataTools DataTool = new DataTools();

	    public enum ValueType
	    {
		Parent = 0, FCol, BCol, Fpts,
		Fid, Size, Mline, Sbar, Ronly,
		Brdr, Fixs
	    };

	    public enum Module
	    {
		Label = 0, Button, TextBox
	    };

	    public Control TxtboxParent = null;
	    public Control BttnParent = null;
	    public Control LblParent = null;

	    public Color TxtboxBCol = Color.Black;
	    public Color TxtboxFCol = Color.White;
	    public Color BttnBCol = Color.Black;
	    public Color BttnFCol = Color.White;
	    public Color LblBCol = Color.Black;
	    public Color LblFCol = Color.White;

	    public Size TxtboxSize = Size.Empty;
	    public Size BttnSize = Size.Empty;

	    public bool TxtboxBorder = true;
	    public bool BttnBorder = true;
	    public bool Multiline = false;
	    public bool Scrollbar = false;
	    public bool FixedSize = true;
	    public bool Readonly = true;

	    public int TxtboxFpts = 8;
	    public int TxtboxFid = 1;
	    public int BttnFpts = 8;
	    public int BttnFid = 1;
	    public int LblFpts = 8;
	    public int LblFid = 1;
	}
    }
}