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
	public class Network
	{
	    private void HandleError(Exception E) => ErrorHandler.JustDoIt(E);


	    public bool AllowedDomain(string data) => !new List<string>()
		{ ".gov", ".govt", ".edu" }.Any(data.EndsWith);


	    public bool CanInteger(string data) => GetInteger(data) != -1;
	    public bool CanPort(string data) => (GetPort(data) != -1);
	    public bool CanByte(string data) => CanDuration(data);
	    public bool CanIP(string data) => GetIP(data) != string.Empty;


	    public bool CanDuration(string data)
	    {
		int duration = GetInteger(data);
		return (duration != 1 && duration >= 10);
	    }


	    public int GetInteger(string data)
	    {
		try
		{
		    return int.Parse(data);
		}

		catch
		{
		    return -1;
		}
	    }


	    public string GetIP(string data)
	    {
		try
		{
		    var r_host = data.ToLower();

		    if (!IPAddress.TryParse(r_host, out IPAddress ham))
		    {
			if (!r_host.Contains("http://") && !r_host.Contains("https://"))
			{
			    r_host = "https://" + r_host;
			}

			if (!Uri.TryCreate(r_host, UriKind.RelativeOrAbsolute, out Uri bacon))
			{
			    return string.Empty;
			}

			try
			{
			    r_host = Dns.GetHostAddresses(bacon.Host)[0].ToString();
			}

			catch
			{
			    return string.Empty;
			}
		    }

		    else
		    {
			r_host = ham.ToString();

			if (ham.AddressFamily != AddressFamily.InterNetwork && ham.AddressFamily != AddressFamily.InterNetworkV6)
			{
			    return string.Empty;
			}
		    }

		    if (r_host.Length < 7 || r_host == string.Empty)
		    {
			return string.Empty;
		    }

		    return r_host;
		}

		catch
		{
		    return string.Empty;
		}
	    }


	    public AddressFamily GetAddressFamily(string data)
	    {
		try
		{
		    return IPAddress.Parse(data).AddressFamily;
		}

		catch (Exception E)
		{
		    throw (ErrorHandler.GetException(E));
		}
	    }


	    public bool IsHostReachable(string host, int port = 80, SocketType socketType = SocketType.Stream, ProtocolType protocol = ProtocolType.Tcp, string packetData = ".", int timeout = 500)
	    {
		try
		{
		    using (Socket socket = new Socket(GetAddressFamily(host), socketType, protocol)
		    { LingerState = new LingerOption(true, 0) })
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


	    public int GetPort(string data)
	    {
		try
		{
		    int iData = GetInteger(data);

		    if (iData == -1 || iData < 0 || iData > 65535)
		    {
			return -1;
		    }

		    return iData;
		}

		catch
		{
		    return -1;
		}
	    }
	}
    }
}