// Copyright 2019. All Rights Reserved.
namespace Backend.Common.Chat
{
	public class RegisterReq
	{
	}

	public class SendChatToClientReq
	{
		public uint ID;
		public string Content;
	}

	public class ChatReceivedFromClientReq
	{
		public uint ID;
		public string Content;
	}
}