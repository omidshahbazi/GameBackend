// Copyright 2019. All Rights Reserved.
using Backend.Base;
using Backend.Core.ConfigSystem;
using Backend.Core.NetworkSystem;
using GameFramework.Common.MemoryManagement;

namespace Backend.Core
{
	public class InternalRequestHandlers : Singleton<InternalRequestHandlers>, IService
	{
		public void Initialize()
		{
			ServerRequestManager requestMan = ServerRequestManager.Instance;

			requestMan.RegisterHandler<ShutdownReq>((client, req) =>
			{
				Application.Instance.ScheduleForShutdown();
			});

			requestMan.RegisterHandler<RestartReq>((client, req) =>
			{
				Application.Instance.ScheduleForRestart();
			});

			requestMan.RegisterHandler<UpdateServerConfigs>((client, req) =>
			{
				ConfigManager.Instance.Server = req.Config;
				ConfigManager.Instance.Save();
			});
		}

		public void Service()
		{
		}

		public void Shutdown()
		{
		}
	}
}