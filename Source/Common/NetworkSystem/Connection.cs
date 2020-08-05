// Copyright 2019. All Rights Reserved.
using GameFramework.BinarySerializer;
using GameFramework.Networking;
using System;

namespace Backend.Common.NetworkSystem
{
	public delegate void ConnectionEventHandler(Connection Connection);

	public class Connection
	{
		private ClientSocket socket = null;
		private ClientRequestManager requestManager = null;

		public bool FindOptimumMTU
		{
			get;
			set;
		}

		public uint MTU
		{
			get;
			set;
		}

		public bool IsConnected
		{
			get { return (socket == null ? false : socket.IsConnected); }
		}

		public uint ReceiveBufferSize
		{
			get;
			set;
		}

		public uint SendBufferSize
		{
			get;
			set;
		}

		public event ConnectionEventHandler OnConnected;
		public event ConnectionEventHandler OnConnectionFailed;
		public event ConnectionEventHandler OnDisconnected;

		public Connection()
		{
			requestManager = new ClientRequestManager(this);

			MTU = new UDPClientSocket().MTU;
		}

		public void Connect(ProtocolTypes Protocol, string Host, ushort Port)
		{
			if (Protocol == ProtocolTypes.TCP)
				socket = new TCPClientSocket();
			else if (Protocol == ProtocolTypes.UDP)
			{
				UDPClientSocket udpSocket = new UDPClientSocket();

				udpSocket.FindOptimumMTU = FindOptimumMTU;
				udpSocket.MTU = MTU;

				socket = udpSocket;
			}

			if (ReceiveBufferSize != 0)
				socket.ReceiveBufferSize = ReceiveBufferSize;
			else
				ReceiveBufferSize = socket.ReceiveBufferSize;

			if (SendBufferSize != 0)
				socket.SendBufferSize = SendBufferSize;
			else
				SendBufferSize = socket.SendBufferSize;

			socket.MultithreadedCallbacks = false;
			socket.MultithreadedReceive = false;
			socket.MultithreadedSend = false;

			socket.OnConnected += Socket_OnConnected;
			socket.OnConnectionFailed += Socket_OnConnectionFailed;
			socket.OnDisconnected += Socket_OnDisconnected;
			socket.OnBufferReceived += Socket_OnBufferReceived;

			socket.Connect(Host, Port);
		}

		public void Disconnect()
		{
			if (socket == null)
				return;

			socket.Disconnect();

			socket.OnConnected -= Socket_OnConnected;
			socket.OnConnectionFailed -= Socket_OnConnectionFailed;
			socket.OnDisconnected -= Socket_OnDisconnected;
			socket.OnBufferReceived -= Socket_OnBufferReceived;
		}

		public void Service()
		{
			if (socket != null)
				socket.Service();
		}

		public void RegisterHandler<ArgT>(Action<ArgT> Handler)
			where ArgT : class
		{
			requestManager.RegisterHandler(Handler);
		}

		public void Send<ArgT>(ArgT Argument, Action OnComplete = null)
			where ArgT : class
		{
			requestManager.Send(Argument, OnComplete);
		}

		public void Send<ArgT, ResT>(ArgT Argument, Action<ResT> OnComplete = null)
			where ArgT : class
			where ResT : class
		{
			requestManager.Send(Argument, OnComplete);
		}

		internal void WriteBuffer(byte[] Buffer, uint Index, uint Length)
		{
			if (socket.Type == Protocols.TCP)
				((TCPClientSocket)socket).Send(Buffer, Index, Length);
			else if (socket.Type == Protocols.UDP)
				((UDPClientSocket)socket).Send(Buffer, Index, Length);
		}

		private void Socket_OnConnected()
		{
			if (OnConnected != null)
				OnConnected(this);
		}

		private void Socket_OnConnectionFailed()
		{
			if (OnConnectionFailed != null)
				OnConnectionFailed(this);
		}

		private void Socket_OnDisconnected()
		{
			if (OnDisconnected != null)
				OnDisconnected(this);
		}

		private void Socket_OnBufferReceived(BufferStream Buffer)
		{
			requestManager.DispatchBuffer(Buffer);
		}
	}
}