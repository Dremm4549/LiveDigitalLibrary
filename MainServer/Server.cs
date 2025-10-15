using ClientTest;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MainServer
{
    internal class Server
    {
        public bool IsRunning { get; private set; }
        public int MaxConnections { get; private set; }
        public int Port { get; private set; }

        private Socket serverListener;

        private ConcurrentQueue<Client> cq = new ConcurrentQueue<Client>();



        public Server(int _port, int _maxUsers)
        {
            Port = _port;
            IPEndPoint ep = new IPEndPoint(IPAddress.Any, _port);
            MaxConnections = _maxUsers;
            serverListener = new Socket(ep.Address.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
            serverListener.Bind(ep);
            IsRunning = true;
        }


        
        public static void Initialize(int _maxConnections)
        {
            //MaxConnections = _maxConnections;

            // this is where we are going bind and create the socket
        }

        public void Start()
        {
            Client state = new Client();

            serverListener.BeginReceiveFrom(state.Buffer, 0, state.Buffer.Length, SocketFlags.None, ref state.EndPoint, new AsyncCallback(RecieveCallBack), state);
        }

        public void RecieveCallBack(IAsyncResult _result)
        {
            if (_result != null)
            {
                Client state = (Client)_result.AsyncState;
                int bytesReceived = serverListener.EndReceiveFrom(_result, ref state.EndPoint);

                RequestHandler.cq.Enqueue(state);

                serverListener.BeginReceiveFrom(state.Buffer, 0, state.Buffer.Length, SocketFlags.None, ref state.EndPoint, new AsyncCallback(RecieveCallBack), state);
            }

            //serverListener.EndReceiveFrom(_result)

        }

        public static void ProcessMessages()
        {
            
            if(RequestHandler.cq.Count > 0)
            {
                Console.WriteLine("We are now going to process messages in the queue");
                RequestHandler.ProcessRequests();
            }
        }

    }
}
