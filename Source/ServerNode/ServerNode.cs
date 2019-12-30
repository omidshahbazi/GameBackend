// Copyright 2019. All Rights Reserved.
using Backend.Base;
using Backend.Base.ModuleSystem;
using Backend.Common.NetworkSystem;
using System.Net.Sockets;

namespace Backend.MasterBalancer
{
	class ServerNode : IModule
	{
		private Connection connection = null;

		public void Initialize(IContext Context, object Config)
		{

			connection = new Connection();
			connection.Connect()

			if (Config == null)
			{
				Context.Logger.WriteError("ServerNode config is null, ignore initializing");
				return;
			}

			Configuration config = (Configuration)Config;
		}

		public void Shutdown()
		{
		}

		public void Service()
		{
		}
	}
}