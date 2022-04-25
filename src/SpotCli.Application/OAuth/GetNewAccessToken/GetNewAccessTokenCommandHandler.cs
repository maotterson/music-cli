using MediatR;
using SpotCli.Application.Api;
using SpotCli.Application.Interfaces;
using SpotCli.Application.OAuth.Commands;
using SpotCli.Application.OAuth.Responses;
using SpotCli.Application.OAuth.Utils;

namespace SpotCli.Application.OAuth.Handlers;

public class GetNewAccessTokenCommandHandler : IRequestHandler<GetNewAccessTokenCommand, GetNewAccessTokenResponse>
{
    private readonly ISpotifyOAuthApi _api;
    private readonly ISpotifyApiConfiguration _configuration;
    public GetNewAccessTokenCommandHandler(ISpotifyOAuthApi api, ISpotifyApiConfiguration configuration)
    {
        _api = api;
        _configuration = configuration;
    }
    public async Task<GetNewAccessTokenResponse> Handle(GetNewAccessTokenCommand request, CancellationToken cancellationToken)
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
