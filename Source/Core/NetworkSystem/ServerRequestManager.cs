// Copyright 2019. All Rights Reserved.
using Backend.Base.NetworkSystem;
using Backend.Common.NetworkSystem;
using Backend.Core.LogSystem;
using GameFramework.BinarySerializer;
using GameFramework.Common.MemoryManagement;
using GameFramework.Common.Timing;
using System;
using System.Collections.Generic;
using System.IO;

namespace Backend.Core.NetworkSystem
{
	class ServerRequestManager : Singleton<ServerRequestManager>, IRequestManager, IService
	{
		private class RequestMap : Dictionary<uint, Action<Client, uint, object>>
		{ }

		private class SocketStatisticsMap : Dictionary<uint, RequestsStatistics>
		{ }

		private RequestMap handlers = null;
		private SocketStatisticsMap socketStatistics = null;
		private RequestStatisticsMap requestStatistics = null;

		public RequestsStatistics[] SocketStatistics
		{
			get
			{
				SocketInfo[] sockets = NetworkManager.Instance.Sockets;
				RequestsStatistics[] stats = new RequestsStatistics[sockets.Length];

				for (int i = 0; i < sockets.Length; ++i)
				{
					SocketInfo info = sockets[i];
					RequestsStatistics originStat = socketStatistics[Client.GetSocketInfoHash(info.LocalEndPoint, info.Protocol)];

					RequestsStatistics stat = stats[i] = new RequestsStatistics();

					stat.IncomingMessageCount = originStat.IncomingMessageCount;
					stat.OutgoingMessageCount = originStat.OutgoingMessageCount;

					stat.IncomingInvalidMessageCount = originStat.IncomingInvalidMessageCount;
					stat.IncomingFailedMessageCount = originStat.IncomingFailedMessageCount;

					stat.TotalProcessTime = originStat.TotalProcessTime;
				}

				return stats;
			}
		}

		public RequestStatisticsMap RequestStatistics
		{
			get { return new RequestStatisticsMap(requestStatistics); }
		}

		private ServerRequestManager()
		{
		}

		public void Initialize()
		{
			handlers = new RequestMap();

			socketStatistics = new SocketStatisticsMap();
			SocketInfo[] sockets = NetworkManager.Instance.Sockets;
			for (int i = 0; i < sockets.Length; ++i)
			{
				SocketInfo info = sockets[i];

				socketStatistics[Client.GetSocketInfoHash(info.LocalEndPoint, info.Protocol)] = new RequestsStatistics();
			}

			requestStatistics = new RequestStatisticsMap();
		}

		public void Shutdown()
		{
			handlers.Clear();
			socketStatistics.Clear();
		}

		public void Service()
		{
		}

		public void RegisterHandler<ArgT>(Action<Client, ArgT> Handler)
			where ArgT : class
		{
			requestStatistics[typeof(ArgT)] = new RequestsStatistics();

			uint typeID = MessageCreator.Instance.Register<ArgT>();

			handlers[typeID] = (Client, ID, Argument) =>
			{
				Handler(Client, (ArgT)Argument);

				SendInternal(Client, ID, typeID, (object)null);

				RequestsStatistics stats = GetSocketStatistics(Client);
				++stats.OutgoingMessageCount;

				stats = GetRequestStatistics(typeof(ArgT));
				++stats.OutgoingMessageCount;
			};
		}

		public void RegisterHandler<ArgT, ResT>(Func<Client, ArgT, ResT> Handler)
			where ArgT : class
			where ResT : class
		{
			requestStatistics[typeof(ArgT)] = new RequestsStatistics();

			uint typeID = MessageCreator.Instance.Register<ArgT>();
			typeID += MessageCreator.Instance.Register<ResT>();

			handlers[typeID] = (Client, ID, Argument) =>
			{
				ResT res = Handler(Client, (ArgT)Argument);

				SendInternal(Client, ID, typeID, res);

				RequestsStatistics stats = GetSocketStatistics(Client);
				++stats.OutgoingMessageCount;

				stats = GetRequestStatistics(typeof(ArgT));
				++stats.OutgoingMessageCount;
			};
		}

		public void Send<ArgT>(Client Client, ArgT Argument)
			where ArgT : class
		{
			requestStatistics[typeof(ArgT)] = new RequestsStatistics();

			uint typeID = MessageCreator.Instance.Register<ArgT>();

			SendInternal(Client, 0, typeID, Argument);

			RequestsStatistics stats = GetSocketStatistics(Client);
			++stats.OutgoingMessageCount;

			stats = GetRequestStatistics(typeof(ArgT));
			++stats.OutgoingMessageCount;
		}

		public void DispatchBuffer(Client Client, BufferStream Buffer)
		{
			RequestsStatistics sockStats = GetSocketStatistics(Client);

			++sockStats.IncomingMessageCount;

			uint id = 0;
			uint requestTypeID = 0;
			object obj = null;
			try
			{
				obj = MessageCreator.Instance.Deserialize(Buffer, out id, out requestTypeID);
			}
			catch { }

			if (obj == null)
			{
				++sockStats.IncomingInvalidMessageCount;

				LogManager.Instance.WriteWarning("Client [{0}] sent an unknown packet, going to disconnect client", Client);

				Client.Disconnect();

				return;
			}

			RequestsStatistics reqStats = GetRequestStatistics(obj.GetType());
			if (reqStats != null)
				++reqStats.IncomingMessageCount;

			if (!handlers.ContainsKey(requestTypeID))
			{
				LogManager.Instance.WriteError("Invalid combinition with request [{0}] has been received from [{1}], going to disconnect client", obj.GetType(), Client);

				return;
			}

			try
			{
				double startTime = Time.CurrentEpochTime;

				handlers[requestTypeID](Client, id, obj);

				double processTime = Time.CurrentEpochTime - startTime;
				sockStats.TotalProcessTime += processTime;
				reqStats.TotalProcessTime += processTime;
			}
			catch (Exception e)
			{
				++sockStats.IncomingFailedMessageCount;
				if (reqStats != null)
					++reqStats.IncomingFailedMessageCount;

				LogManager.Instance.WriteException(e, "Dispatching [{0}] from [{1}] failed", obj.GetType(), Client);
			}
		}

		private void SendInternal<T>(Client Client, uint ID, uint RequestTypeID, T Argument)
			where T : class
		{
			BufferStream buffer = new BufferStream(new MemoryStream());

			if (!MessageCreator.Instance.Serialize(ID, RequestTypeID, Argument, buffer))
				return;

			Client.WriteBuffer(buffer.Buffer, 0, buffer.Size);
		}

		private RequestsStatistics GetSocketStatistics(Client Client)
		{
			if (socketStatistics.ContainsKey(Client.SocketHash))
				return socketStatistics[Client.SocketHash];

			return null;
		}

		private RequestsStatistics GetRequestStatistics(Type RequestType)
		{
			if (requestStatistics.ContainsKey(RequestType))
				return requestStatistics[RequestType];

			return null;
		}
	}
}