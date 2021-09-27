
// Author: Dashie


using System;
using System.Windows.Forms;

using DashFramework.ControlTools;


namespace DashFramework
{
    namespace NETExtensions
    {
	public static class ControlExtension
	{
	    readonly static Extern ext = new Extern();

	    public static void SetUrl(this Control control, string dest)
	    {
		try
		{
		    control.Click += (s, e) =>
		    {
			try
			{
			    ext.OpenUrl(dest);
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


	    public static void RegisterClickEvent(this Control control, Action code)
	    {
		try
		{
		    control.Click += (s, e) =>
		    {
			try
			{
			    code();
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