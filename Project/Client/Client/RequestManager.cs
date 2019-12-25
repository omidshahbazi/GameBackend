// Copyright 2019. All Rights Reserved.
using Backend.Common.NetworkSystem;
using GameFramework.BinarySerializer;
using System;
using System.Collections.Generic;
using System.IO;

namespace Backend.Client
{
	public class RequestManager
	{
		private class RequestMap : Dictionary<uint, Action<object>>
		{ }

		private ServerConnection connection = null;
		private RequestMap requests = null;

		public RequestManager(ServerConnection Connection)
		{
			connection = Connection;
			requests = new RequestMap();
		}

		public void RegisterHandler<ArgT, ResT>(Action<ArgT> Handler)
			where ArgT : class
			where ResT : class
		{
			uint typeID = MessageCreator.Instance.Register<ArgT>();
			MessageCreator.Instance.Register<ResT>();

			requests[typeID] = (Argument) =>
			{
				Handler((ArgT)Argument);

				//ResT res = Handler((ArgT)Argument);

				//if (res == null)
				//	return;

				//BufferStream buffer = new BufferStream(new MemoryStream());
				//if (!MessageCreator.Instance.Serialize(res, buffer))
				//	return;

				//connection.WriteBuffer(buffer.Buffer);
			};
		}

		public void DispatchBuffer(BufferStream Buffer)
		{
			object obj = MessageCreator.Instance.Deserialize(Buffer);
			if (obj == null)
				return;

			uint typeID = MessageCreator.GenerateTypeID(obj.GetType());

			try
			{
				requests[typeID](obj);
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		public void Request<ArgT>(ArgT Argument)
		{
			BufferStream buffer = new BufferStream(new MemoryStream());
			if (!MessageCreator.Instance.Serialize(Argument, buffer))
				return;

			connection.WriteBuffer(buffer.Buffer);
		}
	}
}