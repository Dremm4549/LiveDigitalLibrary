using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainServer
{
    internal class Constants
    {
        public const int TICKS_PER_SEC = 60;
        public const int MS_PER_TICK = 1000 / TICKS_PER_SEC;
        public const int MAX_FRAMESKIP = 10;

        //PACKET CONSTANTS
        public const int MAX_BUFFER = 512;

        public const int SequenceNoSize = sizeof(int);
        public const int RequestTypeSize = sizeof(byte);
        public const int PayloadLength = sizeof(short);

        public const int RequestTypeOffset = 0;
        public const int SequenceNoOffset = RequestTypeOffset + RequestTypeSize;

        public const int PayloadLengthOffset = SequenceNoOffset + SequenceNoSize;

        //Header size
        public const int HeaderSize = RequestTypeSize + SequenceNoSize + PayloadLength;

        //Payload
        public const int PayloadOffset = HeaderSize;
        public const int maxPayloadSize = MAX_BUFFER - HeaderSize;
    }
}
