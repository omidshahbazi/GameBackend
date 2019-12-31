// Copyright 2019. All Rights Reserved.
using Backend.Base;
using Backend.Base.MasterBalancer;
using Backend.Base.ModuleSystem;
using Backend.Common.NetworkSystem;

namespace Backend.ServerNode
{
	class ServerNode : IModule
	{
		private IContext context = null;
		private Connection connection = null;

		public void Initialize(IContext Context, object Config)
		{
			context = Context;

			if (Config == null)
			{
				context.Logger.WriteError("ServerNode config is null, ignore initializing");
				return;
			}

			Configuration config = (Configuration)Config;

			connection = new Connection();
			connection.OnConnected += Connection_OnConnected;
			connection.OnConnectionFailed += Connection_OnConnectionFailed;
			connection.OnDisconnected += Connection_OnDisconnected;
			connection.Connect(config.Protocol, config.Host, config.Port);
		}

		private void Connection_OnConnected(Connection Connection)
		{
			context.Logger.WriteInfo("Connection_OnConnected");

			connection.Send(new ServerNodeIntrodunctionReq());
		}

		private void Connection_OnConnectionFailed(Connection Connection)
		{
			context.Logger.WriteError("Connection_OnConnectionFailed");
		}

		private void Connection_OnDisconnected(Connection Connection)
		{
			context.Logger.WriteError("Connection_OnDisconnected");
		}

		public void Shutdown()
		{
		}

		public void Service()
		{
			if (connection != null)
				connection.Service();
		}
	}
}