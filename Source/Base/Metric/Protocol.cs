// Copyright 2019. All Rights Reserved.
using System.Net.Sockets;

namespace Backend.Base.Metric
{
	public class GetMetricsReq
	{
	}

	public class GetMetricsRes
	{
		public class SocketMetric
		{
			public ProtocolType Protocol;
			public ushort Port;

			public ulong IncomingTraffic;
			public ulong OutgoingTraffic;

			public uint ClientCount;

			public ulong IncomingMessageCount;
			public ulong OutgoingMessageCount;
			public ulong IncomingInvalidMessageCount;
			public ulong IncomingFailedMessageCount;
		}

		public float CPUUsage;
		public float MemoryUsage;

		public SocketMetric[] SocketsMetric;
	}
}