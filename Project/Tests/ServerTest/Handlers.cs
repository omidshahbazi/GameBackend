// Copyright 2019. All Rights Reserved
using Backend.Base;
using Backend.Base.ConnectionManager;
using Backend.Base.ModuleSystem;
using Backend.Base.NetworkSystem;
using GameFramework.ASCIISerializer;

namespace ServerTest
{
	public class Handlers : IModule
	{
		private IContext context = null;

		public void Initialize(IContext Context, ISerializeData Config)
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

		private GetInitialDataRes GetInitialData(Client Client, GetInitialDataReq Arg)
		{
			IConnection con = context.Database.Acquire();

			ISerializeArray arr = con.ExeeecuteWithReturnDataTable("show tables");


			con.Dispose();


			return new GetInitialDataRes() { Data = arr.Content };
		}
	}
}