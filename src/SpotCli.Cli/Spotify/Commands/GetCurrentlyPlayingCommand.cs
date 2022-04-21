using MediatR;
using Refit;
using SpotCli.Cli.Spotify.Responses;

namespace SpotCli.Cli.Spotify.Commands;

public class GetCurrentlyPlayingCommand : IConsoleVerb, IRequest<IApiResponse<GetCurrentlyPlayingResponse>>
{
    public string ConsoleArgument => "playing";
}
