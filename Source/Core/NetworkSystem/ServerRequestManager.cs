// Copyright 2019. All Rights Reserved.
using Backend.Base.NetworkSystem;
using Backend.Common.NetworkSystem;
using Backend.Core.LogSystem;
using GameFramework.BinarySerializer;
using GameFramework.Common.MemoryManagement;
using System;
using System.Collections.Generic;
using System.IO;

namespace Backend.Core.NetworkSystem
{
	class ServerRequestManager : Singleton<ServerRequestManager>, IRequestManager, IService
	{
		private class RequestMap : Dictionary<uint, Action<Client, uint, object>>
		{ }

		private RequestMap handlers = null;

		private ServerRequestManager()
		{
		}

		public void Initialize()
		{
			handlers = new RequestMap();
		}

		public void Shutdown()
		{
		}

		public void Service()
		{
		}

		public void RegisterHandler<ArgT>(Action<Client, ArgT> Handler)
			where ArgT : class
		{
			uint typeID = MessageCreator.Instance.Register<ArgT>();

			handlers[typeID] = (Client, ID, Argument) =>
			{
				Handler(Client, (ArgT)Argument);

				SendInternal(Client, ID, (object)null);
			};
		}

		public void RegisterHandler<ArgT, ResT>(Func<Client, ArgT, ResT> Handler)
			where ArgT : class
			where ResT : class
		{
			uint typeID = MessageCreator.Instance.Register<ArgT>();
			MessageCreator.Instance.Register<ResT>();

			handlers[typeID] = (Client, ID, Argument) =>
			{
				ResT res = Handler(Client, (ArgT)Argument);

				SendInternal(Client, ID, res);
			};
		}

		public void Send<T>(Client Client, T Argument)
			where T : class
		{
			SendInternal(Client, 0, Argument);
		}

		public void DispatchBuffer(Client Client, BufferStream Buffer)
		{
			uint id = 0;
			uint typeID = 0;
			object obj = null;
			try
			{
				obj = MessageCreator.Instance.Deserialize(Buffer, out id, out typeID);
			}
			catch { }

			if (obj == null)
			{
				LogManager.Instance.WriteWarning("Client [{0}] sent an unknown packet, going to disconnect", Client.ToString());

				Client.Disconnect();

				return;
			}

			try
			{
				handlers[typeID](Client, id, obj);
			}
			catch (Exception e)
			{
				LogManager.Instance.WriteException(e, "Dispatching [{0}] failed", obj.GetType());
			}
		}

		private void SendInternal<T>(Client Client, uint ID, T Argument)
			where T : class
		{
			MessageCreator.Instance.Register<T>();

			BufferStream buffer = new BufferStream(new MemoryStream());

			if (!MessageCreator.Instance.Serialize(ID, Argument, buffer))
				return;

			Client.WriteBuffer(buffer.Buffer, 0, buffer.Size);
		}
	}
}