// Copyright 2019. All Rights Reserved.
using Backend.Base;
using Backend.Base.ModuleSystem;
using Backend.Base.NetworkSystem;
using Backend.Common.Chat;
using System.Collections.Generic;

namespace Backend.Chat
{
	class ChatHandler : IModule
	{
		private class ClientMap : Dictionary<uint, IClient>
		{ }

		private IContext context = null;
		private ClientMap clients = null;

		public void Initialize(IContext Context, object Config)
		{
			context = Context;
			clients = new ClientMap();

			context.NetworkManager.OnClientDisconnected += NetworkManager_OnClientDisconnected;
			context.RequestManager.RegisterHandler<RegisterReq>(HandlerRegister);
			context.RequestManager.RegisterHandler<SendChatToClientReq>(HandleSendChatToClient);
		}

		private void NetworkManager_OnClientDisconnected(IClient Client)
		{
			if (clients.ContainsKey(Client.ID))
				clients.Remove(Client.ID);
		}

		public void Service()
		{
		}

		public void Shutdown()
		{
		}

		private void HandlerRegister(IClient Client, RegisterReq Data)
		{
			clients[Client.ID] = Client;
		}

		private void HandleSendChatToClient(IClient Client, SendChatToClientReq Data)
		{
			if (Client.ID == Data.ID)
				return;

			if (!clients.ContainsKey(Data.ID))
				return;

			IClient targetClient = clients[Data.ID];

			context.RequestManager.Send(targetClient, new ChatReceivedFromClientReq() { ID = Client.ID, Content = Data.Content });
		}
	}
}