using Newtonsoft.Json;

namespace SpotCli.Application.Dto;

public record PlaylistDto
{
    [JsonProperty("id")]
    public string? Id { get; set; }
    [JsonProperty("name")]
    public string? Name { get; set; }
    [JsonProperty("uri")]
    public string? Uri { get; set; }
}
