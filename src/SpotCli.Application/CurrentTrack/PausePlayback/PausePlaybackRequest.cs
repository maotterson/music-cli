using MediatR;
using Newtonsoft.Json;
using SpotCli.Application.Interfaces;

namespace SpotCli.Application.CurrentTrack.PausePlayback;

public class PausePlaybackRequest : IRequest<PausePlaybackResponse>, IValidRequest
{
    public PausePlaybackRequest(PausePlaybackRequestQuery query)
    {
        Query = query;
    }
    public PausePlaybackRequestQuery Query { get; init; }
    public string Description => "Pause playback";
}
