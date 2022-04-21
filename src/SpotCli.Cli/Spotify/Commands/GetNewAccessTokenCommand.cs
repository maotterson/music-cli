using MediatR;
using Refit;
using SpotCli.Cli.Spotify.OAuth;

namespace SpotCli.Cli.Spotify.Commands;

public record GetNewAccessTokenCommand : IConsoleVerb, IRequest<IApiResponse<GetNewAccessTokenResponse>>
{
    public GetNewAccessTokenCommand(string refreshToken)
    {
        RefreshToken = refreshToken;
    }

    [AliasAs("grant_type")]
    public string GrantType { get; init; } = "refresh_token";
    [AliasAs("refresh_token")]
    public string RefreshToken { get; init; }

    public string ConsoleArgument => "refresh";
}
