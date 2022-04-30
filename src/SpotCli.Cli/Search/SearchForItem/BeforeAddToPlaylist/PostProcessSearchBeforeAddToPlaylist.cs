using MediatR.Pipeline;
using SpotCli.Application.Search.SearchForItem;
using SpotCli.Cli.Services;
using SpotCli.Cli.Services.Playlist;

namespace SpotCli.Cli.Search.SearchForItem.BeforeAddToPlaylist;

public class PostProcessSearchBeforeAddToPlaylist : IRequestPostProcessor<SearchBeforeAddToPlaylistRequest, SearchForItemResponse>
{
    private readonly IPlaylistCreatorService _playlistCreatorService;
    private readonly IRequestQueue _requestQueue;

    public PostProcessSearchBeforeAddToPlaylist(IPlaylistCreatorService playlistCreatorService, IRequestQueue requestQueue)
    {
        _playlistCreatorService = playlistCreatorService;
        _requestQueue = requestQueue;
    }

    public Task Process(SearchBeforeAddToPlaylistRequest request, SearchForItemResponse response, CancellationToken cancellationToken)
    {
        var trackUri = response.Tracks.Items[0].Uri;
        _playlistCreatorService.AddTrackUri(trackUri);

        if (_playlistCreatorService.HasSearchedForAllTracks())
        {
            var playlistId = _playlistCreatorService.PlaylistId;
            var body = new AddToPlaylistRequestBody()
            {
                //todo
                Uris = _playlistCreatorService.UriArray()
            };
            var bulkAddRequest = new AddToPlaylistRequest(playlistId, body)
            // todo enqueue bulk add request in requestqueue
            _requestQueue.Enqueue(bulkAddRequest);
        }

        return Task.CompletedTask;
    }
}
