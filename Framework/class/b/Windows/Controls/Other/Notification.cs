
// Author: Dashie


using System.Drawing;
using System.Windows.Forms;

using DashFramework.ControlTools;


namespace DashFramework
{
    namespace DashControls.Customs
    {
	public class Notification
	{
	    readonly DashPanel Panel1 = new DashPanel() { Parent = null };
	    readonly Label Label1 = new Label();
	    readonly Label Label2 = new Label();

	    public void SetLocation(Point location)
	    {
		try
		{
		    if (!Panel1.Location.Equals(location))
		    {
			Panel1.Location = location;
			Panel1.Update();
		    }
		}

		catch
		{
		    throw;
		}
	    }

	    public bool Integrate(Control parent, Point location)
	    {
		try
		{
		    void Integration()
		    {
			try
			{
			   // add panel with colors etc
			}

			catch
			{
			    throw;
			}
		    }

		    SetLocation(location);
		}

		catch
		{
		    return false;
		}

		return true;
	    }

	    public void SetText(string title, string description)
	    {
		try
		{
		    Label2.Text = description;
		    Label1.Text = title;
		}

		catch
		{
		    throw;
		}
	    }

	    public bool InitAppear(Control parent, string title, string description, Point location)
	    {
		try
		{
		    if (parent != Panel1.Parent && location != Panel1.Location)
		    {
			Integrate(parent, location);
		    }

		    else if (parent != Panel1.Parent)
		    {
			parent.Controls.Add(parent);
		    }

		    else if (location != Panel1.Location)
		    {
			Panel1.Location = location;
		    }

		    SetText(title, description);
		    Appear();
		}

		catch
		{
		    return false;
		}

		return true;
	    }

	    Color backColor = Color.DarkRed;
	    Color foreColor = Color.White;

	    public void SetColors(Color backgroundColor, Color foregroundColor)
	    {
		try
		{
		    if (backColor != backgroundColor)
		    {
			Panel1.BackColor = backgroundColor;
			Label1.BackColor = backgroundColor;
			Label2.BackColor = backgroundColor;
			backColor = backgroundColor;
		    }

		    if (foreColor != foregroundColor)
		    {
			Panel1.ForeColor = foregroundColor;
			Label1.ForeColor = foregroundColor;
			Label2.ForeColor = foregroundColor;
			foreColor = foregroundColor;
		    }
		}

		catch
		{
		    throw;
		}
	    }

	    public bool InitAppear(Control parent, string title, string description, Point location, Color backgroundColor, Color foregroundColor)
	    {
		try
		{
		    if (!InitAppear(parent, title, description, location))
		    {
			return false;
		    }

		    SetColors(backgroundColor, foregroundColor);
		    Appear();
		}

		catch
		{
		    return false;
		}

		return true;
	    }

	    Transformer transform = new Transformer();
	    
	    public void SetSize(Size size)
	    {
		try
		{
		    if (!size.Equals(Panel1.Size))
		    {
			transform.Resize(Panel1, size);
		    }
		}

		catch
		{
		    throw;
		}
	    }

	    public void InitAppear(Control parent, string title, string description, Point location, Size size, Color backgroundColor, Color foregroundColor)
	    {
		try
		{
		    if (!InitAppear(parent, title, description, location, backgroundColor, foregroundColor))
		    {
			return;
		    }

		    SetSize(size);
		    Appear();
		}

		catch
		{
		    throw;
		}
	    }

	    public bool Appear()
	    {
		try
		{
		    if (Panel1.Parent == null)
		    {
			return false;
		    }

		    else if (!Panel1.Visible)
		    {
			Panel1.Show();
		    }
		}

		catch
		{
		    return false;
		}

		return true;
	    }
	}
    }
}