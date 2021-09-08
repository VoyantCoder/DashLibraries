// Author: Dashie

using System;
using System.Threading;

namespace DashFramework
{
    namespace Threading
    {
	public class InsertyThread
	{
	    Thread MainThread = default(Thread);
	    Action Code = default(Action);

	    delegate void ThreadRunnable();

	    void InsertCode(Action Code)
	    {
		try
		{
		    this.Code = Code;
		}

		catch
		{
		    throw;
		}
	    }

	    void StartThread(Action Optional = default(Action))
	    {
		try
		{
		    MainThread = new Thread(() =>
		    {
			try
			{
			    if (Optional != default(Action))
			    {
				Code();
			    }

			    do
			    {
				if (Code != default(Action))
				{
				    Code.Invoke();
				    Code = default(Action);
				}
			    }

			    while (true);
			}

			catch
			{
			    throw;
			}
		    });

		    MainThread.Start();
		}

		catch
		{
		    throw;
		}
	    }

	    public InsertyThread(Action Code) => StartThread(Code);
	    public InsertyThread() => StartThread();
	}
    }
}