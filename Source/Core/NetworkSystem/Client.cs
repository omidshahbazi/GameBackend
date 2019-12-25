// Copyright 2019. All Rights Reserved.
using ServerSocket = GameFramework.Networking.ServerSocket;
using TCPServerSocket = GameFramework.Networking.TCPServerSocket;
using UDPServerSocket = GameFramework.Networking.UDPServerSocket;
using NativeClient = GameFramework.Networking.Client;

namespace Backend.Core.NetworkSystem
{
	public class Client
	{
		ServerSocket socket = null;
		NativeClient client = null;

		public Client(ServerSocket Socket, NativeClient Client)
		{
			socket = Socket;
			client = Client;
		}

		public void WriteBuffer(byte[] Buffer)
		{
			if (socket is TCPServerSocket)
				((TCPServerSocket)socket).Send(client, Buffer);
			else if (socket is UDPServerSocket)
				((UDPServerSocket)socket).Send(client, Buffer);
		}
	}
}