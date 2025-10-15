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
        public static void InitalizeClient(Client _client)
        {

            Guid newUserId = Guid.NewGuid();

            if(!ConnectedUsers.ContainsKey(newUserId))
            {
                ConnectedUsers.Add(newUserId, _client);
            }
            
        }
    }
}
