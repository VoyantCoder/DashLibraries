
// Author: Dashie


using System;
using System.Drawing;
using System.Windows.Forms;

using DashFramework.Erroring;
using DashFramework.Forms;


namespace DashFramework
{
    namespace DashDialogs
    {
	public partial class SimpleDialog
	{
	    public void InitializeWindow()
	    {
		try
		{
		    WindowInstance.Integrate(DashWindowPosition.Center, new Size(400, 200), 
			DefaultAppBackColor, DefaultMenubarBackColor, 
			false, 0, DefaultMenubarBackColor, Color.White, 
			resources.Resources.LOGO, "Dash Message Box");

		    Form inst = WindowInstance.Instance();
			
		    Integrator.Label(inst, Title, Size.Empty, new Point(-1, 40), DefaultLabelBackColor, 
			DefaultLabelForeColor, "DAHHH", FontSize: 22);

		    Integrator.Label(inst, Description, Size.Empty, new Point(-1, Title.Top + Title.Height + 20), 
			DefaultLabelBackColor, DefaultLabelForeColor, ".", FontSize: 12);

		    Description.TextAlign = ContentAlignment.MiddleCenter;
    	    	    Title.TextAlign = ContentAlignment.MiddleCenter;
		}

		catch
		{
		    throw;
		}
	    }

	    public void SetWindowText(string description, string title)
	    {
		try
		{
		    Sorters.SortCode(("Title and Description"), () =>
		    {
			Size DescriptionSize = DataTool.GetFontSize(description, 12);
			Size TitleSize = DataTool.GetFontSize(title, 22);

			Transform.Resize(Description, DescriptionSize);
			Transform.Resize(Title, TitleSize);

			Description.Left = (Description.Parent.Width - Description.Width) / 2;
			Title.Left = (Title.Parent.Width - Title.Width) / 2;

			Description.Text = description;
			Title.Text = title;
		    });

		    Sorters.SortCode(("Window Sizing"), () =>
		    {
			int height = 28 + 15 + 20 + 15 + Title.Height + Description.Height;
			int width = WindowInstance.GetWindowSize().Width;

			Size WindowSize = new Size(width, height);

			Transform.Resize(WindowInstance.Instance(), WindowSize);
		    });
		}

		catch
		{
		    throw;
		}
	    }

	    public void PresentMessage(string description, string title)
	    {
		try
		{
		    if (!WindowInstance.Registered())
		    {
			InitializeWindow();
		    }

		    SetWindowText(description, title);
		}

		catch
		{
		    throw;
		}
		Show();
	    }

	    public void PresentMessage(string description, string title, Color BackColor, Color ForeColor)
	    {
		try
		{
		    if (!DefaultLabelBackColor.Equals(BackColor) || !DefaultLabelForeColor.Equals(ForeColor))
		    {
			WindowInstance.Instance().BackColor = BackColor;

			DefaultLabelBackColor = BackColor;
			DefaultLabelForeColor = ForeColor;

			Title.ForeColor = ForeColor;
			Title.BackColor = BackColor;

			Description.ForeColor = ForeColor;
			Description.BackColor = BackColor;

			WindowInstance.Instance().Update();
		    }

		    PresentMessage(description, title);
		}

		catch
		{
		    throw;
		}
	    } 
	}
    }
}