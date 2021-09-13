
// Author: Dashie


using System;
using System.IO;
using System.Collections.Generic;

using DashFramework.Erroring;


namespace DashFramework
{
    namespace Data
    {

	public class Values
	{
	    // List Related:
	    public List<string> GetLineIf(string file, string contains)
	    {
		try
		{
		    var lines = new List<string>();

		    if (!File.Exists(file))
		    {
			return null;
		    }

		    foreach (string line in File.ReadAllLines(file))
		    {
			if (line.IndexOf(contains, StringComparison.OrdinalIgnoreCase) >= 0)
			{
			    lines.Add(line);
			}
		    }

		    return lines;
		}

		catch (Exception E)
		{
		    throw (ErrorHandler.GetException(E));
		}
	    }


	    public List<object> ListRemove(List<object> obj, object criteria)
	    {
		try
		{
		    for (int id = 0; id < obj.Count; id += 1)
		    {
			if (obj[id] == criteria)
			{
			    obj.RemoveAt(id);
			}
		    }

		    return obj;
		}

		catch (Exception E)
		{
		    throw (ErrorHandler.GetException(E));
		}
	    }


	    // String etc Related:
	    public bool ArrayContains(object obj, object[] arr)
	    {
		for (int k = 0; k < arr.Length; k += 1)
		    if (arr[k] != obj && !arr[k].Equals(obj))
			return false;
		return true;
	    }


	    public string Replace(string obj, string to, params string[] wha)
	    {
		try
		{
		    foreach (string criteria in wha)
		    {
			obj = obj.ToLower().Replace(criteria
			    .ToLower(), $@"{to}");
		    }

		    return obj;
		}

		catch (Exception E)
		{
		    throw (ErrorHandler.GetException(E));
		}
	    }


	    public bool IsAnyNull(params object[] targets)
	    {
		foreach (object target in targets)
		    if (target == null)
			return true;
		return false;
	    }
	}
    }
}