using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotCli.Cli.Spotify.OAuth;
public record GetNewAccessTokenResponse
{
    [JsonProperty(PropertyName = "access_token")]
    public string? AccessToken { get; set; }

    [JsonProperty(PropertyName = "token_type")]
    public string? TokenType { get; set; }

    [JsonProperty(PropertyName = "expires_in")]
    public string? ExpiresIn { get; set; }

    [JsonProperty(PropertyName = "scope")]
    public string? Scope { get; set; }
}
