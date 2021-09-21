// Sector Name:
// Author: Dashie


#pragma warning disable IDE1006


using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using DashFramework.DashControls.Controls;
using DashFramework.DashResources;
using DashFramework.DashControls;
using DashFramework.ControlTools;
using DashFramework.Sorters;


namespace DashFramework
{
    namespace Forms
    {
	public enum TitlePosition
	{
	    Top, Bottom, Right, Left,
	    TopMiddle, BottomMiddle, Center,
	    LeftMiddle, RightMiddle,
	}

	public enum IconPosition
	{
	    Top, Bottom, Right, Left,
	    TopMiddle, BottomMiddle, Center,
	    LeftMiddle, RightMiddle
	}

	public enum ButtonSet
	{
	    Close, CloseMinimize, Custom
	}


	public class MenuBar
	{
	    readonly Transformer Transform = new Transformer();
	    readonly DashPanel Panel1 = new DashPanel();

	    public bool HasMenubarBeenAdded()
	    {
		return Panel1.Parent != null;
	    }

	    public void SetMenubarSize(Size NewSize)
	    {
		try
		{
		    if (Panel1.Parent != null)
		    {
			if (!NewSize.Equals(Panel1.Size))
			{
			    Transform.Resize(Panel1, NewSize);
			}
		    }
		}

		catch
		{
		    throw;
		}
	    }

	    public Size GetMenubarSize()
	    {
		try
		{
		    if (Panel1.Size != null)
		    {
			return Panel1.Size;
		    }

		    return Size.Empty;
		}

		catch
		{
		    throw;
		}
	    }

	    public Point GetMenubarLocation()
	    {
		try
		{
		    if (Panel1.Location != null)
		    {
			return Panel1.Location;
		    }

		    return Point.Empty;
		}

		catch
		{
		    throw;
		}
	    }

	    readonly Apply Appliance = new Apply();

	    public void SetMenubarDraggability()
	    {
		try
		{
		    if (Panel1.Parent != null)
		    {
			void Apply(Control ToMe)
			{
			    Appliance.ApplyDraggability(ToMe, Panel1.Parent);
			}

			foreach (Control A in Panel1.Controls)
			{
			    foreach (Control B in A.Controls)
			    {
				Apply(B);
			    }

			    Apply(A);
			}

			Apply(Panel1);
		    }
		}

		catch
		{
		    throw;
		}
	    }

	    readonly ControlIntegrator Integrator = new ControlIntegrator();

	    public void Integrate(Control Parent, Size BarSize, Point BarLoca, Color BarBColor)
	    {
		try
		{
		    BarLoca.Y = (BarLoca.Y == -1 ? (Parent.Height - BarSize.Height) / 2 : BarLoca.Y);
		    BarLoca.X = (BarLoca.X == -1 ? (Parent.Width - BarSize.Width) / 2 : BarLoca.X);

		    Integrator.Panel(Parent, Panel1, BarSize, BarLoca, BarBColor);
		}

		catch
		{
		    throw;
		}
	    }


	    // Title Integration:
	    readonly ResourceTools ResourceTool = new ResourceTools();
	    readonly Label Label1 = new Label();

	    public int FontPoints = 10;
	    public int FontTypeId = 1;

	    public void SetTitleFont(int FontPoints, int FontTypeId)
	    {
		try
		{
		    Font TitleFont = ResourceTool.GetFont(FontTypeId, FontPoints);

		    if (TitleFont != null)
		    {
			this.FontPoints = FontPoints;
			this.FontTypeId = FontTypeId;

			Label1.Font = TitleFont;
		    }
		}

		catch
		{
		    throw;
		}
	    }

	    public TitlePosition ExTitlePosition = TitlePosition.Center;

	    public void UpdateTitlePosition()
	    {
		try
		{
		    Label1.Location = GetTitlePosition(ExTitlePosition);
		}

		catch
		{
		    throw;
		}
	    }

