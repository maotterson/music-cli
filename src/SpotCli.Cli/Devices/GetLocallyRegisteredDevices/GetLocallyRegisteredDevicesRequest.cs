using MediatR;
using SpotCli.Application.Interfaces;

namespace SpotCli.Cli.Devices.GetLocallyRegisteredDevices;

public class GetLocallyRegisteredDevicesRequest : IRequest<GetLocallyRegisteredDevicesResponse>, IValidRequest
{
    public string Description => "Get locally registered devices";
}
