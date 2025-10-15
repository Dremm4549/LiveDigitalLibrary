using MainServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientTest
{
    internal class Packet
    {
        public PacketType RequestType { get; private set; }
        public int SequenceNo { get; init; }
        public byte[] Buffer;
        public int HeaderSize { get; private set; }
        public int PayloadLength { get; private set; }

        public Packet(int _sequenceNo, PacketType _packetType)
        {
            SequenceNo = _sequenceNo;
            Buffer = new byte[Constants.MAX_BUFFER];
            RequestType = _packetType;
        }


        /// <summary>
        ///  In this serialize function we want to pack our buffer using bit converter.
        ///  Essentially we are going to reserve 4 bytes for the sequenceNo 1 byte for the RequestType and the remaining bytes will be for the payload
        /// </summary>
        public void Serialize(string? payload)
        {
            Buffer[0] = (byte)RequestType;
            BitConverter.GetBytes(SequenceNo).CopyTo(Buffer, Constants.SequenceNoOffset);
            PayloadLength = Constants.RequestTypeSize + Constants.SequenceNoSize;

            if (payload != string.Empty && payload != null)
            {
                //We only should only do this if there is a payload to send.
                short payloadLength = (short)Encoding.ASCII.GetByteCount(payload);
                BitConverter.GetBytes(payloadLength).CopyTo(Buffer, Constants.PayloadLengthOffset);

                System.Text.Encoding.ASCII.GetBytes(payload).CopyTo(Buffer, Constants.PayloadOffset);
                PayloadLength += Constants.PayloadLength + payloadLength;

            }

        }

        public static void Deserialize(byte[] data)
        {
            PacketType type = (PacketType)data[Constants.RequestTypeOffset];
            int sequenceNo = BitConverter.ToInt32(data, Constants.SequenceNoOffset);
            short payloadLength = BitConverter.ToInt16(data, Constants.PayloadLengthOffset);

            
            string msg = System.Text.Encoding.ASCII.GetString(data,Constants.PayloadOffset, payloadLength);
        }

    }
}
