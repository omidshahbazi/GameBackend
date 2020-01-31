// Copyright 2019. All Rights Reserved.
using Backend.Base;
using Backend.Base.DatabaseSystem;
using Backend.Base.ModuleSystem;
using Backend.Database.MySQL;

namespace Backend.Database
{
	class DatabaseManager : IModule, IConnectionPool
	{
		private Base.ConfigSystem.Database config;

		public void Initialize(IContext Context, object Config)
		{
			if (Config == null)
			{
				Context.Logger.WriteWarning("DatabaseManager config is null, ignore initializing");
				return;
			}

			config = (Base.ConfigSystem.Database)Config;

			if (!RunTest())
			{
				Context.Logger.WriteInfo("DatabaseManager test query [{0}] failed");
				return;
			}

			Context.Database = this;
		}

		public void Shutdown()
		{
		}

		public void Service()
		{
		}

		public IConnection Acquire()
		{
			if (config.Type == Base.ConfigSystem.Database.DBMSTypes.MySQL)
				return new MySQLConnection(config);

			return null;
		}

		private bool RunTest()
		{
			if (string.IsNullOrEmpty(config.TestQuery))
				return true;

			IConnection con = Acquire();
			if (con == null)
				return false;

			con.Execute(config.TestQuery);

			con.Dispose();

			return true;
		}
	}
}