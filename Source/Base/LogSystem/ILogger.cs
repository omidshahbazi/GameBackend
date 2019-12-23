// Copyright 2019. All Rights Reserved.
using System;

namespace Backend.Base.LogSystem
{
	public interface ILogger
	{
		void WriteInfo(string Format, params object[] Args);
		void WriteWarning(string Format, params object[] Args);
		void WriteError(string Format, params object[] Args);
		void WriteDebug(string Format, params object[] Args);
		void WriteCritical(string Format, params object[] Args);
		void WriteException(Exception E);
	}
}