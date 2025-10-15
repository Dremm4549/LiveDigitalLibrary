using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientTest
{
    public enum PacketType: byte
    {
        Establish = 0x01,
        EstablishAck = 0x02,
        HeartBeat = 0x03,
        Request = 0x04,
    }
}
