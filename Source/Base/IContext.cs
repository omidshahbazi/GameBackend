// Copyright 2019. All Rights Reserved.
using Backend.Base.LogSystem;

namespace Backend.Base
{
	public interface IContext
	{
		ILogger Logger
		{
			get;
		}
	}
}