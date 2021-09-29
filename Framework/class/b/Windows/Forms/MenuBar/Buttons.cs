
// Author: Dashie


using System;
using System.Drawing;
using System.Windows.Forms;


namespace DashFramework
{
    namespace Forms
    {
	public partial class MenuBar
	{
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
			    Sort.Sort(("Close Button Resizing"), () =>
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
			    Sort.Sort(("Close/Min Button Resizing"), () =>
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
			    Sort.Sort(("Custom Button Resizing"), () =>
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

	    public void SetButtonHook(ButtonSet Button, Action Hook, int Index = -1)
	    {
		try
		{
		    void Hook1()
		    {
			try
			{
			    Sort.Sort(("On Close"), () =>
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
			    Sort.Sort(("On Minimize & Close"), () =>
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
			    Sort.Sort(("On Custom"), () =>
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
				Sort.Sort(("On Hover"), () =>
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
				Sort.Sort(("On Down"), () =>
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
				Sort.Sort(("On Click"), () =>
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
		    Sort.Sort(("Top Call"), () =>
		    {
			Integrate(Parent, BarSize, BarLoca, BarBColor, TitleText, TitleFColor, TitlePos, Icon, IconPos);
		    });

		    Sort.Sort(("Button Integration"), () =>
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
				Sort.Sort(("Close Button"), () =>
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
				Sort.Sort(("Close & Minimize Buttons"), () =>
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
				Sort.Sort(("Custom Button(s)"), () =>
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
	}
    }
}