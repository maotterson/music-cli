﻿using Refit;
using SpotCli.Cli.Spotify.Commands;
using SpotCli.Cli.Spotify.OAuth;

namespace SpotCli.Cli.Spotify.Api;

public interface ISpotifyOAuthApi
{
    [Post("/api/token")]
    [Headers("Content-Type: application/x-www-form-urlencoded")]
    Task<IApiResponse<GetNewAccessTokenResponse>> GetNewAccessToken([Header("Authorization")] string base64ClientSecretHeader, [Body(BodySerializationMethod.UrlEncoded)] GetNewAccessTokenCommand command);
}
