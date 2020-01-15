// Copyright 2019. All Rights Reserved.
//#define COPY_ASSEMBLY_TO_TEMP
using Backend.Base.ConfigSystem;
using Backend.Base.ModuleSystem;
using Backend.Core.ConfigSystem;
using Backend.Core.LogSystem;
using GameFramework.Common.MemoryManagement;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

using FileSystem = GameFramework.Common.FileLayer.FileSystem;

namespace Backend.Core.ModuleSystem
{
	class ModuleManager : Singleton<ModuleManager>, IService
	{
		private class AssemblyMap : Dictionary<string, Assembly>
		{ }

#if COPY_ASSEMBLY_TO_TEMP
		private const string TEMP_ROOT_DIRECOTRY = "TempAssemblies/";
#endif

		private const string DLL_EXTENSION = ".dll";

#if COPY_ASSEMBLY_TO_TEMP
		private string tempDirectory = "";
#endif

		private AssemblyMap assemblies = null;
		private List<IModule> modules = null;

		private ModuleManager()
		{
		}

		public void Initialize()
		{
			InitializeAssemblyCache();
			modules = new List<IModule>();

#if COPY_ASSEMBLY_TO_TEMP
			tempDirectory = Path.Combine(TEMP_ROOT_DIRECOTRY, DateTime.Now.ToString("yyyyMMddhhmmss"));

			FileSystem.CreateDirectory(tempDirectory);
#endif

			LoadLibraries();

			LoadModules();
		}

		public void Shutdown()
		{
			// We do not clear loaded assemblys, because we cannot unload them, so will face to type confilicts and/or mismatch in cast

			for (int i = 0; i < modules.Count; ++i)
				modules[i].Shutdown();
		}

		public void Service()
		{
			for (int i = 0; i < modules.Count; ++i)
				modules[i].Service();
		}

		private void InitializeAssemblyCache()
		{
			assemblies = new AssemblyMap();

			Assembly[] loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();
			for (int i = 0; i < loadedAssemblies.Length; ++i)
			{
				Assembly assembly = loadedAssemblies[i];

				string path = assembly.Location;
				//path = path.Replace('\\', '/');
				//path = path.Replace(FileSystem.DataPath, "");
				path = Path.GetFileName(path);

				assemblies[path] = assembly;
			}
		}

		private void LoadLibraries()
		{
			string librariesPath = ConfigManager.Instance.Server.Modules.LibrariesPath;
			if (string.IsNullOrEmpty(librariesPath))
			{
				LogManager.Instance.WriteWarning("Libraries path is empty, so ignore loading libraries");
				return;
			}

			string[] files = FileSystem.GetFiles(librariesPath, "*" + DLL_EXTENSION, SearchOption.AllDirectories);
			if (files == null)
			{
				LogManager.Instance.WriteWarning("Directory [{0}] doesn't exsits, so ignore loading libraries", librariesPath);
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
			//FilePath = FilePath.Replace('\\', '/');

			AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

			Assembly assembly = null;

			try
			{
				assembly = LoadAssemblyFromFile(FilePath);
				if (assembly == null)
				{
					LogManager.Instance.WriteError("Assembly [{0}] doesn't exsits", FilePath);
					goto FinishUp;
				}

				object configInstance = null;
				ConfigManager.Instance.LoadConfig(Path.ChangeExtension(FilePath, "json"), out configInstance);

				Type[] types = null;
				try
				{
					types = assembly.GetTypes();
				}
				catch (ReflectionTypeLoadException)
				{
					LogManager.Instance.WriteWarning("Loading assembly [{0}] aborted beacuse of one of it's dependency couldn't loaded", FilePath);

					goto FinishUp;
				}

				Type moduleInterfaceType = typeof(IModule);

				for (int i = 0; i < types.Length; ++i)
				{
					Type type = types[i];

					if (type.IsInterface || !moduleInterfaceType.IsAssignableFrom(type))
						continue;

					IModule module = (IModule)Activator.CreateInstance(type);

					if (module == null)
					{
						LogManager.Instance.WriteError("Couldn't create an instance of type [{0}] as IModule", type.ToString());

						continue;
					}

					module.Initialize(Application.Instance, configInstance);

					LogManager.Instance.WriteInfo("An instance of type [{0}] initialized successfully", type.ToString());

					modules.Add(module);
				}

				LogManager.Instance.WriteInfo("Assembly [{0}] loaded successfully", FilePath);

				goto FinishUp;
			}
			catch (Exception e)
			{
				LogManager.Instance.WriteException(e, "Loading assembly [{0}] failed", FilePath);
			}

		FinishUp:
			AppDomain.CurrentDomain.AssemblyResolve -= CurrentDomain_AssemblyResolve;

			return assembly;
		}

		private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
		{
			string assemblyFileName = args.Name.Split(',')[0] + DLL_EXTENSION;
			string depFilePath = Path.GetDirectoryName(ConfigManager.Instance.Server.Modules.LibrariesPath);//.Replace('\\', '/');

			string[] files = FileSystem.GetFiles(depFilePath, assemblyFileName, SearchOption.AllDirectories);

			if (files == null || files.Length == 0)
				return null;

			Assembly assembly = LoadAssemblyFromFile(files[0]);//.Replace('\\', '/'));
			if (assembly == null)
			{
				LogManager.Instance.WriteError("Dependency assembly [{0}] doesn't exsits", depFilePath);

				return null;
			}

			return assembly;
		}

		private Assembly LoadAssemblyFromFile(string FilePath)
		{
			string path = CopyAndGetPath(FilePath);
			string fileName = Path.GetFileName(path);

			if (assemblies.ContainsKey(fileName))
				return assemblies[fileName];

			byte[] assemblyData = FileSystem.ReadBytes(path);
			if (assemblyData == null)
				return null;

			Assembly assembly = Assembly.Load(assemblyData);

			assemblies[fileName] = assembly;

			return assembly;
		}

		private string CopyAndGetPath(string FilePath)
		{
#if COPY_ASSEMBLY_TO_TEMP
			string fileName = Path.GetFileName(FilePath);

			string toPath = Path.Combine(tempDirectory, fileName);//.Replace('\\', '/');

			FileSystem.CopyFile(FilePath, toPath, true);

			return toPath;
#else
			return FilePath;
#endif
		}
	}
}