// Sector Name:
// Author: Dashie


#pragma warning disable IDE1006


using System;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

using DashFramework.DashResources;
using DashFramework.DashControls;
using DashFramework.Erroring;
using DashFramework.Data;


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

		    catch (Exception E)
		    {
			throw (ErrorHandler.GetException(E));
		    }
		}


		public Size TextBoxSize(Size Size, Point Loca, int Height = 21)
		{
		    try
		    {
			int Width = (TextBoxParent.Width - Loca.X - Size.Width);
			return new Size(Width, Height);
		    }

		    catch (Exception E)
		    {
			throw (ErrorHandler.GetException(E));
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

		    catch (Exception E)
		    {
			throw (ErrorHandler.GetException(E));
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

		    catch (Exception E)
		    {
			throw (ErrorHandler.GetException(E));
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

		    catch (Exception E)
		    {
			throw (ErrorHandler.GetException(E));
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

		    catch (Exception E)
		    {
			throw (ErrorHandler.GetException(E));
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

		    catch (Exception E)
		    {
			throw (ErrorHandler.GetException(E));
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

		    catch (Exception E)
		    {
			throw (ErrorHandler.GetException(E));
		    }
		}
	    }
	}


	public class Externalities
	{
	    public void StartProcess(string Path, bool UseShell = true, bool NoAppear = false)
	    {
		try
		{
		    using (Process proc = new Process())
		    {
			proc.StartInfo = new ProcessStartInfo()
			{
			    UseShellExecute = UseShell,
			    CreateNoWindow = !NoAppear,
			    FileName = Path,
			};

			proc.Start();
		    }
		}

		catch (Exception E)
		{
		    throw (ErrorHandler.GetException(E));
		}
	    }


	    public void OpenUrl(string Destination)
	    {
		try
		{
		    using (var Process = new Process())
		    {
			Process.StartInfo = new ProcessStartInfo()
			{
			    FileName = Destination,
			    UseShellExecute = true,
			};

			Process.Start();
		    }
		}

		catch (Exception E)
		{
		    throw (ErrorHandler.GetException(E));
		}
	    }
	}


	public class Transformer
	{
	    public void Resize(Control Object, Size Size)
	    {
		Object.MaximumSize = Size;
		Object.MinimumSize = Size;
		Object.Size = Size;
	    }


	    public void RoundContainerControls(Control container)
	    {
		try
		{
		    foreach (Control a1 in container.Controls)
		    {
			foreach (Control a2 in a1.Controls)
			{
			    Round(a2, 6);
			}

			Round(a1, 6);
		    }
		}

		catch (Exception E)
		{
		    throw (ErrorHandler.GetException(E));
		}
	    }


	    readonly ReadOnlyForm ReadForm = new ReadOnlyForm();
	    class ReadOnlyForm : System.Windows.Forms.Form
	    {
		public void PaintOwner(PaintEventArgs e)
		{
		    e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
		    base.OnPaint(e);
		}
	    }

	    public void Round(Control Object, int Radius)
	    {
		try
		{
		    Object.Paint += (s, e) =>
		    {
			try
			{
			    ReadForm.PaintOwner(e);

			    GraphicsPath GraphicsPath = new GraphicsPath();

			    var Rectangle = new Rectangle(0, 0, Object.Width, Object.Height);

			    int R = Radius * 3;

			    int H = Rectangle.Height;
			    int W = Rectangle.Width;

			    int X = Rectangle.X;
			    int Y = Rectangle.X;

			    GraphicsPath.AddArc(X, Y, R, R, 170, 90);
			    GraphicsPath.AddArc(X + W - R, Y, R, R, 270, 90);
			    GraphicsPath.AddArc(X + W - R, Y + H - R, R, R, 0, 90);
			    GraphicsPath.AddArc(X, Y + H - R, R, R, 80, 90);

			    Object.Region = new Region(GraphicsPath);
			}

			catch (Exception E)
			{
			    throw (ErrorHandler.GetException(E));
			}
		    };
		}

		catch (Exception E)
		{
		    throw (ErrorHandler.GetException(E));
		}
	    }


	    public void AddBorderTo(Control Con, int Ptw, Color BCol)
	    {
		try
		{
		    Size Size = new Size(Con.Width - 1, Con.Height - 1);
		    Point Loca = new Point(0, 0);

		    PaintRectangle(Con, Ptw, Size, Loca, BCol);
		}

		catch (Exception E)
		{
		    ErrorHandler.JustDoIt(E);
		}
	    }


	    public void PaintRectangle(Control Object, int Thickness, Size Size, Point Location, Color Color)
	    {
		Object.Paint += (s, e) =>
		{
		    var graphics = e.Graphics;

		    graphics.SmoothingMode = SmoothingMode.HighQuality;

		    using (Pen pen = new Pen(Color, Thickness))
		    {
			graphics.DrawRectangle(pen, new Rectangle(Location, Size));
		    };
		};
	    }


	    public void PaintLine(Control Object, Color Color, int Thickness, Point Location1, Point Location2)
	    {
		Object.Paint += (s, e) =>
		{
		    var graphics = e.Graphics;

		    graphics.SmoothingMode = SmoothingMode.HighQuality;

		    using (Pen pen = new Pen(Color, Thickness))
		    {
			graphics.DrawLine(pen, Location1, Location2);
		    };
		};
	    }


	    public void PaintCircle(Control Object, Color Color, int Thickness, Point Location, Size Size)
	    {
		Object.Paint += (s, e) =>
		{
		    var graphics = e.Graphics;

		    graphics.SmoothingMode = SmoothingMode.HighQuality;

		    using (Pen pen = new Pen(Color, Thickness))
		    {
			graphics.DrawEllipse(pen, new RectangleF(Location, Size));
		    };
		};
	    }
	}


	public class Apply
	{
	    public void ApplyDraggability(Control Object, Control Target)
	    {
		var Location = Point.Empty;

		Object.MouseMove += (s, e) =>
		{
		    if (Location.IsEmpty)
		    {
			return;
		    }

		    Target.Location = new Point(Target.Location.X + (e.X - Location.X),
			Target.Location.Y + (e.Y - Location.Y));
		};

		Object.MouseDown += (s, e) =>
		{
		    Location = new Point(e.X, e.Y);
		};

		Object.MouseUp += (s, e) =>
		{
		    Location = Point.Empty;
		};
	    }
	}


	public class DirectInteract
	{
	    readonly Externalities Extern = new Externalities();
	    public void SetUrl(Control Object, string Destination)
	    {
		try
		{
		    Object.Click += (s, e) =>
		    {
			try
			{
			    Extern.OpenUrl(Destination);
			}

			catch (Exception E)
			{
			    throw (ErrorHandler.GetException(E));
			}
		    };
		}

		catch (Exception E)
		{
		    throw (ErrorHandler.GetException(E));
		}
	    }


	    public delegate void Holder();
	    public void RegisterClickEvent(Control For, Holder This)
	    {
		try
		{
		    For.Click += (s, e) =>
		    {
			try
			{
			    This();
			}

			catch (Exception E)
			{
			    throw (ErrorHandler.GetException(E));
			}
		    };
		}

		catch (Exception E)
		{
		    throw (ErrorHandler.GetException(E));
		}
	    }


	    public void SetButtonColors(Button Bttn, Color OnHover, Color OnDown, Color OnLeave, Color RightNow)
	    {
		try
		{
		    void SetButtonColor(Color Color)
		    {
			Bttn.BackColor = Color;
		    }

		    Bttn.MouseHover += (s, e) => SetButtonColor(OnHover);
		    Bttn.MouseLeave += (s, e) => SetButtonColor(OnLeave);
		    Bttn.MouseDown += (s, e) => SetButtonColor(OnDown);
		    Bttn.FlatAppearance.MouseDownBackColor = OnDown;

		    SetButtonColor(RightNow);
		}

		catch (Exception E)
		{
		    throw (ErrorHandler.GetException(E));
		}
	    }


	    readonly ResourceTools ResourceTool = new ResourceTools();
	    public void SetTxtBoxContents(TextBox TxtBox, string such, bool isResource = false)
	    {
		try
		{
		    if (isResource)
		    {
			such = ResourceTool.GetStringFrom($"{such}");
		    }

		    TxtBox.Text = ($"{such}");
		}

		catch (Exception E)
		{
		    throw (ErrorHandler.GetException(E));
		}
	    }


	    public void SetDock(Control For, DockStyle DockStyle)
	    {
		try
		{
		    For.Dock = DockStyle;
		}

		catch (Exception E)
		{
		    throw (ErrorHandler.GetException(E));
		}
	    }


	    public void AlignContainerTextBoxes(Control container, HorizontalAlignment alignment)
	    {
		try
		{
		    foreach (Control a1 in container.Controls)
		    {
			foreach (Control a2 in a1.Controls)
			{
			    if (a2 is TextBox)
			    {
				((TextBox)a2).TextAlign = alignment;
			    }
			}
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