using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotCli.Application.Ratings.GetRating;
public class GetRatingResponse
{
    [JsonProperty("id")]
    public string Id { get; init; }
    [JsonProperty("spotify_id")]
    public string SpotifyId { get; init; }
    [JsonProperty("artist")]
    public string Artist { get; init; }
    [JsonProperty("album")]
    public string Album { get; init; }
    [JsonProperty("track")]
    public string Track { get; init; }
    [JsonProperty("rating")]
    public int Rating { get; init; }
}
