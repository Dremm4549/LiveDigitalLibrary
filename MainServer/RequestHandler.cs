using ClientTest;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainServer
{
    internal static class RequestHandler
    {
        public static ConcurrentQueue<Client> cq = new ConcurrentQueue<Client>();

        /// <summary>
        /// This function will process all messages in the queue at the current tick
        /// </summary>
        public static void ProcessRequests()
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
