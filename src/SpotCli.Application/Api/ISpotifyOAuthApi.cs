using Refit;
using SpotCli.Application.OAuth.Commands;
using SpotCli.Application.OAuth.Responses;

namespace SpotCli.Application.Api;

public interface ISpotifyOAuthApi
{
    [Post("/api/token")]
    [Headers("Content-Type: application/x-www-form-urlencoded")]
    Task<IApiResponse<GetNewAccessTokenResponse>> GetNewAccessToken([Header("Authorization")] string base64ClientSecretHeader, [Body(BodySerializationMethod.UrlEncoded)] GetNewAccessTokenCommand command);
}
