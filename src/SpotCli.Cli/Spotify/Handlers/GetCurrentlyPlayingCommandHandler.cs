using Refit;
using SpotCli.Cli.Spotify.Api;
using SpotCli.Cli.Spotify.Commands;

public class GetCurrentlyPlayingCommandHandler
{
    private readonly ISpotifyWebApi _spotifyWebApi;
    public GetCurrentlyPlayingCommandHandler(ISpotifyWebApi spotifyWebApi)
    {
        _spotifyWebApi = spotifyWebApi;
    }
    public async Task<IApiResponse> ExecuteAsync(GetCurrentlyPlayingCommand command)
    {
        return await _spotifyWebApi.GetCurrentlyPlaying();
    }
}
