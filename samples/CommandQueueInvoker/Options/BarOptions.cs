using CommandQueueInvoker.Commands;
using CommandQueueInvoker.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandQueueInvoker.Options;

public class BarOptions : ICommandOptions, ICanGetOptionsFromResponse<BarOptions, FooResponse>
{
    public int Code { get; set; }

    public BarOptions Map(FooResponse response)
    {
        return new BarOptions
        {
            Code = response.Code
        };
    }
}
