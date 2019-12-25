// Copyright 2019. All Rights Reserved.
using Backend.Client;
using Backend.Common;
using ServerTest;
using System;
using System.Threading;

namespace ClientTest
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

				connection.Send<GetInitialDataReq, GetInitialDataRes>(new GetInitialDataReq(), (res) =>
				{
					Console.WriteLine("respond");
				});
			}
		}
	}
}