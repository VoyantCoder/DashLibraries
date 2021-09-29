  
// Author: Dashie


using System;
using DashFramework.Erroring;


namespace DashFramework
{
    namespace Sorters
    {
	public class GenericSorter<T> 
	{
	    public T Sort(string sectionName, Action code, bool throwException = false)
	    {
		try
		{
		    code();
		}

		catch
		{
		    if (throwException)
		    {
			throw;
		    }
		}
		return default(T);
	    }

	    public bool BSort(string sectionName, Action code, bool throwException = false)
	    {
		try
		{
		    code();
		}

		catch
		{
		    if (throwException)
		    {
			throw;
		    }

		    return false;
		}

		return true;
	    }
	}

	public class GenericSorter : GenericSorter<int>
	{
	    public new void Sort(string sectionName, Action code, bool throwException = false)
	    {
		try
		{
		    code();
		}

		catch
		{
		    if (throwException)
		    {
			throw;
		    }
		}
	    }
	}
    }
}