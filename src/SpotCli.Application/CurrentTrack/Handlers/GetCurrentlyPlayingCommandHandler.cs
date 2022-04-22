using MediatR;
using SpotCli.Application.Api;
using SpotCli.Application.CurrentTrack.Commands;
using SpotCli.Application.CurrentTrack.Responses;

namespace SpotCli.Application.CurrentTrack.Handlers;

public class GetCurrentlyPlayingCommandHandler : IRequestHandler<GetCurrentlyPlayingCommand, GetCurrentlyPlayingResponse>
{
    private readonly ISpotifyWebApi _spotifyWebApi;
    public GetCurrentlyPlayingCommandHandler(ISpotifyWebApi spotifyWebApi)
    {
        _spotifyWebApi = spotifyWebApi;
    }

    public async Task<GetCurrentlyPlayingResponse> Handle(GetCurrentlyPlayingCommand request, CancellationToken cancellationToken)
    {
        var response = await _spotifyWebApi.GetCurrentlyPlaying();

        if(!response.IsSuccessStatusCode || response.Content is null)
        {
            throw new Exception();
        }

        return response.Content;
    }
}
