// Copyright 2019. All Rights Reserved.
using Backend.Common;
using System.Threading;

namespace Backend.Client
{
	public static class Program
	{
		public static void Main(string[] Args)
		{
			ServerConnection connection = new ServerConnection();
			connection.Connect(ProtocolTypes.TCP, "::1", 81);

			while (true)
			{
				connection.Service();

				Thread.Sleep(1000);
			}
		}
	}
}