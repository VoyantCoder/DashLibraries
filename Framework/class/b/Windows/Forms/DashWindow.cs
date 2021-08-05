// Sector Name:
// Author: Dashie


#pragma warning disable IDE1006


using System;
using System.Drawing;
using System.Windows.Forms;

using DashFramework.DashControls.Customs;
using DashFramework.ControlTools;
using DashFramework.Erroring;
using DashFramework.Data;

using DashFramework.resources;


namespace DashFramework
{
    namespace Forms
    {
	public class DashWindow : Form // Try to extend MenuBar instead.  Should be nicer to use. ;)
	{
	    readonly static Transformer Transform = new Transformer();
	    readonly static DataTools DataTool = new DataTools();

	    public class Values
	    {
		public DashMenuBar MenuBar = null;

		public Control.ControlCollection getControls() => MenuBar.values.getControls();
		public Control getParent() => MenuBar.values.getParent();
		public DashPanel getBar() => MenuBar.values.Bar;
		public Label getTitle() => MenuBar.values.Title;

		public Color getBarColor() => MenuBar.values.getBarColor();

		public void setLocationOf(Control me, Point to) => me.Location = to;
		public void setColorOf(Control me, Color to) => me.BackColor = to;
		public void setBarBackColor(Color to) => MenuBar.values.setBarBackColor(to);
		public void setTitle(string to) => MenuBar.values.setTitle(to);


		public PictureBox GetIconA() => MenuBar.values.LogoLayer1;
		public PictureBox GetIconB() => MenuBar.values.LogoLayer2;


		public void SetTitleLocation(Point to)
		{
		    try
		    {
			if (to.Y == -2)
			{
			    to.Y = (MenuBar.values.Bar.Height - MenuBar.values.Title.Height) / 2;
			}

			if (to.X == -2)
			{
			    to.X = (MenuBar.values.Bar.Width - MenuBar.values.Title.Width) / 2;
			}

			MenuBar.values.Title.Location = to;
		    }

		    catch (Exception E)
		    {
			throw (ErrorHandler.GetException(E));
		    }
		}


		public int parentHeight() => MenuBar.values.parentHeight();
		public int parentWidth() => MenuBar.values.parentWidth();
		public int Height() => MenuBar.values.Height();
		public int Width() => MenuBar.values.Width();


		public delegate void holder();

		public void onControlClick(int id, holder action)
		{
		    Control me = MenuBar.values.Button1;

		    if (id == 2) me = MenuBar.values.Button2;

		    me.Click += (s, e) =>
		    {
			action.Invoke();
		    };
		}


		public void HideIcons()
		{
		    MenuBar.values.LogoLayer1.Hide();
		    MenuBar.values.LogoLayer2.Hide();
		}


		public void HideTitle()
		{
		    MenuBar.values.Title.Hide();
		}


		public void CenterTitle() => MenuBar.values.Title.Location
		    = DataTool.GetCenterFor(MenuBar.values.Title, MenuBar.values.Bar);

		public void ResizeTitle(int FontSize, int Id = 1, bool CenterTitle = true)
		{
		    try
		    {
			MenuBar.values.Title.Font = new Font(MenuBar.values.Title
			    .Font.FontFamily, FontSize);

			Transform.Resize(MenuBar.values.Title, DataTool.GetFontSize(MenuBar
			    .values.Title.Text, FontSize, Id));

			if (CenterTitle) this.CenterTitle();
		    }

		    catch (Exception E)
		    {
			throw (ErrorHandler.GetException(E));
		    }
		}
	    }

	    public Values values = new Values();


	    private void InitS1(Size appSize, string appTitle, Color appBCol,
		FormStartPosition startPosition = FormStartPosition.CenterScreen, FormBorderStyle borderStyle = FormBorderStyle.None, int roundRadius = -1)
	    {
		try
		{
		    SuspendLayout();

		    MaximumSize = appSize;
		    MinimumSize = appSize;

		    FormBorderStyle = borderStyle;
		    StartPosition = startPosition;

		    BackColor = appBCol;
		    Icon = Resources.ICON;

		    Text = appTitle;
		    Name = appTitle;

		    if (roundRadius > 0)
		    {
			Transform.Round(this, roundRadius);
		    }
		}

		catch (Exception E)
		{
		    throw (ErrorHandler.GetException(E));
		}
	    }


	    private void InitS2(string appTitle, bool appMinim, bool appClose, bool appHide, Color barBCol)
	    {
		try
		{
		    values.MenuBar = new DashMenuBar(appTitle, appMinim, appClose, appHide);
		    values.MenuBar.AddMe(this, barBCol, barBCol);
		}

		catch (Exception E)
		{
		    throw (ErrorHandler.GetException(E));
		}
	    }


	    public void InitializeWindow(Size appSize, string appTitle, Color appBCol, Color barBCol,
		FormStartPosition startPosition = FormStartPosition.CenterScreen, FormBorderStyle borderStyle = FormBorderStyle.None,
		bool barMinim = false, bool barClose = true, bool hideApp = true, bool appMenuBar = true, int roundRadius = 8)
	    {
		try
		{
		    InitS1(appSize, appTitle, appBCol, startPosition, borderStyle, roundRadius);

		    if (appMenuBar)
		    {
			InitS2(appTitle, barMinim, barClose, hideApp, barBCol);
		    }
		}

		catch (Exception E)
		{
		    throw (ErrorHandler.GetException(E));
		}
	    }


	    private bool DoInitialize = true;

	    public void ShowWindow(Size appSize, string appTitle, Color appBCol, Color barBCol,
		FormStartPosition startPosition = FormStartPosition.CenterScreen, FormBorderStyle borderStyle = FormBorderStyle.None,
		bool showDialog = true, bool barMinim = false, bool barClose = true, bool closeHideApp = true, bool appMenuBar = true)
	    {
		try
		{
		    if (DoInitialize)
		    {
			InitializeWindow(appSize, appTitle, appBCol, barBCol, startPosition, borderStyle, barMinim, barClose, closeHideApp, appMenuBar);
			DoInitialize = false;
		    }

		    ShowAsIs(showDialog);
		}

		catch (Exception E)
		{
		    throw (ErrorHandler.GetException(E));
		}
	    }


	    public void ShowAsIs(bool showDialog = true)
	    {
		try
		{
		    if (showDialog)
		    {
			ShowDialog();
		    }

		    else
		    {
			Show();
		    }
		}

		catch (Exception E)
		{
		    throw (ErrorHandler.GetException(E));
		}
	    }
	}
    }
}