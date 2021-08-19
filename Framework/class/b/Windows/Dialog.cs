// Sector Name:
// Author: Dashie


#pragma warning disable IDE1006


using System;
using System.Drawing;
using System.Windows.Forms;

using DashFramework.DashControls.Customs;
using DashFramework.DashResources;
using DashFramework.DashControls;
using DashFramework.ControlTools;
using DashFramework.Erroring;
using DashFramework.Sorters;
using DashFramework.Forms;
using DashFramework.Data;


namespace DashFramework
{
    namespace DialogSet
    {
	namespace Dialogs
	{
	    public enum QuickDialogTemplate
	    {
		OkayCancel, YesNo, Okay, Close
	    }

	    public class QuickyDialog
	    {
		readonly ControlIntegrator Integrator = new ControlIntegrator();
		readonly PlainSorters Sorters = new PlainSorters();

		readonly DashWindow WindowInstance = new DashWindow();

		readonly Label Title = new Label();
		readonly Label Description = new Label();

		public Color DefaultLabelBackColor = Color.FromArgb(10, 10, 10);
		public Color DefaultMenubarBackColor = Color.FromArgb(4, 4, 4);
		public Color DefaultAppBackColor = Color.FromArgb(10, 10, 10);
		public Color DefaultLabelForeColor = Color.White;


		public void InitializeWindow()
		{
		    try
		    {
			Sorters.SortCode(("Main Window Initiator"), () =>
			{
			    WindowInstance.Integrate(DashWindowPosition.Center, new Size(400, 200), DefaultAppBackColor,
				DefaultMenubarBackColor, false, 0, DefaultMenubarBackColor, Color.White, resources.Resources.LOGO, "Dash Message Box");
			});

			Sorters.SortCode(("Title & Description"), () =>
			{
			    Form inst = WindowInstance.Instance();
			    Size EmptySize = Size.Empty;

			    Integrator.Label(inst, Title, EmptySize, new Point(-1, 40), 
				DefaultLabelBackColor, DefaultLabelForeColor, "DAHHH", FontSize: 22);

			    Integrator.Label(inst, Description, EmptySize, new Point(-1, Title.Top + Title.Height + 20), 
				DefaultLabelBackColor, DefaultLabelForeColor, ".", FontSize: 12);

			    Description.TextAlign = ContentAlignment.MiddleCenter;
			    Title.TextAlign = ContentAlignment.MiddleCenter;
			});
		    }

		    catch
		    {
			throw;
		    }
		}

		readonly Transformer Transform = new Transformer();
		readonly DataTools DataTool = new DataTools();

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

			// Height Resizing Logic:
			// 1) Set the label to the fixed width.
			// 2) Retrieve preferred height.
			// 3) Set preferred height.
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
			Show();
		    }

		    catch
		    {
			throw;
		    }
		}


		// Recolor Integration:
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


		// Template Integration:
		public void PresentMessage(string description, string title, Color BackColor, Color ForeColor, QuickDialogTemplate Template)
		{
		    try
		    {
			// Integrate buttons, setup hook events, allow changing of hooks by using interfaces.  public virtual void OnButtonClose();
		    }

		    catch
		    {
			throw;
		    }
		}


		// Visibility Integration:
		public void Show()
		{
		    if (!WindowInstance.IsVisible())
		    {
			WindowInstance.Show();
		    }
		}
	    }
	}


	public class Shortcuts
	{
	    public void MsgBox(string msg, string title = "Dash Notification", MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Information)
	    {
		try
		{
		    MessageBox.Show(msg, title, buttons, icon);
		}

		catch (Exception E)
		{
		    ErrorHandler.GetException(E);
		}
	    }
	}


	public class DashLink// Forms
	{
	    public void CenterDialog(Control Dialog, Control Parent)
	    {
		try
		{
		    Point ParentLoca = Parent.PointToScreen(Point.Empty);

		    int Y = ParentLoca.Y + ((Parent.Height - Dialog.Height) / 2);
		    int X = ParentLoca.X + ((Parent.Width - Dialog.Width) / 2);

		    Dialog.Location = new Point(X, Y);
		}

		catch (Exception E)
		{
		    ErrorHandler.JustDoIt(E);
		}
	    }

	    // Auto Update Ideology: (Future Feature)
	    // - When parent GUI moves update added dialog
	    // - Old Dialog Location on Screen
	    // - Update it by changed value of Parent
	    // - If changed value is higher than old +
	    // - If changed value is lower than old -
	}
    }
}