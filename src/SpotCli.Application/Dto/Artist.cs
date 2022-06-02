using Newtonsoft.Json;

namespace SpotCli.Application.Dto;

public record Artist
{
    [JsonProperty("name")]
    public string? Name { get; init; }
}