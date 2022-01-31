
// Author: Dashie


using System;
using System.Collections.Generic;
using System.Text;


namespace FlamefulAssembly
{
    namespace Networking
    {
        public partial class Network
        {
            public partial class HttpServer
            {
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

                        int length = build.Length - 1;
                        return build.ToString().Substring(0, length);
                    }

                    catch
                    {
                        throw;
                    }
                }
            }
        }
    }
}