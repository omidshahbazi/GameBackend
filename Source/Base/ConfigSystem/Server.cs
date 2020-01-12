// Copyright 2019. All Rights Reserved.
using Backend.Common;

namespace Backend.Base.ConfigSystem
{
	public struct Server
	{
		public struct Socket
		{
			public string Host;
			public ushort[] Ports;
			public ProtocolTypes Protocol;
		}

		public struct Module
		{
			public struct File
			{
				public string FilePath;
			}

			public string LibrariesPath;
			public File[] Files;
		}

		public struct Logger
		{
			public enum Types
			{
				Console = 0,
				File = 1
			}

			public enum Levels
			{
				Info = 0,
				Warning = 1,
				Error = 2,
				Debug = 3,
				Critical = 4
			}

			public Types Type;
			public Levels MinimumLevel;
			public string Path;
		}

		public Socket[] Sockets;
		public Module Modules;
		public Logger[] Loggers;
	}
}