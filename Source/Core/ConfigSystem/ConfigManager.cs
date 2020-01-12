// Copyright 2019. All Rights Reserved.
using Backend.Base.ConfigSystem;
using GameFramework.ASCIISerializer;
using GameFramework.Common.FileLayer;
using GameFramework.Common.MemoryManagement;
using System;
using System.Collections.Generic;

namespace Backend.Core.ConfigSystem
{
	class ConfigManager : Singleton<ConfigManager>, IService
	{
		private const string FILE_PATH = "Configs/Server.json";
		private const string CONFIG_STRUCT_TYPE_KEY_NAME = "ConfigStructType";

		private class TypePathMap : Dictionary<Type, string>
		{ }

		private TypePathMap typePaths;
		public Server Server;

		private ConfigManager()
		{
		}

		public void Initialize()
		{
			typePaths = new TypePathMap();

			if (!LoadConfig(FILE_PATH, out Server))
				BuildSampleServerConfig();
		}

		public void Shutdown()
		{
		}

		public void Service()
		{
		}

		public void SaveServerConfig()
		{
			SaveConfig(Server);
		}

		public bool LoadConfig<T>(string FilePath, out T Config)
		{
			Config = default(T);

			string configFileContent = FileSystem.Read(FilePath);

			if (string.IsNullOrEmpty(configFileContent))
				return false;

			ISerializeObject configData = Creator.Create<ISerializeObject>(configFileContent);

			if (!configData.Contains(CONFIG_STRUCT_TYPE_KEY_NAME))
				return false;

			Type configType = Type.GetType(configData.Get<string>(CONFIG_STRUCT_TYPE_KEY_NAME), true, true);
			if (configType == null)
				return false;

			typePaths[configType] = FilePath;

			Config = (T)Creator.Bind(configType, configData);

			return true;
		}

		public bool SaveConfig<T>(T Config)
		{
			Type configType = Config.GetType();

			if (!typePaths.ContainsKey(configType))
				return false;

			string path = typePaths[configType];

			FileSystem.Write(path, Creator.Serialize<ISerializeObject>(Config).Content);

			return true;
		}

		private void BuildSampleServerConfig()
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

			Server.Loggers = new Server.Logger[1];
			Server.Loggers[0] = new Server.Logger();
			Server.Loggers[0].Type = Server.Logger.Types.Console;
			Server.Loggers[0].MinimumLevel = Server.Logger.Levels.Info;

			SaveServerConfig();
		}
	}
}