// Copyright 2019. All Rights Reserved.
namespace Backend.Core
{
	interface IService
	{
		void Initialize();
		void Shutdown();

		void Service();
	}
}