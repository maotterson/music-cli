using SpotCli.Core.Entities;
using SpotCli.WebApi.Api.Data.Requests;

namespace SpotCli.WebApi.Api.Repositories;

public interface IRatingRepository
{
    Task<IEnumerable<TrackRating>> GetAll();
    Task<TrackRating> GetById(string id);
    Task Create(CreateTrackRatingRequest request);
    Task Modify(ModifyTrackRatingRequest request, string id);
    Task Delete(string id);
}
