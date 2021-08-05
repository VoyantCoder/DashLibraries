// Author: Dashie
// Version: 1.0


using System;
using System.Drawing;
using System.Windows.Forms;

using DashFramework.DashControls.Customs;
using DashFramework.DashControls;
using DashFramework.Erroring;
using DashFramework.Forms;

namespace DashFramework
{
    public partial class MainGUI
    {

	public void Initiator(DashWindow inst)
	{
	    try
	    {
		// test framework components here.
	    }

	    catch (Exception E)
	    {
		ErrorHandler.GetException(E);
	    }
	}
    }
}
