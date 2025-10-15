using ClientTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MainServer
{
    internal class ConnectionManager
    {
        public static Dictionary<Guid, Client> ConnectedUsers = new Dictionary<Guid, Client>();
        public static void InitalizeClient(PacketType _packetType, Client _client)
        {
            if(_packetType == PacketType.Establish)
            {
                Guid newUserId = Guid.NewGuid();
                ConnectedUsers.Add(newUserId, _client);
            }
        }
    }
}
