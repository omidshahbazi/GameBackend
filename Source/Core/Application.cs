// Copyright 2019. All Rights Reserved.
using Backend.Base;
using Backend.Base.LogSystem;
using Backend.Core.LogSystem;
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
			services = new List<IService>();
		}

		public void Initialize()
		{
			GameFramework.Common.FileLayer.FileSystem.DataPath = Environment.CurrentDirectory + "/../";

			AddService(Configs.Instance);

			AddService(LogManager.Instance);
			Logger = LogManager.Instance;

			AddService(NetworkManager.Instance);

			AddService(Modules.Instance);

			IsRunning = true;
		}

		public void Shutdown()
		{
			for (int i = services.Count - 1; i >= 0; --i)
				services[i].Service();

			services.Clear();
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