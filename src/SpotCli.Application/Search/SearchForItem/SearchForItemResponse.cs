using Refit;
using SpotCli.Core.ValueObjects;

namespace SpotCli.Application.Search.SearchForItem;

public record SearchForItemResponse
{
    public override string ToString()
    {
        string output = "Search Results:\n=============================\n";
        foreach(var item in Tracks.Items)
        {
            var primaryArtistName = item.Artists[0].Name;
            var albumName = item.Album.Name;
            var trackName = item.Name;
            var id = item.Id;

            output += $"{primaryArtistName} - {trackName} (Album: {albumName})\nTrack Id: {id}\n\n";
        }

        return output;
    }

    [AliasAs("tracks")]
    public TrackObject Tracks { get; set; } // currently implemented
    [AliasAs("artists")]
    public string? Artists { get; set; }
    [AliasAs("albums")]
    public string? Albums { get; set; }
    [AliasAs("playlists")]
    public string? Playlists { get; set; }
    [AliasAs("shows")]
    public string? Shows { get; set; }
    [AliasAs("episodes")]
    public string? Episodes { get; set; }

    public struct TrackObject
    {
        [AliasAs("href")]
        public string Href { get; set; }
        [AliasAs("items")]
        public TrackItem[] Items { get; set; }
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

    public struct TrackItem
    {
        [AliasAs("album")]
        public Album Album { get; set; }

        [AliasAs("artist")]
        public Artist[] Artists { get; set; }

        [AliasAs("name")]
        public string Name { get; set; }

        [AliasAs("uri")]
        public string Uri { get; set; }

        [AliasAs("id")]
        public string Id { get; set; }
    }
}


