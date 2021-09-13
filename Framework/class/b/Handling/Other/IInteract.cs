// Sector Name:
// Author: Dashie


#pragma warning disable IDE1006


using System;
using System.Reflection;
using System.Diagnostics;
using System.Windows.Forms;
using System.Security.Principal;

using DashFramework.ControlTools;
using DashFramework.Erroring;


namespace DashFramework
{
    namespace DashInteract
    {
	public class CurrentInstance
	{
	    public bool IsAdministrator() => new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
	    public bool IsRunning(string ProcessName) => Process.GetProcessesByName(ProcessName).Length > 1;
	    public string GetFilePath() => Assembly.GetExecutingAssembly().Location;


	    public void Restart()
	    {
		Start();
		Close();
	    }

	    public void Close()
	    {
		Application.Exit();
	    }


	    readonly Externalities Externality = new Externalities();
	    public void Start()
	    {
		try
		{
		    Externality.StartProcess(GetFilePath());
		}

		catch (Exception E)
		{
		    ErrorHandler.JustDoIt(E);
		}
	    }
	}
    }
}