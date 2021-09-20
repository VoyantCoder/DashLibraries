// Author: Dashie
// Version: 1.0


namespace DashFramework
{
    namespace DashControls.Customs
    {
	public partial class CBDropMenu
	{
	    public void Show(bool force = false)
	    {
		try
		{
		    if (Layer1.Visible)
		    {
			if (!force)
			{
			    return;
			}
		    }

		    Layer1.Show();
		    Layer1.BringToFront();
		}

		catch
		{
		    throw;
		}
	    }

	    public void Hide(bool force = false)
	    {
		try
		{
		    if (!Layer1.Visible)
		    {
			if (!force)
			{
			    return;
			}
		    }

		    Layer1.Hide();
		}

		catch
		{
		    throw;
		}
	    }
	}
    }
}
