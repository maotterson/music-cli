using Microsoft.Extensions.Configuration;

namespace SpotCli.Cli.Configuration;

public interface ISpotifyApiConfiguration
{
    public IConfigurationRoot Configuration { get; init; }
    public string BearerTokenHeader { get; }
    public string BearerToken { get; }
    public string RefreshToken { get; }
    public string BaseAddress { get; }
    public string OAuthBaseAddress { get; }
    public string ClientId { get; }
    public string ClientSecret { get; }
    public Dictionary<string, string> SpotifyDeviceSettings { get; }
}
