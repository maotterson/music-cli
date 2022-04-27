using MediatR;
using SpotCli.Cli.Options.Interfaces;
using SpotCli.Cli.Services;

namespace SpotCli.Cli.App;

public class ConsoleApplication : IConsoleApplication
{
    private readonly ICommandLineOptionsResolver _commandLineOptionsResolver;
    private readonly IMediator _mediator;
    private readonly IRequestQueue _requestQueue;

    public ConsoleApplication(ICommandLineOptionsResolver commandLineOptionsResolver, 
        IMediator mediator, 
        IRequestQueue requestQueue)
    {
        _commandLineOptionsResolver = commandLineOptionsResolver;
        _mediator = mediator;
        _requestQueue = requestQueue;
    }

    public async Task RunAsync(string[] args)
    {
        try
        {
            _commandLineOptionsResolver.ParseOptions(args);
            while (_requestQueue.Count > 0)
            {
                var response = await ProcessRequest();
                Console.WriteLine(response);
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private async Task<string> ProcessRequest()
    {
        var request = _requestQueue.Dequeue();
        var response = await _mediator.Send(request);
        if (response is null)
        {
            return $"{request.Description} was unsuccessful. Please try again.";
        }
        return response.ToString()!;
    }
}