	    public void SetTitleSize(int FontPoints)
	    {
		try
		{
		    Label1.Size = DataTool.GetFontSize(Label1.Text, FontPoints, FontTypeId);
		    Label1.Font = new Font(Label1.Font.FontFamily, FontPoints);

		    UpdateTitlePosition();
		}

		catch
		{
		    throw;
		}
	    }

	    readonly DataTools DataTool = new DataTools();
	    
	    public Point GetTitlePosition(TitlePosition TitlePos, string TitleText = ".")
	    {
		try
		{
		    if (TitleText.Equals("."))
		    {
			TitleText = Label1.Text;
		    }

		    Size TitleSize = DataTool.GetFontSize(TitleText, FontPoints, FontTypeId);

		    int DetermineBottom()
		    {
			try
			{
			    if (Panel1.Height <= TitleSize.Height)
			    {
				return Panel1.Height - TitleSize.Height;
			    }

			    else
			    {
				return 0;
			    }
			}

			catch
			{
			    throw;
			}
		    }

		    int DetermineRight()
		    {
			try
			{
			    return (Panel1.Width - TitleSize.Width);
			}

			catch
			{
			    throw;
			}
		    }

		    Point TitleLocation = new Point(-1, -1);

		    switch (TitlePos)
		    {
			case TitlePosition.Top:
			{
			    TitleLocation.X = 0;
			    TitleLocation.Y = 0;
			    break;
			}

			case TitlePosition.TopMiddle:
			{
			    TitleLocation.Y = 0;
			    break;
			}

			case TitlePosition.Bottom:
			{
			    TitleLocation.Y = DetermineBottom();
			    TitleLocation.X = 0;
			    break;
			}

			case TitlePosition.BottomMiddle:
			{
			    TitleLocation.Y = DetermineBottom();
			    break;
			}

			case TitlePosition.Right:
			{
			    TitleLocation.X = DetermineRight();
			    TitleLocation.Y = 0;
			    break;
			}

			case TitlePosition.RightMiddle:
			{
			    TitleLocation.X = DetermineRight();
			    break;
			}

			case TitlePosition.Left:
			{
			    TitleLocation.X = 10;
			    TitleLocation.Y = 0;
			    break;
			}

			case TitlePosition.LeftMiddle:
			{
			    TitleLocation.X = 10;
			    break;
			}
		    }

		    return TitleLocation;
		}

		catch
		{
		    throw;
		}
	    }
	    
	    public void SetTitlePosition(TitlePosition Position)
	    {
		try
		{
		    Label1.Location = GetTitlePosition(Position);
		}

		catch
		{
		    throw;
		}
	    }

	    public void SetTitleLocation(Point Location)
	    {
		try
		{
		    if (Location.X == -1 || Location.Y == -1)
		    {
			if (Location.Y == -1)
			{
			    Location.Y = (Panel1.Height - Label1.Height) / 2;
			}

			if (Location.X == -1)
			{
			    Location.X = (Panel1.Width - Label1.Width) / 2;
			}
		    }

		    Label1.Location = Location;
		}

		catch
		{
		    throw;
		}
	    }

	    public void SetTitleBackColor(Color Color)
	    {
		try
		{
		    Label1.BackColor = Color;
		}

		catch
		{
		    throw;
		}
	    }

	    public void SetTitleForeColor(Color Color)
	    {
		try
		{
		    Label1.ForeColor = Color;
		}

		catch
		{
		    throw;
		}
	    }

	    readonly PlainSorters Sorters = new PlainSorters();

	    public void Integrate(Control Parent, Size BarSize, Point BarLoca, Color BarBColor, string TitleText, Color TitleFColor, TitlePosition TitleLoca)
	    {
		try
		{
		    Sorters.SortCode(("Top Call"), () =>
		    {
			Integrate(Parent, BarSize, BarLoca, BarBColor);
		    });

		    Sorters.SortCode(("Label Integration"), () =>
		    {
			Size TitleSize = DataTool.GetFontSize(TitleText, FontPoints, FontTypeId);
			Point TitlePosition = GetTitlePosition(TitleLoca, TitleText);

			Integrator.Label(Panel1, Label1, TitleSize, TitlePosition, 
			    Panel1.BackColor, TitleFColor, TitleText, FontTypeId, FontPoints);

			ExTitlePosition = TitleLoca;
		    });
		}

		catch
		{
		    throw;
		}
	    }


