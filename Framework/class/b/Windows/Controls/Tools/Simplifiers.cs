
// Author: Dashie


using System;
using System.Drawing;
using System.Windows.Forms;

using DashFramework.DashResources;
using DashFramework.DashControls;
using DashFramework.Erroring;


namespace DashFramework
{
    namespace ControlTools
    {
	public class Simplifiers
	{
	    public class AshamedClass//I spit on it.
	    {
		readonly ControlIntegrator Control = new ControlIntegrator();
		public Control TextBoxParent = new Control();

		public Color TextBoxBCol = Color.FromArgb(28, 28, 28);
		public Color TextBoxFCol = Color.White;

		public void AddTextBox(TextBox TextBox, Size Size, Point Loca, string Text, int FontHeight = 8)
		{
		    try
		    {
			TextBox.TextAlign = HorizontalAlignment.Center;
			TextBox.Text = (Text);

			Control.TextBox(TextBoxParent, TextBox, Size, Loca, TextBoxBCol, TextBoxFCol, 1, FontHeight);
		    }

		    catch
		    {
			throw;
		    }
		}


		public Size TextBoxSize(Size Size, Point Loca, int Height = 21)
		{
		    try
		    {
			int Width = (TextBoxParent.Width - Loca.X - Size.Width);
			return new Size(Width, Height);
		    }

		    catch
		    {
			throw;
		    }
		}


		public Control LabelParent = new Control();

		public Color LabelBCol = Color.FromArgb(28, 28, 28);
		public Color LabelFCol = Color.White;

		public void AddLabel(Label Label, Size Size, Point Loca, string Text, int FontHeight = 10)
		{
		    try
		    {
			Control.Label(LabelParent, Label, Size, Loca, LabelBCol, LabelFCol, Text, 1, FontHeight);
		    }

		    catch
		    {
			throw;
		    }
		}


		readonly ResourceTools ResourceTool = new ResourceTools();
		public Size GetFontSize(string Text, int FontHeight = 10)
		{
		    try
		    {
			Font Font = ResourceTool.GetFont(1, FontHeight);
			return TextRenderer.MeasureText(Text, Font);
		    }

		    catch
		    {
			throw;
		    }
		}


		public Point ControlX(Size Size, Point Loca, int Y = -1, int Extra = 0)
		{
		    try
		    {
			int X = (Size.Width + Loca.X + Extra);

			if (Y == -1)
			    Y = Loca.Y;

			return new Point(X, Y);
		    }

		    catch
		    {
			throw;
		    }
		}
	    }


	    public class Quickify
	    {
		readonly ControlIntegrator Controls = new ControlIntegrator();
		readonly Transformer Transform = new Transformer();
		readonly DataTools DataTool = new DataTools();

		public enum ValueType
		{
		    Parent = 0, FCol, BCol, Fpts,
		    Fid, Size, Mline, Sbar, Ronly,
		    Brdr, Fixs
		};

		public enum Module
		{
		    Label = 0, Button, TextBox
		};

		public void SetValue(Module For, ValueType Type, object With)
		{
		    switch ((int)For)
		    {
			case 0:
			{
			    switch ((int)Type)
			    {
				case 0: LblParent = (Control)With; break;
				case 1: LblFCol = (Color)With; break;
				case 2: LblBCol = (Color)With; break;
				case 3: LblFpts = (int)With; break;
				case 4: LblFid = (int)With; break;
			    }

			    break;
			}

			case 1:
			{
			    switch ((int)Type)
			    {
				case 0: BttnParent = (Button)With; break;
				case 9: BttnBorder = (bool)With; break;
				case 1: BttnFCol = (Color)With; break;
				case 2: BttnBCol = (Color)With; break;
				case 5: BttnSize = (Size)With; break;
				case 3: BttnFpts = (int)With; break;
				case 4: BttnFid = (int)With; break;
			    }

			    break;
			}

			case 2:
			{
			    switch ((int)Type)
			    {
				case 0: TxtboxParent = (Control)With; break;
				case 9: TxtboxBorder = (bool)With; break;
				case 1: TxtboxFCol = (Color)With; break;
				case 2: TxtboxBCol = (Color)With; break;
				case 5: TxtboxSize = (Size)With; break;
				case 10: FixedSize = (bool)With; break;
				case 3: TxtboxFpts = (int)With; break;
				case 6: Multiline = (bool)With; break;
				case 7: Scrollbar = (bool)With; break;
				case 4: TxtboxFid = (int)With; break;
				case 8: Readonly = (bool)With; break;
			    }

			    break;
			}
		    }
		}


		public Control BttnParent = null;
		public Color BttnBCol = Color.Black;
		public Color BttnFCol = Color.White;
		public Size BttnSize = Size.Empty;
		public bool BttnBorder = true;
		public int BttnFpts = 8;
		public int BttnFid = 1;

		public void QuickButton(Button button, string text, Point loca, Control parent = null)
		{
		    parent = parent == null ? BttnParent : parent;

		    try
		    {
			Controls.Button(parent, button, BttnSize,
			    loca, BttnBCol, BttnFCol, BttnFid, BttnFpts, text);

			if (BttnBorder) Transform.Round(button, 6);
		    }

		    catch
		    {
			throw;
		    }
		}


		public Control TxtboxParent = null;
		public Color TxtboxBCol = Color.Black;
		public Color TxtboxFCol = Color.White;
		public Size TxtboxSize = Size.Empty;
		public bool TxtboxBorder = true;
		public bool Multiline = false;
		public bool Scrollbar = false;
		public bool FixedSize = true;
		public bool Readonly = true;
		public int TxtboxFpts = 8;
		public int TxtboxFid = 1;

		public void QuickTxtBox(TextBox txtbox, string text, Point loca, Control parent = null)
		{
		    parent = parent == null ? TxtboxParent : parent;

		    try
		    {
			Controls.TextBox(parent, txtbox, TxtboxSize, loca, TxtboxBCol,
			    TxtboxFCol, TxtboxFpts, TxtboxFid, Readonly, Multiline, Scrollbar, FixedSize);

			if (TxtboxBorder)
			    Transform.Round(txtbox.Parent is
				PictureBox ? txtbox.Parent : txtbox, 6);
		    }

		    catch
		    {
			throw;
		    }
		}


		public Control LblParent = null;
		public Color LblBCol = Color.Black;
		public Color LblFCol = Color.White;
		public int LblFpts = 8;
		public int LblFid = 1;

		public void QuickLabel(Label label, string text, Point loca, Control parent = null)
		{
		    parent = parent == null ? LblParent : parent;

		    try
		    {
			Size lblSize = DataTool.GetFontSize(text, LblFpts, LblFid);

			Controls.Label(parent, label, lblSize, loca, LblBCol,
			    LblFCol, text, LblFid, LblFpts);
		    }

		    catch
		    {
			throw;
		    }
		}
	    }
	}
    }
}