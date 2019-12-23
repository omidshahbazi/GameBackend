// Copyright 2019. All Rights Reserved.
using Backend.Base;
using Backend.Base.LogSystem;
using Backend.Core.LogSystem;
using GameFramework.Common.MemoryManagement;
using System;

namespace Backend.Core
{
	public class Application : Singleton<Application>, IContext
	{
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

			Configs.Instance.Initialize();

			LogManager.Instance.Initialize();
			Logger = LogManager.Instance;

			NetworkManager.Instance.Initialize();

			Modules.Instance.Initialize();
		}
	}
}