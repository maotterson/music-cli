using Microsoft.Extensions.Configuration;
using SpotCli.Application.Interfaces;

namespace SpotCli.Cli.Configuration;

public class SpotifyApiConfiguration : ISpotifyApiConfiguration
{
    public SpotifyApiConfiguration(IConfigurationRoot configuration)
    {
        Configuration = configuration;
    }
    public IConfigurationRoot Configuration { get; init; }
    public string? AppDataDirectory => Configuration["AppDataDirectory"];
    public string BearerTokenHeader => $"Bearer {BearerToken}";
    public string BearerToken => Configuration["BearerToken"];
    public string RefreshToken => Configuration["RefreshToken"];
    public string BaseAddress => Configuration["SpotifyApi:BaseAddress"];
    public string OAuthBaseAddress => Configuration["SpotifyApi:OAuthBaseAddress"];
    public string ClientId => Configuration["ClientId"];
    public string ClientSecret => Configuration["ClientSecret"];
    public string SpotifyId => Configuration["SpotifyId"];
    public string WebApiRatingsEndpoint => Configuration["WebApi:RatingsEndpoint"];
    public string WebApiAuthorizationKey => Configuration["WebApi:AuthorizationKey"];
    public Dictionary<string, string> SpotifyDeviceSettings => Configuration.GetSection("Devices").Get<Dictionary<string, string>>();
}
