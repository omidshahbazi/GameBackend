// Copyright 2019. All Rights Reserved.
using Backend.Base;
using Backend.Base.LogSystem;
using Backend.Core.ConfigSystem;
using Backend.Core.LogSystem;
using Backend.Core.ModuleSystem;
using GameFramework.Common.MemoryManagement;
using System;
using System.Collections.Generic;

namespace Backend.Core
{
	public class Application : Singleton<Application>, IContext, IService
	{
		private List<IService> services = null;

		public bool IsRunning
		{
			get;
			private set;
		}

		public ILogger Logger
		{
			get;
			private set;
		}

		private Application()
		{
		}

		public void Initialize()
		{
			GameFramework.Common.FileLayer.FileSystem.DataPath = Environment.CurrentDirectory + "/../";

			services = new List<IService>();

			AddService(ConfigManager.Instance);
			AddService(LogManager.Instance);
			AddService(NetworkManager.Instance);
			AddService(ModuleManager.Instance);

			Logger = LogManager.Instance;

			IsRunning = true;
		}

		public void Shutdown()
		{
			for (int i = services.Count - 1; i >= 0; --i)
				services[i].Service();

			services.Clear();

			IsRunning = false;
		}

		public void Service()
		{
			for (int i = 0; i < services.Count; ++i)
				services[i].Service();
		}

		private void AddService(IService Service)
		{
			Service.Initialize();

			services.Add(Service);
		}
	}
}