// Copyright 2019. All Rights Reserved.
using Backend.Base.Configs;
using System;

namespace Backend.Core.LogSystem
{
	class FileLogger : IInternalLogger
	{
		public void Initialize(Server.Logger Config)
		{
		}

		public void WriteInfo(string Format, params object[] Args)
		{
		}

		public void WriteWarning(string Format, params object[] Args)
		{
		}

		public void WriteError(string Format, params object[] Args)
		{
		}

		public void WriteDebug(string Format, params object[] Args)
		{
		}

		public void WriteCritical(string Format, params object[] Args)
		{
		}

		public void WriteException(string Message, Exception E)
		{
		}
	}
}