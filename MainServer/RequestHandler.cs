using ClientTest;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace MainServer
{
    internal static class RequestHandler
    {
        public static ConcurrentQueue<Client> cq = new ConcurrentQueue<Client>();

        /// <summary>
        /// This function will process all messages in the queue at the current tick
        /// </summary>
        public static void ProcessRequests(Socket s)
        {
            Client? request;
            
            if(cq.Count > 0)
            {
                cq.TryDequeue(out request);

                if(request != null)
                {
                    Packet p = Packet.Deserialize(request.Buffer);

                    switch(p.RequestType)
                    {
                        case PacketType.Establish:
                            Console.WriteLine("Okay Assign the client is credentials");
                            // Basically we want to take the users username end point aswell as create a unique identifier then display the current catalouge...?
                            //Create an ack establish packet
                            // must include the following properties. PacketType, Sequence Number, AckNumber Payload
                            // The payload will include data such as session id
                            
                            ConnectionManager.InitalizeClient(request);
                            Packet ackPacket = new Packet(0, PacketType.EstablishAck);
                            ackPacket.Serialize(null);

                            //We know want to send a establishAck
                            s.SendTo(ackPacket.Buffer, 0, ackPacket.PayloadLength, SocketFlags.None, request.EndPoint);
                            Console.WriteLine("CREATING GOBBLY GOOK");

                            break;
                        case PacketType.HeartBeat:
                            Console.WriteLine("Ensure client is still here");
                            break;
                        case PacketType.Request:
                            Console.WriteLine("Start to send the client the book data");
                            break;
                        default:
                            break;

                    }
                }

            }
        }
    }
}
