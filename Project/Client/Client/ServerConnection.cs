// Copyright 2019. All Rights Reserved.
using Backend.Common;
using GameFramework.BinarySerializer;
using GameFramework.Networking;

namespace Backend.Client
{
	public class ServerConnection
	{
		private ClientSocket socket = null;

		public ServerConnection()
		{

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
		}
	}
}