using MediatR;
using SpotCli.Application.CurrentTrack.Commands;
using SpotCli.Application.CurrentTrack.Queries;
using SpotCli.Application.CurrentTrack.Responses;
using SpotCli.Application.Interfaces;

namespace SpotCli.Application.CurrentTrack.Requests;

public class StartOrResumePlaybackRequest : IRequest<StartOrResumePlaybackResponse>, IValidCommand
{
    public StartOrResumePlaybackRequest(StartOrResumePlaybackQuery query, StartOrResumePlaybackBody body)
    {
        Body = body;
        Query = query;
    }
    public StartOrResumePlaybackBody Body { get; init; }
    public StartOrResumePlaybackQuery Query { get; init; }

    public string Description => "Start or resume playback";
}
