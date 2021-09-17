
// Author: Dashie


using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;


namespace DashFramework
{
    namespace Networking
    {
	public partial class Network
	{
	    /*
		POST,PUT / HTTP/0.9,1.0,2.0,3.0
		Host: ip
		Content-Length: 5000
		User-Agent: Random
		Cookie: Cookie;
		\r\n\r\n
	    */
	    
	    public partial class HttpServer
	    {
		private Network network = new Network();
		private int components = 7;

		public int MaxContentLength = 10000;
		public int MaxCookieLength = 100;

		public string GetRandomHeader(string host)
		{
		    try
		    {
			host = network.GetIp(host).ToString();
			if (host == null) return string.Empty;

			StringBuilder build = new StringBuilder();

			void Append(string append) =>
			    build.Append($"{append}");
			
			void Hook1()
			{
			    try
			    {
				string[] versions = { "0.9", "1.0", "2.0", "3.0" };
				string[] methods = { "POST", "PUT" };

				string version = versions[Random(versions.Length)];
				string method = methods[Random(methods.Length)];

				Append($"{method} / HTTP/{version}");
			    }

			    catch
			    {
				throw;
			    }
			}

			void Hook2()
			{
			    try
			    {
				Append($"Host: {host}");
			    }

			    catch
			    {
				throw;
			    }
			}

			void Hook3()
			{
			    try
			    {
				Append($"Content-Length: {Random(MaxContentLength)}");
			    }

			    catch
			    {
				throw;
			    }
			}

			void Hook4()
			{
			    try
			    {
				Append($"User-Agent: {GetRandomUA()}");
			    }

			    catch
			    {
				throw;
			    }
			}

			void Hook5()
			{
			    try
			    {
				string cookie()
				{
				    string selection = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

				    return new string(Enumerable.Repeat(selection, Random(MaxCookieLength))
					.Select(a => a[rand.Next(a.Length)]).ToArray());
				}

				Append($"Cookie: {cookie()}");
			    }

			    catch
			    {
				throw;
			    }
			}

			void Hook6()
			{
			    try
			    {
				Append("\r\n");
			    }

			    catch
			    {
				throw;
			    }
			}

			for (int i = 0; i < components; i += 1)
			{
			    switch (i)
			    {
				case 0: Hook1(); break;
				case 1: Hook2(); break;
				case 2: Hook3(); break;
				case 3: Hook4(); break;
				case 4: Hook5(); break;
				case 5: Hook6(); break;
			    }

			    build.Append("\r\n");
			}

			return build.ToString();
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