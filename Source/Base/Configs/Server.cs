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

		public Socket[] Sockets;
		public Module Modules;
		public Admin[] Admins;
	}
}