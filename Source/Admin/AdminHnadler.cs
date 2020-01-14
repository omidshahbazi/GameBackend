// Copyright 2019. All Rights Reserved.
using Backend.Base;
using Backend.Base.Admin;
using Backend.Base.ModuleSystem;
using Backend.Base.NetworkSystem;
using System.Diagnostics;
using System.Collections.Generic;
using GameFramework.Common.Utilities;
#if NET_FRAMEWORK
using Microsoft.VisualBasic.Devices;
#endif

namespace Backend.Admin
{
	//https://www.digitalocean.com/community/tutorials/an-introduction-to-metrics-monitoring-and-alerting
	class AdminHnadler : IModule
	{
		private class AuditClientMap : Dictionary<uint, Client>
		{ }

		private IContext context = null;
		private Base.ConfigSystem.Admin config;
		private PerformanceCounter cpuUsageCounter = null;

		private AuditClientMap auditClients = null;

#if NET_FRAMEWORK
		private ComputerInfo computerInfo = null;
#endif

		public void Initialize(IContext Context, object Config)
		{
			context = Context;

			if (Config == null)
			{
				context.Logger.WriteError("Admin config is null, ignore initializing");
				return;
			}

			config = (Base.ConfigSystem.Admin)Config;

			cpuUsageCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

#if NET_FRAMEWORK
			computerInfo = new ComputerInfo();
#endif

			auditClients = new AuditClientMap();

			context.RequestManager.RegisterHandler<LoginReq, LoginRes>(HandleLogin);
			context.RequestManager.RegisterHandler<ShutdownReq>(HandlerShutdown);
			context.RequestManager.RegisterHandler<RestartReq>(HandlerRestart);
			context.RequestManager.RegisterHandler<UpdateServerConfigsReq>(HandleUpdateServerConfigs);
			context.RequestManager.RegisterHandler<GetMetricsReq, GetMetricsRes>(HandleGetMetrics);
		}

		public void Service()
		{
		}

		public void Shutdown()
		{
		}

		private LoginRes HandleLogin(Client Client, LoginReq Data)
		{
			LoginRes res = new LoginRes();
			res.Result = false;

			if (config.Users != null)
				for (int i = 0; i < config.Users.Length; ++i)
				{
					if (config.Users[i].Username == Data.Username &&
						config.Users[i].Password == Data.Password)
					{
						res.Result = true;
						break;
					}
				}

			if (res.Result)
			{
				uint hash = CRC32.CalculateHash(System.Text.Encoding.ASCII.GetBytes(Data.Username + Data.Password));

				if (auditClients.ContainsKey(hash))
				{
					Client client = auditClients[hash];

					context.RequestManager.Send(client, new Logout());
				}

				auditClients[hash] = Client;
			}

			return res;
		}

		private void HandlerShutdown(Client Client, ShutdownReq Data)
		{
			if (!CheckAuditClient(Client))
				return;

			context.ScheduleForShutdown();
		}

		private void HandlerRestart(Client Client, RestartReq Data)
		{
			if (!CheckAuditClient(Client))
				return;

			context.ScheduleForRestart();
		}

		private void HandleUpdateServerConfigs(Client Client, UpdateServerConfigsReq Data)
		{
			if (!CheckAuditClient(Client))
				return;

			context.ConfigManager.SaveConfig(Data.Config);
		}

		//separate to 3 request
		private GetMetricsRes HandleGetMetrics(Client Client, GetMetricsReq Data)
		{
			if (!CheckAuditClient(Client))
				return null;

			GetMetricsRes res = new GetMetricsRes();

			res.CPUUsage = cpuUsageCounter.NextValue() / 100;

#if NET_FRAMEWORK
			res.MemoryUsage = 1 - (computerInfo.AvailablePhysicalMemory / (float)computerInfo.TotalPhysicalMemory);
#endif

			GetMetricsRes.Metric totalMetric = res.TotalMetric = new GetMetricsRes.Metric();

			SocketInfo[] sockets = context.NetworkManager.Sockets;
			RequestsStatistics[] socketStats = context.RequestManager.SocketStatistics;
			res.SocketsMetric = new GetMetricsRes.SocketMetric[socketStats.Length];

			double totalProcessTime = 0;

			int i = 0;
			for (; i < socketStats.Length; ++i)
			{
				SocketInfo socket = sockets[i];
				RequestsStatistics socketStat = socketStats[i];
				GetMetricsRes.SocketMetric metric = res.SocketsMetric[i] = new GetMetricsRes.SocketMetric();

				metric.Protocol = socket.Protocol;
				metric.Port = (ushort)socket.LocalEndPoint.Port;

				metric.IncomingTraffic = socket.IncomingTraffic;
				metric.OutgoingTraffic = socket.OutgoingTraffic;

				metric.ClientCount = socket.ClientCount;

				AddMetric(metric, socketStat);
				AddMetric(totalMetric, socketStat);

				totalProcessTime += socketStat.TotalProcessTime;
			}

			if (totalMetric.IncomingMessageCount != 0)
				totalMetric.AverageProcessTime = (float)(totalProcessTime / totalMetric.IncomingMessageCount);

			RequestStatisticsMap requestStats = context.RequestManager.RequestStatistics;
			res.RequestsMetric = new GetMetricsRes.RequestMetric[requestStats.Count];

			RequestStatisticsMap.Enumerator requestStatIt = requestStats.GetEnumerator();
			i = 0;
			while (requestStatIt.MoveNext())
			{
				GetMetricsRes.RequestMetric metric = res.RequestsMetric[i++] = new GetMetricsRes.RequestMetric();

				metric.Type = requestStatIt.Current.Key.Name;

				AddMetric(metric, requestStatIt.Current.Value);
			}

			return res;
		}

		private void AddMetric(GetMetricsRes.Metric Metric, RequestsStatistics Stats)
		{
			Metric.IncomingMessageCount += Stats.IncomingMessageCount;
			Metric.OutgoingMessageCount += Stats.OutgoingMessageCount;
			Metric.IncomingInvalidMessageCount += Stats.IncomingInvalidMessageCount;
			Metric.IncomingFailedMessageCount += Stats.IncomingFailedMessageCount;

			if (Stats.IncomingMessageCount != 0)
				Metric.AverageProcessTime += (float)(Stats.TotalProcessTime / Stats.IncomingMessageCount);
		}

		private bool CheckAuditClient(Client Client)
		{
			bool isAudit = auditClients.ContainsValue(Client);

			if (!isAudit)
			{
				context.Logger.WriteWarning("Not audited client [{0}] tried to send administration request, going to disconnect", Client);

				Client.Disconnect();
			}

			return isAudit;
		}
	}
}