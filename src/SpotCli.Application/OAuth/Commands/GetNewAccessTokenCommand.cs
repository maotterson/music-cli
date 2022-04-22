using MediatR;
using Refit;
using SpotCli.Application.Interfaces;
using SpotCli.Application.OAuth.Responses;

namespace SpotCli.Application.OAuth.Commands;

public record GetNewAccessTokenCommand : IRequest<GetNewAccessTokenResponse>, IValidCommand
{
    public GetNewAccessTokenCommand(string refreshToken)
    {
        RefreshToken = refreshToken;
    }

    [AliasAs("grant_type")]
    public string GrantType { get; init; } = "refresh_token";
    [AliasAs("refresh_token")]
    public string RefreshToken { get; init; }

    public string Description => "Get new access token";
}
