// Copyright 2019. All Rights Reserved.
using GameFramework.BinarySerializer;
using System;
using System.Collections.Generic;
using System.IO;

namespace Backend.Common.NetworkSystem
{
	class ClientRequestManager
	{
		private class RequestMap : Dictionary<uint, Action<object>>
		{ }

		private uint lastID = 0;
		private Connection connection = null;
		private RequestMap handlers = null;
		private RequestMap callbacks = null;

		public ClientRequestManager(Connection Connection)
		{
			connection = Connection;
			handlers = new RequestMap();
			callbacks = new RequestMap();
		}

		public void RegisterHandler<ArgT>(Action<ArgT> Handler)
			where ArgT : class
		{
			uint typeID = MessageCreator.Instance.Register<ArgT>();

			handlers[typeID] = (arg) =>
			{
				Handler((ArgT)arg);
			};
		}

		public void Send<ArgT>(ArgT Argument, Action OnCompleted = null)
			where ArgT : class
		{
			++lastID;

			MessageCreator.Instance.Register<ArgT>();

			BufferStream buffer = new BufferStream(new MemoryStream());
			if (!MessageCreator.Instance.Serialize(lastID, Argument, buffer))
				return;

			connection.WriteBuffer(buffer.Buffer, 0, buffer.Size);

			if (OnCompleted != null)
				callbacks[lastID] = (arg) =>
				{
					OnCompleted();
				};
		}

		public void Send<ArgT, ResT>(ArgT Argument, Action<ResT> OnCompleted = null)
			where ArgT : class
			where ResT : class
		{
			++lastID;

			MessageCreator.Instance.Register<ArgT>();
			MessageCreator.Instance.Register<ResT>();

			BufferStream buffer = new BufferStream(new MemoryStream());
			if (!MessageCreator.Instance.Serialize(lastID, Argument, buffer))
				return;

			connection.WriteBuffer(buffer.Buffer, 0, buffer.Size);

			if (OnCompleted != null)
				callbacks[lastID] = (arg) =>
				{
					OnCompleted((ResT)arg);
				};
		}

		public void DispatchBuffer(BufferStream Buffer)
		{
			uint id;
			uint typeID;
			object obj = MessageCreator.Instance.Deserialize(Buffer, out id, out typeID);

			bool isReply = (id != 0);

			if (!isReply && obj == null)
				return;

			try
			{
				if (isReply)
				{
					if (callbacks.ContainsKey(id))
					{
						callbacks[id](obj);

						callbacks.Remove(id);
					}
				}
				else
					handlers[typeID](obj);
			}
			catch (Exception e)
			{
				throw e;
			}
		}
	}
}