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
using System.Net.Sockets;

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

					socketsInfo[i] = new SocketInfo((socket.Type == NetworkingProtocol.TCP ? ProtocolType.Tcp : ProtocolType.Udp), socket.LocalEndPoint, socket.Statistics.BandwidthIn, socket.Statistics.BandwidthOut, (uint)socket.Clients.Length);
				}

				return socketsInfo;
			}
		}

		public event ClientConnectionEventHandler OnClientConnected;
		public event ClientConnectionEventHandler OnClientDisconnected;

		private NetworkManager()
		{
			clients = new ClientMap();
		}

		public void Initialize()
		{
			TCPServerSocket.OpenDynamicTCPPorts();

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

		public void StartListening()
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

			string ipPort = "[" + Host + "]:" + Port + "/" + Protocol;

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

				socket.OnClientConnected += (Client) => { OnClientConnectedHandler(socket, Client); };
				socket.OnClientDisconnected += (Client) => { OnClientDisconnectedHandler(socket, Client); };
				socket.OnBufferReceived += (Client, Buffer) => { OnBufferReceivedHandler(socket, Client, Buffer); };

				socket.Bind(Host, Port);

				LogManager.Instance.WriteInfo("Socket on {0} created successfully", ipPort);
			}
			catch (Exception e)
			{
				LogManager.Instance.WriteException(e, "Creating socket for {0} failed", ipPort);
			}

			return socket;
		}

		private void OnClientConnectedHandler(ServerSocket Socket, NativeClient Client)
		{
			uint hash = Base.NetworkSystem.Client.GetClientHash(Socket, Client);

			if (clients.ContainsKey(hash))
				LogManager.Instance.WriteWarning("Redundant client [{0}] connected", Client.EndPoint);

			Client client = new Client(Socket, Client);

			clients[hash] = client;

			if (OnClientConnected != null)
				CallbackUtilities.InvokeCallback(OnClientConnected.Invoke, client);
		}

		private void OnClientDisconnectedHandler(ServerSocket Socket, NativeClient Client)
		{
			uint hash = Base.NetworkSystem.Client.GetClientHash(Socket, Client);

			if (!clients.ContainsKey(hash))
			{
				LogManager.Instance.WriteWarning("Not listed client [{0}] disconnected", Client.EndPoint);
				return;
			}

			Client client = clients[hash];

			if (OnClientDisconnected != null)
				CallbackUtilities.InvokeCallback(OnClientDisconnected.Invoke, client);

			clients.Remove(hash);
		}

		private void OnBufferReceivedHandler(ServerSocket Socket, NativeClient Sender, BufferStream Buffer)
		{
			uint hash = Client.GetClientHash(Socket, Sender);

			if (!clients.ContainsKey(hash))
			{
				LogManager.Instance.WriteError("Not listed client [{0}] sent a packet, going to disconnect", Sender.EndPoint);

				Socket.DisconnectClient(Sender);

				return;
			}

			Client client = clients[hash];

			ServerRequestManager.Instance.DispatchBuffer(client, Buffer);
		}
	}
}