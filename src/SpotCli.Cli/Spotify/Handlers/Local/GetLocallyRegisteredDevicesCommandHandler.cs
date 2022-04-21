using MediatR;
using SpotCli.Cli.Configuration;
using SpotCli.Cli.Spotify.Commands.Local;
using SpotCli.Cli.Spotify.Responses.Local;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SpotCli.Cli.Spotify.Responses.Local.GetLocallyRegisteredDevicesResponse;

namespace SpotCli.Cli.Spotify.Handlers.Local;

public class GetLocallyRegisteredDevicesCommandHandler : IRequestHandler<GetLocallyRegisteredDevicesCommand, GetLocallyRegisteredDevicesResponse>
{
    private readonly ISpotifyApiConfiguration _configuration;
    public GetLocallyRegisteredDevicesCommandHandler(ISpotifyApiConfiguration configuration)
    {
        _configuration = configuration;
    }
    public async Task<GetLocallyRegisteredDevicesResponse> Handle(GetLocallyRegisteredDevicesCommand request, CancellationToken cancellationToken)
    {
        var deviceDictionary = _configuration.SpotifyDeviceSettings;
        var response = new GetLocallyRegisteredDevicesResponse()
        {
            Devices = deviceDictionary
                .Select(kvp => new Device()
                    {
                        Id = kvp.Key,
                        Name = kvp.Value
                    })
                .ToArray()
        };

        return response;
    }
}
