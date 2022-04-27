using SpotCli.Application.CurrentTrack.StartOrResumePlayback;
using SpotCli.Application.Search.SearchForItem;
using SpotCli.Application.Utils;
using SpotCli.Cli.Services;

namespace SpotCli.Cli.Options.CurrentTrack.StartOrResumePlayback;

public class StartOrResumePlaybackOptionsMapper
{
    private readonly IRequestQueue _commandQueue;
    private readonly ISearchQueryBus _searchQueryBus;
    public StartOrResumePlaybackOptionsMapper(IRequestQueue commandQueue, ISearchQueryBus searchQueryBus)
    {
        _commandQueue = commandQueue;
        _searchQueryBus = searchQueryBus;
    }
    public void Map(StartOrResumePlaybackOptions options)
    {
        if(options.Query is not null)
        {
            var searchQuery = new SearchForItemRequestQuery()
            {
                Query = options.Query,
                Limit = 1,
                Types = "track"
            };

            var searchRequest = new SearchForItemRequest(searchQuery);
            _commandQueue.Enqueue(searchRequest);
            _search
            return;
        }

        var query = new StartOrResumePlaybackRequestQuery
        {
            DeviceId = options.DeviceId
        };
        var body = new StartOrResumePlaybackRequestBody
        {
            // todo receive potential body options
            Uris = options.TrackId is not null ?
                new[] { SpotifyContextUriBuilder.GetTrackContextUriFromId(options.TrackId) } :
                null
        };

        var request = new StartOrResumePlaybackRequest(query, body);
        _commandQueue.Enqueue(request);
    }
}

