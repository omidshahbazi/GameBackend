// Copyright 2019. All Rights Reserved.
using Backend.Base.NetworkSystem;
using Backend.Base.ConnectionManager;
using Backend.Base.LogSystem;

namespace Backend.Base
{
	public interface IContext
	{
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
		}
	}
}