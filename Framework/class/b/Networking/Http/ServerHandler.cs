
// Author: Dashie


using System.Net;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;


namespace DashFramework
{
    namespace Networking
    {
	public partial class Network
	{
	    public partial class HttpServer
	    {
		// Summary:
		//  Anything with stopping the server
		public void Stop()
		{
		    try
		    {
			if (Listener.IsListening)
			{
			    Listener.Stop();
			}
		    }

		    catch
		    {
			throw;
		    }
		}

		// Summary:
		//  Anything with starting the server
		public void Start(bool LaunchInBrowser)
		{
		    try
		    {
			if (!Listener.IsListening)
			{
			    Listener.Start();

			    if (Listener.IsListening && ServerPrefix != string.Empty)
			    {
				Task.Delay(1000).ContinueWith(ok =>
				{
				    try
				    {
					if (LaunchInBrowser)
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

					if (AutoStartPageHandler)
					{
					    StartPageHandler();
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

		// Summary:
		//  Initiation related.  Default procedures
		public HttpListener Listener = new HttpListener();
		string ServerPrefix;

		public HttpServer(string host = "127.0.0.1", int port = 80, bool startListener = true)
		{
		    try
		    {
			if (Listener.Prefixes.Count > 0) Listener.Prefixes.Clear();
			if (Listener.IsListening) Listener.Stop();
			
			ServerPrefix = ($"http://{host}:{port}/");
			Listener.Prefixes.Add(ServerPrefix);

			byte[] html = Encoding.ASCII.GetBytes("default page");

			AddPage(html, "/", "");

			if (startListener) Start(false);
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
