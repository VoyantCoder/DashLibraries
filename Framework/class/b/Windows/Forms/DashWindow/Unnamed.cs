
// Author: Dashie


using System.Drawing;
using System.Windows.Forms;


namespace DashFramework
{
    namespace Forms
    {
	public partial class DashWindow
	{
	    public bool ChangeParent(Control NewParent)
	    {
		try
		{
		    WindowInstance.Parent = NewParent;
		    return (WindowInstance.Parent == NewParent);
		}

		catch
		{
		    return false;
		}
	    }

	    public Form Instance()
	    {
		try
		{
		    return WindowInstance;
		}

		catch
		{
		    return null;
		}
	    }

	    public bool Registered()
	    {
		try
		{
		    return Initialized;
		}

		catch
		{
		    throw;
		}
	    }
	    
	    public Size GetWindowSize()
	    {
		try
		{
		    return WindowInstance.Size;
		}

		catch
		{
		    return Size.Empty;
		}
	    }

	    public void SetWindowBackColor(Color Color)
	    {
		try
		{
		    Instance().BackColor = Color;
		}

		catch
		{
		    throw;
		}
	    }
	}
    }
}