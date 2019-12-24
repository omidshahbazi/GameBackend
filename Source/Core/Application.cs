// Copyright 2019. All Rights Reserved.
using Backend.Base;
using Backend.Base.ConnectionManager;
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

		public IConnectionPool Database
		{
			get;
			set;
		}

		private Application()
		{
		}

		public void Initialize()
		{
			GameFramework.Common.FileLayer.FileSystem.DataPath = Environment.CurrentDirectory + "/../";

			services = new List<IService>();

			Logger = LogManager.Instance;

			AddService(ConfigManager.Instance);
			AddService(LogManager.Instance);
			AddService(NetworkManager.Instance);
			AddService(ModuleManager.Instance);

			IsRunning = true;







			RequestManager.Instance.RegisterHandler<req, res>(handler);
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
			req r = new req();
			r.a = 203;
			RequestManager.Instance.InvokeHandler(r);

			for (int i = 0; i < services.Count; ++i)
				services[i].Service();
		}

		private void AddService(IService Service)
		{
			Service.Initialize();

			services.Add(Service);
		}



		class req
		{
			public int a;
		}

		class res
		{
			public int b;
			public string c;
		}

		private res handler(req r)
		{
			res re = new res();
			re.b = r.a;
			re.c = "omid";

			return re;
		}
	}
}