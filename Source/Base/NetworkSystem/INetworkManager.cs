// Copyright 2019. All Rights Reserved.
using System.Net;
using System.Net.Sockets;

namespace Backend.Base.NetworkSystem
{
	public class SocketInfo
	{
		public ProtocolType Protocol
		{
			get;
			private set;
		}

		public IPEndPoint LocalEndPoint
		{
			get;
			private set;
		}

		public SocketInfo(ProtocolType Protocol, IPEndPoint LocalEndPoint)
		{
			this.Protocol = Protocol;
			this.LocalEndPoint = LocalEndPoint;
		}
	}

	public interface INetworkManager
	{
		SocketInfo[] Sockets
		{
			get;
		}
	}
}