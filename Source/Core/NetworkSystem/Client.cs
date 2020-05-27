// Copyright 2019. All Rights Reserved.
using GameFramework.Networking;
using System.Text;
using GameFramework.Common.Utilities;
using System.Net;
using System.Net.Sockets;
using Backend.Base.NetworkSystem;

using ServerSocket = GameFramework.Networking.ServerSocket;
using TCPServerSocket = GameFramework.Networking.TCPServerSocket;
using UDPServerSocket = GameFramework.Networking.UDPServerSocket;
using NativeClient = GameFramework.Networking.Client;

namespace Backend.Core.NetworkSystem
{
	public class Client : IClient
	{
		private ServerSocket socket = null;
		private NativeClient client = null;

		public uint SocketHash
		{
			get { return GetSocketInfoHash(socket.LocalEndPoint, (socket.Type == Protocols.TCP ? ProtocolType.Tcp : ProtocolType.Udp)); }
		}

		public uint ID
		{
			get;
			private set;
		}

		public Client(ServerSocket Socket, NativeClient Client)
		{
			socket = Socket;
			client = Client;

			ID = GetClientHash(socket, client);
		}

		public void Disconnect()
		{
			socket.DisconnectClient(client);
		}

		public void WriteBuffer(byte[] Buffer, uint Index, uint Length)
		{
			if (socket.Type == Protocols.TCP)
				((TCPServerSocket)socket).Send(client, Buffer, Index, Length);
			else if (socket.Type == Protocols.UDP)
				((UDPServerSocket)socket).Send(client, Buffer, Index, Length);
		}

		public override string ToString()
		{
			return client.EndPoint.ToString() + "/" + socket.Type + " -> " + socket.LocalEndPoint.Port + "/" + socket.Type;
		}

		public static uint GetSocketInfoHash(IPEndPoint EndPoint, ProtocolType Protocol)
		{
			return CRC32.CalculateHash(Encoding.ASCII.GetBytes(EndPoint.ToString() + Protocol.ToString().ToUpper()));
		}

		public static uint GetClientHash(ServerSocket Socket, NativeClient Client)
		{
			return CRC32.CalculateHash(Encoding.ASCII.GetBytes(Socket.LocalEndPoint.ToString() + Client.EndPoint.ToString()));
		}
	}
}