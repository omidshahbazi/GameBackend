// Copyright 2019. All Rights Reserved.
using Backend.Base.ConfigManager;
using GameFramework.ASCIISerializer;
using GameFramework.Common.FileLayer;
using GameFramework.Common.MemoryManagement;
using System;

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
				throw new Exception("Couldn't loaded file [" + FILE_PATH + "]");

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
	}
}