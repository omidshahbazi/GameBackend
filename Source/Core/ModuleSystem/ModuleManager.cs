// Copyright 2019. All Rights Reserved.
using Backend.Base.ConfigManager;
using Backend.Base.ModuleSystem;
using Backend.Core.ConfigSystem;
using Backend.Core.LogSystem;
using GameFramework.Common.MemoryManagement;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Backend.Core.ModuleSystem
{
	class ModuleManager : Singleton<ModuleManager>, IService
	{
		private IModule[] modules = null;

		private ModuleManager()
		{
		}

		public void Initialize()
		{
			List<IModule> modulesList = new List<IModule>();

			LoadLibraries(modulesList);

			LoadModules(modulesList);

			modules = modulesList.ToArray();
		}

		public void Shutdown()
		{
			for (int i = 0; i < modules.Length; ++i)
				modules[i].Shutdown();
		}

		public void Service()
		{
			for (int i = 0; i < modules.Length; ++i)
				modules[i].Service();
		}

		private void LoadLibraries(List<IModule> Modules)
		{
			string librariesPath = ConfigManager.Instance.Server.Modules.LibrariesPath;
			if (string.IsNullOrEmpty(librariesPath))
			{
				LogManager.Instance.WriteWarning("Libraries path is empty, so ignore loading libraries");
				return;
			}

			string[] files = GameFramework.Common.FileLayer.FileSystem.GetFiles(librariesPath, "*.dll", SearchOption.AllDirectories);
			if (files == null)
			{
				LogManager.Instance.WriteError("Directory [{0}] doesn't exsits", librariesPath);
				return;
			}

			for (int i = 0; i < files.Length; ++i)
				LoadAssembly(files[i], Modules);
		}

		private void LoadModules(List<IModule> Modules)
		{
			Server.Module.File[] files = ConfigManager.Instance.Server.Modules.Files;
			if (files == null)
			{
				LogManager.Instance.WriteError("Module files is empty, so ignore loading modules");
				return;
			}

			for (int i = 0; i < files.Length; ++i)
				LoadAssembly(files[i].Path, Modules);
		}

		private void LoadAssembly(string FilePath, List<IModule> Modules)
		{
			LogManager.Instance.WriteInfo("Loading assembly [{0}]", FilePath);

			try
			{
				byte[] assemblyData = GameFramework.Common.FileLayer.FileSystem.ReadBytes(FilePath);
				if (assemblyData == null)
				{
					LogManager.Instance.WriteError("Assembly [{0}] doesn't exsits", FilePath);
					return;
				}

				Assembly assembly = Assembly.Load(assemblyData);

				Type[] types = assembly.GetTypes();

				Type moduleInterfaceType = typeof(IModule);

				for (int i = 0; i < types.Length; ++i)
				{
					Type type = types[i];

					if (!moduleInterfaceType.IsAssignableFrom(type))
						continue;

					LogManager.Instance.WriteInfo("	|_Creating instance of type [{0}]", type.ToString());

					IModule module = (IModule)Activator.CreateInstance(type);

					if (module == null)
					{
						LogManager.Instance.WriteError("Couldn't create instance of type [{0}] as IModule", type.ToString());

						continue;
					}

					module.Initialize(Application.Instance);

					LogManager.Instance.WriteInfo("		|_Instance of type [{0}] initialized successfully", type.ToString());

					Modules.Add(module);
				}

				LogManager.Instance.WriteInfo("Assembly [{0}] loaded successfully", FilePath);
			}
			catch (Exception e)
			{
				LogManager.Instance.WriteException("Loading assembly [" + FilePath + "] failed", e);
			}
		}
	}
}