using SpotCli.Application.CurrentTrack.StartOrResumePlayback;
using SpotCli.Cli.Options.Utils;
using SpotCli.Cli.Search.Enums;
using SpotCli.Cli.Search.SearchForItem;
using SpotCli.Cli.Services;
using SpotCli.Core.Utils;

namespace SpotCli.Cli.Options.CurrentTrack.StartOrResumePlayback;

public class StartOrResumePlaybackOptionsMapper
{

    private readonly IRequestQueue _commandQueue;
    public StartOrResumePlaybackOptionsMapper(IRequestQueue commandQueue)
    {
        _commandQueue = commandQueue;
    }
    public void Map(StartOrResumePlaybackOptions options)
    {
        var (preSearchMethod, searchQuery) = GetSearchTypeBeforePlayback(options);
        if (preSearchMethod is not null && searchQuery is not null)
        {
            CreatePrePlaybackSearchRequest((SearchMethod)preSearchMethod, searchQuery, options);
            return;
        }

        CreateStartOrResumePlaybackRequest(options);
    }

    private void CreateStartOrResumePlaybackRequest(StartOrResumePlaybackOptions options)
    {
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

    private (SearchMethod? Method,string? Query) GetSearchTypeBeforePlayback(StartOrResumePlaybackOptions options)
    {
        if(options.SongQuery is not null)
        {
            return (SearchMethod.Track, options.SongQuery);
        }
        else if(options.AlbumQuery is not null)
        {
            return (SearchMethod.Album, options.AlbumQuery);
        }
        else if(options.ArtistQuery is not null)
        {
            return (SearchMethod.Artist, options.ArtistQuery);
        }
        return (null,null);
    }
    private void CreatePrePlaybackSearchRequest(SearchMethod searchMethod, string search, StartOrResumePlaybackOptions options)
    {
        var query = SearchMethodToQueryDictionary.GetQuery(searchMethod, search);
        var searchRequest = new SearchBeforePlaybackRequest(searchMethod, query, options);

        _commandQueue.Enqueue(searchRequest);
    }
}

