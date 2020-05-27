// Copyright 2019. All Rights Reserved.
using System.Net;
using System.Net.Sockets;

namespace Backend.Base.NetworkSystem
{
	public delegate void ClientConnectionEventHandler(IClient Client);

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

		public ulong IncomingTraffic
		{
			get;
			private set;
		}

		public ulong OutgoingTraffic
		{
			get;
			private set;
		}

		public uint ClientCount
		{
			get;
			private set;
		}

		public SocketInfo(ProtocolType Protocol, IPEndPoint LocalEndPoint, ulong IncomingTraffic, ulong OutgoingTraffic, uint ClientCount)
		{
			this.Protocol = Protocol;
			this.LocalEndPoint = LocalEndPoint;
			this.IncomingTraffic = IncomingTraffic;
			this.OutgoingTraffic = OutgoingTraffic;
			this.ClientCount = ClientCount;
		}
	}

	public interface INetworkManager
	{
		SocketInfo[] Sockets
		{
			get;
		}

		event ClientConnectionEventHandler OnClientConnected;
		event ClientConnectionEventHandler OnClientDisconnected;
	}
}