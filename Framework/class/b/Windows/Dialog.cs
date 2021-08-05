// Sector Name:
// Author: Dashie


#pragma warning disable IDE1006


using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using DashFramework.DashControls.Customs;
using DashFramework.DashControls;
using DashFramework.ControlTools;
using DashFramework.Erroring;
using DashFramework.Forms;
using DashFramework.Data;


namespace DashFramework
{
    namespace Dialogs
    {
	namespace Dialog
	{
	    public class DashDialog
	    {
		readonly ControlIntegrator Control = new ControlIntegrator();
		readonly Transformer Transform = new Transformer();
		readonly DataTools DataTool = new DataTools();
		readonly Apply Application = new Apply();

		public DashWindow Dialog = new DashWindow();

		public void InitS1(Size DialogSize, string Title, Color DialogBCol)
		{
		    try
		    {
			if (Dialog.Controls.Count < 1)
			{
			    Dialog = new DashWindow();
			}

			Dialog.InitializeWindow(DialogSize, Title, DialogBCol, Color.Empty,
			    appMenuBar: false, startPosition: FormStartPosition.CenterParent);

			Application.ApplyDraggability(Dialog, Dialog);
		    }

		    catch (Exception E)
		    {
			throw (ErrorHandler.GetException(E));
		    }
		}


		public readonly DashPanel S2Container1 = new DashPanel();
		public readonly DashPanel S2Container2 = new DashPanel();
		public readonly TextBox S2TextBox1 = new TextBox();
		public readonly Button S2Button1 = new Button();
		public readonly Button S2Button2 = new Button();
		public readonly Label S2Label1 = new Label();

		private int S2ButtonID = 0;

		public void InitS2(Color DialogFCol, string Description, string Title, Buttons DialogButtons)
		{
		    try
		    {
			var LabelLoca = new Point(-2, 12);

			Control.Label(Dialog, S2Label1, Size.Empty, LabelLoca, Dialog.BackColor, DialogFCol, Title, 1, 10);

			var Container1Size = new Size(Dialog.Width - 20, Dialog.Height - (S2Label1.Height + 68));
			var Container1Loca = new Point(10, S2Label1.Height + S2Label1.Top + 10);
			var Container1BCol = Dialog.BackColor;

			Control.Panel(Dialog, S2Container1, Container1Size, Container1Loca, Container1BCol);
			Transform.Round(S2Container1, 6);

			var TextBoxSize = DataTool.ResizeSize(Container1Size, 8, 8, false);
			var TextBoxLoca = new Point(4, 4);

			Control.TextBox(S2Container1, S2TextBox1, TextBoxSize, TextBoxLoca, Container1BCol, DialogFCol, 1, 8, true, true, true, false);
			S2TextBox1.Text = Description;

			var Container2Loca = new Point(Container1Loca.X, Container1Size.Height + Container1Loca.Y + 10);
			var Container2Size = new Size(Container1Size.Width, 24);

			Control.Panel(Dialog, S2Container2, Container2Size, Container2Loca, Container1BCol);

			string[] Texts = new string[] { "Okay", "" };

			void Action1()
			{
			    Texts[1] = ("Cancel");
			}

			void Action2()
			{
			    Texts[0] = ("Yes");
			    Texts[1] = ("No");
			}

			switch (DialogButtons)
			{
			    case Buttons.OKCancel: Action1(); break;
			    case Buttons.YesNo: Action2(); break;
			}

			var ButtonObjects = new List<Button>() { S2Button1 };

			if (Texts[1].Length > 0)
			{
			    ButtonObjects.Add(S2Button2);
			}

			var ButtonSize = new Size((Container2Size.Width / 2) - 30, 24);
			var ButtonBCol = Color.MidnightBlue;

			Point ButtonStartPoint()
			{
			    if (ButtonObjects.Count <= 1)
			    {
				return new Point((Container2Size.Width - ButtonSize.Width) / 2);
			    }

			    return new Point(10);
			};

			var ButtonLoca = ButtonStartPoint();

			for (int k = 0; k < ButtonObjects.Count; k += 1)
			{
			    if (k >= 1)
			    {
				ButtonLoca.X = (Container2Size.Width - ButtonSize.Width - 10);
			    }

			    Control.Button(S2Container2, ButtonObjects[k], ButtonSize, ButtonLoca,
				ButtonBCol, DialogFCol, 1, 9, Texts[k]);
			}

			S2Button1.Click += (s, e) =>
			{
			    S2ButtonID = 0;
			    Dialog.Hide();
			};

			S2Button2.Click += (s, e) =>
			{
			    S2ButtonID = 1;
			    Dialog.Hide();
			};
		    }

		    catch (Exception E)
		    {
			throw (ErrorHandler.GetException(E));
		    }
		}


		public enum Buttons { OKCancel, YesNo, OK };

		public int Show(Color DialogBCol, Color DialogFCol, Size DialogSize, string Description, string Title, Buttons DialogButtons = Buttons.OK)
		{
		    try
		    {
			if (DialogSize == Size.Empty)
			{
			    DialogSize = new Size(350, 350);
			}

			InitS1(DialogSize, Title, DialogBCol);
			InitS2(DialogFCol, Description, Title, DialogButtons);

			Dialog.ShowAsIs();

			return S2ButtonID;
		    }

		    catch (Exception E)
		    {
			MessageBox.Show(ErrorHandler.GetRawFormat(E));
			throw (ErrorHandler.GetException(E));
		    }
		}


		public int Show()
		{
		    try
		    {
			Dialog.ShowAsIs();
			return S2ButtonID;
		    }

		    catch (Exception E)
		    {
			throw (ErrorHandler.GetException(E));
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

	    // Auto Update Ideology:
	    // - When parent GUI moves update added dialog
	    // - Old Dialog Location on Screen
	    // - Update it by changed value of Parent
	    // - If changed value is higher than old +
	    // - If changed value is lower than old -
	}
    }
}