using MongoDB.Bson;
using SpotCli.Core.Entities;
using SpotCli.Core.ValueObjects;
using SpotCli.WebApi.Api.Data;
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

    public static TrackRating AsTrackRating(this TrackRatingDto trackRatingDto)
    {
        var trackRating = new TrackRating
        {
            Id = trackRatingDto.Id!,
            SpotifyId = new SpotifyIdVO(trackRatingDto.SpotifyId),
            Artist = new ArtistVO(trackRatingDto.Artist),
            Album = new AlbumVO(trackRatingDto.Album),
            Track = new TrackVO(trackRatingDto.Track),
            Rating = new RatingVO(trackRatingDto.Rating)
        };
        return trackRating;
    }
    public static TrackRatingDto AsRatingDto(this CreateTrackRatingRequest trackRatingRequest)
    {
        var dto = new TrackRatingDto
        {
            SpotifyId = trackRatingRequest.SpotifyId,
            Artist = trackRatingRequest.Artist,
            Album = trackRatingRequest.Album,
            Track = trackRatingRequest.Track,
            Rating = trackRatingRequest.Rating
        };
        return dto;
    }
    public static TrackRatingDto AsRatingDto(this ModifyTrackRatingRequest trackRatingRequest)
    {
        var dto = new TrackRatingDto
        {
            SpotifyId = trackRatingRequest.SpotifyId,
            Artist = trackRatingRequest.Artist,
            Album = trackRatingRequest.Album,
            Track = trackRatingRequest.Track,
            Rating = trackRatingRequest.Rating
        };
        return dto;
    }
}
