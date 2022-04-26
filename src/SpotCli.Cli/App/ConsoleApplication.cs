using MediatR;
using SpotCli.Application.Interfaces;
using SpotCli.Cli.Options.Interfaces;
using SpotCli.Cli.Services;

namespace SpotCli.Cli.App;

public class ConsoleApplication : IConsoleApplication
{
    private readonly ICommandLineOptionsResolver _commandLineOptionsResolver;
    private readonly IMediator _mediator;
    private readonly IRequestQueue _commandQueue;
    private readonly ISpotifyApiConfiguration _configuration;

    public ConsoleApplication(ICommandLineOptionsResolver commandLineOptionsResolver, 
        IMediator mediator, 
        ISpotifyApiConfiguration configuration,
        IRequestQueue commandQueue)
    {
        _commandLineOptionsResolver = commandLineOptionsResolver;
        _mediator = mediator;
        _configuration = configuration;
        _commandQueue = commandQueue;
    }

    public async Task RunAsync(string[] args)
    {
        try
        {
            _commandLineOptionsResolver.ParseOptions(args);
            while (_commandQueue.Count > 0)
            {
                var response = await ProcessCommand();
                Console.WriteLine(response);
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private async Task<string> ProcessCommand()
    {
        var command = _commandQueue.Dequeue();
        var response = await _mediator.Send(command);
        if (response is null)
        {
            return $"{command.Description} was unsuccessful. Please try again.";
        }
        return response.ToString()!;
    }
}
