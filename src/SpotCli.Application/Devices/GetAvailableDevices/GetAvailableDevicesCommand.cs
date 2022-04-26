using MediatR;
using SpotCli.Application.Interfaces;

namespace SpotCli.Application.Devices.GetAvailableDevices;

public class GetAvailableDevicesCommand : IRequest<GetAvailableDevicesResponse>, IValidRequest
{
    public string Description => "Get all available devices";

}
