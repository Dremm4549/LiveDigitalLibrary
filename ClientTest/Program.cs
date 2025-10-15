using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace ClientTest
{
    internal class Program
    {
        static void Main()
        {
            IPEndPoint destIp = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 7777);
            Socket s = new Socket(destIp.Address.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
            Packet p = new Packet(5000000, PacketType.Establish);
            p.Serialize();

            p.Deserialize(p.Buffer);

            byte[] msg = Encoding.ASCII.GetBytes("Thius is a test");
            s.SendTo(p.Buffer, 0, p.HeaderSize, SocketFlags.None, destIp);
            s.Close();
        }
    }
}
