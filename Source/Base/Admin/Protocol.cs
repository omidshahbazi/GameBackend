// Copyright 2019. All Rights Reserved.
using Backend.Base.ConfigSystem;
using System.Net.Sockets;

namespace Backend.Base.Admin
{
	public class Metric
	{
		public ulong IncomingTraffic;
		public ulong OutgoingTraffic;

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
		public uint ClientCount;
	}

	public class RequestMetric : Metric
	{
		public string Type;
	}

	public class LoginReq
	{
		public string Username;
		public string Password;
	}

	public class LoginRes
	{
		public bool Result;
	}

	public class LogoutReq
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

	public class FetchFilesReq
	{
	}

	public class FetchFilesRes
	{
		public string[] FilePaths;
	}

	public class UploadFileReq
	{
		public string FilePath;
		public byte[] Content;
	}

	public class DeleteFileReq
	{
		public string FilePath;
	}

	public class GetTotalMetricsReq
	{
	}

	public class GetTotalMetricsRes
	{
		public float CPUUsage;
		public float MemoryUsage;
		public double UpTime;
		public uint ClientCount;
		public Metric TotalMetric;
	}

	public class GetDetailedSocketMetricsReq
	{
	}

	public class GetDetailedSocketMetricsRes
	{
		public SocketMetric[] SocketsMetric;
	}

	public class GetDetailedRequestMetricsReq
	{
	}

	public class GetDetailedRequestMetricsRes
	{
		public RequestMetric[] RequestsMetric;
	}
}