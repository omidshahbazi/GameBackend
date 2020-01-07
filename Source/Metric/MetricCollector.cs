// Copyright 2019. All Rights Reserved.
using Backend.Base;
using Backend.Base.Metric;
using Backend.Base.ModuleSystem;
using Backend.Base.NetworkSystem;
using Microsoft.VisualBasic.Devices;
using System.Diagnostics;

namespace Backend.Metric
{
	//https://www.digitalocean.com/community/tutorials/an-introduction-to-metrics-monitoring-and-alerting
	//CPU
	//Memory
	//Disk space
	//Processes
	//Performance and latency of responses
	//Connectivity
	//Error rates and packet loss
	//Latency
	//Bandwidth utilization

	class MetricCollector : IModule
	{
		private IContext context = null;
		private PerformanceCounter cpuUsageCounter = null;
		private ComputerInfo computerInfo = null;

		public void Initialize(IContext Context, object Config)
		{
			context = Context;

			cpuUsageCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
			computerInfo = new ComputerInfo();


			context.RequestManager.RegisterHandler<GetMetricsReq, GetMetricsRes>(GetMetrics);
		}

		public void Service()
		{
		}

		public void Shutdown()
		{
		}

		private GetMetricsRes GetMetrics(Client Client, GetMetricsReq Data)
		{
			GetMetricsRes res = new GetMetricsRes();

			res.CPUUsage = cpuUsageCounter.NextValue() / 100;
			res.MemoryUsage = 1 - (computerInfo.AvailablePhysicalMemory / (float)computerInfo.TotalPhysicalMemory);

			SocketInfo[] sockets = context.NetworkManager.Sockets;
			RequestsStatistics[] stats = context.RequestManager.Statistics;
			res.SocketsMetric = new GetMetricsRes.SocketMetric[stats.Length];

			for (int i = 0; i < stats.Length; ++i)
			{
				SocketInfo socket = sockets[i];
				RequestsStatistics stat = stats[i];
				GetMetricsRes.SocketMetric metric = res.SocketsMetric[i] = new GetMetricsRes.SocketMetric();

				metric.Protocol = socket.Protocol;
				metric.Port = (ushort)socket.LocalEndPoint.Port;

				metric.IncomingTraffic = socket.IncomingTraffic;
				metric.OutgoingTraffic = socket.OutgoingTraffic;

				metric.ClientCount = socket.ClientCount;

				metric.IncomingMessageCount = stat.IncomingMessageCount;
				metric.OutgoingMessageCount = stat.OutgoingMessageCount;
				metric.IncomingInvalidMessageCount = stat.IncomingInvalidMessageCount;
				metric.IncomingFailedMessageCount = stat.IncomingFailedMessageCount;
			}

			return res;
		}
	}
}