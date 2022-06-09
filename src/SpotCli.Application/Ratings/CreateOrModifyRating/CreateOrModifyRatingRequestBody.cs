using Refit;

namespace SpotCli.Application.Ratings.CreateOrModifyRating;

public class CreateOrModifyRatingRequestBody
{
    [AliasAs("spotify_id")]
    public string? SpotifyId { get; init; }
    [AliasAs("track")]
    public string? Track { get; init; }
    [AliasAs("artist")]
    public string? Artist { get; init; }
    [AliasAs("album")]
    public string? Album { get; init; }
    [AliasAs("rating")]
    public int Rating { get; init; }
}