using SpotCli.Core.Entities;
using SpotCli.WebApi.Api.Common;
using SpotCli.WebApi.Api.Dto;

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

    public async Task<IEnumerable<TrackRatingDto>> GetAll()
    {
        var trackRatings = _trackRatings
            .Select(rating =>
            {
                return rating.AsTrackRatingDto();
            }).AsEnumerable();
        return trackRatings;
    }
    public async Task<TrackRatingDto> GetById(string id)
    {
        var trackRating = _trackRatings
            .FirstOrDefault(rating => rating.Id.ToString() == id)!
            .AsTrackRatingDto();
        return trackRating;
    }
    public async Task Create(CreateTrackRatingDto createTrackRatingDto)
    {

    }
    public async Task Modify(string id)
    {

    }
    public async Task Delete(string id)
    {

    }
}
