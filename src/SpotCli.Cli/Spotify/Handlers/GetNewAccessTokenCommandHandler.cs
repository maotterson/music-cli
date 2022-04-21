using SpotCli.Cli.Spotify.Commands;
using MediatR;
using SpotCli.Cli.Spotify.Api;
using SpotCli.Cli.Configuration;
using SpotCli.Cli.Spotify.OAuth;
using Refit;

namespace SpotCli.Cli.Spotify.Handlers;

public class GetNewAccessTokenCommandHandler : IRequestHandler<GetNewAccessTokenCommand, IApiResponse<GetNewAccessTokenResponse>>
{
    private readonly ISpotifyOAuthApi _api;
    private readonly ISpotifyApiConfiguration _configuration;
    public GetNewAccessTokenCommandHandler(ISpotifyOAuthApi api, ISpotifyApiConfiguration configuration)
    {
        _api = api;
        _configuration = configuration;
    }
    public async Task<IApiResponse<GetNewAccessTokenResponse>> Handle(GetNewAccessTokenCommand request, CancellationToken cancellationToken)
    {
        var header = new Base64ClientSecretAuthHeader(_configuration.ClientSecret, _configuration.ClientId).Get();
        var response = await _api.GetNewAccessToken(header, request);
        return response;
    }
}
