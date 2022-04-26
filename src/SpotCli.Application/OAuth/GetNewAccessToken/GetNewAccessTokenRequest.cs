using MediatR;
using Refit;
using SpotCli.Application.Interfaces;

namespace SpotCli.Application.OAuth.GetNewAccessToken;

public record GetNewAccessTokenRequest : IRequest<GetNewAccessTokenResponse>, IValidRequest
{
    public GetNewAccessTokenRequest(GetNewAccessTokenRequestBody body)
    {
        Body = body;
    }
    public GetNewAccessTokenRequestBody Body { get; set; }

    public string Description => "Get new access token";
}
