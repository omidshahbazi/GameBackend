// Copyright 2019. All Rights Reserved.
using Backend.Base;
using Backend.Base.ModuleSystem;
using Backend.Base.NetworkSystem;
using Backend.Common.Chat;

namespace Backend.Chat
{
	class ChatHandler : IModule
	{
		private IContext context = null;

		public void Initialize(IContext Context, object Config)
		{
			context = Context;

			context.RequestManager.RegisterHandler<RegisterReq, RegisterRes>(HandlerRegister);
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