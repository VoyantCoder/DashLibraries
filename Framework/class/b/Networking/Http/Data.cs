
// Author: Dashie


using System;
using System.Text;
using System.Collections.Generic;


namespace DashFramework
{
    namespace Networking
    {
	public partial class Network
	{
	    public partial class HttpServer
	    {
		// Summary:
		//  random user-agent generation
		readonly Random rand = new Random();

		int Random(int Range)
		{
		    try
		    {
			return rand.Next(Range);
		    }

		    catch
		    {
			throw;
		    }
		}

		readonly List<string> browserNames = new List<string>()// perhaps do not hard code it?
		{
		    "Mozilla", "Chrome", "Safari", "DashBrowser", "Netscape",
		    "Internet Explorer", "Comodo Browser", "Opera", "Brave",
		    "Luminator", "Whale", "Dragon", "Maxthon", "Coc Coc", "Samsung Browser",
		    "ChromePlus", "TaoBrowser", "Konqueror", "Opera Mini",
		    "Opera Mobile", "AOL", "Lunascape", "ValveSource", "ValveSteam"
		};

		public string RandomBrowser()
		{
		    string a = browserNames[Random(browserNames.Count)];
		    int b = Random(100);
		    int c = Random(65);
		    return ($"{a}/{b}.{c}");
		}

		readonly List<string> OSNames = new List<string>()
		{
		    "BackBox", "ParrotOS", "Parrot", "Kali", "Backtrack",
		    "Windows", "iOS", "Apple", "someos", "doesnotmatter",
		    "whatthenameis", "Lubuntu", "Slack", "Gentoo", "Linux Mint",
		    "Linux", "Kali Linux", "CentOS", "Fedora", "Red Hat", 
		    "Debian"
		};

		public string RandomOSName()
		{
		    try
		    {
			return $"({OSNames[Random(OSNames.Count)]})";
		    }

		    catch
		    {
			throw;
		    }
		}
		
		public string RandomWebKit()
		{
		    try
		    {
			return $"AppleWebKit/{Random(100)}";
		    }

		    catch
		    {
			throw;
		    }
		}

		public string GetRandomUA()
		{
		    try
		    {
			string browser = RandomBrowser() + " ";
			string osname = RandomOSName() + " ";
			string webkit = RandomWebKit() + " ";
			string prefix = "(HTML, Like Gecko) ";

			StringBuilder build = new StringBuilder();

			build.Append(browser);
			build.Append(osname);
			build.Append(webkit);
			build.Append(prefix);

			return build.ToString();
		    }

		    catch
		    {
			throw;
		    }
		}	
	    }

	    public partial class HttpServer
	    {
		// Summary:
		//  random header generation
	    }
	}

	// Random Header Gen -- generates a random header
	// Header Generator -- generates a header based on options set
	// SendHttpHeader -- sends http header and gets the response return value
	// Header Validator -- validates given headers using local server
	//UAT: Mozilla/5.0 (Windows NT 6.3; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.83 Safari/537.36
    }
}