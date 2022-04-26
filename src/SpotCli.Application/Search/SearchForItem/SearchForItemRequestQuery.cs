using Refit;

namespace SpotCli.Application.Search.SearchForItem;

public record SearchForItemRequestQuery
{
    [AliasAs("q")]
    public string? Query { get; set; }
    [AliasAs("type")]
    public string[]? Types { get; set; }
    [AliasAs("include_external")]
    public string? IncludeExternal { get; set; }
    [AliasAs("limit")]
    public int? Limit { get; set; }
    [AliasAs("market")]
    public string? Market { get; set; }
    [AliasAs("offset")]
    public int? Offset { get; set; }
}
