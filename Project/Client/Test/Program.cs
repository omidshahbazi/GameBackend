// Copyright 2019. All Rights Reserved.
using Backend.Common;
using System;
using System.Threading;

namespace Backend.Client
{
	public static class Program
	{
		public static void Main(string[] Args)
		{
			ServerConnection connection = new ServerConnection();
			connection.Connect(ProtocolTypes.TCP, "::1", 81);

			connection.RegisterHandler<args>(handler);

			while (true)
			{
				connection.Service();

				Thread.Sleep(1000);

				connection.Send<args, args>(new args() { doIt = 1586 }, (res) =>
				{
					Console.WriteLine("respond" + res.doIt);
				});
			}
		}

		private static void handler(args res)
		{
			Console.WriteLine("handler" + res.doIt);
		}
	}
}