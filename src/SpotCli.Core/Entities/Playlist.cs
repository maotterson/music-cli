using Newtonsoft.Json;

namespace SpotCli.Core.Entities;

public record Playlist
{
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("uri")]
    public string Uri { get; set; }
}
