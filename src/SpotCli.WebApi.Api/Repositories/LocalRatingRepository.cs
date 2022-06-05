using SpotCli.Core.Entities;
using SpotCli.Core.Exceptions;
using SpotCli.Core.ValueObjects;
using SpotCli.WebApi.Api.Common;
using SpotCli.WebApi.Api.Data.Requests;

namespace SpotCli.WebApi.Api.Repositories;

public class LocalRatingRepository : IRatingRepository
{
    private readonly ICollection<TrackRating> _trackRatings = new List<TrackRating>()
    {
        new TrackRating
        {
            Id = Guid.NewGuid(),
            Artist = new("The Velvet Underground"),
            Track = new("Sunday Morning"),
            Album = new("The Velvet Underground & Nico"),
            Rating = new(5),
            SpotifyId = new("ABC123")
        },
        new TrackRating
        {
            Id = Guid.NewGuid(),
            Artist = new("Radiohead"),
            Track = new("Daydreaming"),
            Album = new("A Moon Shaped Pool"),
            Rating = new(5),
            SpotifyId = new("ASDF25")
        },
        new TrackRating
        {
            Id = Guid.NewGuid(),
            Artist = new("Radiohead"),
            Track = new("Decks Dark"),
            Album = new("A Moon Shaped Pool"),
            Rating = new(5),
            SpotifyId = new("B12345")
        },
        new TrackRating
        {
            Id = Guid.NewGuid(),
            Artist = new("Radiohead"),
            Track = new("Treefingers"),
            Album = new("Kid A"),
            Rating = new(4),
            SpotifyId = new("A123B6")
        },
    };

    public async Task<IEnumerable<TrackRating>> GetAll()
    {
        var trackRatings = _trackRatings.AsEnumerable();
        return trackRatings;
    }
    public async Task<TrackRating> GetById(string id)
    {
        var trackRating = _trackRatings.FirstOrDefault(rating => rating.Id.ToString() == id) ?? throw new TrackNotFoundException(id);
        return trackRating;
    }
    public async Task Create(CreateTrackRatingRequest request)
    {
        _trackRatings.Add(request.AsTrackRating());
    }
    public async Task Modify(ModifyTrackRatingRequest request, string id)
    {
        var oldTrackRating = _trackRatings
            .FirstOrDefault(tr => tr.Id.ToString() == id) ?? throw new TrackNotFoundException(id); 
        var updatedTrackRating = new TrackRating
        {
            Id = oldTrackRating!.Id,
            SpotifyId = request.SpotifyId is not null ? new SpotifyIdVO(request.SpotifyId) : oldTrackRating.SpotifyId,
            Artist = request.Artist is not null ? new ArtistVO(request.Artist) : oldTrackRating.Artist,
            Album = request.Album is not null ? new AlbumVO(request.Album) : oldTrackRating.Album,
            Track = request.Track is not null ? new TrackVO(request.Track) : oldTrackRating.Track,
            Rating = new RatingVO(request.Rating)
        };
        _trackRatings.Remove(oldTrackRating);
        _trackRatings.Add(updatedTrackRating);
    }

    public async Task Delete(string id)
    {
        var oldTrackRating = _trackRatings
            .FirstOrDefault(tr => tr.Id.ToString() == id) ?? throw new TrackNotFoundException(id);
        _trackRatings.Remove(oldTrackRating);
    }
}
