// Copyright 2019. All Rights Reserved.
using Backend.Base.NetworkSystem;
using Backend.Base.DatabaseSystem;
using Backend.Base.LogSystem;
using GameFramework.Common.Utilities;
using Backend.Base.ScheduleSystem;
using Backend.Base.ConfigSystem;
using Backend.Base.EMailSystem;

namespace Backend.Base
{
	public interface IContext
	{
		ArgumentParser Arguments
		{
			get;
		}

		IConfigManager ConfigManager
		{
			get;
		}

		IScheduleManager ScheduleManager
		{
			get;
		}

		INetworkManager NetworkManager
		{
			get;
		}

		IRequestManager RequestManager
		{
			get;
		}

		ILogger Logger
		{
			get;
		}

		IConnectionPool Database
		{
			get;
			set;
		}

		IEmailManager EMailManager
		{
			get;
			set;
		}

		void ScheduleForShutdown();

		void ScheduleForRestart();
	}
}