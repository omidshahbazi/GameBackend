// Copyright 2019. All Rights Reserved.
using Backend.Base;
using Backend.Base.MasterBalancer;
using Backend.Base.ModuleSystem;
using Backend.Base.NetworkSystem;
using GameFramework.ASCIISerializer;
using GameFramework.Common.FileLayer;
using GameFramework.Common.Utilities;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Backend.MasterBalancer
{
	class MasterBalancer : IModule
	{
		private List<Client> serverNodes = null;

		public void Initialize(IContext Context, object Config)
		{
			serverNodes = new List<Client>();

			if (Config == null)
			{
				Context.Logger.WriteError("MasterBalancer config is null, ignore initializing");
				return;
			}

			Configuration config = (Configuration)Config;
			if (string.IsNullOrEmpty(config.NodeWorkingDirectory))
			{
				Context.Logger.WriteError("NodeWorkingDirectory in config is null, ignore initializing");
				return;
			}

			Context.NetworkManager.OnClientDisconnected += NetworkManager_OnClientDisconnected; ;
			Context.RequestManager.RegisterHandler<ServerNodeIntrodunctionReq>(ServerNodeIntroduction);

			ArgumentParser arguments = new ArgumentParser();
			arguments.Set("directory", config.NodeWorkingDirectory);

			SocketInfo socket = Context.NetworkManager.Sockets[0];

			ISerializeObject configObj = Creator.Create<ISerializeObject>();
			configObj.Set("ConfigStructType", "Backend.ServerNode.Configuration, Backend.ServerNode.NetFramework");
			configObj.Set("Protocol", socket.Protocol.ToString().ToUpper());
			configObj.Set("Host", "::1");
			configObj.Set("Port", socket.LocalEndPoint.Port);

			string path = Path.Combine(Path.Combine(config.NodeWorkingDirectory, "Libraries/"), "Backend.ServerNode.NetFramework.json");
			FileSystem.Write(path, configObj.Content);

			Process.Start("Standalone.NetFramework.exe", arguments.Content);
		}

		private void NetworkManager_OnClientDisconnected(Client Client)
		{
			if (!serverNodes.Contains(Client))
				return;

			serverNodes.Remove(Client);
		}

		public void Shutdown()
		{
		}

		public void Service()
		{
		}

		private void ServerNodeIntroduction(Client Client, ServerNodeIntrodunctionReq Request)
		{
			serverNodes.Add(Client);
		}
	}
}