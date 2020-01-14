// Copyright 2019. All Rights Reserved.
using GameFramework.BinarySerializer;
using GameFramework.Common.MemoryManagement;
using GameFramework.Common.Utilities;
using System;
using System.Collections.Generic;

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

		public bool Serialize(uint ID, uint RequestTypeID, object Instance, BufferStream Buffer)
		{
			uint typeID = Instance == null ? 0 : GenerateTypeID(Instance.GetType());

			Buffer.WriteUInt32(ID);
			Buffer.WriteUInt32(RequestTypeID);
			Buffer.WriteUInt32(typeID);

			if (Instance != null)
				Serializer.Serialize(Instance, Buffer);

			return true;
		}

		public object Deserialize(BufferStream Buffer, out uint ID, out uint RequestTypeID)
		{
			ID = Buffer.ReadUInt32();
			RequestTypeID = Buffer.ReadUInt32();
			uint typeID = Buffer.ReadUInt32();

			if (!types.ContainsKey(typeID))
				return null;

			return Serializer.Deserialize(types[typeID], Buffer);
		}

		public static uint GenerateTypeID(Type Type)
		{
			return ReflectionExtensions.MakeHash(Type);
		}
	}
}