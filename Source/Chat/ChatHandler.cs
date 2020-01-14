// Copyright 2019. All Rights Reserved.
using Backend.Base;
using Backend.Base.ModuleSystem;
using Backend.Base.NetworkSystem;
using Backend.Common.Chat;

namespace Backend.Chat
{
	class ChatHandler : IModule
	{
		//private class Client
		private IContext context = null;

		public void Initialize(IContext Context, object Config)
		{
			context = Context;

			context.NetworkManager.OnClientDisconnected += NetworkManager_OnClientDisconnected;
			context.RequestManager.RegisterHandler<RegisterReq, RegisterRes>(HandlerRegister);
		}

		private void NetworkManager_OnClientDisconnected(Client Client)
		{

		}

		public void Service()
		{
		}

		public void Shutdown()
		{
		}

		private RegisterRes HandlerRegister(Client Client, RegisterReq Data)
		{

			return null;
		}
	}
}