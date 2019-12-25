// Copyright 2019. All Rights Reserved
using Backend.Base;
using Backend.Base.ModuleSystem;
using Backend.Base.NetworkSystem;

namespace ServerTest
{
	public class Handlers : IModule
	{
		public void Initialize(IContext Context)
		{
			//Context.RequestManager.RegisterHandler<GetInitialDataReq, GetInitialDataRes>(GetInitialData);

			Context.Logger.WriteInfo("ServerTest initialized successfully");
		}

		public void Service()
		{
		}

		public void Shutdown()
		{
		}

		private GetInitialDataRes GetInitialData(Client Client, GetInitialDataReq Arg)
		{
			return null;
		}
	}
}