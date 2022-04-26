
using SpotCli.Application.Interfaces;
using SpotCli.Application.OAuth.GetNewAccessToken;
using SpotCli.Cli.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotCli.Cli.Options.OAuth.GetNewAccessToken;

public class GetNewAccessTokenOptionsMapper
{
    private readonly IRequestQueue _commandQueue;
    private readonly ISpotifyApiConfiguration _configuration;
    public GetNewAccessTokenOptionsMapper(IRequestQueue commandQueue, ISpotifyApiConfiguration configuration)
    {
        _commandQueue = commandQueue;
        _configuration = configuration;
    }
    public void Map(GetNewAccessTokenOptions options)
    {
        var body = new GetNewAccessTokenRequestBody
        {
            RefreshToken = _configuration.RefreshToken
        };

        var request = new GetNewAccessTokenRequest(body);
        _commandQueue.Enqueue(request);
    }
}
