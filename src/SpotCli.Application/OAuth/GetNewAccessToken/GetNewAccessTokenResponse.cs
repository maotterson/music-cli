﻿using Newtonsoft.Json;

namespace SpotCli.Application.OAuth.GetNewAccessToken;
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

    public override string ToString()
    {
        return $"Access Token {AccessToken} retrieved.";
    }
}
