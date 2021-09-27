
// Author: Dashie


using System.Drawing;


namespace DashFramework
{
    namespace Forms
    {
	public partial class MenuBar
	{
	    public void SetMenuBarBorder()
	    {
		try
		{
		    if (BorderRadius > 0)
		    {
			Transform.Round(Panel1, BorderRadius);
		    }
		}

		catch
		{
		    throw;
		}
	    }

	    public Color MenubarColor()
	    {
		try
		{
		    if (Panel1.Parent != null)
		    {
			return Panel1.BackColor;
		    }

		    return Color.Empty;
		}

		catch
		{
		    throw;
		}
	    }
	}
    }
}