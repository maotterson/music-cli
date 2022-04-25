using MediatR;
using SpotCli.Application.CurrentTrack.Responses;
using SpotCli.Application.Interfaces;

namespace SpotCli.Application.CurrentTrack.Commands;

public class StartOrResumePlaybackCommand : IRequest<StartOrResumePlaybackResponse>, IValidCommand
{
    public string Description => "Start or resume playback";
    public string? DeviceId { get; set; }
}
