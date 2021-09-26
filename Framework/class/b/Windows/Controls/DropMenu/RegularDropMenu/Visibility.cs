
// Author: Dashie


using System.Windows.Forms;


namespace DashFramework
{
    namespace DashControls.Controls
    {
	public partial class RegularDropMenu
	{
	    public void RegVisTrigger(params Control[] Triggers)
	    {
		try
		{
		    void Register(Control Trigger)
		    {
			try
			{
			    Trigger.MouseEnter += (s, e) =>
			    {
				Show();
			    };
			}

			catch
			{
			    throw;
			}
		    }

		    foreach (Control Trigger in Triggers)
		    {
			Register(Trigger);
		    }
		}

		catch
		{
		    throw;
		}
	    }

	    public void RegInvisTrigger(params Control[] Triggers)
	    {
		try
		{
		    void Register(Control Trigger)
		    {
			try
			{
			    Trigger.MouseEnter += (s, e) =>
			    {
				Hide();
			    };
			}

			catch
			{
			    throw;
			}
		    }

		    foreach (Control Trigger in Triggers)
		    {
			Register(Trigger);
		    }
		}

		catch
		{
		    throw;
		}
	    }
	}
    }
}