using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Http;

namespace DotNode
{
	class Program
	{
		static void Main(string[] args)
		{
			HttpServer.CreateListener(context =>
			{
				context.Response.StatusCode = (int)HttpStatusCode.OK;
				context.Response.ContentType = "text/plain";

				using (var sw = new StreamWriter(context.Response.OutputStream))
				{
					sw.Write("Hello world!");
				}
			});

			Console.ReadLine();
		}
	}
}
