
// Author: Dashie


using System;
using System.Collections.Generic;


namespace DashFramework
{
    namespace DashSpecial.Herbal
    {
	public struct WeedStrain
	{
	    public string StrainName;
	    public int Weeks;

	    public double IndicaContents;
	    public double SativaContents;
	    public double Price;

	    public bool Autoflower;
	    public bool Feminised;
	}

	public partial class Weeds
	{
	    public WeedStrain[] GetStrains()
	    {
		List<WeedStrain> strains = new List<WeedStrain>();

		try
		{
		    // Configuration file processing
		}

		catch
		{
		    throw;
		}

		return strains.ToArray();
	    }
	}
    }
}