﻿using MediatR;
using SpotCli.Cli.Configuration;
using static SpotCli.Cli.Devices.GetLocallyRegisteredDevicesResponse;

namespace SpotCli.Cli.Devices;

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
