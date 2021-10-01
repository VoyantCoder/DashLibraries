
// Author: Dashie


using System.Drawing;
using System.Windows.Forms;


namespace DashFramework
{
    namespace ControlTools.Simplifiers
    {
	public partial class Quickify
	{
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

	    public void QuickButton(Button button, string text, Point loca, Control parent = null)
	    {
		parent = parent == null ? BttnParent : parent;

		try
		{
		    Controls.Button(parent, button, BttnSize,
			loca, BttnBCol, BttnFCol, text, BttnFid, BttnFpts);

		    if (BttnBorder) Transform.Round(button, 6);
		}

		catch
		{
		    throw;
		}
	    }

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