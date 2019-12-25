// Copyright 2019. All Rights Reserved.
using Backend.Common;
using Backend.Common.NetworkSystem;
using GameFramework.BinarySerializer;
using GameFramework.Networking;
using System;

namespace Backend.Client
{
	public class ServerConnection
	{
		private ClientSocket socket = null;

		public RequestManager RequestManager
		{
			get;
			private set;
		}

		public ServerConnection()
		{
			RequestManager = new RequestManager(this);
		}

		public void Connect(ProtocolTypes Protocol, string Host, ushort Port)
		{
			if (Protocol == ProtocolTypes.TCP)
				socket = new TCPClientSocket();
			else if (Protocol == ProtocolTypes.UDP)
				socket = new UDPClientSocket();

			socket.MultithreadedCallbacks = false;

			socket.OnConnected += Socket_OnConnected;
			socket.OnConnectionFailed += Socket_OnConnectionFailed;
			socket.OnDisconnected += Socket_OnDisconnected;
			socket.OnBufferReceived += Socket_OnBufferReceived;

			socket.Connect(Host, Port);
		}

		public void Service()
		{
			if (socket != null)
				socket.Service();
		}

		private void Socket_OnConnected()
		{
		}

		private void Socket_OnConnectionFailed()
		{
		}

		private void Socket_OnDisconnected()
		{
		}

		private void Socket_OnBufferReceived(BufferStream Buffer)
		{
			RequestManager.DispatchBuffer(Buffer);
		}

		public void WriteBuffer(byte[] Buffer)
		{
			if (socket is TCPClientSocket)
				((TCPClientSocket)socket).Send(Buffer);
			else if (socket is UDPClientSocket)
				((UDPClientSocket)socket).Send(Buffer);
		}
	}
}