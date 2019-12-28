// Copyright 2019. All Rights Reserved.
using Backend.Base;
using Backend.Base.ConnectionManager;
using Backend.Base.ModuleSystem;
using Backend.Core;
using GameFramework.Common.MemoryManagement;

namespace Backend.Database
{
	class DatabaseManager : Singleton<DatabaseManager>, IModule, IConnectionPool
	{
		public void Initialize(IContext Context)
		{
			Application.Instance.Database = this;



			Context.Logger.WriteInfo("Database Manager initialized successfully");
		}

		public void Shutdown()
		{
		}

		public void Service()
		{
		}

		public IConnection Acquire()
		{
			return null;
		}
	}
}