// Copyright 2019. All Rights Reserved
using Backend.Base;
using Backend.Base.ModuleSystem;
using Backend.Base.NetworkSystem;

namespace ServerTest
{
	public class Handlers : IModule
	{
		private IContext context = null;

		public void Initialize(IContext Context, object Config)
		{
			context = Context;

			Context.RequestManager.RegisterHandler<GetInitialDataReq, GetInitialDataRes>(GetInitialData);
		}

		public void Service()
		{
		}

		public void Shutdown()
		{
		}

		private GetInitialDataRes GetInitialData(IClient Client, GetInitialDataReq Arg)
		{

			return new GetInitialDataRes() { Data = "xxxxxxxxxxxxxxxxxxxxxxxxxx" };
		}
	}
}