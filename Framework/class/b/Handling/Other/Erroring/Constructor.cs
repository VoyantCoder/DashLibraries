 
// Author: Dashie


using System.Drawing;

using DashFramework.DashDialogs;


namespace DashFramework
{
    namespace Erroring
    {
	public partial class HandleError
	{
	    private void StandardProcedure(bool show = false)
	    {
		try
		{
		    Initialize();

		    if (show)
		    {
			Show();
		    }
		}

		catch
		{
		    throw;
		}
	    }

	    public HandleError()
	    {
		try
		{
		    StandardProcedure();
		}

		catch
		{
		    throw;
		}
	    }

	    public HandleError(Color backColor, Color foreColor)
	    {
		try
		{
		    dialog.UpdateColor(foreColor, DiagColorType.UIText);
		    dialog.UpdateColor(backColor, DiagColorType.UI);
		    StandardProcedure();
		}

		catch
		{
		    throw;
		}
	    }
	    
	    public HandleError(Color backColor, Color foreColor, string headerText, string descriptionText)
	    {
		try
		{
		    dialog.UpdateColor(foreColor, DiagColorType.UIText);
		    dialog.UpdateColor(backColor, DiagColorType.UI);
		    dialog.SetContents(headerText, descriptionText);
		    StandardProcedure(true);
		}

		catch
		{
		    throw;
		}
	    }
	}
    }
}