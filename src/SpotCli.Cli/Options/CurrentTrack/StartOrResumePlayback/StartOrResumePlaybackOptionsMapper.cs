using SpotCli.Application.CurrentTrack.StartOrResumePlayback;
using SpotCli.Application.Search.SearchForItem;
using SpotCli.Application.Utils;
using SpotCli.Cli.Search.SearchForItem;
using SpotCli.Cli.Services;

namespace SpotCli.Cli.Options.CurrentTrack.StartOrResumePlayback;

public class StartOrResumePlaybackOptionsMapper
{
    private readonly static int SEARCH_RESULTS_LIMIT_FOR_PLAY_REQUEST = 1;
    private readonly static string SEARCH_RESULTS_TYPES_ACCEPTED_FOR_PLAY_REQUEST = "track";

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
            SearchForProvidedQuery(options.Query);
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
    private void SearchForProvidedQuery(string query)
    {
        var searchQuery = new SearchForItemRequestQuery()
        {
            Query = query,
            Limit = SEARCH_RESULTS_LIMIT_FOR_PLAY_REQUEST,
            Types = SEARCH_RESULTS_TYPES_ACCEPTED_FOR_PLAY_REQUEST
        };

        var searchRequest = new SearchForItemBeforeStartOrResumePlaybackRequest(searchQuery);

        _commandQueue.Enqueue(searchRequest);
    }
}

