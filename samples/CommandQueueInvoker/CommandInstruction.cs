using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandQueueInvoker;

internal enum CommandInstruction
{
    ORIGINAL,
    PREVIOUS,
    RETRY
}
