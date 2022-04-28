using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var assembly = typeof(Program);
services.AddMediatR(assembly);

var mediatr = services.BuildServiceProvider().GetService<IMediator>();
await mediatr!.Send(new Request("regular request"));
await mediatr.Send(new DecoratedRequest("decorated request"));

public class Request : IRequest<Response>
{
    public string Message { get; set; }
    public Request(string message)
    {
        Message = message;
    }
}

public class DecoratedRequest : Request, IDecorator
{
    public DecoratedRequest(string message) : base(message)
    {
    }

}


public interface IDecorator
{
}

public class Response
{
    public string Message => "Response message.";
}

public class Handler : IRequestHandler<Request, Response>, IRequestHandler<DecoratedRequest, Response>
{
    public Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        var response = GetResponse(request);
        return Task.FromResult(response);
    }

    public Task<Response> Handle(DecoratedRequest request, CancellationToken cancellationToken)
    {
        var response = GetResponse(request);
        return Task.FromResult(response);
    }

    private Response GetResponse(Request request)
    {
        Console.WriteLine(request.Message);
        var response = new Response();
        Console.WriteLine(response.Message);

        return response;
    }
}

public class PostProcessOnlyDecorated : IRequestPostProcessor<DecoratedRequest, Response>
{
    public Task Process(DecoratedRequest request, Response response, CancellationToken cancellationToken)
    {
        Console.WriteLine("do more stuff");
        return Task.CompletedTask;
    }
}
