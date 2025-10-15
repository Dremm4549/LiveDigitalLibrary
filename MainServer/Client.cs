using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MainServer
{
    internal class Client
    {
        public EndPoint EndPoint;
        public byte[] Buffer { get; private set; }

        public Client()
        {
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            EndPoint = (EndPoint)sender;

            Buffer = new byte[1024];
        }
    }
}
