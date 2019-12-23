// Copyright 2019. All Rights Reserved.
namespace Backend.Base.Module
{
	public interface IModule
	{
		void Initialize(IContext Context);
		void Shutdown();

		void Service();
	}
}