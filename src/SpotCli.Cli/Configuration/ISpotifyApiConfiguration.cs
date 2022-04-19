using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotCli.Cli.Configuration;

public interface ISpotifyApiConfiguration
{
    public string BearerTokenHeader { get; }
    public string BearerToken { get; }
    public string RefreshToken { get; }
    public string BaseAddress { get; }
    public string OAuthBaseAddress { get; }
    public string ClientId { get; }
    public string ClientSecret { get; }
}
