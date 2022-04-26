using MediatR;
using SpotCli.Application.CurrentTrack.Commands;
using SpotCli.Application.CurrentTrack.Queries;
using SpotCli.Application.CurrentTrack.Responses;
using SpotCli.Application.Interfaces;

namespace SpotCli.Application.CurrentTrack.Requests;

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
