using SpotCli.WebApi.Api.Dto;

namespace SpotCli.WebApi.Api.Repositories;

public interface IRatingRepository
{
    Task<IEnumerable<TrackRatingDto>> GetAll();
    Task<TrackRatingDto> GetById(string id);
    Task Create(CreateTrackRatingDto createTrackRatingDto);
    Task Modify(string id);
    Task Delete(string id);
}
