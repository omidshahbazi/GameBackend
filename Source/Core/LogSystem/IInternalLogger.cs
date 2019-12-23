// Copyright 2019. All Rights Reserved.
using Backend.Base.ConfigManager;
using Backend.Base.LogSystem;

namespace Backend.Core.LogSystem
{
	interface IInternalLogger : ILogger
	{
		void Initialize(Server.Logger Config);
		void Shutdown();
	}
}