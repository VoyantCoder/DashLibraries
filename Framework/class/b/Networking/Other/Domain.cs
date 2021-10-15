
// Author: Dashie


using System.Linq;
using System.Collections.Generic;


namespace DashFramework
{
    namespace Networking
    {
        public partial class Network
        {
            public List<string> Blacklist = new List<string>()
        {
        ".edu", ".gov", ".govt", ".co.uk"
        };

            public bool Blacklisted(string IpUrl, bool Sensitive = false)
            {
                return Blacklist.Any(a => IpUrl.EndsWith(a) ||
                (Sensitive ? IpUrl.Contains(a) : IpUrl.EndsWith(a)));
            }
        }
    }
}
