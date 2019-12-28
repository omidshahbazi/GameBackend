// Copyright 2019. All Rights Reserved.
using GameFramework.ASCIISerializer;
using System;
using System.Data;

namespace Backend.Base.ConnectionManager
{
	public interface IConnection : IDisposable
	{
		void Execute(string Query, params object[] Parameters);

		int ExecuteInsert(string Query, params object[] Parameters);

		DataTable ExecuteWithReturnDataTable(string Query, params object[] Parameters);

		ISerializeArray ExeeecuteWithReturnDataTable(string Query, params object[] Parameters);
	}
}