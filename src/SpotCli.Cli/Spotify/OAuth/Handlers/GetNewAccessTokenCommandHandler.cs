using SpotCli.Cli.Spotify.Commands;
using MediatR;
using SpotCli.Cli.Spotify.Api;
using SpotCli.Cli.Configuration;
using SpotCli.Cli.Spotify.OAuth;
using Refit;

namespace SpotCli.Cli.Spotify.Handlers;

public class GetNewAccessTokenCommandHandler : IRequestHandler<GetNewAccessTokenCommand, GetNewAccessTokenResponse>
{
    private readonly ISpotifyOAuthApi _api;
    private readonly ISpotifyApiConfiguration _configuration;
    private readonly ISaveTokenService _saveTokenService;
    public GetNewAccessTokenCommandHandler(ISpotifyOAuthApi api, ISpotifyApiConfiguration configuration, ISaveTokenService saveTokenService)
    {
        _api = api;
        _configuration = configuration;
        _saveTokenService = saveTokenService;
    }
    public async Task<GetNewAccessTokenResponse> Handle(GetNewAccessTokenCommand request, CancellationToken cancellationToken)
    {
        var header = new Base64ClientSecretAuthHeader(_configuration.ClientSecret, _configuration.ClientId).Get();
        var response = await _api.GetNewAccessToken(header, request);
        if (response.IsSuccessStatusCode && response.Content is not null && response.Content.AccessToken is not null)
        {
            _saveTokenService.Save(response.Content.AccessToken);
        }

        return response.Content;
    }
}
