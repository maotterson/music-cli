using SpotCli.Application.Interfaces;

namespace SpotCli.Application.Search.SearchForItem;

public class SearchForItemRequest : IValidRequest
{
    public SearchForItemRequest(SearchForItemRequestQuery query)
    {
        Query = query;
    }

    public SearchForItemRequestQuery Query { get; init; }

    public string Description => "Search for item";
}
