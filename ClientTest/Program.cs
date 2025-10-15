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
        /// <summary>
        /// Okay so this is atesting file where the user will enter a user name and we will attempt to establish a connection with the server
        /// The server will attempt to send us a session id along with current library cataloug
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        static void Main()
        {
            Console.WriteLine("Please enter in a username");

            string? name = Console.ReadLine();

            if (name == string.Empty)
            {
                throw new ArgumentException("Error: USERNAMES MAY NOT BE EMPTY");
            }

            IPEndPoint destIp = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 7777);
            Socket s = new Socket(destIp.Address.AddressFamily, SocketType.Dgram, ProtocolType.Udp);

            
            Packet p = new Packet(1, PacketType.Establish);
            p.Serialize(null);

            //Likely need to open a listener to receive requests from the server

           
            s.SendTo(p.Buffer, 0, p.PayloadLength, SocketFlags.None, destIp);
            s.Close();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
