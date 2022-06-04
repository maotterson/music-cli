﻿using Newtonsoft.Json;

namespace SpotCli.WebApi.Api.Dto;

public class CreateTrackRatingDto
{
    [JsonProperty("spotify_id")]
    public string SpotifyId { get; init; }
    [JsonProperty("track")]
    public string Track { get; init; }
    [JsonProperty("artist")]
    public string Artist { get; init; }
    [JsonProperty("album")]
    public string Album { get; init; }
    [JsonProperty("rating")]
    public int Rating { get; init; }
}
