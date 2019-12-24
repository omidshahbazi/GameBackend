// Copyright 2019. All Rights Reserved.
namespace Backend.Base.ConnectionManager
{
	public interface IConnectionPool
	{
		IConnection Acquire();
	}
}