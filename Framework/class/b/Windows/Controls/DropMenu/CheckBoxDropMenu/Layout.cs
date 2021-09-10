// Author: Dashie
// Version: 1.0


using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using DashFramework.DashControls.Customs;
using DashFramework.DashControls;
using DashFramework.ControlTools;
using DashFramework.Sorters;
using DashFramework.Data;


namespace DashFramework
{
    namespace DashControls
    {
	namespace Customs
	{
	    public enum MenuBarColor
	    {
		LicensePlate = 0, License, Layer1, Layer2, Layer3,
		Layer4, CheckBoxBasis, CheckBoxOutter, CheckBoxInner
	    }

	    public enum MenuBarColorEvent
	    {
		Current, Hover, Leave, Enter, Up, Down
	    }

	    public partial class CBDropMenu
	    {
		public void SetEventColor(Color Color1, MenuBarColor Target, MenuBarColorEvent Event)
		{
		    try
		    {
			try
			{
			    List<Control> SpecifiedControls()
			    {
				IEnumerable<Control> Hook1()
				{
				    foreach (CheckBox CheckBox in DropMenuBoxes)
				    {
					yield return CheckBox.OutterHeadlight;
				    }
				}

				IEnumerable<Control> Hook2()
				{
				    foreach (CheckBox CheckBox in DropMenuBoxes)
				    {
					yield return CheckBox.InnerHeadlight;
				    }
				}

				IEnumerable<Control> Hook3()
				{
				    foreach (CheckBox CheckBox in DropMenuBoxes)
				    {
					yield return CheckBox.BasisHeadlight;
				    }
				}

				IEnumerable<Control> Hook4()
				{
				    foreach (Entry Item in DropMenuEntries)
				    {
					yield return Item.LicensePlate;
				    }
				}

				IEnumerable<Control> Hook5()
				{
				    foreach (Entry Item in DropMenuEntries)
				    {
					yield return Item.License;
				    }
				}

				List<Control> Controls = new List<Control>();

				void Add2(IEnumerable<Control> Adds) => Controls.AddRange(Adds);
				void Add1(params Control[] Adds) => Controls.AddRange(Adds);

				switch (Target)
				{
				    case MenuBarColor.CheckBoxOutter: Add2(Hook1()); break;
				    case MenuBarColor.CheckBoxInner: Add2(Hook2()); break;
				    case MenuBarColor.CheckBoxBasis: Add2(Hook3()); break;
				    case MenuBarColor.LicensePlate: Add2(Hook4()); break;
				    case MenuBarColor.License: Add2(Hook5()); break;
				    case MenuBarColor.Layer1: Add1(Layer1); break;
				    case MenuBarColor.Layer2: Add1(Layer2); break;
				    case MenuBarColor.Layer3: Add1(Layer3); break;
				}

				return Controls;
			    }

			    void Color(Control Control) => Control.BackColor = Color1;

			    foreach (Control Control in SpecifiedControls())
			    {
				switch (Event)
				{
				    case MenuBarColorEvent.Enter:
					Control.MouseEnter += 
					    (s, e) => Color(Control);
					break;
				    case MenuBarColorEvent.Hover:
					Control.MouseHover += 
					    (s, e) => Color(Control);
					break;
				    case MenuBarColorEvent.Leave:
					Control.MouseLeave += 
					    (s, e) => Color(Control);
					break;
				    case MenuBarColorEvent.Down:
					Control.MouseDown += 
					    (s, e) => Color(Control);
					break;
				    case MenuBarColorEvent.Up:
					Control.MouseUp += 
					    (s, e) => Color(Control);
					break;
				    case MenuBarColorEvent.Current:
					Color(Control);
					break;
				}
			    }
			}

			catch
			{
			    throw;
			}
		    }

		    catch
		    {
			throw;
		    }
		}

		public void SetColor(Color Color, Color Color2, params MenuBarColor[] Targets)
		{
		    try
		    {
			void Workout1()
			{
			    try
			    {
				foreach (CheckBox CheckBox in DropMenuBoxes)
				{
				    CheckBox.OutterHeadlight.BackColor = Color;
				}
			    }

			    catch
			    {
				throw;
			    }
			}

			void Workout2()
			{
			    try
			    {
				foreach (CheckBox CheckBox in DropMenuBoxes)
				{
				    CheckBox.InnerHeadlight.BackColor = Color;
				}
			    }

			    catch
			    {
				throw;
			    }
			}

			void Workout3()
			{
			    try
			    {
				foreach (CheckBox CheckBox in DropMenuBoxes)
				{
				    CheckBox.BasisHeadlight.BackColor = Color;
				}
			    }

			    catch
			    {
				throw;
			    }
			}

			void Workout4()
			{
			    try
			    {
				foreach (Entry Item in DropMenuEntries)
				{
				    Item.LicensePlate.BackColor = Color;
				}
			    }

			    catch
			    {
				throw;
			    }
			}

			void Workout5()
			{
			    try
			    {
				foreach (Entry Item in DropMenuEntries)
				{
				    Item.License.BackColor = Color;
				    Item.License.ForeColor = Color2;
				}
			    }

			    catch
			    {
				throw;
			    }
			}

			void Workout7(Control Control)
			{
			    try
			    {
				Control.BackColor = Color;
			    }

			    catch
			    {
				throw;
			    }
			}

			foreach (var Target in Targets)
			{
			    switch (Target)
			    {
				case MenuBarColor.CheckBoxOutter: Workout1(); break;
				case MenuBarColor.CheckBoxInner: Workout2(); break;
				case MenuBarColor.CheckBoxBasis: Workout3(); break;
				case MenuBarColor.Layer1: Workout7(Layer1); break;
				case MenuBarColor.Layer2: Workout7(Layer2); break;
				case MenuBarColor.Layer3: Workout7(Layer3); break;
				case MenuBarColor.LicensePlate: Workout4(); break;
				case MenuBarColor.License: Workout5(); break;
			    }
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
}
