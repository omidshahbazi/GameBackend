// Copyright 2019. All Rights Reserved.
using Backend.Base;
using Backend.Base.Admin;
using Backend.Base.ModuleSystem;
using Backend.Base.NetworkSystem;
using System.Diagnostics;
using System.Collections.Generic;
using GameFramework.Common.Utilities;
using System;
using GameFramework.Common.FileLayer;
using System.IO;
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
			context.RequestManager.RegisterHandler<FetchFilesReq, FetchFilesRes>(HandleFetchFiles);
			context.RequestManager.RegisterHandler<UploadFileReq>(HandleUploadFile);
			context.RequestManager.RegisterHandler<GetTotalSocketMetricsReq, GetTotalSocketMetricsRes>(HandleGetTotalSocketMetrics);
			context.RequestManager.RegisterHandler<GetDetailedSocketMetricsReq, GetDetailedSocketMetricsRes>(HandleGetDetailedSocketMetrics);
			context.RequestManager.RegisterHandler<GetDetailedRequestMetricsReq, GetDetailedRequestMetricsRes>(HandleGetDetailedRequestMetrics);
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

		private FetchFilesRes HandleFetchFiles(Client Client, FetchFilesReq Data)
		{
			if (!CheckAuditClient(Client))
				return null;

			List<string> files = new List<string>();

			if (config.UploadPaths != null)
				for (int i = 0; i < config.UploadPaths.Length; ++i)
				{
					string path = config.UploadPaths[i];

					string[] filesPaths = FileSystem.GetFiles(path);
				}

			return new FetchFilesRes() { FilePaths = files.ToArray() };
		}

		private void HandleUploadFile(Client Client, UploadFileReq Data)
		{
			if (!CheckAuditClient(Client))
				return;

			if (config.UploadPaths == null)
				return;

			string path = Path.GetDirectoryName(Data.FilePath).Replace('\\', '/');
			bool found = false;
			for (int i = 0; i < config.UploadPaths.Length; ++i)
			{
				string uploadPath = config.UploadPaths[i];
				if (uploadPath.Replace('\\', '/').EndsWith("/"))
					uploadPath = uploadPath.Substring(0, uploadPath.Length - 1);

				if (path != uploadPath)
					continue;

				found = true;
				break;
			}

			if (!found)
				return;

			FileSystem.Write(Data.FilePath, Data.Content);
		}

		private GetTotalSocketMetricsRes HandleGetTotalSocketMetrics(Client Client, GetTotalSocketMetricsReq Data)
		{
			if (!CheckAuditClient(Client))
				return null;

			GetTotalSocketMetricsRes res = new GetTotalSocketMetricsRes();

			res.CPUUsage = cpuUsageCounter.NextValue() / 100;

#if NET_FRAMEWORK
			res.MemoryUsage = 1 - (computerInfo.AvailablePhysicalMemory / (float)computerInfo.TotalPhysicalMemory);
#endif

			Metric totalMetric = res.TotalMetric = new Metric();

			RequestsStatistics[] socketStats = context.RequestManager.SocketStatistics;

			double totalProcessTime = 0;

			int i = 0;
			for (; i < socketStats.Length; ++i)
			{
				RequestsStatistics socketStat = socketStats[i];

				AddMetric(totalMetric, socketStat);

				totalProcessTime += socketStat.TotalProcessTime;
			}

			if (totalMetric.IncomingMessageCount != 0)
				totalMetric.AverageProcessTime = (float)(totalProcessTime / totalMetric.IncomingMessageCount);

			return res;
		}

		private GetDetailedSocketMetricsRes HandleGetDetailedSocketMetrics(Client Client, GetDetailedSocketMetricsReq Data)
		{
			if (!CheckAuditClient(Client))
				return null;

			GetDetailedSocketMetricsRes res = new GetDetailedSocketMetricsRes();

			SocketInfo[] sockets = context.NetworkManager.Sockets;
			RequestsStatistics[] socketStats = context.RequestManager.SocketStatistics;
			res.SocketsMetric = new SocketMetric[socketStats.Length];

			double totalProcessTime = 0;

			for (int i = 0; i < socketStats.Length; ++i)
			{
				SocketInfo socket = sockets[i];
				RequestsStatistics socketStat = socketStats[i];
				SocketMetric metric = res.SocketsMetric[i] = new SocketMetric();

				metric.Protocol = socket.Protocol;
				metric.Port = (ushort)socket.LocalEndPoint.Port;

				metric.IncomingTraffic = socket.IncomingTraffic;
				metric.OutgoingTraffic = socket.OutgoingTraffic;

				metric.ClientCount = socket.ClientCount;

				AddMetric(metric, socketStat);

				totalProcessTime += socketStat.TotalProcessTime;
			}

			return res;
		}

		private GetDetailedRequestMetricsRes HandleGetDetailedRequestMetrics(Client Client, GetDetailedRequestMetricsReq Data)
		{
			if (!CheckAuditClient(Client))
				return null;

			GetDetailedRequestMetricsRes res = new GetDetailedRequestMetricsRes();

			RequestStatisticsMap requestStats = context.RequestManager.RequestStatistics;
			res.RequestsMetric = new RequestMetric[requestStats.Count];

			RequestStatisticsMap.Enumerator requestStatIt = requestStats.GetEnumerator();
			int i = 0;
			while (requestStatIt.MoveNext())
			{
				RequestMetric metric = res.RequestsMetric[i++] = new RequestMetric();

				metric.Type = requestStatIt.Current.Key.Name;

				AddMetric(metric, requestStatIt.Current.Value);
			}

			return res;
		}

		private void AddMetric(Metric Metric, RequestsStatistics Stats)
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