//
// Author: Dashie

#pragma warning disable IDE1006

using System;
using System.Net;
using System.Net.Sockets;


namespace FlamefulAssembly
{
    namespace Networking
    {
        public partial class Network
        {
            public int GetInt(string str)
            {
                try
                {
                    return int.Parse(str);
                }

                catch
                {
                    return -1;
                }
            }

            public int MaxDuration = int.MaxValue;

            public bool IsDuration(string str)
            {
                try
                {
                    return GetInt(str) > 0 && GetInt(str) <= MaxDuration;
                }

                catch
                {
                    return false;
                }
            }

            public bool IsDuration(int duration)
            {
                try
                {
                    return duration > 0 && duration < MaxDuration;
                }

                catch
                {
                    return false;
                }
            }

            public bool IsPort(string str)
            {
                try
                {
                    return (GetInt(str) > 0 && GetInt(str) < 65535);
                }

                catch
                {
                    return false;
                }
            }

            public bool IsByte(string str)
            {
                try
                {
                    return GetInt(str) > 0;
                }

                catch
                {
                    return false;
                }
            }

            public bool IsIp(string str)
            {
                try
                {
                    return IPAddress.TryParse(str, out _);
                }

                catch
                {
                    return false;
                }
            }

            public string DefaultProtocol = "http";

            public IPAddress GetIp(string str)
            {
                try
                {
                    string lower = str.ToLower();

                    if (!IPAddress.TryParse(lower, out IPAddress IP))
                    {
                        if (!lower.StartsWith("https://") && !lower.StartsWith("http://"))
                        {
                            lower = $"{DefaultProtocol}://{lower}";
                        }

                        if (Uri.TryCreate(lower, UriKind.RelativeOrAbsolute, out Uri url))
                        {
                            try
                            {
                                lower = Dns.GetHostAddresses(url.Host)[0].ToString();
                            }

                            catch
                            {
                                return null;
                            }
                        }

                        return IPAddress.Parse(lower);
                    }

                    return IP;
                }

                catch
                {
                    return null;
                }
            }

            public bool HasIp(string str)
            {
                try
                {
                    return GetIp(str) != null;
                }

                catch
                {
                    return false;
                }
            }

            public AddressFamily GetAddrFam(string str)
            {
                try
                {
                    if (IsIp(str))
                    {
                        return IPAddress.Parse(str).AddressFamily;
                    }

                    return default(AddressFamily);
                }

                catch
                {
                    return default(AddressFamily);
                }
            }
        }
    }
}

