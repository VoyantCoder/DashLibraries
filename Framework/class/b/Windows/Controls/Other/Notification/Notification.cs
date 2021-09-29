
// Author: Dashie


using System.Drawing;
using System.Windows.Forms;


namespace DashFramework
{
    namespace DashControls.Controls
    {
	public partial class Notification
	{
	    public void Integration(Control parent)
	    {
		try
		{
		    Sort.Sort("Display Container", () =>
		    {
			if (defaultSize.Width == -1)
			{
			    defaultSize.Width = parent.Width;
			}

			Integrator.Panel(parent, Panel1, 
			    defaultSize, new Point(-1, -1), backColor);
		    });

		    Sort.Sort("Title/Description", () =>
		    {
			void ResizeEventHandler(Control control)
			{
			    try
			    {
				control.Resize += (s, e) =>
				{
				    try
				    {
					if (!autoResizeContainer)
					{
					    return;
					}

					int h1 = Label1.Height + Label1.Top;
					int h2 = Label2.Height + Label2.Top;
					int h3 = 20; 

					Size size = new Size(Panel1.Size.Width, h1 + h2 + h3);
					
					transform.Resize(Panel1, size);
				    }

				    catch
				    {
					throw;
				    }
				};
			    }

			    catch
			    {
				throw;
			    }
			}

			void Integrate(Label label, int fontSize)
			{
			    try
			    {
				Integrator.Label(Panel1, label, new Size(1, 1), new
				    Point(1, 1), Color.Black, foreColor, "", FontSize: fontSize);

				ResizeEventHandler(label);
			    }

			    catch
			    {
				throw;
			    }

			    label.TextAlign = ContentAlignment.MiddleCenter;
			}

			Integrate(Label1, titleFontSize);
			Integrate(Label2, descriptionFontSize);
		    });

		    Label1.Top = 10;
		}

		catch
		{
		    throw;
		}
	    }

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
		    if (Panel1.Parent != parent)
		    {
			Integration(parent);
		    }

		    SetLocation(location);
		    Appear();
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
		    Size size2 = DataTool.GetFontSize(description, descriptionFontSize);
		    Size size1 = DataTool.GetFontSize(title, titleFontSize);

		    transform.Resize(Label1, size1);
		    transform.Resize(Label2, size2);

		    Label2.Text = description;
		    Label1.Text = title;

		    Label1.Left = (Panel1.Width - Label1.Width) / 2;
		    Label2.Left = (Panel1.Width - Label2.Width) / 2;
		    Label2.Top = Label1.Top + size1.Height + 10;

		    Label1.Refresh();
		    Label2.Refresh();
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
		}

		catch
		{
		    throw;
		}

		Appear();
	    }

	    public bool Appear()
	    {
		try
		{
		    if (Panel1.Parent == null)
		    {
			return false;
		    }

		    Panel1.Show();
		    Panel1.BringToFront();
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