// Copyright 2019. All Rights Reserved.
using Backend.Common.Chat;
using Backend.Common.NetworkSystem;
using System;

namespace Backend.Client
{
	public class ServerConnection : Connection
	{
		public void RegisterInChatService(Action<RegisterRes> OnComplete = null)
		{
			Send(new RegisterReq(), OnComplete);
		}
	}
}