	    // Icon Integration:
	    readonly PictureBox Icon1 = new PictureBox();
	    readonly PictureBox Icon2 = new PictureBox();

	    public void UpdateIconLayers()
	    {
		try
		{
		    if (Icon2.Parent.BackColor.Equals(Icon2.BackColor))
		    {
			if (Icon2.Parent != null)
			{
			    Icon2.BackColor = Icon2.Parent.BackColor;
			}

			Icon2.BringToFront();
		    }
		}

		catch
		{
		    throw;
		}
	    }

	    public void Integrate(Control Parent, Size BarSize, Point BarLoca, Color BarBColor, string TitleText, Color TitleFColor, TitlePosition TitlePos, Image Icon, IconPosition IconPos)
	    {
		try
		{
		    Integrate(Parent, BarSize, BarLoca, BarBColor, TitleText, TitleFColor, TitlePos);
		    
		    int DetermineBottom()
		    {
			try
			{
			    if (Panel1.Height <= Icon.Height)
			    {
				return Panel1.Height - Icon.Height;
			    }

			    else
			    {
				return 0;
			    }
			}

			catch
			{
			    throw;
			}
		    }

		    Point Icon1Position = new Point(-1, -1);

		    void MayRepositionTitle()
		    {
			try
			{
			    if (Label1.Left <= 10)
			    {
				Label1.Left = 10 + Icon.Width + Icon1Position.X;
			    }
			}

			catch
			{
			    throw;
			}
		    }

		    switch (IconPos)
		    {
			case IconPosition.Top:
			{
			    Icon1Position.X = 0;
			    Icon1Position.Y = 0;
			    break;
			}

			case IconPosition.TopMiddle:
			{
			    Icon1Position.Y = 0;
			    break;
			}

			case IconPosition.Right:
			{
			    Icon1Position.X = Panel1.Width;
			    Icon1Position.Y = 0;
			    break;
			}

			case IconPosition.RightMiddle:
			{
			    Icon1Position.X = Panel1.Width;
			    break;
			}

			case IconPosition.Left:
			{
			    Icon1Position.Y = Icon1.Location.Y;
			    Icon1Position.X = 0;
			    MayRepositionTitle();
			    break;
			}

			case IconPosition.LeftMiddle:
			{
			    Icon1Position.X = 0;
			    MayRepositionTitle();
			    break;
			}

			case IconPosition.Bottom:
			{
			    Icon1Position.Y = DetermineBottom();
			    Icon1Position.X = 0;
			    break;
			}

			case IconPosition.BottomMiddle:
			{
			    Icon1Position.Y = DetermineBottom();
			    break;
			}
		    }
		    
		    if (Icon.Height <= Panel1.Height)
		    {
			Icon2.Visible = false;
		    }

		    Color IconBackColor = Panel1.BackColor;
		    Integrator.Image(Panel1, Icon1, Icon.Size, Icon1Position, IconBackColor, Icon);

		    Point Icon2Position = new Point(Icon1Position.X, Icon1.Top);
		    Integrator.Image(Panel1.Parent, Icon2, Icon.Size, Icon2Position, IconBackColor, Icon);
		}

		catch
		{
		    throw;
		}
	    }
	    

	    // Button Integration:
	    readonly List<Button> CustomButtons = new List<Button>();

	    public void AddCustomButtons(bool Cleanup = false, params Button[] Buttons)
	    {
		try
		{
		    if (Cleanup)
		    {
			CustomButtons.Clear();
		    }

		    CustomButtons.AddRange(Buttons);
		}

		catch
		{
		    throw;
		}
	    }

	    readonly Button Button1 = new Button();
	    readonly Button Button2 = new Button();
	    
