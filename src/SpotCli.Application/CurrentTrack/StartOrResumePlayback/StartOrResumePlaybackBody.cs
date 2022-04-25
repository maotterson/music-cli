using MediatR;
using Newtonsoft.Json;
using SpotCli.Application.CurrentTrack.Responses;
using SpotCli.Application.Interfaces;
using SpotCli.Application.ValueObjects;

namespace SpotCli.Application.CurrentTrack.Commands;

public record StartOrResumePlaybackBody
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