// Copyright 2019. All Rights Reserved.
using Backend.Base.ConfigSystem;
using Backend.Base.NetworkSystem;
using Backend.Core.ConfigSystem;
using Backend.Core.LogSystem;
using Backend.Common;
using GameFramework.BinarySerializer;
using GameFramework.Common.MemoryManagement;
using System;
using System.Collections.Generic;
using GameFramework.Common.Utilities;
using System.Net.Sockets;
using System.Text;

using ServerSocket = GameFramework.Networking.ServerSocket;
using TCPServerSocket = GameFramework.Networking.TCPServerSocket;
using UDPServerSocket = GameFramework.Networking.UDPServerSocket;
using NativeClient = GameFramework.Networking.Client;
using NetworkingProtocol = GameFramework.Networking.Protocols;

namespace Backend.Core.NetworkSystem
{
	class NetworkManager : Singleton<NetworkManager>, IService, INetworkManager
	{
		private class ClientMap : Dictionary<uint, Client>
		{ }

		private ServerSocket[] sockets = null;

		private ClientMap clients = null;

		public SocketInfo[] Sockets
		{
			get
			{
				if (sockets == null)
					return null;

				SocketInfo[] socketsInfo = new SocketInfo[sockets.Length];

				for (int i = 0; i < sockets.Length; ++i)
				{
					ServerSocket socket = sockets[i];

					socketsInfo[i] = new SocketInfo((socket.Type == NetworkingProtocol.TCP ? ProtocolType.Tcp : ProtocolType.Udp), socket.LocalEndPoint);
				}

				return socketsInfo;
			}
		}

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

		public void StartListenening()
		{
			for (int i = 0; i < sockets.Length; ++i)
				sockets[i].Listen();
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

				//socket.MultithreadedCallbacks = false;
				//socket.MultithreadedReceive = false;
				//socket.MultithreadedSend = false;

				socket.OnClientConnected += (Client) => { OnClientConnected(socket, Client); };
				socket.OnClientDisconnected += (Client) => { OnClientDisconnected(socket, Client); };
				socket.OnBufferReceived += (Client, Buffer) => { OnBufferReceived(socket, Client, Buffer); };

				socket.Bind(Host, Port);

				LogManager.Instance.WriteInfo("Socket on {0} created successfully", ipPort);
			}
			catch (Exception e)
			{
				LogManager.Instance.WriteException(e, "Creating socket for {0} failed", ipPort);
			}

			return socket;
		}

		private void OnClientConnected(ServerSocket Socket, NativeClient Client)
		{
			uint hash = GetHash(Socket, Client);

			if (clients.ContainsKey(hash))
				LogManager.Instance.WriteWarning("Redundant client [{0}] connected", Client.EndPoint);

			clients[hash] = new Client(Socket, Client);
		}

		private void OnClientDisconnected(ServerSocket Socket, NativeClient Client)
		{
			uint hash = GetHash(Socket, Client);

			if (!clients.ContainsKey(hash))
				LogManager.Instance.WriteWarning("Not listed client [{0}] disconnected", Client.EndPoint);

			clients.Remove(hash);
		}

		private void OnBufferReceived(ServerSocket Socket, NativeClient Sender, BufferStream Buffer)
		{
			uint hash = GetHash(Socket, Sender);

			if (!clients.ContainsKey(hash))
			{
				LogManager.Instance.WriteError("Not listed client [{0}] Sent a packet, going to disconnect", Sender.EndPoint);

				Socket.DisconnectClient(Sender);

				return;
			}

			Client client = clients[hash];

			ServerRequestManager.Instance.DispatchBuffer(client, Buffer);
		}

		private static uint GetHash(ServerSocket Socket, NativeClient Client)
		{
			return CRC32.CalculateHash(Encoding.ASCII.GetBytes(Socket.LocalEndPoint.ToString() + Client.EndPoint.ToString()));
		}
	}
}