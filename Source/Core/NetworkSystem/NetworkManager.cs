// Copyright 2019. All Rights Reserved.
using Backend.Base.Configs;
using GameFramework.Common.MemoryManagement;
using GameFramework.Networking;
using System;
using System.Collections.Generic;

namespace Backend.Core
{
	class NetworkManager : Singleton<NetworkManager>
	{
		private ServerSocket[] sockets = null;

		private NetworkManager()
		{
		}

		public void Initialize()
		{
			CreateAndBindSockets();
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
					string ipPort = "[" + socketInfo.Host + "]:" + socketInfo.Ports[j];

					try
					{
						Application.Instance.Logger.WriteInfo("Creating socket on {0}", ipPort);

						ServerSocket socket = null;

						if (socketInfo.Protocol == Server.Socket.ProtocolTypes.TCP)
							socket = new TCPServerSocket();
						else if (socketInfo.Protocol == Server.Socket.ProtocolTypes.UDP)
							socket = new UDPServerSocket();

						socket.Bind(socketInfo.Host, socketInfo.Ports[j]);

						socket.Listen();

						socketList.Add(socket);

						Application.Instance.Logger.WriteInfo("Socket on {0} created successfully", ipPort);
					}
					catch (Exception e)
					{
						Application.Instance.Logger.WriteException("Creating socket for " + ipPort + " failed", e);
					}
				}
			}

			sockets = socketList.ToArray();
		}
	}
}