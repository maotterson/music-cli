using SpotCli.Application.Search.SearchForItem;
using SpotCli.Cli.Services;

namespace SpotCli.Cli.Options.Search;

public class SearchForItemOptionsMapper
{
    private readonly IRequestQueue _requestQueue;
    private readonly static int RESULTS_LIMIT = 5;
    private readonly static string RESULTS_TYPES = "track";

    public SearchForItemOptionsMapper(IRequestQueue requestQueue)
    {
        _requestQueue = requestQueue;
    }

    public void Map(SearchForItemOptions options)
    {
        var query = new SearchForItemRequestQuery()
        {
            Query = options.Query,
            Limit = RESULTS_LIMIT,
            Types = RESULTS_TYPES
            // todo other potential parameters omitted, could be added later
        };

        var request = new SearchForItemRequest(query);
        _requestQueue.Enqueue(request);
    }
}
