
// Author: Dashie


using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;


namespace FlamefulAssembly
{
    namespace Networking
    {
        public partial class Network
        {
            public partial class PortScanner : Network
            {
                public IEnumerable<(int, bool)> ScanPorts(string host, int[] ports, PSFormatType PortFormatType, int timeout = 1000)
                {
                    (int, bool) exit = (-1, false);

                    if (DoCheckAddressFormat)
                    {
                        if (!IsIp(host))
                        {
                            yield return exit;
                            yield break;
                        }
                    }

                    if (DoCheckTimeout)
                    {
                        if (!IsDuration(timeout))
                        {
                            yield return exit;
                            yield break;
                        }
                    }

                    if (DoCheckPortFormat)
                    {
                        if (ports == null || ports.Length < 1)
                        {
                            yield return exit;
                            yield break;
                        }
                    }

                    switch (PortFormatType)
                    {
                        case PSFormatType.Specific://specific
                            foreach (var value in Hook1())
                                yield return value;
                            break;
                        case PSFormatType.Ranged://range
                            foreach (var value in Hook2())
                                yield return value;
                            break;
                        case PSFormatType.Singular://single
                            yield return Hook3();
                            break;
                    }

                    host = GetIp(host).ToString();

                    bool SocketStatus(Socket socket)
                    {
                        return (socket == null ? false : true);
                    }

                    IEnumerable<(int, bool)> Hook1()
                    {
                        foreach (int port in ports)
                        {
                            Socket socket = SocketConnect(host, port, timeout);
                            bool result = SocketStatus(socket);
                            yield return (port, result);
                        }
                    }

                    IEnumerable<(int, bool)> Hook2()
                    {
                        if (ports.Length != 2 || ports[0] >= ports[1])
                        {
                            yield return exit;
                            yield break;
                        }

                        for (int p = ports[0]; p <= ports[1]; p += 1)
                        {
                            Socket socket = SocketConnect(host, p, timeout);
                            bool result = SocketStatus(socket);
                            yield return (p, result);
                        }
                    }

                    (int, bool) Hook3()
                    {
                        try
                        {
                            Socket socket = SocketConnect(host, ports[0], timeout);
                            bool result = SocketStatus(socket);
                            return (ports[0], result);
                        }

                        catch
                        {
                            throw;
                        }
                    }
                }

                public IEnumerable<(string, IEnumerable<(int, bool)>)> MultiScan(string[] hosts, int[] ports, PSFormatType PortFormatType, int timeout = 1000)
                {
                    foreach (string host in hosts)
                    {
                        IEnumerable<(int, bool)> result = ScanPorts
                            (host, ports, PortFormatType, timeout);

                        yield return (host, result);
                    }
                }

                public bool ScanPort(string host, int port, int timeout = 1000)
                {
                    try
                    {
                        (int, bool) result = ScanPorts(host, new int[] { port },
                            PSFormatType.Singular, timeout).ToList()[0];

                        return result.Item2;
                    }

                    catch
                    {
                        return false;
                    }
                }
            }
        }
    }
}