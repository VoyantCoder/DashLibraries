// Sector Name:
// Author: Dashie


#pragma warning disable IDE1006


using System.Drawing;
using System.Windows.Forms;


namespace DashFramework
{
    namespace DashControls.Controls
    {
	public partial class DashCheckBox
	{
	    public void UpdateColor(Color[] CheckBox = null, Color[] MarkBox = null, bool UpdateNow = true, string Order = ("Unchecked, Checked, Default"))
	    {
		try
		{
		    if (CheckBox != null && CheckBox.Length > 2)
		    {
			CheckBoxUncheckColor = CheckBox[0];
			CheckBoxCheckColor = CheckBox[1];
			CheckBoxDefaultColor = CheckBox[2];

			if (UpdateNow)
			{
			    Panel2.BackColor = CheckBoxDefaultColor;
			}
		    }

		    if (MarkBox != null && MarkBox.Length > 2)
		    {
			MarkBoxUncheckedColor = MarkBox[0];
			MarkBoxCheckedColor = MarkBox[1];
			MarkBoxDefaultColor = MarkBox[2];

			if (UpdateNow)
			{
			    Panel1.BackColor = MarkBoxDefaultColor;
			}
		    }
		}

		catch
		{
		    throw;
		}
	    }

	    public void UpdateSize(Size A, Size B)
	    {
		try
		{
		    CheckBoxHeight = A.Height;
		    CheckBoxWidth = A.Width;

		    MarkBoxHeight = B.Height;
		    MarkBoxWidth = B.Width;

		    Transform.Resize(Panel1, A);
		    Transform.Resize(Panel2, B);
		}

		catch
		{
		    throw;
		}
	    }
	    
	    public void UpdateLocation(Point Location)
	    {
		try
		{
		    if (!Panel1.Location.Equals(Location))
		    {
			Panel1.Location = Location;
		    }
		}

		catch
		{
		    throw;
		}
	    }
	    
	    public void AddCheckBox(Control Parent, Point Location, bool Round = false, int RoundRadius = 12)
	    {
		Sorter.SortCode(("Containers"), () =>
		{
		    Size Panel1Size = new Size(CheckBoxWidth, CheckBoxHeight);
		    Size Panel2Size = new Size(MarkBoxWidth, MarkBoxHeight);
		    Point Panel2Loca = new Point(-1, -1);
		    Point Panel1Loca = Location;

		    Integrate.Panel(Parent, Panel1, Panel1Size, Panel1Loca, CheckBoxDefaultColor);
		    Integrate.Panel(Panel1, Panel2, Panel2Size, Panel2Loca, MarkBoxDefaultColor);

		    if (Round)
		    {
			Transform.Round(Panel1, RoundRadius);
			Transform.Round(Panel2, RoundRadius);
		    }
		});

		Sorter.SortCode(("Hook Handler Setup"), () =>
		{
		    void CheckBoxEvent()
		    {
			try
			{
			    if (Panel2.BackColor.Equals(MarkBoxCheckedColor))
			    {
				Panel2.BackColor = (MarkBoxUncheckedColor);
				Panel1.BackColor = (CheckBoxUncheckColor);

				OnCheck();
			    }

			    else
			    {
				Panel2.BackColor = (MarkBoxCheckedColor);
				Panel1.BackColor = (CheckBoxCheckColor);

				OnUncheck();
			    }
			}

			catch
			{
			    throw;
			}
		    }

		    Panel1.Click += (s, e) => CheckBoxEvent();
		    Panel2.Click += (s, e) => CheckBoxEvent();
		});
	    }
	}
    }
}