// Copyright 2019. All Rights Reserved.
using Backend.Common.NetworkSystem;
using Backend.Core.LogSystem;
using Backend.Core.NetworkSystem;
using GameFramework.BinarySerializer;
using GameFramework.Common.MemoryManagement;
using GameFramework.Common.Utilities;
using System;
using System.Collections.Generic;
using System.IO;

namespace Backend.Core.NetworkSystem
{
	class RequestManager : Singleton<RequestManager>
	{
		private class RequestMap : Dictionary<uint, Action<Client, object>>
		{ }

		private RequestMap requests = null;

		private RequestManager()
		{
			requests = new RequestMap();
		}

		public void RegisterHandler<ArgT, ResT>(Func<Client, ArgT, ResT> Handler)
			where ArgT : class
			where ResT : class
		{
			uint typeID = MessageCreator.Instance.Register<ArgT>();
			MessageCreator.Instance.Register<ResT>();

			requests[typeID] = (Client, Argument) =>
			{
				try
				{
					ResT res = Handler(Client, (ArgT)Argument);

					if (res == null)
						return;

					BufferStream buffer = new BufferStream(new MemoryStream());
					if (!MessageCreator.Instance.Serialize(res, buffer))
						return;

					Client.WriteBuffer(buffer.Buffer);
				}
				catch (Exception e)
				{
					LogManager.Instance.WriteException("RequestManager", e);
				}
			};
		}

		public void RegisterHandler<ArgT>(Action<Client, ArgT> Handler)
			where ArgT : class
		{
			uint typeID = MessageCreator.Instance.Register<ArgT>();

			requests[typeID] = (Client, Argument) =>
			{
				try
				{
					Handler(Client, (ArgT)Argument);

					byte[] buffer = null;//just ack

					Client.WriteBuffer(buffer);
				}
				catch (Exception e)
				{
					LogManager.Instance.WriteException("RequestManager", e);
				}
			};
		}

		public void DispatchBuffer(Client Client, BufferStream Buffer)
		{
			object obj = MessageCreator.Instance.Deserialize(Buffer);
			if (obj == null)
				return;

			uint typeID = MessageCreator.GenerateTypeID(obj.GetType());

			requests[typeID](Client, obj);
		}
	}
}