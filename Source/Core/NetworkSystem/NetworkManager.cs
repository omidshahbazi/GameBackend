// Copyright 2019. All Rights Reserved.
using Backend.Base.ConfigManager;
using Backend.Core.ConfigSystem;
using Backend.Core.LogSystem;
using GameFramework.BinarySerializer;
using GameFramework.Common.MemoryManagement;
using GameFramework.Networking;
using System;
using System.Collections.Generic;

namespace Backend.Core
{
	class NetworkManager : Singleton<NetworkManager>, IService
	{
		private ServerSocket[] sockets = null;

		private NetworkManager()
		{
		}

		public void Initialize()
		{
			CreateSockets();
		}

		public void Shutdown()
		{
			for (int i = 0; i < sockets.Length; ++i)
			{
				ServerSocket socket = sockets[i];

				socket.OnClientConnected -= OnClientConnected;
				socket.OnClientDisconnected -= OnClientDisconnected;
				socket.OnBufferReceived -= OnBufferReceived;

				socket.UnBind();
			}
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

		private ServerSocket CreateSocket(Server.Socket.ProtocolTypes Protocol, string Host, ushort Port)
		{
			ServerSocket socket = null;

			string ipPort = Protocol + " [" + Host + "]:" + Port;

			try
			{
				LogManager.Instance.WriteInfo("Creating socket on {0}", ipPort);

				if (Protocol == Server.Socket.ProtocolTypes.TCP)
					socket = new TCPServerSocket();
				else if (Protocol == Server.Socket.ProtocolTypes.UDP)
					socket = new UDPServerSocket();
				else
				{
					LogManager.Instance.WriteError("Unknown protocol [{0}", Protocol);
					return null;
				}

				socket.OnClientConnected += OnClientConnected;
				socket.OnClientDisconnected += OnClientDisconnected;
				socket.OnBufferReceived += OnBufferReceived;

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

		private void OnClientConnected(Client Client)
		{
		}

		private void OnClientDisconnected(Client Client)
		{
		}

		private void OnBufferReceived(Client Sender, BufferStream Buffer)
		{

		}
	}
}