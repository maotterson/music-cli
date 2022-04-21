using SpotCli.Cli.Spotify.Commands;

namespace SpotCli.Cli.Spotify;

internal interface IConsoleCommandFactory
{
    public IConsoleCommand GetRequestObject(string[] args);
}
