// Copyright 2019. All Rights Reserved.
using Backend.Core.LogSystem;
using Backend.Core.NetworkSystem;
using GameFramework.BinarySerializer;
using GameFramework.Common.MemoryManagement;
using GameFramework.Common.Utilities;
using System;
using System.Collections.Generic;
using System.IO;

namespace Backend.Core
{
	class RequestManager : Singleton<RequestManager>
	{
		private class TypeMap : Dictionary<uint, Type>
		{ }

		private class RequestMap : Dictionary<uint, Action<Client, object>>
		{ }

		private TypeMap types = null;
		private RequestMap requests = null;

		private RequestManager()
		{
			types = new TypeMap();
			requests = new RequestMap();
		}

		public void RegisterHandler<ArgT, ResT>(Func<Client, ArgT, ResT> Handler)
			where ArgT : class
			where ResT : class
		{
			uint hash = ReflectionExtensions.MakeHash<ArgT>();

			types[hash] = typeof(ArgT);

			requests[hash] = (Client, Argument) =>
			{
				ResT res = Handler(Client, (ArgT)Argument);
				hash = ReflectionExtensions.MakeHash<ResT>();

				BufferStream buffer = new BufferStream(new MemoryStream());
				buffer.WriteUInt32(hash);
				Serializer.Serialize(res, buffer);

				Client.WriteBuffer(buffer.Buffer);
			};
		}

		public void RegisterHandler<ArgT>(Action<Client, ArgT> Handler)
			where ArgT : class
		{
			uint hash = ReflectionExtensions.MakeHash<ArgT>();

			requests[hash] = (Client, Argument) =>
			{
				Handler(Client, (ArgT)Argument);

				byte[] buffer = null;//just ack

				Client.WriteBuffer(buffer);
			};
		}

		public object InstantiateArgument(BufferStream Buffer)
		{
			uint hash = Buffer.ReadUInt32();

			if (!types.ContainsKey(hash))
				return null;

			return Serializer.Deserialize(types[hash], Buffer);
		}

		public void InvokeHandler(Client Client, object Argument)
		{
			Type argType = Argument.GetType();

			uint hash = ReflectionExtensions.MakeHash(argType);

			if (!types.ContainsKey(hash))
				return;

			if (!requests.ContainsKey(hash))
			{
				LogManager.Instance.WriteWarning("Request arguments [{0}] not recognized", argType.Name);
				return;
			}

			requests[hash](Client, Argument);
		}
	}
}