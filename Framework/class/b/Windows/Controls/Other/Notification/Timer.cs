
// Author: Dashie


using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

using DashFramework.Runnables;


namespace DashFramework
{
    namespace DashControls.Controls
    {
	public partial class Notification
	{
	    readonly System.Timers.Timer timer = new System.Timers.Timer() { AutoReset = false, Enabled = false, };
	    readonly Runnable runnable = new Runnable();

	    public void EnableAppearanceTimer(int Delay)
	    {
		try
		{   
		    if (timer.Enabled)
		    {
			timer.Enabled = false;
		    }

		    timer.Elapsed += (s, e) =>
		    {
			try
			{
			    new Thread(() =>
			    {
				try
				{
				    void sync(Action Code)
				    {
					try
					{
					    runnable.RunTaskSynchronously(Panel1.Parent, () =>
					    {
						Code();
					    });
					}

					catch
					{
					    throw;
					}
				    }

				    void recolor(Control control, int alpha)
				    {
					try
					{
					    Color color = Color.FromArgb
					    (
						alpha,
						backColor.R,
						backColor.G,
						backColor.B
					    );

					    sync(() => control.BackColor = color);
					}

					catch
					{
					    throw;
					}
				    }

				    for (int a = 255; a >= 30; a -= 5)
				    {//Slow, why?  Idek
					recolor(Panel1, a);
					recolor(Label1, a);
					recolor(Label2, a);
					
					Thread.Sleep(50);
				    }
				    
				    sync(() => Panel1.Hide());

				    recolor(Panel1, 254);
				    recolor(Label1, 254);
				    recolor(Label2, 254);
				}

				catch
				{
				    throw;
				};

				timer.Enabled = false;
			    })

			    { IsBackground = true }.Start();
			}

			catch
			{
			    throw;
			}
		    };

		    timer.Interval = Delay;
		    timer.Enabled = true;

		    Panel1.VisibleChanged += (s, e) =>
		    {
			try
			{
			    if (Panel1.Visible)
			    {
				timer.Start();
			    }
			}

			catch
			{
			    throw;
			}
		    };
		}

		catch
		{
		    throw;
		}
	    }
	}
    }
}