using MediatR;
using SpotCli.Application.Interfaces;
using static SpotCli.Cli.Devices.GetLocallyRegisteredDevices.GetLocallyRegisteredDevicesResponse;

namespace SpotCli.Cli.Devices.GetLocallyRegisteredDevices;

public class GetLocallyRegisteredDevicesRequestHandler : IRequestHandler<GetLocallyRegisteredDevicesRequest, GetLocallyRegisteredDevicesResponse>
{
    private readonly ISpotifyApiConfiguration _configuration;
    public GetLocallyRegisteredDevicesRequestHandler(ISpotifyApiConfiguration configuration)
    {
        _configuration = configuration;
    }
    public Task<GetLocallyRegisteredDevicesResponse> Handle(GetLocallyRegisteredDevicesRequest request, CancellationToken cancellationToken)
    {
        var deviceDictionary = _configuration.SpotifyDeviceSettings;
        var response = new GetLocallyRegisteredDevicesResponse()
        {
            Devices = deviceDictionary
                .Select(kvp => new Device()
                    {
                        Id = kvp.Value,
                        Name = kvp.Key
                    })
                .ToArray()
        };

        return Task.FromResult(response);
    }
}
