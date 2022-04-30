using SpotCli.Application.Interfaces;
using SpotCli.Application.Playlists.CreatePlaylist;
using SpotCli.Cli.Exceptions;
using SpotCli.Cli.Services;
using SpotCli.Cli.Services.Playlist;

namespace SpotCli.Cli.Options.Playlists.CreatePlaylist;

public class CreatePlaylistOptionsMapper
{
    private readonly IRequestQueue _requestQueue;
    private readonly ISpotifyApiConfiguration _configuration;
    private readonly IPlaylistFileParser _playlistFileParser;

    public CreatePlaylistOptionsMapper(ISpotifyApiConfiguration configuration, IRequestQueue requestQueue, IPlaylistFileParser playlistFileParser)
    {
        _requestQueue = requestQueue;
        _configuration = configuration;
        _playlistFileParser = playlistFileParser;
    }
    public void Map(CreatePlaylistOptions options)
    {
        if(options.Tracklist is not null)
        {
            _playlistFileParser.ParseFile("sample-playlist.txt");

            throw new InvalidTracklistPathException();
        }

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
