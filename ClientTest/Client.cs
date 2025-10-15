using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientTest
{
    internal class Client
    {
        public required string Username { get; init; }
        public Guid UserId { get; private set; }

        public Client(string _username)
        {
            Username = _username;
        }

        public void EstablishUserId(Guid userId)
        {
            UserId = userId;
        }
    }
}