	    public void ResizeButton(ButtonSet Button, Size[] Size)
	    {
		try
		{
		    if (Size.Length < 1)
		    {
			return;
		    }

		    void Hook1()
		    {
			try
			{
			    Sorters.SortCode(("Close Button Resizing"), () =>
			    {
				Button1.Left = Panel1.Width - Size[0].Width;
				Transform.Resize(Button1, Size[0]);
			    });
			}

			catch
			{
			    throw;
			}
		    }

		    void Hook2()
		    {
			try
			{
			    Sorters.SortCode(("Close/Min Button Resizing"), () =>
			    {
				Button2.Left = Panel1.Width - (Size[0].Width * 2);
				Button1.Left = Panel1.Width - (Size[0].Width);

				Transform.Resize(Button1, Size[0]);
				Transform.Resize(Button2, Size[0]);
			    });
			}

			catch
			{
			    throw;
			}
		    }

		    void Hook3()
		    {
			try
			{
			    Sorters.SortCode(("Custom Button Resizing"), () =>
			    {
				if (CustomButtons.Count < Size.Length)
				{
				    return;
				}

				for (int k = 0; k < Size.Length; k += 1)
				{
				    Transform.Resize(CustomButtons[k], Size[k]);
				}
			    });
			}

			catch
			{
			    throw;
			}
		    }

		    switch (Button)
		    {
			case ButtonSet.CloseMinimize: Hook2(); break;
			case ButtonSet.Custom: Hook3(); break;
			case ButtonSet.Close: Hook1(); break;
		    }
		}

		catch
		{
		    throw;
		}
	    }

	    public void ResizeButton(ButtonSet Button, Size Size)
	    {
		try
		{
		    ResizeButton(Button, new Size[] { Size });
		}

		catch
		{
		    throw;
		}
	    }

	    public void SetButtonLocation(ButtonSet Button, Point[] Loca)
	    {
		try
		{
		    if (Loca.Length < 1)
		    {
			return;
		    }

		    void SetCustomButtonLocation()
		    {
			if (Loca.Length > CustomButtons.Count)
			{
			    return;
			}

			for (int k = 0; k < Loca.Length; k += 1)
			{
			    CustomButtons[k].Location = Loca[k];
			}
		    }

		    switch (Button)
		    {
			case ButtonSet.Custom: SetCustomButtonLocation(); break;
			case ButtonSet.Close: Button1.Location = Loca[0]; break;

			case ButtonSet.CloseMinimize:
			{
			    Button1.Location = Loca[0];
			    Button2.Location = Loca[1];
			    break;
			}
		    }
		}

		catch
		{
		    throw;
		}
	    }

	    public void SetButtonLocation(ButtonSet Button, Point Loca)
	    {
		try
		{
		    if (Loca.X == -1 || Loca.Y == -1)
		    {
			if (Loca.Y == -1)
			{
			    Loca.Y = (Panel1.Height - Button1.Height) / 2;
			}

			if (Loca.X == -1)
			{
			    Loca.X = (Panel1.Width - Button1.Width) / 2;
			}
		    }

		    SetButtonLocation(Button, new Point[] { Loca });
		}

		catch
		{
		    throw;
		}
	    }

	    public void ResetExistingButtons()
	    {
		try
		{
		    if (Button1 == null || Button1.Parent == null)
		    {
			return;
		    }

		    for (int k = Button1.Parent.Controls.Count; k > 0; k -= 1)
		    {
			if (Button1.Parent.Controls[k] is Button)
			{
			    Button1.Parent.Controls.RemoveAt(k);
			}
		    }
		}

		catch
		{
		    throw;
		}
	    }

	    public delegate void ButtonHook();

