using Refit;
using SpotCli.Application.Ratings.GetAllRatings;

namespace SpotCli.Application.Apis;
public interface ILambdaRatingsApi
{
    [Get("/")]
    Task<IApiResponse<GetAllRatingsResponse>> GetAllRatings();
}
