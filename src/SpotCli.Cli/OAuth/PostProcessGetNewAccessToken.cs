using SpotCli.Application.Interfaces;
using MediatR.Pipeline;
using SpotCli.Application.OAuth.GetNewAccessToken;

namespace SpotCli.Cli.OAuth;

public class PostProcessGetNewAccessTokenCommand : IRequestPostProcessor<GetNewAccessTokenRequest, GetNewAccessTokenResponse>
{
    private readonly ISaveTokenService _saveTokenService;
    public PostProcessGetNewAccessTokenCommand(ISaveTokenService saveTokenService)
    {
        _saveTokenService = saveTokenService;
    }


    public Task Process(GetNewAccessTokenRequest request, GetNewAccessTokenResponse response, CancellationToken cancellationToken)
    {
        if(response.AccessToken is null)
        {
            throw new();
        }
        _saveTokenService.Save(response.AccessToken);

        return Task.CompletedTask;
    }
}
