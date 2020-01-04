// Copyright 2019. All Rights Reserved.
using Backend.Base.ConnectionManager;
using GameFramework.ASCIISerializer;
using System.Data;
using NativeConnection = GameFramework.DatabaseManaged.MySQLDatabase;

namespace Backend.Database.MySQL
{
	class MySQLConnection : IConnection
	{
		private NativeConnection connection = null;

		public MySQLConnection(Base.ConfigSystem.Database Config)
		{
			FillConnection(Config);
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

		private void FillConnection(Base.ConfigSystem.Database Config)
		{
			NativeConnection.CreateInfo info = new NativeConnection.CreateInfo();

			info.Host = Config.Host;
			info.Port = Config.Port;

			info.Username = Config.Username;
			info.Password = Config.Password;

			info.Name = Config.Name;

			info.CharacterSet = NativeConnection.CreateInfo.CharacterSets.UTF8;

			info.PoolingEnabled = false;

			connection = new NativeConnection(info);
		}
	}
}