// Copyright 2019. All Rights Reserved.
using Backend.Base;
using Backend.Base.ModuleSystem;
using Backend.Base.NetworkSystem;
using GameFramework.Common.Utilities;
using System.Diagnostics;

namespace Backend.MasterBalancer
{
	class ServerNode : IModule
	{
		public void Initialize(IContext Context, object Config)
		{
			if (Config == null)
			{
				Context.Logger.WriteError("ServerNode config is null, ignore initializing");
				return;
			}

			Configuration config = (Configuration)Config;

			SocketInfo socket = Context.NetworkManager.Sockets[0];

			ArgumentParser arguments = new ArgumentParser();
			arguments.Set("directory", config.NodeWorkingDirectory);
			arguments.Set("protocol", socket.Protocol);
			arguments.Set("port", socket.LocalEndPoint.Port);
		}

		public void Shutdown()
		{
		}

		public void Service()
		{
		}
	}
}