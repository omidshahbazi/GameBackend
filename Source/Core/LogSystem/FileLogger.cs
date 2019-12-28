// Copyright 2019. All Rights Reserved.
using Backend.Base.ConfigManager;
using GameFramework.Common.FileLayer;
using System;
using System.IO;

namespace Backend.Core.LogSystem
{
	class FileLogger : IInternalLogger
	{
		private Server.Logger.Levels minLevel;
		private StreamWriter writer = null;

		public void Initialize(Server.Logger Config)
		{
			if (string.IsNullOrEmpty(Config.Path))
				return;

			minLevel = Config.MinimumLevel;

			string path = Path.Combine(Config.Path, DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss") + ".log");

			writer = FileSystem.CreateStreamWriter(path);
			writer.AutoFlush = true;
		}

		public void Shutdown()
		{
			if (writer != null)
				writer.Close();
		}

		public void WriteInfo(string Format, params object[] Args)
		{
			if (writer == null || minLevel > Server.Logger.Levels.Info)
				return;

			writer.WriteLine(Format, Args);
		}

		public void WriteWarning(string Format, params object[] Args)
		{
			if (writer == null || minLevel > Server.Logger.Levels.Warning)
				return;

			writer.WriteLine(Format, Args);
		}

		public void WriteError(string Format, params object[] Args)
		{
			if (writer == null || minLevel > Server.Logger.Levels.Error)
				return;

			writer.WriteLine(Format, Args);
		}

		public void WriteDebug(string Format, params object[] Args)
		{
			if (writer == null || minLevel > Server.Logger.Levels.Debug)
				return;

			writer.WriteLine(Format, Args);
		}

		public void WriteCritical(string Format, params object[] Args)
		{
			if (writer == null || minLevel > Server.Logger.Levels.Critical)
				return;

			writer.WriteLine(Format, Args);
		}

		public void WriteException(string Message, Exception E)
		{
			if (writer == null || minLevel > Server.Logger.Levels.Critical)
				return;

			writer.WriteLine(Message);
			writer.Write("	|_");
			writer.WriteLine(E.ToString());
		}
	}
}