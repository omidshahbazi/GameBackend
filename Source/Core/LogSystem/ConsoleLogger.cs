// Copyright 2019. All Rights Reserved.
using Backend.Base.ConfigSystem;
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

			Console.BackgroundColor = ConsoleColor.Gray;
			Console.ForegroundColor = ConsoleColor.Black;
			Console.Write("Info");
			Console.BackgroundColor = ConsoleColor.Black;

			Console.ForegroundColor = ConsoleColor.Gray;

			Console.Write(" ");

			Console.WriteLine(Format, Args);

			Console.ResetColor();
		}

		public void WriteWarning(string Format, params object[] Args)
		{
			if (minLevel > Server.Logger.Levels.Warning)
				return;

			Console.BackgroundColor = ConsoleColor.DarkYellow;
			Console.ForegroundColor = ConsoleColor.Black;
			Console.Write("Warning");
			Console.BackgroundColor = ConsoleColor.Black;

			Console.ForegroundColor = ConsoleColor.Gray;

			Console.Write(" ");

			Console.WriteLine(Format, Args);

			Console.ResetColor();
		}

		public void WriteError(string Format, params object[] Args)
		{
			if (minLevel > Server.Logger.Levels.Error)
				return;

			Console.BackgroundColor = ConsoleColor.DarkRed;
			Console.ForegroundColor = ConsoleColor.Black;
			Console.Write("Error");
			Console.BackgroundColor = ConsoleColor.Black;

			Console.ForegroundColor = ConsoleColor.Gray;

			Console.Write(" ");

			Console.WriteLine(Format, Args);

			Console.ResetColor();
		}

		public void WriteDebug(string Format, params object[] Args)
		{
			if (minLevel > Server.Logger.Levels.Debug)
				return;

			Console.BackgroundColor = ConsoleColor.Cyan;
			Console.ForegroundColor = ConsoleColor.Black;
			Console.Write("Debug");
			Console.BackgroundColor = ConsoleColor.Black;

			Console.ForegroundColor = ConsoleColor.Gray;

			Console.Write(" ");

			Console.WriteLine(Format, Args);

			Console.ResetColor();
		}

		public void WriteCritical(string Format, params object[] Args)
		{
			if (minLevel > Server.Logger.Levels.Critical)
				return;

			Console.BackgroundColor = ConsoleColor.Red;
			Console.ForegroundColor = ConsoleColor.Black;
			Console.Write("Critical");
			Console.BackgroundColor = ConsoleColor.Black;

			Console.ForegroundColor = ConsoleColor.Gray;

			Console.Write(" ");

			Console.WriteLine(Format, Args);

			Console.ResetColor();
		}

		public void WriteException(Exception E, string Format, params object[] Args)
		{
			if (minLevel > Server.Logger.Levels.Critical)
				return;

			Console.BackgroundColor = ConsoleColor.Red;
			Console.ForegroundColor = ConsoleColor.Black;
			Console.Write("Exception");
			Console.BackgroundColor = ConsoleColor.Black;

			Console.ForegroundColor = ConsoleColor.Gray;

			Console.Write(" ");

			Console.WriteLine(Format, Args);

			if (E != null)
			{
				Console.ForegroundColor = ConsoleColor.DarkGray;
				Console.WriteLine(E.ToString());
				Console.WriteLine(E.StackTrace);
			}

			Console.ResetColor();
		}
	}
}