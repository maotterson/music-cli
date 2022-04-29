using SpotCli.Application.Search.SearchForItem;
using SpotCli.Cli.Search.Enums;

namespace SpotCli.Cli.Options.Utils;

internal static class SearchMethodToQueryDictionary
{
    private readonly static int SEARCH_RESULTS_LIMIT_FOR_PLAY_REQUEST = 1;
    private readonly static string SEARCH_RESULTS_TYPES_ACCEPTED_FOR_TRACK_REQUEST = "track";
    private readonly static string SEARCH_RESULTS_TYPES_ACCEPTED_FOR_ALBUM_REQUEST = "album";
    private readonly static string SEARCH_RESULTS_TYPES_ACCEPTED_FOR_ARTIST_REQUEST = "artist";
    private static Dictionary<SearchMethod, Func<string, SearchForItemRequestQuery>> _dictionary = new()
    {
        {
            SearchMethod.Album,
            query =>
            {
                return new SearchForItemRequestQuery()
                {
                    Query = query,
                    Limit = SEARCH_RESULTS_LIMIT_FOR_PLAY_REQUEST,
                    Types = SEARCH_RESULTS_TYPES_ACCEPTED_FOR_ALBUM_REQUEST
                };
            }
        },
        {
            SearchMethod.Artist,
            query =>
            {
                return new SearchForItemRequestQuery()
                {
                    Query = query,
                    Limit = SEARCH_RESULTS_LIMIT_FOR_PLAY_REQUEST,
                    Types = SEARCH_RESULTS_TYPES_ACCEPTED_FOR_ARTIST_REQUEST
                };
            }
        },
        {
            SearchMethod.Track,
            query =>
            {
                return new SearchForItemRequestQuery()
                {
                    Query = query,
                    Limit = SEARCH_RESULTS_LIMIT_FOR_PLAY_REQUEST,
                    Types = SEARCH_RESULTS_TYPES_ACCEPTED_FOR_TRACK_REQUEST
                };
            }
        }
    };

    internal static SearchForItemRequestQuery GetQuery(SearchMethod searchMethod, string searchQuery)
    {
        return _dictionary[searchMethod](searchQuery);
    }
}
