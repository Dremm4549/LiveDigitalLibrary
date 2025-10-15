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
    }
}
