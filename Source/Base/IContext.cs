// Copyright 2019. All Rights Reserved.
using Backend.Base.NetworkSystem;
using Backend.Base.ConnectionManager;
using Backend.Base.LogSystem;
using GameFramework.Common.Utilities;

namespace Backend.Base
{
	public interface IContext
	{
		ArgumentParser Arguments
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
	}
}