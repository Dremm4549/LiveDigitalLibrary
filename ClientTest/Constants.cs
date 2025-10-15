using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClientTest
{
    internal class Constants
    {
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
