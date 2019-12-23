// Copyright 2019. All Rights Reserved.
using Backend.Base.Configs;
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
			CreateAndBindSockets();
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

		private void CreateAndBindSockets()
		{
			Server.Socket[] socketsConfig = Configs.Instance.Server.Sockets;
			if (socketsConfig == null)
			{
				Application.Instance.Logger.WriteWarning("Sockets is empty, so ignore creating sockets");
				return;
			}

			List<ServerSocket> socketList = new List<ServerSocket>();

			for (int i = 0; i < socketsConfig.Length; ++i)
			{
				Server.Socket socketInfo = socketsConfig[i];

				for (int j = 0; j < socketInfo.Ports.Length; ++j)
				{
					ServerSocket socket = CreateAndBindSocket(socketInfo.Protocol, socketInfo.Host, socketInfo.Ports[j]);
					if (socket == null)
						continue;

					socketList.Add(socket);
				}
			}

			sockets = socketList.ToArray();
		}

		private ServerSocket CreateAndBindSocket(Server.Socket.ProtocolTypes Protocol, string Host, ushort Port)
		{
			ServerSocket socket = null;

			string ipPort = "[" + Host + "]:" + Port;

			try
			{
				Application.Instance.Logger.WriteInfo("Creating socket on {0}", ipPort);

				if (Protocol == Server.Socket.ProtocolTypes.TCP)
					socket = new TCPServerSocket();
				else if (Protocol == Server.Socket.ProtocolTypes.UDP)
					socket = new UDPServerSocket();
				else
				{
					Application.Instance.Logger.WriteError("Unknown protocol [{0}", Protocol);
					return null;
				}

				socket.OnClientConnected += OnClientConnected;
				socket.OnClientDisconnected += OnClientDisconnected;
				socket.OnBufferReceived += OnBufferReceived;

				socket.Bind(Host, Port);

				socket.Listen();

				Application.Instance.Logger.WriteInfo("Socket on {0} created successfully", ipPort);
			}
			catch (Exception e)
			{
				Application.Instance.Logger.WriteException("Creating socket for " + ipPort + " failed", e);
			}

			return socket;
		}

		private void OnClientConnected(Client Sender)
		{
		}

		private void OnClientDisconnected(Client Client)
		{
		}

		private void OnBufferReceived(Client Client, BufferStream Buffer)
		{
		}
	}
}