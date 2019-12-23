// Copyright 2019. All Rights Reserved.
using Backend.Base;
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
			{
				Application.Instance.Logger.WriteWarning("Libraries path is empty, so ignore loading libraries");
				return;
			}

			string[] files = FileSystem.GetFiles(librariesPath, "*.dll", SearchOption.AllDirectories);
			if (files == null)
			{
				Application.Instance.Logger.WriteError("Directory [{0}] doesn't exsits", librariesPath);
				return;
			}

			for (int i = 0; i < files.Length; ++i)
				LoadAssembly(files[i]);
		}

		private void LoadModules()
		{
			Server.Module.File[] files = Configs.Instance.Server.Modules.Files;
			if (files == null)
			{
				Application.Instance.Logger.WriteError("Module files is empty, so ignore loading modules");
				return;
			}

			for (int i = 0; i < files.Length; ++i)
				LoadAssembly(files[i].Path);
		}

		private void LoadAssembly(string FilePath)
		{
			Application.Instance.Logger.WriteInfo("Loading assembly [{0}]", FilePath);

			IContext context = Application.Instance;

			try
			{
				byte[] assemblyData = FileSystem.ReadBytes(FilePath);
				if (assemblyData == null)
				{
					Application.Instance.Logger.WriteError("Assembly [{0}] doesn't exsits", FilePath);
					return;
				}

				Assembly assembly = Assembly.Load(assemblyData);

				Type[] types = assembly.GetExportedTypes();

				Type moduleInterfaceType = typeof(IModule);

				for (int i = 0; i < types.Length; ++i)
				{
					Type type = types[i];

					if (!moduleInterfaceType.IsAssignableFrom(type))
						continue;

					Application.Instance.Logger.WriteInfo("|_Creating instance of type [{0}]", type.ToString());

					IModule module = (IModule)Activator.CreateInstance(type);

					if (module == null)
					{
						context.Logger.WriteError("Couldn't create instance of type [{0}] as IModule", type.ToString());

						continue;
					}

					module.Initialize(context);

					Application.Instance.Logger.WriteInfo("	|_Instance of type [{0}] initialized successfully", type.ToString());
				}
			}
			catch (Exception e)
			{
				context.Logger.WriteException("Loading assembly [" + FilePath + "] failed", e);
			}

			Application.Instance.Logger.WriteInfo("Assembly [{0}] loaded successfully", FilePath);
		}
	}
}