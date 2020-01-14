// Copyright 2019. All Rights Reserved.
using Backend.Base.ConfigSystem;
using GameFramework.ASCIISerializer;
using GameFramework.Common.FileLayer;
using GameFramework.Common.MemoryManagement;

namespace Backend.Core.ConfigSystem
{
	class ConfigManager : Singleton<ConfigManager>, IService
	{
		private const string FILE_PATH = "Configs/Server.json";

		public Server Server;

		private ConfigManager()
		{
		}

		public void Initialize()
		{
			string data = FileSystem.Read(FILE_PATH);

			if (string.IsNullOrEmpty(data))
				BuildSampleConfig();
			else
				Server = Creator.Create<Server>(data);
		}

		public void Shutdown()
		{
			Save();
		}

		public void Service()
		{
		}

		public void Save()
		{
			FileSystem.Write(FILE_PATH, Creator.Serialize<ISerializeObject>(Server).Content);
		}

		private void BuildSampleConfig()
		{
			Server = new Server();

			Server.Sockets = new Server.Socket[1];
			Server.Sockets[0] = new Server.Socket();
			Server.Sockets[0].Host = "::0";
			Server.Sockets[0].Protocol = Common.ProtocolTypes.TCP;
			Server.Sockets[0].Ports = new ushort[1];
			Server.Sockets[0].Ports[0] = 5000;

			Server.Modules = new Server.Module();
			Server.Modules.LibrariesPath = "Libraries/";
			Server.Modules.Files = new Server.Module.File[1];
			Server.Modules.Files[0] = new Server.Module.File();
			Server.Modules.Files[0].FilePath = "Sample.dll";

			Server.Admins = new Server.Admin[1];
			Server.Admins[0] = new Server.Admin();
			Server.Admins[0].Username = "admin";

			Server.Loggers = new Server.Logger[1];
			Server.Loggers[0] = new Server.Logger();
			Server.Loggers[0].Type = Server.Logger.Types.Console;
			Server.Loggers[0].MinimumLevel = Server.Logger.Levels.Info;

			Save();
		}
	}
}