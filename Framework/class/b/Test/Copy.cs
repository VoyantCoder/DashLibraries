// Sector Name: Temporarily Rewrite File
// Author: Dashie

using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

using DashFramework.DashControls.Customs;
using DashFramework.DashControls;
using DashFramework.ControlTools;
using DashFramework.Erroring;
using DashFramework.Data;

using DashFramework.resources;


namespace DashFramework
{
    namespace Forms
    {
	public class DashMenuBar
	{
	    readonly ControlIntegrator Control = new ControlIntegrator();
	    readonly Transformer Transform = new Transformer();
	    readonly DataTools DataTool = new DataTools();
	    readonly Apply Applies = new Apply();


	    public class Values
	    {
		public readonly PictureBox LogoLayer1 = new PictureBox();
		public readonly PictureBox LogoLayer2 = new PictureBox();
		public readonly DashPanel Bar = new DashPanel();
		public readonly Button Button1 = new Button();
		public readonly Button Button2 = new Button();
		public readonly Label Title = new Label();

		public bool Minimize = false;
		public bool Close = false;
		public bool Hide = false;


		public void setLogoBackColor(Color to)
		{
		    LogoLayer1.BackColor = Bar.BackColor;
		    LogoLayer2.BackColor = to;
		}


		public Control.ControlCollection getControls() => Bar.Controls;
		public Control getParent() => Bar.Parent;

		public Color getBarColor() => Bar.BackColor;

		public void setLocationOf(Control me, Point to) => me.Location = to;
		public void setColorOf(Control me, Color to) => me.BackColor = to;
		public void setBarBackColor(Color to) => Bar.BackColor = to;
		public void setTitle(string to) => Title.Text = to;

		public int parentHeight() => Bar.Parent.Height;
		public int parentWidth() => Bar.Parent.Width;
		public int Height() => Bar.Height;
		public int Width() => Bar.Width;
	    }


	    public readonly Values values = new Values();

	    public DashMenuBar(string title, bool minimizeButton, bool closeButton, bool hideDialog = true)
	    {
		try
		{
		    values.Minimize = minimizeButton;
		    values.Close = closeButton;
		    values.Hide = hideDialog;

		    values.setTitle(title);
		}

		catch (Exception E)
		{
		    throw (ErrorHandler.GetException(E));
		}
	    }


	    public enum Heights { Light = 24, Medium = 26, Heavy = 28, Fat = 30 };

	    public void AddMe(Control parent, Color barBCol, Color borderBCol, int barHeight = 26)
	    {
		try
		{
		    var MenuBarSize = new Size(parent.Width, barHeight);
		    var MenuBarLoca = new Point(0, 0);
		    var MenuBarBCol = barBCol;

		    Control.Panel(parent, values.Bar, MenuBarSize, MenuBarLoca, MenuBarBCol);
		    Applies.ApplyDraggability(values.Bar, parent);

		    var LogoSize = Resources.LOGO.Size;
		    var LogoLoca = new Point(5, 2);

		    Control.Image(parent, values.LogoLayer2, LogoSize, LogoLoca, parent.BackColor, ObjectImage: Resources.LOGO);
		    Control.Image(values.Bar, values.LogoLayer1, LogoSize, LogoLoca, barBCol, ObjectImage: Resources.LOGO);

		    Applies.ApplyDraggability(values.LogoLayer1, parent);
		    Applies.ApplyDraggability(values.LogoLayer2, parent);

		    var TitleSize = DataTool.GetFontSize(values.Title.Text, 9);
		    var TitleLoca = new Point(LogoSize.Width + LogoLoca.X + 5, (MenuBarSize.Height - TitleSize.Height) / 2);

		    Control.Label(values.Bar, values.Title, TitleSize, TitleLoca, barBCol, Color.White, values.Title.Text, 1, 9);
		    Applies.ApplyDraggability(values.Title, parent);

		    var ButtonSize = new Size(65, barHeight);
		    var ButtonLoca = new Point(MenuBarSize.Width - ButtonSize.Width, 0);

		    if (values.Close)
		    {
			Control.Button(values.Bar, values.Button1, ButtonSize, ButtonLoca, barBCol, Color.White, 1, 10, "X");
			Applies.ApplyDraggability(values.Button1, parent);

			values.Button1.Click += (s, e) =>
			{
			    if (!values.Hide)
			    {
				Application.Exit();
				Environment.Exit(0);
			    }

			    else
			    {
				parent.Hide();
			    }
			};
		    }

		    if (values.Close && values.Minimize)
		    {
			ButtonLoca.X -= ButtonSize.Width;
		    }

		    else if (values.Minimize)
		    {
			Control.Button(values.Bar, values.Button2, ButtonSize, ButtonLoca, barBCol, Color.White, 1, 10, "-");
			Applies.ApplyDraggability(values.Button2, parent);

			values.Button2.Click += (s, e) =>
			{
			    parent.SendToBack();
			};
		    }

		    values.Button1.TextAlign = ContentAlignment.BottomCenter;

		    var RectangleSize = new Size(values.Width() - 3, values.parentHeight() - values.Height());
		    var RectangleLocation = new Point(1, values.Height() + values.Bar.Top - 2);

		    Transform.PaintRectangle(parent, 3, RectangleSize, RectangleLocation, borderBCol);
		}

		catch (Exception E)
		{
		    throw (ErrorHandler.GetException(E));
		}
	    }


	    public void UpdateTitle(string newValue, int fontSize = 8)
	    {
		try
		{
		    var newSize = DataTool.GetFontSize(newValue, fontSize);
		    var newLabelLoca = new Point(values.Title.Left, (values.Height() - newSize.Height) / 2);

		    values.setLocationOf(values.Title, newLabelLoca);
		    values.setTitle($"{newValue}");

		    Transform.Resize(values.Title, newSize);
		}

		catch (Exception E)
		{
		    throw (ErrorHandler.GetException(E));
		}
	    }


	    public void UpdateColor(Color newValue1, Color newValue2)
	    {
		try
		{
		    foreach (Control Control in values.getControls())
		    {
			values.setColorOf(Control, newValue1);
		    }

		    values.setLogoBackColor(values.getBarColor());
		    values.setBarBackColor(newValue1);

		    var RectSize = new Size(values.Width() - 4, values.parentHeight() - values.Height());
		    var RectLoca = new Point(2, values.Height() + values.Bar.Top - 3);

		    Transform.PaintRectangle(values.getParent(), 3, RectSize, RectLoca, newValue2);
		}

		catch (Exception E)
		{
		    throw (ErrorHandler.GetException(E));
		}
	    }
	}
    }
}
