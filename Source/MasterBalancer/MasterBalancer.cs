// Copyright 2019. All Rights Reserved.
using Backend.Base;
using Backend.Base.ModuleSystem;
using GameFramework.Common.MemoryManagement;
using System.Diagnostics;

namespace Backend.MasterBalancer
{
	class MasterBalancer : Singleton<MasterBalancer>, IModule
	{
		public void Initialize(IContext Context, object Config)
		{
			if (Config == null)
			{
				Context.Logger.WriteWarning("MasterBalancer config is null, ignore initializing");
				return;
			}

			Configuration config = (Configuration)Config;

			Process.Start("Standalone.NetFramework.exe", config.NodeWorkingDirectory);
		}

		public void Shutdown()
		{
		}

		public void Service()
		{
		}
	}
}