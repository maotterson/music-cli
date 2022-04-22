using CommandQueueInvoker.Options;
using CommandQueueInvoker.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandQueueInvoker.Commands;

public class BarCommand : ICommand
{
    private readonly int _code;
    public BarCommand(BarOptions options)
    {
        _code = options.Code;
    }
    
    public IResponse Execute()
    {
        return new BarResponse()
        {
            Message = $"Bar executed with code {_code}"
        };
    }
}
