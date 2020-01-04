// Copyright 2019. All Rights Reserved.
using Backend.Base;
using Backend.Base.ConnectionManager;
using Backend.Base.LogSystem;
using Backend.Base.NetworkSystem;
using Backend.Base.ScheduleSystem;
using Backend.Core.ConfigSystem;
using Backend.Core.LogSystem;
using Backend.Core.ModuleSystem;
using Backend.Core.NetworkSystem;
using GameFramework.Common.MemoryManagement;
using GameFramework.Common.Utilities;
using System;
using System.Collections.Generic;

namespace Backend.Core
{
	public class Application : Singleton<Application>, IContext, IService
	{
		private const string ARGUMENT_WORKING_DIRECTORY = "directory";

		private List<IService> services = null;

		public string WorkingDirectory
		{
			get { return GameFramework.Common.FileLayer.FileSystem.DataPath; }
			set { GameFramework.Common.FileLayer.FileSystem.DataPath = System.IO.Path.Combine(Environment.CurrentDirectory + "/../", value); }
		}

		public bool IsStarting
		{
			get;
			private set;
		}

		public bool IsRunning
		{
			get;
			private set;
		}

		public ArgumentParser Arguments
		{
			get;
			set;
		}

		public IScheduleManager ScheduleManager
		{
			get;
			private set;
		}

		public INetworkManager NetworkManager
		{
			get;
			private set;
		}

		public IRequestManager RequestManager
		{
			get;
			private set;
		}

		public ILogger Logger
		{
			get;
			private set;
		}

		public IConnectionPool Database
		{
			get;
			set;
		}

		private Application()
		{
			IsStarting = true;

			WorkingDirectory = "";
		}

		public void Initialize()
		{
			WorkingDirectory = Arguments.Get<string>(ARGUMENT_WORKING_DIRECTORY);

			IsRunning = true;

			services = new List<IService>();

			ScheduleManager = ScheduleSystem.ScheduleManager.Instance;
			NetworkManager = NetworkSystem.NetworkManager.Instance;
			RequestManager = ServerRequestManager.Instance;
			Logger = LogManager.Instance;

			AddService(ConfigManager.Instance);
			AddService(LogManager.Instance);
			AddService(ScheduleSystem.ScheduleManager.Instance);
			AddService(NetworkSystem.NetworkManager.Instance);
			AddService(ServerRequestManager.Instance);
			AddService(ModuleManager.Instance);

			NetworkSystem.NetworkManager.Instance.StartListenening();

			LogManager.Instance.WriteInfo("Initialization completed");
		}

		public void Shutdown()
		{
			for (int i = services.Count - 1; i >= 0; --i)
				services[i].Service();

			services.Clear();

			IsRunning = false;

			LogManager.Instance.WriteInfo("Shuting down completed");
		}

		public void Service()
		{
			for (int i = 0; i < services.Count; ++i)
				services[i].Service();
		}

		public void Restart()
		{
			IsStarting = true;
		}

		public void Close()
		{
			IsStarting = false;
			IsRunning = false;
		}

		private void AddService(IService Service)
		{
			Service.Initialize();

			services.Add(Service);
		}
	}
}