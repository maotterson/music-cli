using CommandQueueInvoker.Options;
using CommandQueueInvoker.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandQueueInvoker.Commands;

internal class FooCommand : ICommand
{
    private readonly string _name;
    public FooCommand(FooOptions options)
    {
        _name = options.Name;
    }
    public IResponse Execute()
    {
        var response = new FooResponse()
        {
            Message = $"Foo executed by {_name}",
            Code = 200
        };
        return response;
    }
}
