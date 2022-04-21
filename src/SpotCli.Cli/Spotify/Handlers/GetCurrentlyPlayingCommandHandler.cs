using MediatR;
using Refit;
using SpotCli.Cli.Spotify.Api;
using SpotCli.Cli.Spotify.Commands;
using SpotCli.Cli.Spotify.Responses;

namespace SpotCli.Cli.Spotify.Handlers;

public class GetCurrentlyPlayingCommandHandler : IRequestHandler<GetCurrentlyPlayingCommand, IApiResponse<GetCurrentlyPlayingResponse>>
{
    private readonly ISpotifyWebApi _spotifyWebApi;
    public GetCurrentlyPlayingCommandHandler(ISpotifyWebApi spotifyWebApi)
    {
        _spotifyWebApi = spotifyWebApi;
    }

    public async Task<IApiResponse<GetCurrentlyPlayingResponse>> Handle(GetCurrentlyPlayingCommand request, CancellationToken cancellationToken)
    {
        return await _spotifyWebApi.GetCurrentlyPlaying();
    }
}
