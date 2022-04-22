using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandQueueInvoker.Responses;

public class FooResponse : IResponse
{
    public string Message { get; set; }
    public int Code { get; set; }
}
