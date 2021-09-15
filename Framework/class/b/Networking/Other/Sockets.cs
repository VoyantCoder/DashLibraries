
// Author: Dashie


using System;
using System.Threading;
using System.Net.Sockets;


namespace DashFramework
{
    namespace Networking
    {
	public partial class Network
	{
	    public Socket SocketGet(AddressFamily addrfam = AddressFamily.InterNetwork, SocketType socktype = SocketType.Stream, ProtocolType prottype = ProtocolType.Tcp, bool AddFlags = true)
	    {
		try
		{
		    Socket socket = new Socket(addrfam, socktype, prottype);

		    if (AddFlags)
		    {
			socket.LingerState = new LingerOption(true, 0);
		    }

		    return socket;
		}

		catch
		{
		    return null;
		}
	    }
	    
	    bool Connect(Socket socket, string target, int port, int timeout)
	    {
		try
		{
		    target = GetIp(target).ToString();

		    if (target != null)
		    {
			IAsyncResult async = socket.BeginConnect(target, port, null, null);
			return async.AsyncWaitHandle.WaitOne(timeout, true);
		    }

		    return false;
		}

		catch
		{
		    return false;
		}
	    }

	    public Socket SocketConnect(string target, int port, int timeout = 1000)
	    {
		try
		{
		    Socket socket = SocketGet();
		    
		    if (socket != null)
		    {
			bool result = Connect(socket, target, port, timeout);
			socket = result == true ? socket : null;
		    }

		    return socket;
		}

		catch
		{
		    return null;
		}
	    }

	    public Socket SocketConnect(string target, int port, AddressFamily addrfam, SocketType sockettype, ProtocolType prottype, int timeout = 1000)
	    {
		try
		{
		    Socket socket = SocketGet(addrfam, sockettype, prottype); // only difference

		    if (socket != null)
		    {
			bool result = Connect(socket, target, port, timeout);
			socket = result == true ? socket : null;
		    }

		    return socket;
		}

		catch
		{
		    return null;
		}
	    }

	    public void SocketSend(Socket socket, byte[] data)
	    {
		try
		{
		    if (socket.Connected)
		    {
			socket.Send(data, data.Length, SocketFlags.None);
		    }
		}

		catch
		{
		    throw;
		}
	    }

	    public Thread SocketAsyncSend(Socket socket, byte[] data)
	    {
		try
		{
		    if (socket.Connected)
		    {
			Thread thread = new Thread(() =>
			{ SocketSend(socket, data); });

			thread.IsBackground = true;
			thread.Start();

			return thread;
		    }
		}

		catch
		{
		    return null;
		}

		return null;
	    }
	}
    }
}