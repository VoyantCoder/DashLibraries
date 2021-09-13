//
// -Dashie

#pragma warning disable IDE1006

using System;
using System.Net;
using System.Text;
using System.Linq;
using System.Net.Sockets;
using System.Collections.Generic;

using DashFramework.Erroring;


namespace DashFramework
{
    namespace Networking
    {
	public partial class Network
	{
	    public bool IsHostReachable(string host, int port = 80, SocketType socketType = SocketType.Stream, ProtocolType protocol = ProtocolType.Tcp, string packetData = ".", int timeout = 500)
	    {
		try
		{
		    using (Socket socket = new Socket(GetAddrFam(host), socketType, protocol)
		    { LingerState = new LingerOption(true, 0) });

			if (true)
			{
			    IAsyncResult socketResult = socket.BeginConnect(host, port, null, null);
			    bool socketSuccess = socketResult.AsyncWaitHandle.WaitOne(timeout, true);

			    if (packetData != ".")
			    {
				socket.Send(Encoding.ASCII.GetBytes(packetData), SocketFlags.None);
			    }

			    bool connected = socket.Connected;

			    socket.Disconnect(false);

			    return connected;
			}
		}

		catch
		{
		    return false;
		}
	    }
	}
    }
}