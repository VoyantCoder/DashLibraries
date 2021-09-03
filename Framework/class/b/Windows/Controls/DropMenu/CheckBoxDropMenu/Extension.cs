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
	    public partial class CBDropMenu
	    {
		public void Show(bool force = false)
		{
		    try
		    {
			if (Layer1.Visible)
			{
			    if (!force)
			    {
				return;
			    }
			}

			Layer1.Show();
			Layer1.BringToFront();
		    }

		    catch
		    {
			throw;
		    }
		}

		public void Hide(bool force = false)
		{
		    try
		    {
			if (!Layer1.Visible)
			{
			    if (!force)
			    {
				return;
			    }
			}

			Layer1.Hide();
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
