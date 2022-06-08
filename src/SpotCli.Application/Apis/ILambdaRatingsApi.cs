using Refit;
using SpotCli.Application.Ratings.GetAllRatings;
using SpotCli.Application.Ratings.GetRating;

namespace SpotCli.Application.Apis;
public interface ILambdaRatingsApi
{
    [Get("/")]
    Task<IApiResponse<GetAllRatingsResponse>> GetAllRatings();
    [Get("/{id}")]
    Task<IApiResponse<GetRatingResponse>> GetRatingById(string id);
}
