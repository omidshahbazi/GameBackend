// Copyright 2019. All Rights Reserved.
using Backend.Base.ConfigSystem;
using GameFramework.Common.Utilities;
using System;

namespace Backend.Core.LogSystem
{
	class ConsoleLogger : IInternalLogger
	{
		private Server.Logger.Levels minLevel;

		public void Initialize(Server.Logger Config)
		{
			minLevel = Config.MinimumLevel;
		}

		public void Shutdown()
		{
		}

		public void WriteInfo(string Format, params object[] Args)
		{
			if (minLevel > Server.Logger.Levels.Info)
				return;

			ConsoleHelper.WriteInfo(Format, Args);
		}

		public void WriteWarning(string Format, params object[] Args)
		{
			if (minLevel > Server.Logger.Levels.Warning)
				return;

			ConsoleHelper.WriteWarning(Format, Args);
		}

		public void WriteError(string Format, params object[] Args)
		{
			if (minLevel > Server.Logger.Levels.Error)
				return;

			ConsoleHelper.WriteError(Format, Args);
		}

		public void WriteDebug(string Format, params object[] Args)
		{
			if (minLevel > Server.Logger.Levels.Debug)
				return;

			ConsoleHelper.WriteDebug(Format, Args);
		}

		public void WriteCritical(string Format, params object[] Args)
		{
			if (minLevel > Server.Logger.Levels.Critical)
				return;

			ConsoleHelper.WriteCritical(Format, Args);
		}

		public void WriteException(Exception E, string Format, params object[] Args)
		{
			if (minLevel > Server.Logger.Levels.Critical)
				return;

			ConsoleHelper.WriteException(E, Format, Args);
		}
	}
}