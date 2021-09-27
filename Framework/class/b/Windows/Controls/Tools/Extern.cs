
// Author: Dashie


using System;
using System.Diagnostics;

using DashFramework.Erroring;


namespace DashFramework
{
    namespace ControlTools
    {
	public class Extern
	{
	    public void StartProcess(string Path, bool UseShell = true, bool NoAppear = false)
	    {
		try
		{
		    using (Process proc = new Process())
		    {
			proc.StartInfo = new ProcessStartInfo()
			{
			    UseShellExecute = UseShell,
			    CreateNoWindow = !NoAppear,
			    FileName = Path,
			};

			proc.Start();
		    }
		}

		catch (Exception E)
		{
		    throw (ErrorHandler.GetException(E));
		}
	    }


	    public void OpenUrl(string Destination)
	    {
		try
		{
		    using (var Process = new Process())
		    {
			Process.StartInfo = new ProcessStartInfo()
			{
			    FileName = Destination,
			    UseShellExecute = true,
			};

			Process.Start();
		    }
		}

		catch (Exception E)
		{
		    throw (ErrorHandler.GetException(E));
		}
	    }
	}
    }
}