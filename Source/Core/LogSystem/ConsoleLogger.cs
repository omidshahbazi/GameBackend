// Copyright 2019. All Rights Reserved.
using Backend.Base.ConfigManager;
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

			Console.ForegroundColor = ConsoleColor.Gray;

			Console.WriteLine(Format, Args);
		}

		public void WriteWarning(string Format, params object[] Args)
		{
			if (minLevel > Server.Logger.Levels.Warning)
				return;

			Console.ForegroundColor = ConsoleColor.Yellow;

			Console.WriteLine(Format, Args);
		}

		public void WriteError(string Format, params object[] Args)
		{
			if (minLevel > Server.Logger.Levels.Error)
				return;

			Console.ForegroundColor = ConsoleColor.DarkRed;

			Console.WriteLine(Format, Args);
		}

		public void WriteDebug(string Format, params object[] Args)
		{
			if (minLevel > Server.Logger.Levels.Debug)
				return;

			Console.ForegroundColor = ConsoleColor.Cyan;

			Console.WriteLine(Format, Args);
		}

		public void WriteCritical(string Format, params object[] Args)
		{
			if (minLevel > Server.Logger.Levels.Critical)
				return;

			Console.ForegroundColor = ConsoleColor.Red;

			Console.WriteLine(Format, Args);
		}

		public void WriteException(string Message, Exception E)
		{
			if (minLevel > Server.Logger.Levels.Critical)
				return;

			Console.ForegroundColor = ConsoleColor.Red;

			Console.WriteLine(Message);
			Console.Write("	|_");
			Console.WriteLine(E.ToString());
		}
	}
}