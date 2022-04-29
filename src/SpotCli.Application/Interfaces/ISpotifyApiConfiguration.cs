using Microsoft.Extensions.Configuration;

namespace SpotCli.Application.Interfaces;

public interface ISpotifyApiConfiguration
{
    public IConfigurationRoot Configuration { get; init; }
    public string? AppDataDirectory { get; }
    public string BearerTokenHeader { get; }
    public string BearerToken { get; }
    public string RefreshToken { get; }
    public string BaseAddress { get; }
    public string OAuthBaseAddress { get; }
    public string ClientId { get; }
    public string ClientSecret { get; }

    public string SpotifyId { get; }
    public Dictionary<string, string> SpotifyDeviceSettings { get; }
}
