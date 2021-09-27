  
// Author: Dashie


using System;
using DashFramework.Erroring;


namespace DashFramework
{
    namespace Sorters
    {
	public class PlainSorters
	{
	    public delegate void VoidRun();//SORTER CLASS

	    public void SortCode(string Tag, VoidRun runThis)
	    {
		try
		{
		    runThis();
		}

		catch (Exception E)
		{
		    ErrorHandler.JustDoIt(E);
		}
	    }


	    public delegate bool BooleanRun();

	    public bool SortBooleanCode(string Tag, BooleanRun runThis)
	    {
		try
		{
		    return runThis();
		}

		catch
		{
		    return false;
		}
	    }//
	}
    }
}