
// Author: Dashie


using System.Drawing;
using System.Windows.Forms;


namespace DashFramework
{
    namespace Forms
    {
	public partial class MenuBar
	{
	    public void SetMenubarBorder()
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

	    public void SetButtonBackColor(Color color)
	    {
		try
		{
		    if (Panel1.Parent == null)
		    {
			return;
		    }

		    foreach (Control control in Panel1.Controls)
		    {
			if (control is Button)
			{
			    control.BackColor = color;
			}
		    }
		}

		catch
		{
		    throw;
		}
	    }

	    public void SetIconBackColor(Color color)
	    {
		try
		{
		    if (Panel1.Parent == null)
		    {
			return;
		    }

		    Icon1.BackColor = color;

		    UpdateIconLayers();
		}

		catch
		{
		    throw;
		}
	    }

	    public void SetMenubarBackColor(Color color)
	    {
		try
		{
		    if (Panel1.Parent == null)
		    {
			return;
		    }

		    Panel1.BackColor = color;

		    SetButtonBackColor(color);
		    SetTitleBackColor(color);
		    SetIconBackColor(color);
		}

		catch
		{
		    throw;
		}
	    }
	}
    }
}