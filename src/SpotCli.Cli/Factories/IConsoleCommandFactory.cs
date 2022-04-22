using MediatR;
using Refit;
using SpotCli.Cli.Spotify.Commands;

namespace SpotCli.Cli.Spotify.Factories;

public interface IConsoleCommandFactory
{
    public IValidCommand? BuildFromArgs(string[] args);
}
