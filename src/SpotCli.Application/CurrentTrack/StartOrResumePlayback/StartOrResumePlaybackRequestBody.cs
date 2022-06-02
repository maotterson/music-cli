using Newtonsoft.Json;
using SpotCli.Application.Dto;

namespace SpotCli.Application.CurrentTrack.StartOrResumePlayback;

public record StartOrResumePlaybackRequestBody
{
    [JsonProperty("context_uri")]
    public string? ContextUri { get; init; }

    [JsonProperty("uris")]
    public string[]? Uris { get; init; }

    [JsonProperty("offset")]
    public AdditionalProperties? Offset { get; init; }

    [JsonProperty("position_ms")]
    public int? PositionMs { get; init; }
}