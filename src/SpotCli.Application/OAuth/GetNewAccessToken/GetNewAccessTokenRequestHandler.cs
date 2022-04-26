using MediatR;
using SpotCli.Application.Apis;
using SpotCli.Application.Interfaces;
using SpotCli.Application.OAuth.Utils;

namespace SpotCli.Application.OAuth.GetNewAccessToken;

public class GetNewAccessTokenRequestHandler : IRequestHandler<GetNewAccessTokenRequest, GetNewAccessTokenResponse>
{
    private readonly ISpotifyOAuthApi _api;
    private readonly ISpotifyApiConfiguration _configuration;
    public GetNewAccessTokenRequestHandler(ISpotifyOAuthApi api, ISpotifyApiConfiguration configuration)
    {
        _api = api;
        _configuration = configuration;
    }
    public async Task<GetNewAccessTokenResponse> Handle(GetNewAccessTokenRequest request, CancellationToken cancellationToken)
    {
        var header = new Base64ClientSecretAuthHeader(_configuration.ClientSecret, _configuration.ClientId).Get();
        var response = await _api.GetNewAccessToken(header, request);
        if(!response.IsSuccessStatusCode || response.Content is null || response.Content.AccessToken is null)
        {
            throw new();
        }
        return response.Content;
    }
}
