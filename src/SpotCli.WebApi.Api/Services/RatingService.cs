using SpotCli.Core.Entities;
using SpotCli.WebApi.Api.Common;
using SpotCli.WebApi.Api.Data.Requests;
using SpotCli.WebApi.Api.Repositories;

namespace SpotCli.WebApi.Api.Services;

public class RatingService : IRatingService
{
    private readonly IRatingRepository _ratingRepository;
    public RatingService(IRatingRepository ratingRepository)
    {
        _ratingRepository = ratingRepository;
    }

    public async Task Create(CreateTrackRatingRequest request)
    {
        await _ratingRepository.Create(request);
    }

    public async Task Delete(string id)
    {
        await _ratingRepository.Delete(id);
    }

    public async Task<IEnumerable<TrackRating>> GetAll()
    {
        var dtoCollection = await _ratingRepository.GetAll();
        return dtoCollection.Select(dto => dto.AsTrackRating());
    }

    public async Task<TrackRating> GetById(string id)
    {
        var dto = await _ratingRepository.GetById(id);
        return dto.AsTrackRating();
    }

    public async Task Modify(ModifyTrackRatingRequest request, string id)
    {
        await _ratingRepository.Modify(request, id);
    }
}
