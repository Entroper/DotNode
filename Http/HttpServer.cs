using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Http
{
    public class HttpServer
    {
	    private readonly HttpListener _listener;

	    public static HttpServer CreateListener(string prefix, Action<HttpListenerContext> callback)
	    {
		    var listener = new HttpServer(prefix);
			listener.Listen(callback);

		    return listener;
	    }

	    public static HttpServer CreateListener(Action<HttpListenerContext> callback)
	    {
			var listener = new HttpServer();
			listener.Listen(callback);

			return listener;
		}

		private HttpServer(string prefix = "http://*:80/")
	    {
		    _listener = new HttpListener();

			_listener.Prefixes.Add(prefix);
	    }

	    private async void Listen(Action<HttpListenerContext> callback)
	    {
			_listener.Start();

		    while (_listener.IsListening)
		    {
			    var context = await _listener.GetContextAsync();

			    Task.Factory.StartNew(() => callback(context)).Forget();
		    }
	    }
    }
}