	    public void SetButtonHook(ButtonSet Button, ButtonHook Hook, int Index = -1)
	    {
		try
		{
		    void Hook1()
		    {
			try
			{
			    Sorters.SortCode(("On Close"), () =>
			    {
				Button1.Click += (s, e) =>
				{
				    try
				    {
					Hook();
				    }

				    catch
				    {
					throw;
				    }
				};
			    });
			}

			catch
			{
			    throw;
			}
		    }

		    void Hook2()
		    {
			try
			{
			    Sorters.SortCode(("On Minimize & Close"), () =>
			    {
				Button2.Click += (s, e) =>
				{
				    try
				    {
					Hook();
				    }

				    catch
				    {
					throw;
				    }
				};
			    });
			}

			catch
			{
			    throw;
			}
		    }

		    void Hook3()
		    {
			try
			{
			    Sorters.SortCode(("On Custom"), () =>
			    {
				if (CustomButtons.Count >= Index && Index > -1)
				{
				    return;
				}

				else if (Index == -0)
				{
				    foreach (Button button in CustomButtons)
				    {
					button.Click += (s, e) =>
					{
					    Hook();
					};
				    }
				}

				else
				{
				    CustomButtons[Index].Click += (s, e) =>
				    {
					try
					{
					    Hook();
					}

					catch
					{
					    throw;
					}
				    };
				}
			    });
			}

			catch
			{
			    throw;
			}
		    }

		    switch (Button)
		    {
			case ButtonSet.CloseMinimize: Hook2(); goto Close;
			case ButtonSet.Close: Close: Hook1(); break;
			case ButtonSet.Custom: Hook3(); break;
		    }
		}

		catch
		{
		    throw;
		}
	    }

	    public void SetButtonColors(Color[] OnHover, Color[] OnDown, Color[] OnClick, string info = "[0=default,1=new]")
	    {
		try
		{
		    void RegisterColorHook(int id)
		    {
			void SetColor(Control Cntrl, Color Color)
			{
			    try
			    {
				Cntrl.BackColor = Color;
			    }

			    catch
			    {
				throw;
			    }
			}

			void Hook1(Control Cntrl)
			{
			    try
			    {
				Sorters.SortCode(("On Hover"), () =>
				{
				    Cntrl.MouseEnter += (s, e) => SetColor(Cntrl, OnHover[1]);
				    Cntrl.MouseHover += (s, e) => SetColor(Cntrl, OnHover[1]);
				    Cntrl.MouseLeave += (s, e) => SetColor(Cntrl, OnHover[0]);
				});
			    }

			    catch
			    {
				throw;
			    }
			}

			void Hook2(Control Cntrl)
			{
			    try
			    {
				Sorters.SortCode(("On Down"), () =>
				{
				    Cntrl.MouseDown += (s, e) => SetColor(Cntrl, OnDown[1]);
				    Cntrl.MouseUp += (s, e) => SetColor(Cntrl, OnDown[0]);
				});
			    }

			    catch
			    {
				throw;
			    }
			}

			void Hook3(Control Cntrl)
			{
			    try
			    {
				Sorters.SortCode(("On Click"), () =>
				{
				    Cntrl.MouseClick += (s, e) => SetColor(Cntrl, OnDown[1]);
				    Cntrl.MouseDown += (s, e) => SetColor(Cntrl, OnDown[0]);
				});
			    }

			    catch
			    {
				throw;
			    }
			}

			foreach (Control Cntrl in Panel1.Controls)
			{
			    if (Cntrl.GetType() == typeof(Button))
			    {
				switch (id)
				{
				    case 0: Hook1(Cntrl); break;
				    case 1: Hook2(Cntrl); break;
				    case 2: Hook3(Cntrl); break;
				}
			    }
			}
		    }

		    if (OnHover != null && OnHover.Length >= 2)
			RegisterColorHook(0);

		    if (OnClick != null && OnClick.Length >= 2)
			RegisterColorHook(2);
		
		    if (OnDown != null && OnDown.Length >= 2)
			RegisterColorHook(1);
		}

		catch
		{
		    throw;
		}
	    }

	    public virtual void DefaultCloseHook()
	    {
		try
		{
		    if (Panel1.Parent != null)
		    {
			if (Panel1.Parent is Form)
			{
			    ((Form)Panel1.Parent).Close();
			}

			else
			{
			    Panel1.Parent.Hide();
			}
		    }
		}

		catch
		{
		    throw;
		}
	    }

