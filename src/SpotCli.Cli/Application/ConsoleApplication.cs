using SpotCli.Cli.Spotify.Factories;

namespace SpotCli.Cli.Application;

public class ConsoleApplication : IConsoleApplication
{
    private readonly IConsoleCommandFactory _consoleCommandFactory;

    public ConsoleApplication(
        IConsoleCommandFactory consoleCommandFactory)
    {
        _consoleCommandFactory = consoleCommandFactory;
    }

    public async Task RunAsync(string[] args)
    {
        var command = _consoleCommandFactory.BuildFromArgs(args);
        var response = _mediator.Send(command);
    }
}
