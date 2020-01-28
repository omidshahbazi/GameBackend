// Copyright 2019. All Rights Reserved.
namespace Backend.Base.DatabaseSystem
{
	public interface IConnectionPool
	{
		IConnection Acquire();
	}
}