// Copyright 2019. All Rights Reserved.
using GameFramework.ASCIISerializer;

namespace Backend.Base.ModuleSystem
{
	public interface IModule
	{
		void Initialize(IContext Context, ISerializeData Config);
		void Shutdown();

		void Service();
	}
}