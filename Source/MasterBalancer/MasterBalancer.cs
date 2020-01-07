// Copyright 2019. All Rights Reserved.
using Backend.Base;
using Backend.Base.MasterBalancer;
using Backend.Base.ModuleSystem;
using Backend.Base.NetworkSystem;
using GameFramework.ASCIISerializer;
using GameFramework.Common.FileLayer;
using GameFramework.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Backend.MasterBalancer
{
	class MasterBalancer : IModule
	{
		private class NodeInfo
		{
			public Process Process
			{
				get;
				private set;
			}

			public Client Client
			{
				get;
				private set;
			}

			public NodeInfo(Process Process, Client Client)
			{
				this.Process = Process;
				this.Client = Client;
			}
		}

		private IContext context = null;
		private List<NodeInfo> nodes = null;

		public void Initialize(IContext Context, object Config)
		{
			context = Context;

			nodes = new List<NodeInfo>();

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

			Context.NetworkManager.OnClientDisconnected += NetworkManager_OnClientDisconnected;
			Context.RequestManager.RegisterHandler<ServerNodeIntrodunctionReq>(ServerNodeIntroduction);

			ArgumentParser arguments = new ArgumentParser();
			arguments.Set("directory", Path.Combine("../", config.NodeWorkingDirectory));

			SocketInfo socket = Context.NetworkManager.Sockets[0];

			ISerializeObject configObj = Creator.Create<ISerializeObject>();
			configObj.Set("ConfigStructType", "Backend.ServerNode.Configuration, Backend.ServerNode.NetFramework");
			configObj.Set("Protocol", socket.Protocol.ToString().ToUpper());
			configObj.Set("Host", "::1");
			configObj.Set("Port", socket.LocalEndPoint.Port);

			string path = Path.Combine(Path.Combine(config.NodeWorkingDirectory, "Libraries/"), "Backend.ServerNode.NetFramework.json");
			FileSystem.Write(path, configObj.Content);

			//Process.Start("Standalone.NetFramework.exe", arguments.Content);
		}

		private void NetworkManager_OnClientDisconnected(Client Client)
		{
			NodeInfo node = FindNode(Client);

			if (node == null)
				return;

			nodes.Remove(node);

			context.Logger.WriteInfo("Node [{0}] under process {1} disconnected", node.Client.ToString(), node.Process.Id);
		}

		public void Shutdown()
		{
			for (int i = 0; i < nodes.Count; ++i)
			{
				NodeInfo node = nodes[i];

				node.Process.Kill();
			}
		}

		public void Service()
		{
		}

		private void ServerNodeIntroduction(Client Client, ServerNodeIntrodunctionReq Request)
		{
			Process process = null;
			try
			{
				process = Process.GetProcessById(Request.ProcessID);
			}
			catch { }

			if (process == null)
			{
				context.Logger.WriteError("Process [{0}] couldn't find", Request.ProcessID);
				return;
			}

			NodeInfo node = new NodeInfo(process, Client);

			nodes.Add(node);

			context.Logger.WriteInfo("Node [{0}] under process {1} connected", node.Client.ToString(), node.Process.Id);
		}

		private NodeInfo FindNode(Client Client)
		{
			for (int i = 0; i < nodes.Count; ++i)
			{
				NodeInfo node = nodes[i];

				if (node.Client != Client)
					continue;

				return node;
			}

			return null;
		}
	}
}