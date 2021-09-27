
// Author: Dashie


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
