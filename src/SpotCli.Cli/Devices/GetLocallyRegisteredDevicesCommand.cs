using MediatR;
using SpotCli.Application.Interfaces;

namespace SpotCli.Cli.Devices;

public class GetLocallyRegisteredDevicesCommand : IRequest<GetLocallyRegisteredDevicesResponse>, IValidCommand
{
    public string Description => "Get locally registered devices";
}
