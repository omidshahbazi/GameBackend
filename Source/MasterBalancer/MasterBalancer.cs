// Copyright 2019. All Rights Reserved.
using Backend.Base;
using Backend.Base.ModuleSystem;
using Backend.Base.NetworkSystem;
using GameFramework.Common.MemoryManagement;
using System.Diagnostics;

namespace Backend.MasterBalancer
{
	class MasterBalancer : Singleton<MasterBalancer>, IModule
	{
		public void Initialize(IContext Context, object Config)
		{
			if (Config == null)
			{
				Context.Logger.WriteError("MasterBalancer config is null, ignore initializing");
				return;
			}

			Configuration config = (Configuration)Config;

			SocketInfo socket = Context.NetworkManager.Sockets[0];

			Process.Start("Standalone.NetFramework.exe", config.NodeWorkingDirectory + " " + socket.Protocol + " " + socket.LocalEndPoint.Port);
		}

		public void Shutdown()
		{
		}

		public void Service()
		{
		}
	}
}