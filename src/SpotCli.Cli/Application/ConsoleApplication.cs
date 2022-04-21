using MediatR;
using SpotCli.Cli.Spotify.Factories;

namespace SpotCli.Cli.Application;

public class ConsoleApplication : IConsoleApplication
{
    private readonly IConsoleCommandFactory _consoleCommandFactory;
    private readonly IMediator _mediator;

    public ConsoleApplication(IConsoleCommandFactory consoleCommandFactory, IMediator mediator)
    {
        _consoleCommandFactory = consoleCommandFactory;
        _mediator = mediator;
    }

    public async Task RunAsync(string[] args)
    {
        var command = _consoleCommandFactory.BuildFromArgs(args);
        if (command is null) return;
        var response = await _mediator.Send(command);
    }
}
