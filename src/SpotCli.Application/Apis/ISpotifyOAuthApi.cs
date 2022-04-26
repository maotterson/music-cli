using Refit;
using SpotCli.Application.OAuth.GetNewAccessToken;

namespace SpotCli.Application.Apis;

public interface ISpotifyOAuthApi
{
    [Post("/api/token")]
    [Headers("Content-Type: application/x-www-form-urlencoded")]
    Task<IApiResponse<GetNewAccessTokenResponse>> GetNewAccessToken(
        [Header("Authorization")] string base64ClientSecretHeader, 
        [Body(BodySerializationMethod.UrlEncoded)] GetNewAccessTokenRequestBody body);
}
