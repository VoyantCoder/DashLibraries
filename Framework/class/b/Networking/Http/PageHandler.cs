
// Author: Dashie


using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Collections.Generic;


namespace DashFramework
{
    namespace Networking
    {
	public partial class Network
	{
	    public partial class HttpServer
	    {
		// Summary:
		//  add pages
		readonly Dictionary<string, Action> UrlExecutionCache = new Dictionary<string, Action>();
		readonly Dictionary<string, byte[]> UrlPageCache = new Dictionary<string, byte[]>();

		public bool ValidPageArguments(ref string Directory, ref string FileName)
		{
		    try
		    {
			if (Directory.Length < 1)
			{
			    return false;
			}

			if (Directory.Length > 1 && Directory.StartsWith("/"))
			{
			    Directory = Directory.Substring(1, Directory.Length - 1);
			}

			if (!Directory.StartsWith("/"))
			{
			    Directory = $"/{Directory}";
			}

			if (FileName.Length > 1 && FileName.StartsWith("/"))
			{
			    FileName = FileName.Substring(1, FileName.Length - 1);
			}

			return true;
		    }

		    catch
		    {
			return false;
		    }
		}

		public bool AddPage(byte[] HTMLSource, string Directory = "/", string FileName = "index.html")
		{
		    try
		    {
			if (!ValidPageArguments(ref Directory, ref FileName))
			{
			    return false;
			}

			UrlPageCache.Add(Directory + FileName, HTMLSource);

			return true;
		    }

		    catch
		    {
			return false;
		    }
		}

		public bool AddPage(byte[] HTMLSource, string Directory, string FileName, Action Code)
		{
		    try
		    {
			if (!ValidPageArguments(ref Directory, ref FileName))
			{
			    return false;
			}

			string path = Directory + FileName;

			UrlExecutionCache.Add(path, Code);
			UrlPageCache.Add(path, HTMLSource);

			return true;
		    }

		    catch
		    {
			return false;
		    }
		}

		// Summary:
		//  modify pages


		// Summary:
		//  starting the page handler
		public Thread PageHandlerThread = null;

		void StartPageHandler()
		{
		    try
		    {
			PageHandlerThread = new Thread(() =>
			{
			    while (Listener.IsListening)
			    {
				HttpListenerContext context = Listener.GetContext();
				HttpListenerResponse response = context.Response;

				string rawUrl = context.Request.RawUrl;

				if (UrlPageCache.ContainsKey(rawUrl))
				{
				    byte[] pageSource = UrlPageCache[rawUrl];

				    response.ContentLength64 = pageSource.Length;

				    using (Stream s = response.OutputStream)
				    {
					s.Write(pageSource, 0, pageSource.Length);
				    }

				    context.Response.Close();
				}

				if (UrlExecutionCache.ContainsKey(rawUrl))
				{
				    UrlExecutionCache[rawUrl]();
				}
			    }
			});

			PageHandlerThread.IsBackground = true;
			PageHandlerThread.Start();
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