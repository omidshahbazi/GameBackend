// Copyright 2019. All Rights Reserved.
using System;
using Backend.Base.Configs;
using Backend.Base.LogSystem;
using GameFramework.Common.MemoryManagement;

namespace Backend.Core.LogSystem
{
	public class LogManager : Singleton<LogManager>, ILogger
	{
		private ILogger[] loggers = null;

		private LogManager()
		{
		}

		public void Initialize()
		{
			if (Configs.Instance.Server.Loggers == null)
				return;

			int count = Configs.Instance.Server.Loggers.Length;

			loggers = new ILogger[count];

			for (int i = 0; i < count; ++i)
			{
				Server.Logger config = Configs.Instance.Server.Loggers[i];

				Type type = Type.GetType(typeof(LogManager).Namespace + "." + config.Type + "Logger");
				if (type == null)
					continue;

				object instance = Activator.CreateInstance(type);
				if (instance == null)
					continue;

				IInternalLogger logger = (IInternalLogger)instance;

				logger.Initialize(config);

				loggers[i] = logger;
			}
		}

		public void WriteInfo(string Format, params object[] Args)
		{
			if (loggers == null)
				return;

			for (int i = 0; i < loggers.Length; ++i)
				loggers[i].WriteInfo(Format, Args);
		}

		public void WriteWarning(string Format, params object[] Args)
		{
			if (loggers == null)
				return;

			for (int i = 0; i < loggers.Length; ++i)
				loggers[i].WriteWarning(Format, Args);
		}

		public void WriteError(string Format, params object[] Args)
		{
			if (loggers == null)
				return;

			for (int i = 0; i < loggers.Length; ++i)
				loggers[i].WriteError(Format, Args);
		}

		public void WriteDebug(string Format, params object[] Args)
		{
			if (loggers == null)
				return;

			for (int i = 0; i < loggers.Length; ++i)
				loggers[i].WriteDebug(Format, Args);
		}

		public void WriteCritical(string Format, params object[] Args)
		{
			if (loggers == null)
				return;

			for (int i = 0; i < loggers.Length; ++i)
				loggers[i].WriteCritical(Format, Args);
		}

		public void WriteException(Exception E)
		{
			if (loggers == null)
				return;

			for (int i = 0; i < loggers.Length; ++i)
				loggers[i].WriteException(E);
		}
	}
}