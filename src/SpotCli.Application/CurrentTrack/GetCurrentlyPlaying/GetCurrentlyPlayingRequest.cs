using MediatR;
using SpotCli.Application.CurrentTrack.GetCurrentlyPlaying;
using SpotCli.Application.CurrentTrack.Responses;
using SpotCli.Application.Interfaces;

namespace SpotCli.Application.CurrentTrack.Commands;

public class GetCurrentlyPlayingRequest : IRequest<GetCurrentlyPlayingResponse>, IValidRequest
{
    public GetCurrentlyPlayingRequest(GetCurrentlyPlayingRequestQuery query)
    {
        Query = query;
    }
    public GetCurrentlyPlayingRequestQuery Query { get; init; }
    public string Description => "Get currently playing track";
}
