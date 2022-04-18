using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SpotCli.Cli.OAuth;

public record GetNewAccessTokenRequest
{
    public GetNewAccessTokenRequest(string refreshToken)
    {
        RefreshToken = refreshToken;
    }

    [JsonProperty(PropertyName = "grant_type")]
    public string GrantType { get; init; } = "refresh_token";
    [JsonProperty(PropertyName = "refresh_token")]
    public string RefreshToken { get; init; }

    
}
