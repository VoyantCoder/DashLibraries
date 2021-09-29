
// Author: Dashie


using System.Drawing;


namespace DashFramework
{
    namespace DashDialogs
    {
	public partial class SimpleDialog
	{
	    private void DefaultProcedure(string title, bool Show) /* <-- useless now, not for long */
	    {
		try
		{
		    ConstructWindow(title);

		    if (Show)
		    {
			Window.Show();
			Window.BringToFront();
		    }
		}

		catch
		{
		    throw;
		}
	    }

	    public SimpleDialog(string title)
	    {
		try
		{
		    DefaultProcedure(title, false);
		}

		catch
		{
		    throw;
		}
	    }

	    public SimpleDialog(string title, Color backColor, Color foreColor)
	    {
		try
		{
		    UUITextForeColor(foreColor);
		    UUIBackColor(backColor);

		    DefaultProcedure(title, false);
		}

		catch
		{
		    throw;
		}
	    }

	    public SimpleDialog(string title, Color muiBackColor, Color mbarBackColor, Color foreColor)
	    {
		try
		{
		    UUITextForeColor(foreColor);
		    UUIBackColor(muiBackColor);
		    UUIMenubarBackColor(mbarBackColor);

		    DefaultProcedure(title, false);
		}

		catch
		{
		    throw;
		}
	    }
	}
    }
}