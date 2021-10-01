
// Author: Dashie


using System.Drawing;
using System.Windows.Forms;


namespace DashFramework
{
    namespace DashControls.Controls
    {
	public partial class DashPanel : Panel
	{
	    public DashPanel()
	    {
		try
		{
		    //SetStyle(ControlStyles.SupportsTransparentBackColor, true);
		    //SetStyle(ControlStyles.Opaque, true);
		    //BackColor = Color.Transparent;

		    inst = this;
		}

		catch
		{
		    throw;
		}
	    }
	}
    }
}