using SpotCli.Application.Search.SearchForItem;
using SpotCli.Cli.Search.Decorators;

namespace SpotCli.Cli.Search.SearchForItem.BeforeAddToPlaylist;

public class SearchBeforeAddToPlaylistRequest : SearchForItemRequest, ISearchRequestBeforeAddToPlaylist
{
    public SearchBeforeAddToPlaylistRequest(SearchForItemRequest baseRequest) : base(baseRequest.Query)
    {
    }
}
