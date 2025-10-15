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
            p.Serialize("Hello");

           
            s.SendTo(p.Buffer, 0, p.PayloadLength, SocketFlags.None, destIp);
            s.Close();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
