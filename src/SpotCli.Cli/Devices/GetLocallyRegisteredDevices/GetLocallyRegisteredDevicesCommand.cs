using MediatR;
using SpotCli.Application.Interfaces;

namespace SpotCli.Cli.Devices;

public class GetLocallyRegisteredDevicesCommand : IRequest<GetLocallyRegisteredDevicesResponse>, IValidRequest
{
    public string Description => "Get locally registered devices";
}
