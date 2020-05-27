// Copyright 2019. All Rights Reserved.
namespace Backend.Base.NetworkSystem
{
	public interface IClient
	{
		uint SocketHash
		{
			get;
		}

		uint ID
		{
			get;
		}

		void Disconnect();

		string ToString();
	}
}