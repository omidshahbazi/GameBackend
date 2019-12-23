// Copyright 2019. All Rights Reserved.
namespace Backend.Base.Configs
{
	public struct Server
	{
		public struct Socket
		{
			public enum ProtocolTypes
			{
				TCP,
				UDP
			}

			public string Host;
			public ushort[] Ports;
			public ProtocolTypes Protocol;
		}

		public struct Module
		{
			public struct File
			{
				public string Path;
			}

			public string LibrariesPath;
			public File[] Files;
		}

		public struct Admin
		{
			public string Username;
			public string Password;
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
			public string FilePath;
		}

		public Socket[] Sockets;
		public Module Modules;
		public Admin[] Admins;
		public Logger[] Loggers;
	}
}