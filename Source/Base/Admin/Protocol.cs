// Copyright 2019. All Rights Reserved.
using Backend.Base.ConfigSystem;
using System.Net.Sockets;

namespace Backend.Base.Admin
{
	public class LoginReq
	{
		public string Username;
		public string Password;
	}

	public class LoginRes
	{
		public bool Result;
	}

	public class Logout
	{
	}

	public class ShutdownReq
	{
	}

	public class RestartReq
	{
	}

	public class UpdateServerConfigsReq
	{
		public Server Config;
	}

	public class GetMetricsReq
	{
	}

	public class GetMetricsRes
	{
		public class Metric
		{
			public ulong IncomingMessageCount;
			public ulong OutgoingMessageCount;
			public ulong IncomingInvalidMessageCount;
			public ulong IncomingFailedMessageCount;

			public float AverageProcessTime;
		}

		public class SocketMetric : Metric
		{
			public ProtocolType Protocol;
			public ushort Port;

			public ulong IncomingTraffic;
			public ulong OutgoingTraffic;

			public uint ClientCount;
		}

		public class RequestMetric : Metric
		{
			public string Type;
		}

		public float CPUUsage;
		public float MemoryUsage;

		public SocketMetric[] SocketsMetric;
		public RequestMetric[] RequeestsMetric;
	}
}