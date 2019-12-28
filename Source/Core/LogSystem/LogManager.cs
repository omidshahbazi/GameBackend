// Copyright 2019. All Rights Reserved.
using System;
using System.Collections.Generic;
using Backend.Base.ConfigSystem;
using Backend.Base.LogSystem;
using Backend.Core.ConfigSystem;
using GameFramework.Common.MemoryManagement;

namespace Backend.Core.LogSystem
{
	class LogManager : Singleton<LogManager>, ILogger, IService
	{
		private IInternalLogger[] loggers = null;

		private LogManager()
		{
		}

		public void Initialize()
		{
			if (ConfigManager.Instance.Server.Loggers == null)
				return;

			Server.Logger[] loggersConfig = ConfigManager.Instance.Server.Loggers;
			if (loggersConfig == null)
			{
				Application.Instance.Logger.WriteWarning("Loggers is empty, so ignore creating loggers");
				return;
			}

			List<IInternalLogger> loggerList = new List<IInternalLogger>();

			for (int i = 0; i < loggersConfig.Length; ++i)
			{
				Server.Logger config = loggersConfig[i];

				string typeName = typeof(LogManager).Namespace + "." + config.Type + "Logger";

				Type type = Type.GetType(typeName);
				if (type == null)
				{
					Application.Instance.Logger.WriteError("Couldn't find type [{0}]", typeName);
					continue;
				}

				object instance = Activator.CreateInstance(type);
				if (instance == null)
				{
					Application.Instance.Logger.WriteError("Couldn't create instance of type [{0}]", typeName);
					continue;
				}

				IInternalLogger logger = (IInternalLogger)instance;

				logger.Initialize(config);

				loggerList.Add(logger);
			}

			loggers = loggerList.ToArray();
		}

		public void Shutdown()
		{
			for (int i = 0; i < loggers.Length; ++i)
				loggers[i].Shutdown();
		}

		public void Service()
		{
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

		public void WriteException(string Message, Exception E)
		{
			if (loggers == null)
				return;

			for (int i = 0; i < loggers.Length; ++i)
				loggers[i].WriteException(Message, E);
		}
	}
}