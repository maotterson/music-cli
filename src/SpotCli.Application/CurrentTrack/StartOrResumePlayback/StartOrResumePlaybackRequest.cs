using MediatR;
using SpotCli.Application.Interfaces;

namespace SpotCli.Application.CurrentTrack.StartOrResumePlayback;

public class StartOrResumePlaybackRequest : IRequest<StartOrResumePlaybackResponse>, IValidRequest
{
    public StartOrResumePlaybackRequest(StartOrResumePlaybackRequestQuery query, StartOrResumePlaybackRequestBody body)
    {
        Body = body;
        Query = query;
    }
    public StartOrResumePlaybackRequestBody Body { get; init; }
    public StartOrResumePlaybackRequestQuery Query { get; init; }

    public string Description => "Start or resume playback";
}
