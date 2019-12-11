// Copyright 2019. All Rights Reserved.
using GameFramework.Common.FileLayer;
using GameFramework.Common.MemoryManagement;
using System;

namespace Backend.Core
{
	public class Application : Singleton<Application>
	{
		private Application()
		{
		}

		public void Initialize()
		{
			FileSystem.DataPath = Environment.CurrentDirectory + "/../";

			Configs.Instance.Initialize();
		}
	}
}