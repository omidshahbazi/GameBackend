// Copyright 2019. All Rights Reserved.
using Backend.Common.NetworkSystem;
using Backend.Core.LogSystem;
using GameFramework.BinarySerializer;
using GameFramework.Common.MemoryManagement;
using System;
using System.Collections.Generic;
using System.IO;

namespace Backend.Core.NetworkSystem
{
	public class RequestManager : Singleton<RequestManager>
	{
		private class RequestMap : Dictionary<uint, Action<Client, uint, object>>
		{ }

		private RequestMap handlers = null;

		private RequestManager()
		{
			handlers = new RequestMap();
		}

		public void RegisterHandler<ArgT>(Action<Client, ArgT> Handler)
			where ArgT : class
		{
			uint typeID = MessageCreator.Instance.Register<ArgT>();

			handlers[typeID] = (Client, ID, Argument) =>
			{
				Handler(Client, (ArgT)Argument);

				//respond if ID != 0 with SendInternal
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

				if (res == null)
					return;

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
			uint id;
			uint typeID;
			object obj = MessageCreator.Instance.Deserialize(Buffer, out id, out typeID);
			if (obj == null)
				return;

			try
			{
				handlers[typeID](Client, id, obj);
			}
			catch (Exception e)
			{
				LogManager.Instance.WriteException("RequestManager", e);
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