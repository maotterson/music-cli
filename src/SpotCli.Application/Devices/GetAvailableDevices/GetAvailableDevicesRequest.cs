using MediatR;
using SpotCli.Application.Interfaces;

namespace SpotCli.Application.Devices.GetAvailableDevices;

public class GetAvailableDevicesRequest : IRequest<GetAvailableDevicesResponse>, IValidRequest
{
    public string Description => "Get all available devices";

}
