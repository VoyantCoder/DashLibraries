// Sector Name:
// Author: Dashie


#pragma warning disable IDE1006


using System;
using System.Threading;
using System.Windows.Forms;

using DashFramework.Erroring;


namespace DashFramework
{
    namespace Runnables
    {
	public class Runnable
	{
	    public delegate void RunnableHolder();


	    public void RunTaskAsynchronously(Control parent, RunnableHolder execute)
	    {
		try
		{
		    new Thread(() =>
		    {
			if (parent != null)
			{
			    parent.Invoke
			    (
				new MethodInvoker
				(
				    () =>
				    {
					try
					{
					    execute();
					}

					catch (Exception E)
					{
					    throw (ErrorHandler.GetException(E));
					}
				    }
				)
			    );
			}

			else
			{
			    execute();
			}
		    })

		    { IsBackground = true }.Start();
		}

		catch (Exception E)
		{
		    throw (ErrorHandler.GetException(E));
		}
	    }


	    public void RunTaskSynchronously(Control parent, RunnableHolder execute)
	    {
		try
		{
		    parent.Invoke(new MethodInvoker(() =>
		    {
			try
			{
			    execute();
			}

			catch (Exception E)
			{
			    throw (ErrorHandler.GetException(E));
			}
		    }));
		}

		catch (Exception E)
		{
		    throw (ErrorHandler.GetException(E));
		}
	    }


	    public void RunTaskLater(Control parent, RunnableHolder execute, int startWhen, bool autoReset = false)
	    {
		try
		{
		    System.Timers.Timer timer = new System.Timers.Timer();

		    timer.Elapsed += (s, e) =>
		    {
			execute();
		    };

		    timer.AutoReset = autoReset;
		    timer.Interval = startWhen;
		    timer.Enabled = true;
		    timer.Start();
		}

		catch (Exception E)
		{
		    throw ErrorHandler.GetException(E);
		}
	    }


	    public void RunTaskLaterAsynchronously(Control parent, RunnableHolder execute, int startWhen, bool autoReset = false)
	    {
		try
		{
		    System.Timers.Timer timer = new System.Timers.Timer();

		    timer.Elapsed += (s, e) =>
		    {
			new Thread(() =>
			{
			    if (parent != null)
			    {
				parent.Invoke
				(
				    new MethodInvoker
				    (
					() =>
					{
					    try
					    {
						execute();
					    }

					    catch (Exception E)
					    {
						throw (ErrorHandler.GetException(E));
					    }
					}
				    )
				);
			    }

			    else
			    {
				execute();
			    }
			})

			{ IsBackground = true }.Start();
		    };

		    timer.AutoReset = autoReset;
		    timer.Interval = startWhen;
		    timer.Enabled = true;
		    timer.Start();
		}

		catch (Exception E)
		{
		    throw ErrorHandler.GetException(E);
		}
	    }
	}
    }
}