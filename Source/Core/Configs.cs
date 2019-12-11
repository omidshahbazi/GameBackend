// Copyright 2019. All Rights Reserved.
using Backend.Base.Configs;
using GameFramework.ASCIISerializer;
using GameFramework.Common.FileLayer;
using GameFramework.Common.MemoryManagement;

namespace Backend.Core
{
	class Configs : Singleton<Configs>
	{
		private const string FILE_PATH = "Configs/Server.json";

		public Server Server;

		private Configs()
		{
		}

		public void Initialize()
		{
			string data = FileSystem.Read(FILE_PATH);

			Server = Creator.Create<Server>(data);
		}
	}
}