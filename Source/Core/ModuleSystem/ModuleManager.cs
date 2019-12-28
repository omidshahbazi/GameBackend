// Copyright 2019. All Rights Reserved.
using Backend.Base.ConfigSystem;
using Backend.Base.ModuleSystem;
using Backend.Core.ConfigSystem;
using Backend.Core.LogSystem;
using GameFramework.ASCIISerializer;
using GameFramework.Common.MemoryManagement;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Backend.Core.ModuleSystem
{
	class ModuleManager : Singleton<ModuleManager>, IService
	{
		private const string DLL_EXTENSION = ".dll";

		private List<IModule> modules = null;

		private ModuleManager()
		{
		}

		public void Initialize()
		{
			AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

			modules = new List<IModule>();

			LoadLibraries();

			LoadModules();

			AppDomain.CurrentDomain.AssemblyResolve -= CurrentDomain_AssemblyResolve;
		}

		public void Shutdown()
		{
			for (int i = 0; i < modules.Count; ++i)
				modules[i].Shutdown();
		}

		public void Service()
		{
			for (int i = 0; i < modules.Count; ++i)
				modules[i].Service();
		}

		private void LoadLibraries()
		{
			string librariesPath = ConfigManager.Instance.Server.Modules.LibrariesPath;
			if (string.IsNullOrEmpty(librariesPath))
			{
				LogManager.Instance.WriteWarning("Libraries path is empty, so ignore loading libraries");
				return;
			}

			string[] files = GameFramework.Common.FileLayer.FileSystem.GetFiles(librariesPath, "*" + DLL_EXTENSION, SearchOption.AllDirectories);
			if (files == null)
			{
				LogManager.Instance.WriteError("Directory [{0}] doesn't exsits", librariesPath);
				return;
			}

			for (int i = 0; i < files.Length; ++i)
				LoadAssembly(files[i]);
		}

		private void LoadModules()
		{
			Server.Module.File[] files = ConfigManager.Instance.Server.Modules.Files;
			if (files == null)
			{
				LogManager.Instance.WriteError("Module files is empty, so ignore loading modules");
				return;
			}

			for (int i = 0; i < files.Length; ++i)
				LoadAssembly(files[i].FilePath);
		}

		private Assembly LoadAssembly(string FilePath)
		{
			try
			{
				byte[] assemblyData = GameFramework.Common.FileLayer.FileSystem.ReadBytes(FilePath);
				if (assemblyData == null)
				{
					LogManager.Instance.WriteError("Assembly [{0}] doesn't exsits", FilePath);
					return null;
				}

				Assembly assembly = Assembly.Load(assemblyData);

				ISerializeData configData = null;
				string configFileContent = GameFramework.Common.FileLayer.FileSystem.Read(Path.ChangeExtension(FilePath, "json"));
				if (!string.IsNullOrEmpty(configFileContent))
					configData = Creator.Create<ISerializeData>(configFileContent);

				Type[] types = assembly.GetTypes();

				Type moduleInterfaceType = typeof(IModule);

				for (int i = 0; i < types.Length; ++i)
				{
					Type type = types[i];

					if (!moduleInterfaceType.IsAssignableFrom(type))
						continue;

					IModule module = (IModule)Activator.CreateInstance(type);

					if (module == null)
					{
						LogManager.Instance.WriteError("Couldn't create an instance of type [{0}] as IModule", type.ToString());

						continue;
					}

					module.Initialize(Application.Instance, configData);

					LogManager.Instance.WriteInfo("An instance of type [{0}] initialized successfully", type.ToString());

					modules.Add(module);
				}

				LogManager.Instance.WriteInfo("Assembly [{0}] loaded successfully", FilePath);

				return assembly;
			}
			catch (Exception e)
			{
				LogManager.Instance.WriteException("Loading assembly [" + FilePath + "] failed", e);
			}

			return null;
		}

		private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
		{
			string depFilePath = Path.GetDirectoryName(ConfigManager.Instance.Server.Modules.LibrariesPath).Replace('\\', '/') + "/" + args.Name.Split(',')[0] + DLL_EXTENSION;

			if (!GameFramework.Common.FileLayer.FileSystem.FileExists(depFilePath))
				return null;

			return LoadAssembly(depFilePath);
		}
	}
}