using Refit;

namespace SpotCli.Application.OAuth.GetNewAccessToken;

public record GetNewAccessTokenRequestBody
{
    [AliasAs("grant_type")]
    public string GrantType { get; } = "refresh_token";
    [AliasAs("refresh_token")]
    public string RefreshToken { get; init; }
}
