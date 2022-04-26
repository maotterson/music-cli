using Refit;

namespace SpotCli.Application.Search.SearchForItem;

public record SearchForItemResponse
{
    [AliasAs("tracks")]
    public SearchObject Tracks { get; set; }
    [AliasAs("artists")]
    public SearchObject Artists { get; set; }
    [AliasAs("albums")]
    public SearchObject Albums { get; set; }
    [AliasAs("playlists")]
    public SearchObject Playlists { get; set; }
    [AliasAs("shows")]
    public SearchObject Shows { get; set; }
    [AliasAs("episodes")]
    public SearchObject Episodes { get; set; }

    public struct SearchObject
    {
        [AliasAs("href")]
        public string Href { get; set; }
        [AliasAs("items")]
        public SearchObject[] Items { get; set; }
        [AliasAs("limit")]
        public int Limit { get; set; }
        [AliasAs("next")]
        public string Next { get; set; }
        [AliasAs("offset")]
        public int Offset { get; set; }
        [AliasAs("previous")]
        public string Previous { get; set; }
        [AliasAs("total")]
        public int Total { get; set; }
    }
}


