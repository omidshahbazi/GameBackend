// Copyright 2019. All Rights Reserved.
using GameFramework.BinarySerializer;
using GameFramework.Common.MemoryManagement;
using System;
using System.Collections.Generic;
using System.IO;

namespace Backend.Common.NetworkSystem
{
	public class MessageCreator : Singleton<MessageCreator>
	{
		private class TypeMap : Dictionary<uint, Type>
		{ }

		private TypeMap types = null;

		private MessageCreator()
		{
			types = new TypeMap();
		}

		public uint Register<T>()
		{
			uint typeID = GenerateTypeID(typeof(T));

			types[typeID] = typeof(T);

			return typeID;
		}

		public bool Serialize(object Instance, BufferStream Buffer)
		{
			if (Instance == null)
				return false;

			uint typeID = GenerateTypeID(Instance.GetType());

			BufferStream buffer = new BufferStream(new MemoryStream());
			buffer.WriteUInt32(typeID);
			Serializer.Serialize(Instance, buffer);

			return true;
		}

		public object Deserialize(BufferStream Buffer)
		{
			uint typeID = Buffer.ReadUInt32();

			if (!types.ContainsKey(typeID))
			{
				LogManager.Instance.WriteWarning("Request arguments [{0}] not recognized", typeID);
				return null;
			}

			return Serializer.Deserialize(types[typeID], Buffer);
		}

		public static uint GenerateTypeID(Type Type)
		{
			return ReflectionExtensions.MakeHash(Type);
		}
	}
}