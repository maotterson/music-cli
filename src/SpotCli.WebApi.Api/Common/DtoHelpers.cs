using SpotCli.Core.Entities;
using SpotCli.Core.ValueObjects;
using SpotCli.WebApi.Api.Data.Requests;
using SpotCli.WebApi.Api.Data.Responses;

namespace SpotCli.WebApi.Api.Common;

public static class DtoHelpers
{
    public static TrackRatingResponse AsTrackRatingResponse(this TrackRating trackRating)
    {
        var response = new TrackRatingResponse
        {
            Id = trackRating.Id,
            SpotifyId = trackRating.SpotifyId!.Value,
            Artist = trackRating.Artist!.Value,
            Album = trackRating.Album!.Value,
            Track = trackRating.Track!.Value,
            Rating = trackRating.Rating!.Value
        };
        return response;
    }

    public static TrackRating AsTrackRating(this CreateTrackRatingRequest trackRatingRequest)
    {
        var trackRating = new TrackRating
        {
            Id = Guid.NewGuid(),
            SpotifyId = new SpotifyIdVO(trackRatingRequest.SpotifyId),
            Artist = new ArtistVO(trackRatingRequest.Artist),
            Album = new AlbumVO(trackRatingRequest.Album),
            Track = new TrackVO(trackRatingRequest.Track),
            Rating = new RatingVO(trackRatingRequest.Rating)
        };
        return trackRating;
    }
}
