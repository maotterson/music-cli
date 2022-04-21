using MediatR;
using Refit;
using SpotCli.Cli.Spotify.Api;
using SpotCli.Cli.Spotify.Commands;
using SpotCli.Cli.Spotify.Responses;

namespace SpotCli.Cli.Spotify.Handlers;

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
