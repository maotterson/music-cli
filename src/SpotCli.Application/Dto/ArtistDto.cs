using Newtonsoft.Json;

namespace SpotCli.Application.Dto;

public record ArtistDto
{
    [JsonProperty("name")]
    public string? Name { get; init; }
}