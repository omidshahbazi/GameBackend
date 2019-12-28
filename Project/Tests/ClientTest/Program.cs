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
		private static ServerConnection connection = null;

		public static void Main(string[] Args)
		{
			connection = new ServerConnection();

			connection.OnConnected += Connection_OnConnected;
			connection.OnConnectionFailed += Connection_OnConnectionFailed;
			connection.OnDisconnected += Connection_OnDisconnected;

			connection.Connect(ProtocolTypes.TCP, "::1", 5000);

			while (true)
			{
				connection.Service();

				Thread.Sleep(10);
			}
		}

		private static void Connection_OnConnected(ServerConnection Connection)
		{
			Console.WriteLine("Connected");

			connection.Send<GetInitialDataReq, GetInitialDataRes>(new GetInitialDataReq(), OnGetInitialData);
		}

		private static void Connection_OnConnectionFailed(ServerConnection Connection)
		{
			Console.WriteLine("Connection Failed");
		}

		private static void Connection_OnDisconnected(ServerConnection Connection)
		{
			Console.WriteLine("Disconnected");
		}

		private static void OnGetInitialData(GetInitialDataRes Res)
		{
			Console.WriteLine("respond");

			connection.Send<GetInitialDataReq, GetInitialDataRes>(new GetInitialDataReq(), OnGetInitialData);
		}
	}
}