using CommandQueueInvoker.Commands;
using CommandQueueInvoker.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandQueueInvoker.Options;

public class FooOptions : ICommandOptions
{
    public string Name { get; set; }
}
