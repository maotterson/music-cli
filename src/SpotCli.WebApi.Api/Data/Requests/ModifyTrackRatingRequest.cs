using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SpotCli.WebApi.Api.Data.Requests;

public class ModifyTrackRatingRequest
{
    [JsonPropertyName("spotify_id")]
    public string? SpotifyId { get; init; }
    [JsonPropertyName("track")]
    public string? Track { get; init; }
    [JsonPropertyName("artist")]
    public string? Artist { get; init; }
    [JsonPropertyName("album")]
    public string? Album { get; init; }
    [Required]
    [JsonPropertyName("rating")]
    public int Rating { get; init; }
}
