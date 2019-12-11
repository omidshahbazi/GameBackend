// Copyright 2019. All Rights Reserved.
using Backend.Base.Configs;
using Backend.Base.Module;
using GameFramework.Common.FileLayer;
using GameFramework.Common.MemoryManagement;
using System;
using System.IO;
using System.Reflection;

namespace Backend.Core
{
	class Modules : Singleton<Modules>
	{
		private Modules()
		{
		}

		public void Initialize()
		{
			LoadLibraries();

			LoadModules();
		}

		private void LoadLibraries()
		{
			string librariesPath = Configs.Instance.Server.Modules.LibrariesPath;

			if (string.IsNullOrEmpty(librariesPath))
				return;

			string[] files = FileSystem.GetFiles(librariesPath, "*.dll", SearchOption.AllDirectories);

			for (int i = 0; i < files.Length; ++i)
				LoadAssembly(files[i]);
		}

		private void LoadModules()
		{
			Server.Module.File[] files = Configs.Instance.Server.Modules.Files;

			for (int i = 0; i < files.Length; ++i)
				LoadAssembly(files[i].Path);
		}

		private void LoadAssembly(string FilePath)
		{
			try
			{
				Assembly assembly = Assembly.Load(FileSystem.ReadBytes(FilePath));

				Type[] types = assembly.GetExportedTypes();

				Type moduleInterfaceType = typeof(IModule);

				for (int i = 0; i < types.Length; ++i)
				{
					Type type = types[i];

					if (!moduleInterfaceType.IsAssignableFrom(type))
						continue;

					IModule module = (IModule)Activator.CreateInstance(type);

					if (module == null)
					{
						//TODO: Log
						continue;
					}

					module.Initialize();
				}
			}
			catch (Exception e)
			{
				//TODO: Log
			}
		}
	}
}