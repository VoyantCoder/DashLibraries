
// Author: Dashie


namespace DashFramework
{
    namespace Forms
    {
	public partial class DashWindow
	{
	    public virtual bool Show()
	    {
		try
		{
		    if (!WindowInstance.Visible)
		    {
			WindowInstance.Show();
		    }

		    return true;
		}

		catch
		{
		    return false;
		}
	    }

	    public virtual bool Hide()
	    {
		try
		{
		    if (WindowInstance.Visible)
		    {
			WindowInstance.Hide();
		    }

		    return true;
		}

		catch
		{
		    return false;
		}
	    }

	    public bool IsVisible()
	    {
		try
		{
		    return WindowInstance.Visible;
		}

		catch
		{
		    return false;
		}
	    }

	    public bool SendToBack()
	    {
		try
		{
		    WindowInstance.SendToBack();
		    return true;
		}

		catch
		{
		    return false;
		}
	    }

	    public bool BringToFront()
	    {
		try
		{
		    WindowInstance.BringToFront();
		    return true;
		}

		catch
		{
		    return false;
		}
	    }
	}
    }
}