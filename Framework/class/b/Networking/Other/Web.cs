
// Author: Dashie


using System.Net;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;


namespace DashFramework
{
    namespace Networking
    {
	public partial class Network
	{
	    public partial class LocalHttpServer
	    {
		public HttpListener Listener = null;
		public Thread ServerThread = null;

		string ServerPrefix = string.Empty;
		
		void Server(int p)
		{
		    try
		    {
			ServerPrefix = ($"http://*:{p}/");

			if (Listener.Prefixes.Count > 0)
			    Listener.Prefixes.Clear();

			if (Listener.IsListening)
			    Listener.Stop();

			Listener.Prefixes.Add(ServerPrefix);
			Listener.Start();
		    }

		    catch
		    {
			throw;
		    }
		}

		void SetupServerThread(int p)
		{
		    try
		    {
			ServerThread = new Thread(() => Server(p));
			ServerThread.IsBackground = true;
		    }

		    catch
		    {
			throw;
		    }
		}

		public void Stop()
		{
		    try
		    {
			if (ServerThread != null && Listener.IsListening)
			{
			    Listener.Stop();
			}
		    }

		    catch
		    {
			throw;
		    }
		}

		public void Start()
		{
		    try
		    {
			if (ServerThread != null && !Listener.IsListening)
			{
			    Listener.Start();

			    if (Listener.IsListening && ServerPrefix != string.Empty)
			    {
				Task.Delay(1000).ContinueWith(ok =>
				{
				    try
				    {
					using (Process proc = new Process())
					{
					    proc.StartInfo = new ProcessStartInfo()
					    {
						UseShellExecute = true,
						FileName = ServerPrefix,
					    };

					    proc.Start();
					}
				    }

				    catch
				    {
					throw;
				    }
				});
			    }
			}
		    }

		    catch
		    {
			throw;
		    }
		}

		public LocalHttpServer(int port, bool startListener)
		{
		    try
		    {
			SetupServerThread(port);

			if (startListener)
			{
			    Start();
			}
		    }

		    catch
		    {
			throw;
		    }
		}
	    }
	    // Header Validator (check whether failed to arrive or not)
	    // Random User-Agent Generator (store file with user-agents)
	    // Random Header Generator (should have settings)
	    // HTTP Server (set a directory etc etc)
	}
    }
}
