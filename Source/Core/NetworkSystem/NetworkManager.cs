// Copyright 2019. All Rights Reserved.
using Backend.Base.ConfigManager;
using Backend.Core.ConfigSystem;
using Backend.Core.LogSystem;
using Backend.Common;
using GameFramework.BinarySerializer;
using GameFramework.Common.MemoryManagement;
using System;
using System.Collections.Generic;
using System.Text;
using GameFramework.Common.Utilities;

using ServerSocket = GameFramework.Networking.ServerSocket;
using TCPServerSocket = GameFramework.Networking.TCPServerSocket;
using UDPServerSocket = GameFramework.Networking.UDPServerSocket;
using NativeClient = GameFramework.Networking.Client;

namespace Backend.Core.NetworkSystem
{
	class NetworkManager : Singleton<NetworkManager>, IService
	{
		private class ClientMap : Dictionary<uint, Client>
		{ }

		private ServerSocket[] sockets = null;

		private ClientMap clients = null;

		private NetworkManager()
		{
			clients = new ClientMap();
		}

		public void Initialize()
		{
			CreateSockets();
		}

		public void Shutdown()
		{
			for (int i = 0; i < sockets.Length; ++i)
				sockets[i].UnBind();
		}

		public void Service()
		{
			for (int i = 0; i < sockets.Length; ++i)
				sockets[i].Service();
		}

		private void CreateSockets()
		{
			Server.Socket[] socketsConfig = ConfigManager.Instance.Server.Sockets;
			if (socketsConfig == null)
			{
				LogManager.Instance.WriteWarning("Sockets is empty, so ignore creating sockets");
				return;
			}

			List<ServerSocket> socketList = new List<ServerSocket>();

			for (int i = 0; i < socketsConfig.Length; ++i)
			{
				Server.Socket socketInfo = socketsConfig[i];

				for (int j = 0; j < socketInfo.Ports.Length; ++j)
				{
					ServerSocket socket = CreateSocket(socketInfo.Protocol, socketInfo.Host, socketInfo.Ports[j]);
					if (socket == null)
						continue;

					socketList.Add(socket);
				}
			}

			sockets = socketList.ToArray();
		}

		private ServerSocket CreateSocket(ProtocolTypes Protocol, string Host, ushort Port)
		{
			ServerSocket socket = null;

			string ipPort = Protocol + " [" + Host + "]:" + Port;

			try
			{
				LogManager.Instance.WriteInfo("Creating socket on {0}", ipPort);

				if (Protocol == ProtocolTypes.TCP)
					socket = new TCPServerSocket();
				else if (Protocol == ProtocolTypes.UDP)
					socket = new UDPServerSocket();
				else
				{
					LogManager.Instance.WriteError("Unknown protocol [{0}", Protocol);
					return null;
				}

				socket.OnClientConnected += (Client) => { OnClientConnected(socket, Client); };
				socket.OnClientDisconnected += (Client) => { OnClientDisconnected(socket, Client); };
				socket.OnBufferReceived += (Client, Buffer) => { OnBufferReceived(socket, Client, Buffer); };

				socket.Bind(Host, Port);

				socket.Listen();

				LogManager.Instance.WriteInfo("Socket on {0} created successfully", ipPort);
			}
			catch (Exception e)
			{
				LogManager.Instance.WriteException("Creating socket for " + ipPort + " failed", e);
			}

			return socket;
		}

		private void OnClientConnected(ServerSocket Socket, NativeClient Client)
		{
			uint hash = GetHash(Socket, Client);

			if (clients.ContainsKey(hash))
			{
				LogManager.Instance.WriteError("Redundant client connected");
			}

			Client client = new Client(Socket, Client);

			clients[hash] = client;
		}

		private void OnClientDisconnected(ServerSocket Socket, NativeClient Client)
		{
			uint hash = GetHash(Socket, Client);

			if (!clients.ContainsKey(hash))
			{
				LogManager.Instance.WriteError("Not exists client disconnected");
			}

			clients.Remove(hash);
		}

		private void OnBufferReceived(ServerSocket Socket, NativeClient Sender, BufferStream Buffer)
		{
			uint hash = GetHash(Socket, Sender);

			if (!clients.ContainsKey(hash))
			{
				LogManager.Instance.WriteError("Not exists client Sent something, should disconnect");
			}

			Client client = clients[hash];

			RequestManager.Instance.DispatchBuffer(client, Buffer);
		}

		private static uint GetHash(ServerSocket Socket, NativeClient Client)
		{
			return CRC32.CalculateHash(Encoding.ASCII.GetBytes(Socket.LocalEndPoint.ToString() + Client.EndPoint.ToString()));
		}
	}
}