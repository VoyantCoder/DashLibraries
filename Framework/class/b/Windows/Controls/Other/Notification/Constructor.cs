﻿
// Author: Dashie


using System.Timers;


namespace DashFramework
{
    namespace DashControls.Controls
    {
	public partial class Notification
	{
	    readonly Timer timer = new Timer();

	    public Notification()
	    {
		timer.AutoReset = false;
		timer.Enabled = false;
	    }
	}
    }
}