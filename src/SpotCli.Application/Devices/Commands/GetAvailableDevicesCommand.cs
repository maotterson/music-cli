using MediatR;
using SpotCli.Application.Devices.Responses;
using SpotCli.Application.Interfaces;

namespace SpotCli.Application.Devices.Commands;

public class GetAvailableDevicesCommand : IRequest<GetAvailableDevicesResponse>, IValidCommand
{
    public string Description => "Get all available devices";

}
