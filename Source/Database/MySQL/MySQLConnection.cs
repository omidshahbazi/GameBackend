// Copyright 2019. All Rights Reserved.
using Backend.Base.ConnectionManager;
using GameFramework.ASCIISerializer;
using System.Data;
using NativeConnection = GameFramework.DatabaseManaged.MySQLDatabase;

namespace Backend.Core
{
	class MySQLConnection : IConnection
	{
		private Base.ConfigSystem.Database config;
		private NativeConnection connection = null;

		public MySQLConnection(Base.ConfigSystem.Database Config)
		{
			config = Config;
			connection = new NativeConnection(config.Host, config.Port, config.Username, config.Password, config.Name);
		}

		public void Dispose()
		{
			connection.Close();
		}

		public void Execute(string Query, params object[] Parameters)
		{
			connection.Execute(Query, Parameters);
		}

		public int ExecuteInsert(string Query, params object[] Parameters)
		{
			return connection.ExecuteInsert(Query, Parameters);
		}

		public DataTable ExecuteWithReturnDataTable(string Query, params object[] Parameters)
		{
			return connection.ExecuteWithReturnDataTable(Query, Parameters);
		}

		public ISerializeArray ExeeecuteWithReturnDataTable(string Query, params object[] Parameters)
		{
			return connection.ExecuteWithReturnISerializeArray(Query, Parameters);
		}
	}
}