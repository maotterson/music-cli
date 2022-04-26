using MediatR;
using SpotCli.Application.Interfaces;

namespace SpotCli.Application.CurrentTrack.GetCurrentlyPlaying;

public class GetCurrentlyPlayingRequest : IRequest<GetCurrentlyPlayingResponse>, IValidRequest
{
    public GetCurrentlyPlayingRequest(GetCurrentlyPlayingRequestQuery query)
    {
        Query = query;
    }
    public GetCurrentlyPlayingRequestQuery Query { get; init; }
    public string Description => "Get currently playing track";
}
