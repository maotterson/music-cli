using Newtonsoft.Json;

namespace SpotCli.Core.ValueObjects;

public record Artist
{
    [JsonProperty("name")]
    public string? Name { get; init; }
}