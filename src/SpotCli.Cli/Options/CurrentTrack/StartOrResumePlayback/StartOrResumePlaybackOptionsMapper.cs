using SpotCli.Application.CurrentTrack.StartOrResumePlayback;
using SpotCli.Application.Search.SearchForItem;
using SpotCli.Cli.Search.SearchForItem;
using SpotCli.Cli.Services;
using SpotCli.Core.Utils;

namespace SpotCli.Cli.Options.CurrentTrack.StartOrResumePlayback;

public class StartOrResumePlaybackOptionsMapper
{
    private readonly static int SEARCH_RESULTS_LIMIT_FOR_PLAY_REQUEST = 1;
    private readonly static string SEARCH_RESULTS_TYPES_ACCEPTED_FOR_PLAY_REQUEST = "track";

    private readonly IRequestQueue _commandQueue;
    public StartOrResumePlaybackOptionsMapper(IRequestQueue commandQueue)
    {
        _commandQueue = commandQueue;
    }
    public void Map(StartOrResumePlaybackOptions options)
    {
        if (options.SongQuery is not null)
        {
            SearchForProvidedQuery(options);
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
    private void SearchForProvidedQuery(StartOrResumePlaybackOptions options)
    {
        var searchQuery = new SearchForItemRequestQuery()
        {
            Query = options.SongQuery,
            Limit = SEARCH_RESULTS_LIMIT_FOR_PLAY_REQUEST,
            Types = SEARCH_RESULTS_TYPES_ACCEPTED_FOR_PLAY_REQUEST
        };

        var searchRequest = new SearchForItemBeforeStartOrResumePlaybackRequest(searchQuery, options);

        _commandQueue.Enqueue(searchRequest);
    }
}

