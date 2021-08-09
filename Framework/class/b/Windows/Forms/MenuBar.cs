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
using DashFramework.Sorters;
using DashFramework.Data;

using DashFramework.resources;


namespace DashFramework
{
    namespace Forms
    {
	public enum TitleLocation
	{
	    Top, Bottom, Right, Left,
	    TopMiddle, BottomMiddle, Center,
	    LeftMiddle, RightMiddle,
	}

	public enum IconLocation
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
	    readonly ControlIntegrator Integrator = new ControlIntegrator();
	    readonly Transformer Transform = new Transformer();
	    readonly Apply Appliance = new Apply();

	    readonly DashPanel Panel1 = new DashPanel();

	    public void ResizeMenuBar(Size NewSize)
	    {
		try
		{
		    if (!NewSize.Equals(Panel1.Size))
		    {
			Transform.Resize(Panel1, NewSize);
		    }
		}

		catch
		{
		    throw;
		}
	    }

	    public void SetDraggability()
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
	    readonly DataTools DataTool = new DataTools();
	    readonly Label Label1 = new Label();

	    public int FontPoints = 10;
	    public int FontTypeId = 1;

	    public void Integrate(Control Parent, Size BarSize, Point BarLoca, Color BarBColor, string TitleText, Color TitleFColor, TitleLocation TitleLoca)
	    {
		try
		{
		    Integrate(Parent, BarSize, BarLoca, BarBColor);

		    Size TitleSize = DataTool.GetFontSize(TitleText, FontPoints, FontTypeId);
		    Point TitlePosition = new Point(-2, -2);

		    int DetermineBottom()
		    {
			try
			{
			    return (Panel1.Height >= TitleSize.Height ? 0 : Panel1.Height - TitleSize.Height);
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

		    switch (TitleLoca)
		    {
			case TitleLocation.Top:
			{
			    TitlePosition.X = 0;
			    TitlePosition.Y = 0;
			    break;
			}

			case TitleLocation.TopMiddle:
			{
			    TitlePosition.Y = 0;
			    break;
			}

			case TitleLocation.Bottom:
			{
			    TitlePosition.Y = DetermineBottom();
			    TitlePosition.X = 0;
			    break;
			}

			case TitleLocation.BottomMiddle:
			{
			    TitlePosition.Y = DetermineBottom();
			    break;
			}

			case TitleLocation.Right:
			{
			    TitlePosition.X = DetermineRight();
			    TitlePosition.Y = 0;
			    break;
			}

			case TitleLocation.RightMiddle:
			{
			    TitlePosition.X = DetermineRight();
			    break;
			}

			case TitleLocation.Left:
			{
			    TitlePosition.X = 10;
			    TitlePosition.Y = 0;
			    break;
			}

			case TitleLocation.LeftMiddle:
			{
			    TitlePosition.X = 10;
			    break;
			}
		    }

		    Integrator.Label(Panel1, Label1, TitleSize, TitlePosition, Panel1.BackColor, TitleFColor, TitleText, FontTypeId, FontPoints);
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

	    public void Integrate(Control Parent, Size BarSize, Point BarLoca, Color BarBColor, string TitleText, Color TitleFColor, TitleLocation TitleLoca, Image Icon, IconLocation IconLoca)
	    {
		try
		{
		    Integrate(Parent, BarSize, BarLoca, BarBColor, TitleText, TitleFColor, TitleLoca);
		    
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

		    Point Icon1Position = new Point(-2, -2);

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

		    switch (IconLoca)
		    {
			case IconLocation.Top:
			{
			    Icon1Position.X = 0;
			    Icon1Position.Y = 0;
			    break;
			}

			case IconLocation.TopMiddle:
			{
			    Icon1Position.Y = 0;
			    break;
			}

			case IconLocation.Right:
			{
			    Icon1Position.X = Panel1.Width;
			    Icon1Position.Y = 0;
			    break;
			}

			case IconLocation.RightMiddle:
			{
			    Icon1Position.X = Panel1.Width;
			    break;
			}

			case IconLocation.Left:
			{
			    Icon1Position.Y = Icon1.Location.Y;
			    Icon1Position.X = 0;
			    MayRepositionTitle();
			    break;
			}

			case IconLocation.LeftMiddle:
			{
			    Icon1Position.X = 0;
			    MayRepositionTitle();
			    break;
			}

			case IconLocation.Bottom:
			{
			    Icon1Position.Y = DetermineBottom();
			    Icon1Position.X = 0;
			    break;
			}

			case IconLocation.BottomMiddle:
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

	    readonly PlainSorters Sorters = new PlainSorters();

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

	    public void Integrate(Control Parent, Size BarSize, Point BarLoca, Color BarBColor, string TitleText, Color TitleFColor, TitleLocation TitleLoca, Image Icon, IconLocation IconLoca, ButtonSet Buttons)
	    {
		try
		{
		    Integrate(Parent, BarSize, BarLoca, BarBColor, TitleText, TitleFColor, TitleLoca, Icon, IconLoca);

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
	}
    }
}