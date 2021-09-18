
// Author: Dashie


using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;


namespace DashFramework
{
    namespace Data.Special
    {
	public partial class Specialities
	{
	    readonly Random Rand = new Random();

	    public int GetRandomInt(int min, int max)
	    {
		try
		{
		    return Rand.Next(min, max);
		}

		catch
		{
		    return 0000;
		}
	    }

	    public int GetRandomInt(int max)
	    {
		try
		{
		    return Rand.Next(max);
		}

		catch
		{
		    return 0000;
		}
	    }

	    public string RandomStringAlphabet =
	    (
		"abcdefghijklmnopqrstuvwxyz" +
		"ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
		"0123456789 "
	    );
	    
	    public string GetRandomString(int MinLength, int MaxLength)
	    {
		try
		{
		    int b = GetRandomInt(MinLength, MaxLength);
		    string a = RandomStringAlphabet;

		    return new string(Enumerable.Repeat(a, b).Select
			(entry => entry[GetRandomInt(entry.Length)]).ToArray());
		}

		catch
		{
		    return null;
		}
	    }
		
	    public string GetRandomString(int Length)
	    {
		try
		{
		    return GetRandomString(Length, Length + 1);
		}

		catch
		{
		    return null;
		}
	    }

	    public string GetRandomFileName(int Length)
	    {
		try
		{
		    return GetRandomString(Length);
		}

		catch
		{
		    return null;
		}
	    }

	    public string GetRandomFileName(int Length, string Extension)
	    {
		try
		{
		    return string.Format("{0}.{1}", 
			GetRandomFileName(Length), Extension);
		}

		catch
		{
		    return null;
		}
	    }

	    public string GetRandomFileName(int MinLength, int MaxLength)
	    {
		try
		{
		    return GetRandomString(MinLength, MaxLength);
		}

		catch
		{
		    return null;
		}
	    }

	    public string GetRandomDirPath(int Depth, int MinLength, int MaxLength, string Base = @"C:\")
	    {
		try
		{
		    if (Depth < 1 || !Directory.Exists(Base))
		    {
			return null;
		    }

		    else if (!Base.EndsWith(@"\"))
		    {
			Base += @"\";
		    }

		    StringBuilder build = new StringBuilder();

		    build.Append(string.Format(Base));

		    for (int k = 0; k <= Depth; k += 1)
		    {
			string name = GetRandomString(MinLength, MaxLength);
			build.Append(string.Format(@"{0}\", name));
		    }

		    return build.ToString();
		}

		catch
		{
		    return null;
		}
	    }

	    public string GetRandomDirPath(int Depth, string Base = @"C:\")
	    {
		try
		{
		    return GetRandomDirPath(Depth, 2, 10, Base);
		}

		catch
		{
		    return null;
		}
	    }
	}
    }
}