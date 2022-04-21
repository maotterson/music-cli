using MediatR;
using Refit;

namespace SpotCli.Cli.Spotify.Factories;

public interface IConsoleCommandFactory
{
    public IRequest<IApiResponse>? BuildFromArgs(string[] args);
}
