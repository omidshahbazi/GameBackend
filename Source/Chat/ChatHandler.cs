// Copyright 2019. All Rights Reserved.
using Backend.Base;
using Backend.Base.ModuleSystem;

namespace Backend.Chat
{
	class ChatHandler : IModule
	{
		private IContext context = null;

		public void Initialize(IContext Context, object Config)
		{
			context = Context;
		}

		public void Service()
		{
		}

		public void Shutdown()
		{
		}
	}
}