using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace SpotCli.Cli.Configuration;

public class SpotifyApiConfiguration : ISpotifyApiConfiguration
{
    public SpotifyApiConfiguration(IConfigurationRoot configuration)
    {
        Configuration = configuration;
    }
    public IConfigurationRoot Configuration { get; init; }
    public string BearerTokenHeader => $"Bearer {BearerToken}";
    public string BearerToken => Configuration["BearerToken"];
    public string RefreshToken => Configuration["RefreshToken"];
    public string BaseAddress => Configuration["SpotifyApi:BaseAddress"];
    public string OAuthBaseAddress => Configuration["SpotifyApi:OAuthBaseAddress"];
    public string ClientId => Configuration["ClientId"];
    public string ClientSecret => Configuration["ClientSecret"];
    public Dictionary<string, string> SpotifyDeviceSettings => Configuration.GetSection("Devices").Get<Dictionary<string, string>>();
}
