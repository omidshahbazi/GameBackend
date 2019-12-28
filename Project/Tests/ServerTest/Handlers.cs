// Copyright 2019. All Rights Reserved
using Backend.Base;
using Backend.Base.ModuleSystem;
using Backend.Base.NetworkSystem;
using GameFramework.ASCIISerializer;

namespace ServerTest
{
	public class Handlers : IModule
	{
		public void Initialize(IContext Context, ISerializeData Config)
		{
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
			return new GetInitialDataRes() { Data = "asdhkuhushdkbskbvabdsvdskjdskjnkcdasnnsckjdnkasjdnkcjnsakjcndskcnksdnckjdncjsdnkjcsnkjsdnckjsdnjcnwenoiejijdeoiwjdoiejwiiiiiijjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjj22" };
		}
	}
}