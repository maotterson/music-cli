using System.Text.Json.Serialization;

namespace SpotCli.WebApi.Api.Data.Responses;

public class TrackRatingResponse
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    [JsonPropertyName("spotify_id")]
    public string SpotifyId { get; init; }
    [JsonPropertyName("track")]
    public string Track { get; init; }
    [JsonPropertyName("artist")]
    public string Artist { get; init; }
    [JsonPropertyName("album")]
    public string Album { get; init; }
    [JsonPropertyName("rating")]
    public int Rating { get; init; }

}
