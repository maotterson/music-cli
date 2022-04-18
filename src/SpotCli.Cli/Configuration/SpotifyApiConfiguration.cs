using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace SpotCli.Cli.Configuration;

public class SpotifyApiConfiguration
{
    private readonly IConfigurationRoot _configuration;

    public SpotifyApiConfiguration(IConfigurationRoot configuration)
    {
        _configuration = configuration;
    }
    public string BearerToken => _configuration["BearerToken"];
    public string RefreshToken => _configuration["RefreshToken"];
    public string BaseAddress => _configuration["SpotifyApi:BaseAddress"];
    public string ClientId => _configuration["ClientId"];
    public string ClientSecret => _configuration["ClientSecret"];
}
