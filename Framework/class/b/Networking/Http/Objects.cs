﻿
// Author: Dashie


using System;
using System.Net;
using System.Threading;
using System.Collections.Generic;

using DashFramework.Data.Special;


namespace DashFramework
{
    namespace Networking
    {
	public partial class Network
	{
	    public partial class HttpServer
	    {
		readonly Dictionary<string, Action> UrlExecutionCache = new Dictionary<string, Action>();
		readonly Dictionary<string, byte[]> UrlPageCache = new Dictionary<string, byte[]>();

		readonly Specialities Speciality = new Specialities();
		readonly HttpListener Listener = new HttpListener();
		readonly Network network = new Network();

		public Thread PageHandlerThread = null;

		public int MaxContentLength = 10000;
		public int MaxCookieLength = 100;

		int components = 7;
		string ServerPrefix;
	    }
	}
    }
}