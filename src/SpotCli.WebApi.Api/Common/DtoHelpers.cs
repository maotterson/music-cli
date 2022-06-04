using SpotCli.Core.Entities;
using SpotCli.WebApi.Api.Dto;

namespace SpotCli.WebApi.Api.Common;

public static class DtoHelpers
{
    public static TrackRatingDto AsTrackRatingDto(this TrackRating trackRating)
    {
        var dto = new TrackRatingDto
        {
            Id = trackRating.Id,
            SpotifyId = trackRating.SpotifyId!.Value,
            Artist = trackRating.Artist!.Value,
            Album = trackRating.Album!.Value,
            Track = trackRating.Track!.Value,
            Rating = trackRating.Rating!.Value
        };
        return dto;
    }
}
