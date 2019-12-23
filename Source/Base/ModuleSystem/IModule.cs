// Copyright 2019. All Rights Reserved.
namespace Backend.Base.ModuleSystem
{
	public interface IModule
	{
		void Initialize(IContext Context);
		void Shutdown();

		void Service();
	}
}