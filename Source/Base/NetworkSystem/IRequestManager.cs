// Copyright 2019. All Rights Reserved.
using System;
using System.Collections.Generic;

namespace Backend.Base.NetworkSystem
{
	public class RequestsStatistics
	{
		public ulong IncomingTraffic;
		public ulong OutgoingTraffic;

		public uint IncomingMessageCount;
		public uint OutgoingMessageCount;
		public uint IncomingInvalidMessageCount;
		public uint IncomingFailedMessageCount;

		public double TotalProcessTime;
	}

	public class RequestStatisticsMap : Dictionary<Type, RequestsStatistics>
	{
		public RequestStatisticsMap()
		{
		}

		public RequestStatisticsMap(RequestStatisticsMap Map) :
			base(Map)
		{
		}
	}

	public interface IRequestManager
	{
		RequestsStatistics[] SocketStatistics
		{
			get;
		}

		RequestStatisticsMap RequestStatistics
		{
			get;
		}

		void RegisterHandler<ArgT>(Action<Client, ArgT> Handler) where ArgT : class;

		void RegisterHandler<ArgT, ResT>(Func<Client, ArgT, ResT> Handler) where ArgT : class where ResT : class;

		void Send<T>(Client Client, T Argument) where T : class;
	}
}