﻿using Refit;
using SpotCli.Cli.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotCli.Cli.Spotify.Api;

public interface ISpotifyApi
{
    [Get("/me/player/currently-playing")]
    Task<string> GetCurrentlyPlaying();

    [Post("/api/token")]
    [Headers("Content-Type: application/x-www-form-urlencoded")]
    Task<string> GetNewAccessToken([Header("Authorization")] string base64ClientSecretHeader, [Body(BodySerializationMethod.UrlEncoded)] GetNewAccessTokenRequest request);
}
