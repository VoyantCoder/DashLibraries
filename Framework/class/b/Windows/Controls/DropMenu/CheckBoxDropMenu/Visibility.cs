// Author: Dashie


using System;
using System.Windows.Forms;
using System.Collections.Generic;


namespace DashFramework
{
    namespace DashControls
    {
	namespace Customs
	{
	    public partial class CBDropMenu
	    {
		public void SetVisibilityTrigger(bool Show, params Control[] Objects)
		{
		    try
		    {
			foreach (Control Object in Objects)
			{
			    if (Show) Object.Enter += (s, e) => this.Show();
			    else Object.Enter += (s, e) => Hide();
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