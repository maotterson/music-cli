using SpotCli.Application.Search.SearchForItem;

namespace SpotCli.Cli.Search.SearchForItem;

public class SearchForItemBeforeStartOrResumePlaybackRequest : SearchForItemRequest, IRequestBeforeStartOrResumePlayback
{
    public SearchForItemBeforeStartOrResumePlaybackRequest(SearchForItemRequestQuery query) : base(query)
    {
    }
}
