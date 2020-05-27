// Copyright 2019. All Rights Reserved.
using Backend.Client;
using Backend.Common;
using Backend.Common.Chat;
using Backend.Common.NetworkSystem;
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

			//connection.RegisterChatReceivedFromClientHandler(ChatReceivedFromClientHandler);

			connection.Connect(ProtocolTypes.TCP, "::1", 5000);

			while (true)
			{
				connection.Service();

				Thread.Sleep(10);
			}
		}

		private static void Connection_OnConnected(Connection Connection)
		{
			Console.WriteLine("Connected");

			//connection.RegisterInChatService(() =>
			//{
			//	connection.SendChatToClient(1, "sss");
			//});

			//connection.Send<GetInitialDataReq, GetInitialDataRes>(new GetInitialDataReq(), OnGetInitialData);
		}

		private static void Connection_OnConnectionFailed(Connection Connection)
		{
			Console.WriteLine("Connection Failed");
		}

		private static void Connection_OnDisconnected(Connection Connection)
		{
			Console.WriteLine("Disconnected");
		}

		private static void OnGetInitialData(GetInitialDataRes Data)
		{
			Console.WriteLine("respond");
		}

		private static void ChatReceivedFromClientHandler(ChatReceivedFromClientReq Data)
		{
			Console.WriteLine(Data.ID + " " + Data.Content);
		}
	}
}