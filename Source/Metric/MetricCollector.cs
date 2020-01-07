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

			byte[] b = new byte[1024 * 1024 * 1024];
		}

		public void Service()
		{
			GetMetrics(null, null);
		}

		public void Shutdown()
		{
		}

		private GetMetricsRes GetMetrics(Client Client, GetMetricsReq Data)
		{
			GetMetricsRes res = new GetMetricsRes();

			res.CPUUsage = cpuUsageCounter.NextValue() / 100;
			res.MemoryUsage = 1 - (computerInfo.AvailablePhysicalMemory / (float)computerInfo.TotalPhysicalMemory);

			RequestsStatistics[] stats = context.RequestManager.Statistics;
			res.SocketsMetric = new GetMetricsRes.SocketMetric[stats.Length];

			for (int i = 0; i < stats.Length; ++i)
			{
				RequestsStatistics stat = stats[i];
				GetMetricsRes.SocketMetric metric = res.SocketsMetric[0] = new GetMetricsRes.SocketMetric();

				//metric.IncomingTraffic = 
				//metric.OutgoingTraffic;

				//metric.ClientCount = 

				metric.IncomingMessageCount = stat.IncomingMessageCount;
				metric.OutgoingMessageCount = stat.OutgoingMessageCount;
				metric.IncomingInvalidMessageCount = stat.IncomingInvalidMessageCount;
				metric.IncomingFailedMessageCount = stat.IncomingFailedMessageCount;
			}

			return res;
		}
	}
}