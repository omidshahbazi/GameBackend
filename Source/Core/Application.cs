// Copyright 2019. All Rights Reserved.
using Backend.Base.Configs;
using GameFramework.Common.FileLayer;
using GameFramework.Common.MemoryManagement;
using GameFramework.Networking;
using System;

namespace Backend.Core
{
	public class Application : Singleton<Application>
	{
		private Application()
		{
		}

		public void Initialize()
		{
			FileSystem.DataPath = Environment.CurrentDirectory + "/../";

			Configs.Instance.Initialize();

			Server serverInfo = Configs.Instance.Server;
			for (int i = 0; i < serverInfo.Sockets.Length; ++i)
			{
				Server.Socket socketInfo = serverInfo.Sockets[i];

				for (int j = 0; j < socketInfo.Ports.Length; ++j)
				{
					TCPServerSocket socket = new TCPServerSocket();

					socket.Bind(socketInfo.Host, socketInfo.Ports[j]);

					socket.Listen();
				}
			}
		}
	}
}