using SpotCli.Application.Interfaces;
using SpotCli.Application.Playlists.CreatePlaylist;
using SpotCli.Cli.Exceptions;
using SpotCli.Cli.Playlists.CreatePlaylist;
using SpotCli.Cli.Services;
using SpotCli.Cli.Services.Playlist;

namespace SpotCli.Cli.Options.Playlists.CreatePlaylist;

public class CreatePlaylistOptionsMapper
{
    private readonly IRequestQueue _requestQueue;
    private readonly ISpotifyApiConfiguration _configuration;
    private readonly IPlaylistFileParser _playlistFileParser;
    private readonly IPlaylistCreatorService _playlistCreatorService;

    public CreatePlaylistOptionsMapper(ISpotifyApiConfiguration configuration, 
        IRequestQueue requestQueue, 
        IPlaylistFileParser playlistFileParser
        IPlaylistCreatorService playlistCreatorService)
    {
        _requestQueue = requestQueue;
        _configuration = configuration;
        _playlistFileParser = playlistFileParser;
        _playlistCreatorService = playlistCreatorService;
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

        if (options.Tracklist is not null)
        {
            var tracklist = _playlistFileParser.ParseFile("sample-playlist.txt");
            _playlistCreatorService.SetTracklist(tracklist);
            _playlistCreatorService.SetName(options.Name!);

            var decoratedRequest = new CreatePlaylistBeforeAddingTracksRequest(request);
            _requestQueue.Enqueue(decoratedRequest);
            return;
        }

        _requestQueue.Enqueue(request);
    }

}
