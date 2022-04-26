using MediatR;
using SpotCli.Application.Api;
using SpotCli.Application.CurrentTrack.Commands;
using SpotCli.Application.CurrentTrack.Responses;
using SpotCli.Application.Exceptions;

namespace SpotCli.Application.CurrentTrack.Handlers;

public class GetCurrentlyPlayingRequestHandler : IRequestHandler<GetCurrentlyPlayingRequest, GetCurrentlyPlayingResponse>
{
    private readonly ISpotifyWebApi _spotifyWebApi;
    public GetCurrentlyPlayingRequestHandler(ISpotifyWebApi spotifyWebApi)
    {
        _spotifyWebApi = spotifyWebApi;
    }

    public async Task<GetCurrentlyPlayingResponse> Handle(GetCurrentlyPlayingRequest request, CancellationToken cancellationToken)
    {
        var response = await _spotifyWebApi.GetCurrentlyPlaying();
        if (response is null)
        {
            throw new NullReferenceException();
        }

        response.CheckForErrorStatusCode(request);

        return response.Content!;
    }
}
