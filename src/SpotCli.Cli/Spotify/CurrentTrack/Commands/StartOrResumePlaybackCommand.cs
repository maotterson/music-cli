using MediatR;
using SpotCli.Cli.Spotify.Responses;

namespace SpotCli.Cli.Spotify.Commands;

public class StartOrResumePlaybackCommand : IRequest<StartOrResumePlaybackResponse>, IValidCommand
{
    public string Description => "Start or resume playback";
}
