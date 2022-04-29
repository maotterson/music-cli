using Newtonsoft.Json;

namespace SpotCli.Core.ValueObjects;

public record Album
{
    [JsonProperty("album_type")]
    public string? AlbumType { get; set; }
    [JsonProperty("name")]
    public string? Name { get; set; }
}
