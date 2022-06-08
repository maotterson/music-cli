using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SpotCli.WebApi.Api.Data;

public class TrackRatingDto
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; init; }
    [BsonElement("spotify_id")]
    public string? SpotifyId { get; init; }

    [BsonElement("track")]
    public string? Track { get; init; }
    [BsonElement("artist")]
    public string? Artist { get; init; }
    [BsonElement("album")]
    public string? Album { get; init; }
    [BsonElement("Rating")]
    public int Rating { get; init; }
}
