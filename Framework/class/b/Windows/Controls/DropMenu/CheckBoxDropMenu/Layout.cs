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

	    public partial class CBDropMenu
	    {
		public void SetColors(Color Color, params MenuBarColor[] AppliesTo)
		{
		    try
		    {
			// + Create a list and fill it with all the controls associated
			//   with their index, the items are iterated through.
			// 
			// + Based on index determine the mode to use.  Should be relatively
			//   easy to do.
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
