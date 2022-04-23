using MediatR;
using SpotCli.Application.Interfaces;
using SpotCli.Cli.Factories;

namespace SpotCli.Cli.App;

public class ConsoleApplication : IConsoleApplication
{
    private readonly ICommandLineOptionsResolver _commandLineOptionsResolver;
    private readonly IMediator _mediator;
    private readonly ISpotifyApiConfiguration _configuration;

    public ConsoleApplication(ICommandLineOptionsResolver commandLineOptionsResolver, IMediator mediator, ISpotifyApiConfiguration configuration)
    {
        _commandLineOptionsResolver = commandLineOptionsResolver;
        _mediator = mediator;
        _configuration = configuration;
    }

    public async Task RunAsync(string[] args)
    {
        try
        {
            var command = _commandLineOptionsResolver.PopulateCommandQueue(args);
            if (command is null)
            {
                Console.WriteLine("Command not recognized. Please try again.");
                return;
            }

            var response = await _mediator.Send(command);
            if (response is null)
            {
                Console.WriteLine($"{command.Description} was unsuccessful. Please try again.");
                return;
            }

            Console.WriteLine(response.ToString());
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
