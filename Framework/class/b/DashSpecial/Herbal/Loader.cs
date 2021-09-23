
// Author: Dashie


using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;

using DashFramework.NETExtensions;


namespace DashFramework
{
    namespace DashSpecial.Herbal
    {
	public struct WeedStrain
	{
	    public string StrainName;
	    public string Crossings;
	    public int Weeks;

	    public double IndicaContents;
	    public double SativaContents;
	    public double Price;

	    public bool Autoflower;
	    public bool Feminised;
	}
	
	public partial class Weeds
	{
	    string[] getFileContents()
	    {
		return File.ReadAllText("strains.dash").RemoveAll("(").ISplit(')');
	    }

	    public IEnumerable<object[]> TranslateHerbBlocks()
	    {
		string[] blocks = getFileContents();
		
		for (int k = 0; k < blocks.Length; k += 1)
		{
		    string[] sections = blocks[k].ISplit('\r','\n');
		    
		    for (int s = 0, l = 0; s < sections.Length; s += 1, l = 0)
		    {
			void Update(int i)
			{
			    l = i;
			}

			switch (s)
			{
			    case 0: Update(11); break;
			    case 1: Update(10); break;
			    case 2: Update(15); break;
			    case 3: Update(15); break;
			    case 4: Update(13); break;
			    case 5: Update(12); break;
			    case 6: Update(10); break;
			    case 7: Update(19); break;
			}

			if (l == 0)
			{
			    yield return null;
			    yield break;
			}

			sections[s] = sections[s].Remove(0, l);
			sections[s] = sections[s].StartsWith(" ")
			    ? sections[s].Remove(0, 1) : sections[s];
			
			if (sections.Length != 8)
			{
			    yield return null;
			    yield break;
			}

			yield return sections;
		    }
		}

		yield return null;
		yield break;
	    }

	    public WeedStrain[] GetStrains()
	    {
		List<WeedStrain> strains = new List<WeedStrain>();

		try
		{
		    if (!File.Exists("strains.dash"))
		    {
			return null;
		    }
		    
		    foreach (var block in TranslateHerbBlocks())
		    {
			strains.Add
			(
			    new WeedStrain()
			    {
				StrainName = block[0].ToString(),
				Crossings = block[1].ToString(),
				SativaContents = double.Parse(block[2].ToString()),
				IndicaContents = double.Parse(block[3].ToString()),
				Autoflower = bool.Parse(block[4].ToString()),
				Feminised = bool.Parse(block[5].ToString()),
				Price = double.Parse(block[6].ToString()),
				Weeks = int.Parse(block[7].ToString()),
			    }
			);
		    }
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