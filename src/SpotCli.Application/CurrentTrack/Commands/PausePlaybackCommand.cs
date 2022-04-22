using MediatR;
using SpotCli.Application.CurrentTrack.Responses;
using SpotCli.Application.Interfaces;

namespace SpotCli.Application.CurrentTrack.Commands;

public class PausePlaybackCommand : IRequest<PausePlaybackResponse>, IValidCommand
{
    public string Description => "Pause playback";
}