	    public virtual void DefaultMinimizeHook()
	    {
		try
		{
		    if (Panel1.Parent != null)
		    {
			Panel1.Parent.SendToBack();
		    }
		}

		catch
		{
		    throw;
		}
	    }

	    public void Integrate(Control Parent, Size BarSize, Point BarLoca, Color BarBColor, string TitleText, Color TitleFColor, TitlePosition TitlePos, Image Icon, IconPosition IconPos, ButtonSet Buttons)
	    {
		try
		{
		    Sorters.SortCode(("Top Call"), () =>
		    {
			Integrate(Parent, BarSize, BarLoca, BarBColor, TitleText, TitleFColor, TitlePos, Icon, IconPos);
		    });

		    Sorters.SortCode(("Button Integration"), () =>
		    {
			void OptionalRepositioning()
			{
			    try
			    {
				if (Label1.Left >= (Panel1.Width - Label1.Width - 10))
				{
				    if (Button1.Parent != null && Button2.Parent != null)
				    {
					Label1.Left = Panel1.Width - (Button1.Width * 2);
				    }

				    else if (Button1.Parent != null)
				    {
					Label1.Left = Panel1.Width - Button1.Width;
				    }

				    Label1.Left -= Label1.Width + 10;
				}

				else if (Icon1.Left >= Panel1.Width - 10)
				{
				    if (Button1.Parent != null && Button2.Parent != null)
				    {
					Icon1.Left = Panel1.Width - (Button1.Width * 2);
				    }

				    else if (Button1.Parent != null)
				    {
					Icon1.Left = Panel1.Width - Button1.Width;
				    }

				    Icon1.Left -= Icon1.Width;
				    Icon2.Left = Icon1.Left;
				}
			    }

			    catch
			    {
				throw;
			    }
			}

			void Hook1()
			{
			    try
			    {
				Sorters.SortCode(("Close Button"), () =>
				{
				    ResetExistingButtons();

				    Size ButtonSize = new Size(75, Panel1.Height);
				    Point ButtonLoca = new Point(Panel1.Width - 75, 0);

				    Integrator.Button(Panel1, Button1, ButtonSize, ButtonLoca,
					BarBColor, TitleFColor, FontTypeId, FontPoints, "X");

				    Button1.Click += (s, e) => DefaultCloseHook();
				});
			    }

			    catch
			    {
				throw;
			    }
			}

			void Hook2()
			{
			    try
			    {
				Sorters.SortCode(("Close & Minimize Buttons"), () =>
				{
				    Size ButtonSize = new Size(75, Panel1.Height);
				    Point ButtonLoca = new Point(Panel1.Width - 150, 0);

				    Integrator.Button(Panel1, Button2, ButtonSize, ButtonLoca,
					BarBColor, TitleFColor, FontTypeId, FontPoints, "-");

				    Button2.Click += (s, e) => DefaultMinimizeHook();

				    Hook1();
				});
			    }

			    catch
			    {
				throw;
			    }
			}

			void Hook3()
			{
			    try
			    {
				Sorters.SortCode(("Custom Button(s)"), () =>
				{
				    ResetExistingButtons();

				    for (int k = 0; k < CustomButtons.Count; k += 1)
				    {
					Panel1.Controls.Add(CustomButtons[k]);
				    }
				});
			    }

			    catch
			    {
				throw;
			    }
			}

			switch (Buttons)
			{
			    case ButtonSet.CloseMinimize:
			    {
				Hook2();
				OptionalRepositioning();
				break;
			    }

			    case ButtonSet.Close:
			    {
				Hook1();
				OptionalRepositioning();
				break;
			    }

			    case ButtonSet.Custom:
			    {
				Hook3();
				break;
			    }
			}
		    });
		}

		catch
		{
		    throw;
		}
	    }


	    // Bordering:
	    public int BorderRadius = 8;

	    public void SetMenuBarBorder()
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


	    // Obtainers:
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
	}
    }
}