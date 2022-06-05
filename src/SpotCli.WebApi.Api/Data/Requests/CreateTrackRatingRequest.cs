using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SpotCli.WebApi.Api.Data.Requests;

public class CreateTrackRatingRequest
{
    [Required]
    [JsonPropertyName("spotify_id")]
    public string SpotifyId { get; init; }
    [Required]
    [JsonPropertyName("track")]
    public string Track { get; init; }
    [Required]
    [JsonPropertyName("artist")]
    public string Artist { get; init; }
    [Required]
    [JsonPropertyName("album")]
    public string Album { get; init; }
    [Required]
    [JsonPropertyName("rating")]
    public int Rating { get; init; }
}
