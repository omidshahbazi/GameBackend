// Copyright 2019. All Rights Reserved.
using GameFramework.ASCIISerializer;
using System;
using System.Data;

namespace Backend.Base.DatabaseSystem
{
	public interface IConnection : IDisposable
	{
		void Execute(string Query, params object[] Parameters);

		int ExecuteInsert(string Query, params object[] Parameters);

		DataTable QueryDataTable(string Query, params object[] Parameters);

		ISerializeArray QueryISerializeArray(string Query, params object[] Parameters);
	}
}