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
            byte[] msg = Encoding.ASCII.GetBytes("Thius is a test");
            Console.WriteLine("Sending");
            s.SendTo(msg, 0, msg.Length, SocketFlags.None, destIp);
            s.Close();
        }
    }
}
