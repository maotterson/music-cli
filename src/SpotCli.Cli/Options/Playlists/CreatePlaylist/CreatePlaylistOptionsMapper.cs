using SpotCli.Application.Interfaces;
using SpotCli.Application.Playlists.CreatePlaylist;
using SpotCli.Cli.Services;

namespace SpotCli.Cli.Options.Playlists.CreatePlaylist;

public class CreatePlaylistOptionsMapper
{
    private readonly IRequestQueue _requestQueue;
    private readonly ISpotifyApiConfiguration _configuration;

    public CreatePlaylistOptionsMapper(ISpotifyApiConfiguration configuration, IRequestQueue requestQueue)
    {
        _requestQueue = requestQueue;
        _configuration = configuration;
    }
    public void Map(CreatePlaylistOptions options)
    {
        var playlistName = options.Name;
        var userId = _configuration.SpotifyId;

        var requestBody = new CreatePlaylistRequestBody()
        {
            Name = playlistName
            // todo add additional params
        };
        var request = new CreatePlaylistRequest(userId, requestBody);

        _requestQueue.Enqueue(request);
    }
}
